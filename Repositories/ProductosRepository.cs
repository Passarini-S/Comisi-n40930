using SistemaDeGestion.Models;
using System.Data.SqlClient;

namespace SistemaDeGestion.Repositories
{
    public class ProductosRepository
    {
        private SqlConnection conexion;
        private String cadenaConexion = "Server=sql.bsite.net\\MSSQL2016;" +
            "Database=passarinis_Compras;" +
            "User Id=passarinis_Compras;" +
            "Password=Lobo55##;";

        public ProductosRepository()
        {
            try
            {
                conexion = new SqlConnection(cadenaConexion);
            }
            catch (Exception ex)
            {

            }
        }

        public List<Producto> listarProductos()
        {
            List<Producto> lista = new List<Producto>();
            if (conexion == null)
            {
                throw new Exception("Conexión no establecida");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM producto", conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Producto producto = new Producto();
                                producto.Id = long.Parse(reader["Id"].ToString());
                                producto.Descripcion = reader["Descripciones"].ToString();
                                producto.PrecioCompra = double.Parse(reader["Costo"].ToString());
                                producto.PrecioVenta = double.Parse(reader["PrecioVenta"].ToString());
                                producto.Stock = int.Parse(reader["Stock"].ToString());
                                lista.Add(producto);
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
