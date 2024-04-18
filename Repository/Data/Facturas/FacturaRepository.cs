using Npgsql;
using Repository.Data.ConfiguracionesDB;

namespace Repository.Data.Facturas
{
    public class FacturaRepository
    {
        NpgsqlConnection connection;
        public FacturaRepository(string conexionString)
        {
            connection = new ConexionDB(conexionString).OpenConnection();
        }
        public bool add(FacturaModel factura)
        {
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO factura (IdCliente, nroFactura, fechaHora, total, totalIva5, totalIva10, totalIva, totalLetras, sucursal) " +
                    "VALUES (@IdCliente, @nroFactura, @fechaHora, @total, @totalIva5, @totalIva10, @totalIva, @totalLetras, @sucursal)";

                cmd.Parameters.AddWithValue("@IdCliente", factura.IdCliente);
                cmd.Parameters.AddWithValue("@nroFactura", factura.nroFactura);
                cmd.Parameters.AddWithValue("@fechaHora", factura.fechaHora);
                cmd.Parameters.AddWithValue("@total", factura.total);
                cmd.Parameters.AddWithValue("@totalIva5", factura.totalIva5);
                cmd.Parameters.AddWithValue("@totalIva10", factura.totalIva10);
                cmd.Parameters.AddWithValue("@totalIva", factura.totalIva);
                cmd.Parameters.AddWithValue("@totalLetras", factura.totalLetras);
                cmd.Parameters.AddWithValue("@sucursal", factura.sucursal);

                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<FacturaModel> list()
        {
            List<FacturaModel> facturas = new List<FacturaModel>();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM factura";
            var list = cmd.ExecuteReader();


            while (list.Read())
            {
                facturas.Add(new FacturaModel
                {
                    IdCliente = list.GetInt32(1),
                    nroFactura = list.GetString(2),
                    fechaHora = list.GetDateTime(3),
                    total = list.GetInt32(4),
                    totalIva5 = list.GetInt32(5),
                    totalIva10 = list.GetInt32(6),
                    totalIva = list.GetInt32(7),
                    totalLetras = list.GetString(8),
                    sucursal = list.GetInt32(9)
                });
            }

            return facturas;
        }
        public bool update(FacturaModel factura)
        {
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE factura SET " +
                    "IdCliente = @idCliente, " +
                    "nroFactura = @nroFactura, " +
                    "fechaHora = @fechaHora, " +
                    "total = @total, " +
                    "totalIva5 = @totalIva5, " +
                    "totalIva10 = @totalIva10, " +
                    "totalIva = @totalIva, " +
                    "totalLetras = @totalLetras, " +
                    "sucursal = @sucursal " +
                    "WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@idCliente", factura.IdCliente);
                cmd.Parameters.AddWithValue("@nroFactura", factura.nroFactura);
                cmd.Parameters.AddWithValue("@fechaHora", factura.fechaHora);
                cmd.Parameters.AddWithValue("@total", factura.total);
                cmd.Parameters.AddWithValue("@totalIva5", factura.totalIva5);
                cmd.Parameters.AddWithValue("@totalIva10", factura.totalIva10);
                cmd.Parameters.AddWithValue("@totalIva", factura.totalIva);
                cmd.Parameters.AddWithValue("@totalLetras", factura.totalLetras);
                cmd.Parameters.AddWithValue("@sucursal", factura.sucursal);
                cmd.Parameters.AddWithValue("@Id", factura.Id); 

                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar los datos");
            }
        }
        public bool delete(int id)
        {
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM factura WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar los datos");
            }
        }
        public List<FacturaModel> listar()
        {
            List<FacturaModel> facturas = new List<FacturaModel>();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM factura";
            var list = cmd.ExecuteReader();

            while (list.Read())
            {
                facturas.Add(new FacturaModel
                {
                    IdCliente = list.GetInt32(1),
                    nroFactura = list.GetString(2),
                    fechaHora = list.GetDateTime(3),
                    total = list.GetInt32(4),
                    totalIva5 = list.GetInt32(5),
                    totalIva10 = list.GetInt32(6),
                    totalIva = list.GetInt32(7),
                    totalLetras = list.GetString(8),
                    sucursal = list.GetInt32(9)
                });
            }
            return facturas;
        }
    }
}
