using Selectcomp.CORE;
using Selectcomp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selectcomp.APP
{
    /// <summary>
    /// Clase para manejar las incidencias
    /// </summary>

    public class IncidenceManager : Manager<Incidence>
    {
        public IncidenceManager(ApplicationDbContext context) : base(context)
        {

        }

        /// <summary>
        /// Método que retorna las incidencias de un usuario
        /// </summary>
        /// <param name="userId">Identificador de usuario</param>
        /// <returns>Lista de incidencias</returns>
        public IQueryable<Incidence> GetByUserId(String userId)
        {
            return Context.Incidences.Where(i => i.User_Id == userId);
        }


        /// <summary>
        /// Método rque retorna una incidencia por su Id y el usuario
        /// </summary>
        /// <param name="id">Identificador de incidencia</param>
        /// <param name="userId">Identificador del usuario</param>
        /// <returns>Incidencia o null en el caso de no existir</returns>
        public Incidence GetById(int id)
        {
            return Context.Incidences.Where(i => i.IncidenceId == id).SingleOrDefault();
        }

    }
}
