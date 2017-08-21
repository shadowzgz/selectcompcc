using Selectcomp.CORE;
using Selectcomp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selectcomp.APP
{
    public class OrderLineManager : Manager<OrderLine>
    {

        public OrderLineManager(ApplicationDbContext context)
            : base(context)
        {

            
        }

        /// <summary>
        /// Método que retorna las lineas de un carrito
        /// </summary>
        /// <param name="cartId">Identificador del carrito del que queremos extraer sus líneas</param>
        /// <returns>Devolvémos las lineas de carrito</returns>
        public IQueryable<OrderLine> GetByCartId(int cartId)
        {
            return Context.OrderLines.Where(i => i.OrderId == cartId);
        } 

        
    
    }
}
