
using Repository.Data.Clientes;
using Repository.Data.Facturas;
using Services.Logica;
namespace ExamenOptativoIIIPrimerParcial
{
    class Program
    {
        static void Main(string[] args)
        {
            string conexionString = "Host=localhost;port=5433;Database=ExOptativoIIIPrimerParcial;Username=postgres;Password=postgres;";
            ClienteService clienteService = new ClienteService(conexionString);
            FacturaService facturaService = new FacturaService(conexionString);

            //Prueba para insertar Cliente
            //clienteService.insertar(new ClienteModel
            //{
            //    nombre = "Alex",
            //    apellido = "Fretes",
            //    documento = "4510600",
            //    direccion = "",
            //    mail = "",
            //    celular = "0981000111",
            //    estado = "Activo"
            //});

            //Prueba para actualizar cliente
            //clienteService.actualizar(new ClienteModel
            //{
            //    Id = 1,
            //    nombre = "Juan",
            //    apellido = "Perez",
            //    documento = "4510600",
            //    direccion = "Luque",
            //    mail = "",
            //    celular = "0981000111",
            //    estado = "Inactivo"
            //});

            //Prueba para eliminar cliente
            //clienteService.eliminar(1);

            //Prueba para listar cliente
            //clienteService.listar().ForEach(cliente =>
            //Console.WriteLine(
            //    $"Nombre: {cliente.nombre} \n " +
            //    $"Apellido: {cliente.apellido} \n " +
            //    $"Documento: {cliente.documento} \n " +
            //    $"Correo {cliente.mail} \n " +
            //    $"Estado: {cliente.estado} \n "
            //    )
            //);

            //Prueba para insertar factura
            //facturaService.insertar(new FacturaModel{
            //    IdCliente = 2,
            //    nroFactura = "123-456-789012",
            //    fechaHora = DateTime.Now,
            //    total = 100,
            //    totalIva5 = 10,
            //    totalIva10 = 15,
            //    totalIva = 25,
            //    totalLetras = "Cien dólares",
            //    sucursal = 1 
            //});

            //Prueba para actualizar factura
            //facturaService.actualizar(new FacturaModel
            //{
            //    Id = 7,
            //    IdCliente = 2,
            //    nroFactura = "123-456-789012",
            //    fechaHora = DateTime.Now,
            //    total = 1000,
            //    totalIva5 = 10,
            //    totalIva10 = 15,
            //    totalIva = 25,
            //    totalLetras = "1 Millon de dolares",
            //    sucursal = 1
            //});

            //Prueba para eliminar cliente
            //facturaService.eliminar(8);

            //Prueba para listar facturas
            //facturaService.listar().ForEach(factura =>
            //    Console.WriteLine(
            //        $"Id Cliente: {factura.IdCliente} \n " +
            //        $"Nro. Factura: {factura.nroFactura} \n " +
            //        $"Fecha/Hora: {factura.fechaHora} \n " +
            //        $"Total: {factura.total} \n " +
            //        $"Total IVA 5%: {factura.totalIva5} \n " +
            //        $"Total IVA 10%: {factura.totalIva10} \n " +
            //        $"Total IVA: {factura.totalIva} \n " +
            //        $"Total Letras: {factura.totalLetras} \n " +
            //        $"Sucursal: {factura.sucursal} \n "
            //    )
            //);
        }
    }
}

