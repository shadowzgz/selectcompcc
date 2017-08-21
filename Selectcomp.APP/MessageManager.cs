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
    /// Clase para manejar los mensajes
    /// </summary>
    public class MessageManager : Manager<Message>
    {

        /// <summary>
        /// Constructor del  manager de mensajes
        /// </summary>
        /// <param name="context">Contexto de datos</param>
        public MessageManager(ApplicationDbContext context) : base(context)
        {

        }

        /// <summary>
        /// Retorna el primer mensaje de una incidencia
        /// </summary>
        /// <param name="incidenceId">Identificador d ela incidencia</param>
        /// <returns>Mensaje de la incidencia</returns>
        public Message GetFirstMessage(int incidenceId)
        {

            var message = Context.Messages.Where(m => m.Incidence_Id == incidenceId).OrderBy(i => i.Incidence_Id).FirstOrDefault();

            if (message == null)
                message = new Message();
            return message;


        }

        /// <summary>
        /// Retorna todos los mensajes de una incidencia
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<Message> GetByIncidenceId(int id)
        {
            return Context.Messages.Where(i => i.Incidence_Id == id);
        }
    }
}
