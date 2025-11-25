using CadChipSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnChipSet
{
    public class NombreProovedorCln
    {
        public static List<Proveedor> listar()
        {
            using (var context = new LabChipSetEntities())
            {
                return context.Proveedor
                    .Where(x => x.estado == 1)
                    .OrderBy(x => x.nombre)
                    .ToList();
            }
        }
    }
}
