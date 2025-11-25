using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadChipSet;

namespace CadChipSet
{
    public class PedidoCad
    {
        public static bool GuardarVenta(Pedido pedido, List<DetallePedido> detalles)
        {
            using (var context = new LabChipSetEntities())
            {
                using (var tx = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Pedido.Add(pedido);
                        context.SaveChanges();

                        foreach (var detalle in detalles)
                        {
                            detalle.idPedido = pedido.id;
                            context.DetallePedido.Add(detalle);

                            var producto = context.Producto.Find(detalle.idProducto);

                            if (producto == null || producto.stock < detalle.cantidad)
                            {
                                tx.Rollback();
                                return false;
                            }
                            producto.stock -= detalle.cantidad;
                        }

                        context.SaveChanges();
                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        return false;
                    }
                }
            }
        }
    }
}