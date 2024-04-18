
namespace Repository.Data.Facturas
{
    public class FacturaModel
    {
        public int  Id { get; set; }
        public int  IdCliente { get; set; }
        public string  nroFactura { get; set; }
        public DateTime  fechaHora { get; set; }
        public int  total { get; set; }
        public int  totalIva5 { get; set; }
        public int  totalIva10 { get; set; }
        public int  totalIva { get; set; }
        public string  totalLetras { get; set; }
        public int  sucursal { get; set; }
    }
}
