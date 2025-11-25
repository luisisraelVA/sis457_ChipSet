using CadChipSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnChipSet
{
    public class NombreCliente
    {
        public static List<Cliente> listar()
        {
            using (var context = new LabChipSetEntities())
            {
                return context.Cliente
                    .Where(x => x.estado == 1)
                    .OrderBy(x => x.nombre)
                    .ToList();
            }
        }

     
        public static int ObtenerOcrear(string nombreCliente, string usuarioRegistro)
        {
            using (var context = new LabChipSetEntities())
            {
               
                var clienteExistente = context.Cliente
                                        .FirstOrDefault(c => c.nombre == nombreCliente && c.estado == 1);

              
                if (clienteExistente != null)
                {
                    return clienteExistente.id;
                }

              
                var nuevoCliente = new Cliente
                {
                    nombre = nombreCliente,
                    email = $"temp_{Guid.NewGuid()}@chipset.com",
                    telefono = null,
                    usuarioRegistro = usuarioRegistro,
                    fechaRegistro = DateTime.Now,
                    estado = 1
                };

                context.Cliente.Add(nuevoCliente);
                context.SaveChanges();

             
                return nuevoCliente.id;
            }
        }
    }
}