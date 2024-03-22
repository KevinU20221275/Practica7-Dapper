using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica7.Models;
using Practica7.Repositorio;

namespace Practica7.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProducto _iproducto;
        public ProductoController(IProducto iproducto)
        {
             _iproducto = iproducto;
        }

        // GET: ProductoController
        public IActionResult Index()
        {
            var producto = _iproducto.ObtenerProductos();
            return View(producto);
        }

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            _iproducto.InsertarProducto(producto);
            return RedirectToAction(nameof(Index));
        }


        // GET: ProductoController/Edit/5
        public IActionResult Edit(int idProducto)
        {
            var producto = _iproducto.ObtenerProductoPorId(idProducto);
            return View(producto);
        }

        [HttpPost]
        public IActionResult Edit(Producto producto)
        {
            _iproducto.ActualizarProducto(producto);
            return RedirectToAction(nameof(Index));
        }

       

        // GET: ProductoController/Delete/5
        public IActionResult Delete(int idProducto)
        {
            var producto = _iproducto.ObtenerProductoPorId(idProducto);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int idProducto)
        {
            _iproducto.EliminarProducto(idProducto);
            return RedirectToAction(nameof(Index));
        }
    }
}
