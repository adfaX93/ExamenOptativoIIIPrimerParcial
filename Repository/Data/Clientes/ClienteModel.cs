
namespace Repository.Data.Clientes
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public int IdBanco { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string documento { get; set; }
        public string direccion { get; set; }
        public string mail { get; set; }
        public string celular { get; set; }
        public string estado { get; set; }
    }
}
