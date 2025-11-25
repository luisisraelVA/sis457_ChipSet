using CadChipSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnChipSet
{
    public class ClienteCln
    {
        public static int insertar(Cliente cliente)
        {
            using (var context = new LabChipSetEntities())
            {
                context.Cliente.Add(cliente);
                context.SaveChanges();
                return cliente.id;
            }
        }

        public static int actualizar(Cliente cliente)
        {
            using (var context = new LabChipSetEntities())
            {
                var existe = context.Cliente.Find(cliente.id);
                existe.nombre = cliente.nombre;
                existe.email = cliente.email;
                existe.telefono = cliente.telefono;
                existe.usuarioRegistro = cliente.usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuarioRegistro)
        {
            using (var context = new LabChipSetEntities())
            {
                var existe = context.Cliente.Find(id);
                existe.estado = -1;
                existe.usuarioRegistro = usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static Cliente obtenerUno(int id)
        {
            using (var context = new LabChipSetEntities())
            {
                return context.Cliente.Find(id);
            }
        }



        public static List<Cliente> listar()
        {
            using (var context = new LabChipSetEntities())
            {
                return context.Cliente.Where(x => x.estado == 1).ToList();
            }
        }

        public static List<paClienteListar_Result> listarPa2(string parametro)
        {
            using (var context = new LabChipSetEntities())
            {
                return context.paClienteListar(parametro).ToList();
            }
        }
    }
}
