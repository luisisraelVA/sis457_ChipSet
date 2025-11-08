using CadChipSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnChipSet
{
    public class PedidoCln
    {
        public static int insertar(Pedido pedido)
        {
            using (var context = new LabChipSetEntities())
            {
                context.Pedido.Add(pedido);
                context.SaveChanges();
                return pedido.id;
            }
        }

        public static int actualizar(Pedido pedido)
        {
            using (var context = new LabChipSetEntities())
            {
                var existe = context.Pedido.Find(pedido.id);
                existe.idCliente = pedido.idCliente;
                existe.fechaPedido = pedido.fechaPedido;
                existe.total = pedido.total;
                existe.usuarioRegistro = pedido.usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuarioRegistro)
        {
            using (var context = new LabChipSetEntities())
            {
                var existe = context.Pedido.Find(id);
                existe.estado = -1;
                existe.usuarioRegistro = usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static Pedido obtenerUno(int id)
        {
            using (var context = new LabChipSetEntities())
            {
                return context.Pedido.Find(id);
            }
        }



        public static List<Pedido> listar()
        {
            using (var context = new LabChipSetEntities())
            {
                return context.Pedido.Where(x => x.estado == 1).ToList();
            }
        }

        public static List<paPedidoListar_Result> listarPa3(string parametro)
        {
            using (var context = new LabChipSetEntities())
            {
                return context.paPedidoListar(parametro).ToList();
            }
        }
    }
}
