using Repository.Data.Facturas;
using System.Text.RegularExpressions;

namespace Services.Logica
{
    public class FacturaService
    {
        private FacturaRepository facturaRepository;
        public FacturaService(string conexionString)
        {
            facturaRepository = new FacturaRepository(conexionString);
        }
        public bool insertar(FacturaModel factura)
        {
            if (validarDatos(factura))
            {
                return facturaRepository.add(factura);
            }
            else
            {
                throw new Exception("Error al validar datos");
            }

        }
        public bool actualizar(FacturaModel factura)
        {
            return facturaRepository.update(factura);
        }

        public bool eliminar(int id)
        {
            return facturaRepository.delete(id);
        }
        public List<FacturaModel> listar()
        {
            return facturaRepository.listar();
        }

        private bool validarDatos(FacturaModel factura)
        {
            if (factura == null)
            {
                return false;
            }

            Regex regexNroFactura = new Regex(@"^\d{3}-\d{3}-\d{6}$");
            if (string.IsNullOrEmpty(factura.nroFactura) || !regexNroFactura.IsMatch(factura.nroFactura))
            {
                return false;
            }

            if (!esNumero(factura.total.ToString()) || !esNumero(factura.totalIva5.ToString()) || !esNumero(factura.totalIva10.ToString())|| !esNumero(factura.totalIva.ToString()))
            {
                return false;
            }
                

            if (string.IsNullOrEmpty(factura.totalLetras) || factura.totalLetras.Length < 6)
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
