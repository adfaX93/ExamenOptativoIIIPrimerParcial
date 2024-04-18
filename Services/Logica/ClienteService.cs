using Repository.Data.Clientes;

namespace Services.Logica
{
    public class ClienteService
    {
        private ClienteRepository clienteRepository;
        public ClienteService(string conexionString)
        {
            clienteRepository = new ClienteRepository(conexionString);
        }
        public bool insertar(ClienteModel cliente)
        {
            if (validarDatos(cliente)){
                return clienteRepository.add(cliente);
            }
            else
            {
                throw new Exception("Error al validar datos");
            }

        }
        public bool actualizar(ClienteModel cliente)
        {
            return clienteRepository.update(cliente);
        }
        public bool eliminar(int id)
        {
            return clienteRepository.delete(id);
        }
        public List<ClienteModel> listar()
        {
            return clienteRepository.listar();
        }
        private bool validarDatos(ClienteModel cliente)
        {
            if (cliente == null)
                return false;
            if (string.IsNullOrEmpty(cliente.nombre))
                return false;
            if (string.IsNullOrEmpty(cliente.apellido))
                return false;
            if (string.IsNullOrEmpty(cliente.documento))
                return false;
            if (string.IsNullOrEmpty(cliente.celular))
                return false;
            if(cliente.nombre.Length < 3 || cliente.apellido.Length < 3 ||cliente.documento.Length < 3 || cliente.celular.Length != 10 || !esNumero(cliente.celular))
            {
                return false;
            }
            return true;
        }
        private static bool esNumero(string value)
        {
            return int.TryParse(value, out _);
        }
    }
}
