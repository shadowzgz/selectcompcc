using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selectcomp.CORE
{
    public class Incidence
    {

        /// <summary>
        /// Identificador de la incidencia
        /// </summary>
        public int IncidenceId { get; set; }

        /// <summary>
        /// Fecha en la que se crea la incidencia
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Fecha en la que se cierra la incidencia
        /// </summary>
        public DateTime? CloseDate { get; set; }

        /// <summary>
        /// Asunto de la incidencia
        /// </summary>
        public string IncidenceTitle { get; set; }


        /// <summary>
        /// Tipo de la incidencia
        /// </summary>
        public IncidenceType IncidenceType { get; set; }

        //public List<Message> Messages { get; set; }

        /// <summary>
        /// Prioridad la incidencia a la hora de contestarla
        /// </summary>
        public Priority Priority { get; set; }

        /// <summary>
        /// Lista de mensajes
        /// </summary>
        public List<Message> Messages { get; set; }

        /// <summary>
        /// Estado de la incidencia, abierta o cerrada
        /// </summary>
        public IncidenceStatus Status { get; set; }

        /// <summary>
        /// Notas internas que solo el administrador puede leer.
        /// </summary>
        public string InternalNote { get; set; }

        /// <summary>
        /// Identificador de usuario que crea la incidencia
        /// </summary>
        public ApplicationUser User { get; set; }
        [ForeignKey("User")]
        public string User_Id { get; set; }







    }
}
