namespace software.Models
{
    public class DashboardViewModel
    {
        public int TotalProductos { get; set; }
        public decimal ValorTotal { get; set; }
        public int BajoStock { get; set; }
        public int AlertasCriticas { get; set; }
        public List<CategoriaInventario> InventarioPorCategoria { get; set; } = new();
        public List<CategoriaValorizacion> ValorizacionPorCategoria { get; set; } = new();
        public EstadoInventario EstadoDelInventario { get; set; } = new();
    }

    public class CategoriaInventario
    {
        public required string Nombre { get; set; }
        public int Unidades { get; set; }
    }

    public class CategoriaValorizacion
    {
        public required string Nombre { get; set; }
        public decimal Valor { get; set; }
    }

    public class EstadoInventario
    {
        public int ProductosOptimos { get; set; }
        public int BajoStock { get; set; }
        public int VencidosoPorVencer { get; set; }
    }
}