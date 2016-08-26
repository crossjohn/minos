using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HpAer.Models
{
    public class DireccionRepository : IDireccionRepository
    {
        /*private AddressDataContext _dataContext;*/
        private HpAerDbEntities db; /*= new HpAerDbEntities();*/

        public DireccionRepository()
        {
            /*_dataContext = new AddressDataContext();*/
             db = new HpAerDbEntities();
        }

        public IList<Pais> GetAllPaises()
        {
            var query = from paises in db.Paises
                        select paises;
            var content = query.ToList<Pais>();
            return content;
        }
        public IList<Provincia> GetAllProvinciasByPaisId(int paisId)
        {
            var query = from provincias in db.Provincias
                        where provincias.paisId == paisId
                        select provincias;
            var content = query.ToList<Provincia>();
            return content;
        }

        public IList<Localidad> GetAllLocalidadesByProvinciaId(int provinciaId)
        {
            var query = from localidades in db.Localidads
                        where localidades.provinciaId == provinciaId
                        select localidades;
            var content = query.ToList<Localidad>();
            return content;
        }

        public IList<Barrio> GetAllBarriosByLocalidadId(int localidadId)
        {
            var query = from barrios in db.Barrios
                        where barrios.localidadId == localidadId
                        select barrios;
            var content = query.ToList<Barrio>();
            return content;
        }
    }
}