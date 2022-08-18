using MiPrimeraApi.Model;
using System.Data;
using System.Data.SqlClient;

namespace MiPrimeraApi.Repository
{
    public class ProductoVendidoHandler : DbHandler
    {
        public List<ProductoVendido> TraerProductosVendidos(Usuario pUsuario)
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryTraerProductos = "SELECT ProductoVendido.Id, ProductoVendido.Stock, ProductoVendido.IdProducto, ProductoVendido.IdVenta " +
                    "FROM ProductoVendido INNER JOIN Producto ON ProductoVendido.IdProducto = Producto.Id WHERE Producto.IdUsuario = @vIdProducto";

                SqlParameter parametroIdUsuario = new SqlParameter();
                parametroIdUsuario.ParameterName = "vIdProducto";
                parametroIdUsuario.SqlDbType = System.Data.SqlDbType.Int;
                parametroIdUsuario.Value = pUsuario.Id;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryTraerProductos, sqlConnection))
                {
                    sqlCommand.Parameters.Add(parametroIdUsuario);

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ProductoVendido productoVendido = new ProductoVendido();

                                productoVendido.Id = Convert.ToInt32(dataReader["Id"]);
                                productoVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                productoVendido.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                productoVendido.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);

                                productosVendidos.Add(productoVendido);
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return productosVendidos;
        }

        public static int EliminarProductoVendido(int productoId)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryDelete = "DELETE FROM ProductoVendido WHERE IdProducto = @vId";

                    SqlParameter sqlParameter = new SqlParameter("vId", SqlDbType.BigInt);
                    sqlParameter.Value = productoId;

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(sqlParameter);
                        int numberOfRows = sqlCommand.ExecuteNonQuery();
                        if (numberOfRows > 0)
                        {
                            resultado = 1;
                        }
                    }
                    sqlConnection.Close();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

    }
}
