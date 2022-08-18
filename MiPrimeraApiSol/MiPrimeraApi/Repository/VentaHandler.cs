using MiPrimeraApi.Model;
using System.Data.SqlClient;

namespace MiPrimeraApi.Repository
{
    internal class VentaHandler : DbHandler
    {
        public List<Venta> TraerVentas(Usuario pUsuario)
        {
            List<Venta> ventas = new List<Venta>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryTraerVentas = "SELECT Venta.Id, Venta.Comentarios FROM (Venta INNER JOIN ProductoVendido ON Venta.Id = ProductoVendido.IdVenta)" +
                    " INNER JOIN Producto ON ProductoVendido.IdProducto = Producto.Id WHERE Producto.IdUsuario = @vIdUsuario";

                SqlParameter parametroIdUsuario = new SqlParameter();
                parametroIdUsuario.ParameterName = "vIdUsuario";
                parametroIdUsuario.SqlDbType = System.Data.SqlDbType.Int;
                parametroIdUsuario.Value = pUsuario.Id;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryTraerVentas, sqlConnection))
                {
                    sqlCommand.Parameters.Add(parametroIdUsuario);

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta venta = new Venta();

                                venta.Id = Convert.ToInt32(dataReader["Id"]);
                                venta.Comentarios = dataReader["Comentarios"].ToString();

                                ventas.Add(venta);
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return ventas;
        }
    }
}
