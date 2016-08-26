using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HpAer.Models
{
    public interface IDireccionRepository
    {
        IList<Pais> GetAllPaises();
        IList<Provincia> GetAllProvinciasByPaisId(int paisId);
        IList<Localidad> GetAllLocalidadesByProvinciaId(int provinciaId);
        IList<Barrio> GetAllBarriosByLocalidadId(int localidadId);
    }
}