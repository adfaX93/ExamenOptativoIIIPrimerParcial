using Npgsql;
using Repository.Data.ConfiguracionesDB;

namespace Repository.Data.Clientes
{
    public class ClienteRepository
    {
        NpgsqlConnection connection;
        public ClienteRepository(string conexionString)
        {
            connection = new ConexionDB(conexionString).OpenConnection();
        }
        public bool add(ClienteModel clienteModel)
        {
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO cliente (Nombre, Apellido, Documento, Direccion, Mail, Celular, Estado) " +
                    "VALUES (" +
                    "@nombre," +
                    "@apellido," +
                    "@documento," +
                    "@direccion," +
                    "@mail," +
                    "@celular," +
                    "@estado)";
                cmd.Parameters.AddWithValue("@nombre", clienteModel.nombre);
                cmd.Parameters.AddWithValue("@apellido", clienteModel.apellido);
                cmd.Parameters.AddWithValue("@documento", clienteModel.documento);
                cmd.Parameters.AddWithValue("@direccion", clienteModel.direccion);
                cmd.Parameters.AddWithValue("@mail", clienteModel.mail);
                cmd.Parameters.AddWithValue("@celular", clienteModel.celular);
                cmd.Parameters.AddWithValue("@estado", clienteModel.estado);

                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<ClienteModel> list()
        {
            List<ClienteModel> clientes = new List<ClienteModel>();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM cliente";
            var list = cmd.ExecuteReader();


            while (list.Read())
            {
                clientes.Add(new ClienteModel
                {
                    IdBanco = list.GetInt32(1),
                    nombre = list.GetString(2),
                    apellido = list.GetString(3),
                    documento = list.GetString(4),
                    direccion = list.GetString(5),
                    mail = list.GetString(6),
                    celular = list.GetString(7),
                    estado = list.GetString(8)
                });
            }

            return clientes;
        }
        public bool update(ClienteModel cliente)
        {
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE cliente SET " +
                    "Nombre = @Nombre, " +
                    "Apellido = @Apellido, " +
                    "Documento = @Documento, " +
                    "Direccion = @Direccion, " +
                    "Mail = @Mail, " +
                    "Celular = @Celular, " +
                    "Estado = @Estado " +
                    "WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Nombre", cliente.nombre);
                cmd.Parameters.AddWithValue("@Apellido", cliente.apellido);
                cmd.Parameters.AddWithValue("@Documento", cliente.documento);
                cmd.Parameters.AddWithValue("@Direccion", cliente.direccion);
                cmd.Parameters.AddWithValue("@Mail", cliente.mail);
                cmd.Parameters.AddWithValue("@Celular", cliente.celular);
                cmd.Parameters.AddWithValue("@Estado", cliente.estado);
                cmd.Parameters.AddWithValue("@Id", cliente.Id);

                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al actualizar los datos");
            }
        }
        public bool delete(int id)
        {
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM cliente WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch(Exception ex) 
            {
                throw new Exception("Error al eliminar los datos");
            }
        }
        public List<ClienteModel> listar()
        {
            List<ClienteModel> clientes = new List<ClienteModel>();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM cliente";
            var list = cmd.ExecuteReader();

            while (list.Read())
            {
                clientes.Add(new ClienteModel
                {
                    nombre = list.GetString(1),
                    apellido = list.GetString(2),
                    documento = list.GetString(3),
                    direccion = list.GetString(4),
                    mail = list.GetString(5),
                    celular = list.GetString(6),
                    estado = list.GetString(7)
                });
            }
            return clientes;
        }
    }
}
