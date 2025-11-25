namespace WebChipset.Models.ViewModels
{
    public class VentaViewModel
    {
        public int IdCliente { get; set; }
        public decimal Total { get; set; }
        public List<DetalleVentaViewModel> Detalles { get; set; }
    }
    public class DetalleVentaViewModel
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
