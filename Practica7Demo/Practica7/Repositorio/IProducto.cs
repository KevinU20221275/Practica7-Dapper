using Practica7.Models;

namespace Practica7.Repositorio
{
    public interface IProducto
    {
        Producto ObtenerProductoPorId(int id);

        IEnumerable<Producto> ObtenerProductos();

        void InsertarProducto(Producto producto);

        void ActualizarProducto(Producto producto);

        void EliminarProducto(int id);
    }
}
