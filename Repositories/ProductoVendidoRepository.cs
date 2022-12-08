using SistemaDeGestion.Models;
using System.Data.SqlClient;

namespace SistemaDeGestion.Repositories
{
    public class ProductoVendidoRepository
    {
        private SqlConnection conexion;
        private String cadenaConexion = "Server=sql.bsite.net\\MSSQL2016;" +
            "Database=passarinis_Compras;" +
            "User Id=passarinis_Compras;" +
            "Password=Lobo55##;";
        public ProductoVendidoRepository()
        {
            try
            {
                conexion = new SqlConnection(cadenaConexion);
            }
            catch (Exception ex)
            {

            }
        }
        public List<ProductoVendido> listarProductoVendido()
        {
            List<ProductoVendido> lista = new List<ProductoVendido>();
            if (conexion == null)
            {
                throw new Exception("Conexión no establecida");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM ProductoVendido", conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ProductoVendido productoVendido = new ProductoVendido();
                                productoVendido.Id = long.Parse(reader["Id"].ToString());
                                productoVendido.Stock = int.Parse(reader["Stock"].ToString());
                                productoVendido.IdProducto = long.Parse(reader["IdProducto"].ToString());
                                productoVendido.IdVenta = long.Parse(reader["IdVenta"].ToString());

                                //public ProductoVendido(double id, int stock, double idproducto, double idventa)

                                lista.Add(productoVendido);
                            }

                        }
                    }
                }
                conexion.Close();
            }
            catch
            {
                throw;
            }
            return lista;
        }
    }
}
