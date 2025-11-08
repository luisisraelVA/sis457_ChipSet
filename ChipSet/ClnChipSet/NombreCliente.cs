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
    }
}
