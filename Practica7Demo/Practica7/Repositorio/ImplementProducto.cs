using System.Data;
using Dapper;
using Practica7.Data;
using Practica7.Models;

namespace Practica7.Repositorio
{
    public class ImplementProducto : IProducto
    {
        private readonly Conexion _conexion;

        public ImplementProducto(Conexion conexion)
        {
            _conexion = conexion;
        }

        public IEnumerable<Producto> ObtenerProductos()
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                return conexion.Query<Producto>("SP_obtener_productos", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public Producto ObtenerProductoPorId(int idProducto)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@idProducto", idProducto, DbType.Int32);
                return conexion.QueryFirstOrDefault<Producto>("SP_obtener_productoId", parametros,commandType: CommandType.StoredProcedure);
            }
        }

        public void InsertarProducto(Producto producto)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@nombre", producto.Nombre, DbType.String);
                parametros.Add("@precio", producto.Precio, DbType.Decimal);
                conexion.Execute("SP_insert_producto", parametros,commandType: CommandType.StoredProcedure);
            }
        }

        public void ActualizarProducto(Producto producto)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@idProducto", producto.idProducto, DbType.Int32);
                parametros.Add("@nombre", producto.Nombre, DbType.String);
                parametros.Add("@precio", producto.Precio, DbType.Decimal);
                conexion.Execute("SP_actualizar_producto", parametros,commandType: CommandType.StoredProcedure);
            }
        }

        public void EliminarProducto(int idProducto)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@idProducto", idProducto, DbType.Int32);
                conexion.Execute("SP_eliminar_producto", parametros, commandType: CommandType.StoredProcedure);
            }
        }

        
    }
}
