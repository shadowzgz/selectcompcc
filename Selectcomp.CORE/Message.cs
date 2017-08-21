using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selectcomp.CORE
{
    public class Message
    {
        /// <summary>
        /// Identificador del mensaje
        /// </summary>
        public int MessageId { get; set; }

        /// <summary>
        /// Texto del mensaje
        /// </summary>
        public string MessageText { get; set; }

        /// <summary>
        /// Nombre del usuario que crea el mensaje
        /// </summary>
        public string MessageUserName { get; set; }
       
        /// <summary>
        /// Fecha de creación del mensaje
        /// </summary>
        public DateTime MessageCreateDate { get; set; }

        /// <summary>
        /// Identificador de la incidencia a la que pertenece este mensaje
        /// </summary>
        public Incidence Incidence { get; set; }
        [ForeignKey("Incidence")]
        public int Incidence_Id { get; set; }


        /// <summary>
        /// Usuario que ha creado este mensaje
        /// </summary>
        public ApplicationUser User { get; set; }
        [ForeignKey("User")]
        public string User_Id { get; set; }



    }
}
