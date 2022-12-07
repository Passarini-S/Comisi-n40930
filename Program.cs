// See https://aka.ms/new-console-template for more information
using BasesDeDatos;
using System.Data;
using System.Data.SqlClient;
using ConexionBaseDeDatos;

namespace ConexionBaseDeDatos
{
    internal class Program
    {
    static void Main(string[] args)
    {
            
        String cadenaConexion = "Server=sql.bsite.net\\MSSQL2016;" +
        "Database=passarinis_Compras;" +
        "User Id=passarinis_Compras;" +
        "Password=Lobo55##;";
            
            try
            {
                Console.WriteLine("Creando la conexion");
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuario", conexion))
                    {
                        conexion.Open();
                        List<Usuario> listaUsuario = new List<Usuario>();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Usuario usuario = new Usuario();
                                    usuario.Id = long.Parse(reader["Id"].ToString());
                                    usuario.Nombre = reader["Nombre"].ToString();
                                    usuario.Apellido = reader["Apellido"].ToString();
                                    usuario.NombreUsuario = reader["NombreUsuario"].ToString();
                                    usuario.Contrasenia = reader["Contraseña"].ToString();
                                    usuario.Mail = reader["Mail"].ToString();
                                    listaUsuario.Add(usuario);
                                }
                                Console.WriteLine("Imprimiendo lista de Productos");

                                // La lista contiene objetos del tipo usuario.
                                Console.WriteLine("Imprimiendo lista de Usuarios");
                                foreach (Usuario usuario in listaUsuario)
                                {
                                    Console.WriteLine("ID " + usuario.Id);
                                    Console.WriteLine("Nombre " + usuario.Nombre);
                                    Console.WriteLine("Apellido " + usuario.Apellido);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No existen registro de Usuarios...");
                            }
                        }
                    }
                    conexion.Close();


                }
            }    
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

           //Esto es para acceder a la tabla de productos

            try
            {
                Console.WriteLine("Creando la conexión");
                using (SqlConnection sqlConnection = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Producto", sqlConnection))
                    {
                        sqlConnection.Open();

                        //List<Producto> listaproducto = new List<Producto>();
                        var listaproducto = new List<Producto>();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows) // Consulta si la tabla tiene registros
                            {
                                while (reader.Read())  // itera mientras tenga registros para leer
                                {
                                    

                                    Producto producto = new Producto();
                                    producto.Descripciones = reader["Descripciones"].ToString();
                                    producto.Costo = Convert.ToInt64(reader["Costo"]);
                                    producto.PrecioVenta = Convert.ToInt64(reader["PrecioVenta"]);
                                    producto.Stock = Convert.ToInt32(reader["Stock"]);
                                    producto.IdUsuario = Convert.ToInt64(reader["IdUsuario"]);
                                                                        
                                    listaproducto.Add(producto);

                                }

                                Console.WriteLine("Imprimiendo lista de Productos");

                                // La lista contiene objetos del tipo usuario.
                                Console.WriteLine("Esta es la lista de los productos.....");
                                foreach (Producto producto in listaproducto)
                                {
                                    Console.WriteLine("Descripcion: {0}", producto.Descripciones);
                                    Console.WriteLine("Costo: {0}", producto.Costo);
                                    Console.WriteLine("Precio de Venta: " + producto.PrecioVenta);
                                    Console.WriteLine("Stock: " + producto.Stock);
                                }

                            }
                            else
                            {
                                Console.WriteLine("No tiene registros...");
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Esto es para acceder a la tabla de Ventas

            try
            {
                Console.WriteLine("Creando la conexión");
                using (SqlConnection sqlConnection = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Venta", sqlConnection))
                    {
                        sqlConnection.Open();

                        //List<Producto> listaproducto = new List<Producto>();
                        var listaVenta = new List<Venta>();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows) // Consulta si la tabla tiene registros
                            {
                                while (reader.Read())  // itera mientras tenga registros para leer
                                {


                                    Venta venta = new Venta();
                                    venta.Comentarios = reader["Comentarios"].ToString();
                                    venta.IdUsuario = Convert.ToInt64(reader["IdUsuario"]);
                                    

                                    listaVenta.Add(venta);

                                }

                                Console.WriteLine("Imprimiendo lista de Ventas");

                                // La lista contiene objetos del tipo usuario.
                                Console.WriteLine("Esta es la lista de las ventas.....");
                                foreach (Venta venta in listaVenta)
                                {
                                    Console.WriteLine("Comentarios: {0}", venta.Comentarios);
                                    Console.WriteLine("ID de Usuario: {0}", venta.IdUsuario);
                                }

                            }
                            else
                            {
                                Console.WriteLine("No tiene registros...");
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Esto es para acceder a la tabla de ProductoVendido

            try
            {
                Console.WriteLine("Creando la conexión");
                using (SqlConnection sqlConnection = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM ProductoVendido", sqlConnection))
                    {
                        sqlConnection.Open();

                        //List<Producto> listaproducto = new List<Producto>();
                        var listaProductoVendido = new List<ProductoVendido>();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows) // Consulta si la tabla tiene registros
                            {
                                while (reader.Read())  // itera mientras tenga registros para leer
                                {

                                    ProductoVendido productovendido = new ProductoVendido();
                                    productovendido.IdProducto = Convert.ToInt64(reader["IdProducto"]);
                                    productovendido.IdVenta = Convert.ToInt64(reader["IdVenta"]);
                                    productovendido.Stock = Convert.ToInt32(reader["Stock"]);
                                    
                                    listaProductoVendido.Add(productovendido);

                                }

                                Console.WriteLine("Imprimiendo lista de Prodcutos Vendidos");

                                // La lista contiene objetos del tipo usuario.
                                Console.WriteLine("Esta es la lista de las ventas.....");
                                foreach (ProductoVendido productovendido in listaProductoVendido)
                                {
                                    Console.WriteLine("ID de la Venta: {0}", productovendido.IdVenta);
                                    Console.WriteLine("ID del Producto: {0}", productovendido.IdProducto);
                                    Console.WriteLine("Cantidad Vendida: {0}", productovendido.Stock);
                                }

                            }
                            else
                            {
                                Console.WriteLine("No tiene registros...");
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
