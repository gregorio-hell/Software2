using Microsoft.AspNetCore.Mvc;
using software.Models;

namespace software.Controllers
{
    public class ProductosController : Controller
    {
        private static readonly List<Producto> _productos = new()
        {
            new Producto
            {
                Codigo = "PROD001",
                Nombre = "Leche Entera",
                Categoria = "Lácteos",
                Cantidad = "45 Litros",
                Ubicacion = "Almacén A - Estante 1",
                Vencimiento = DateTime.Parse("2025-11-07"),
                EstadoStock = "Disponible",
                ValorTotal = 112.50M
            },
            new Producto
            {
                Codigo = "PROD002",
                Nombre = "Yogurt Natural",
                Categoria = "Lácteos",
                Cantidad = "15 Unidades",
                Ubicacion = "Almacén A - Estante 2",
                Vencimiento = DateTime.Parse("2025-11-04"),
                EstadoStock = "Bajo Stock",
                ValorTotal = 27.00M
            },
            new Producto
            {
                Codigo = "PROD003",
                Nombre = "Pan Integral",
                Categoria = "Panadería",
                Cantidad = "80 Unidades",
                Ubicacion = "Almacén B - Estante 1",
                Vencimiento = DateTime.Parse("2025-12-02"),
                EstadoStock = "Disponible",
                ValorTotal = 96.00M
            },
            new Producto
            {
                Codigo = "PROD004",
                Nombre = "Aceite de Oliva",
                Categoria = "Aceites",
                Cantidad = "25 Botellas",
                Ubicacion = "Almacén C - Estante 3",
                Vencimiento = DateTime.Parse("2026-05-01"),
                EstadoStock = "Disponible",
                ValorTotal = 212.50M
            },
            new Producto
            {
                Codigo = "PROD005",
                Nombre = "Arroz Blanco",
                Categoria = "Granos",
                Cantidad = "120 Kg",
                Ubicacion = "Almacén C - Estante 1",
                Vencimiento = DateTime.Parse("2026-11-02"),
                EstadoStock = "Disponible",
                ValorTotal = 180.00M
            },
            new Producto
            {
                Codigo = "PROD006",
                Nombre = "Queso Fresco",
                Categoria = "Lácteos",
                Cantidad = "8 Kg",
                Ubicacion = "Almacén A - Refrigerador 1",
                Vencimiento = DateTime.Parse("2025-11-01"),
                EstadoStock = "Bajo Stock",
                ValorTotal = 96.00M
            }
        };

        public IActionResult Index()
        {
            return View(_productos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                producto.Codigo = $"PROD{(_productos.Count + 1):000}";
                _productos.Add(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        public IActionResult Edit(string id)
        {
            var producto = _productos.FirstOrDefault(p => p.Codigo == id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        [HttpPost]
        public IActionResult Edit(string id, Producto producto)
        {
            if (id != producto.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var index = _productos.FindIndex(p => p.Codigo == id);
                if (index != -1)
                {
                    _productos[index] = producto;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            var producto = _productos.FirstOrDefault(p => p.Codigo == id);
            if (producto != null)
            {
                _productos.Remove(producto);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}