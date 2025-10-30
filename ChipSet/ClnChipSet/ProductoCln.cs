using CadChipSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnChipSet
{
    public class ProductoCln
    {
        public static int insertar(Producto producto)
        {
            using (var context = new LabChipSetEntities())
            {
                context.Producto.Add(producto);
                context.SaveChanges();
                return producto.id;
            }
        }

        public static int actualizar(Producto producto)
        {
            using (var context = new LabChipSetEntities())
            {
                var existe = context.Producto.Find(producto.id);
                existe.idProveedor = producto.idProveedor;
                existe.nombre = producto.nombre;
                existe.descripcion = producto.descripcion;
                existe.precioVenta = producto.precioVenta;
                existe.stock = producto.stock;
                existe.usuarioRegistro = producto.usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuarioRegistro)
        {
            using (var context = new LabChipSetEntities())
            {
                var existe = context.Producto.Find(id);
                existe.estado = -1;
                existe.usuarioRegistro = usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static Producto obtenerUno(int id)
        {
            using (var context = new LabChipSetEntities())
            {
                return context.Producto.Find(id);
            }
        }

        public static List<Producto>listar()
        {
            using (var context = new LabChipSetEntities())
            {
                return context.Producto.Where(x => x.estado == 1).ToList();
            }
        }

        public static List<paProductoListar_Result> listarPa(string parametro)
        {
            using (var context = new LabChipSetEntities())
            {
                return context.paProductoListar(parametro).ToList();
            }
        }
    }
}
