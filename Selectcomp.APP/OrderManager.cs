using Selectcomp.CORE;
using Selectcomp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selectcomp.APP
{
    public class OrderManager : Manager<Order>
    {

        public OrderManager(ApplicationDbContext context)
            : base(context)
        {

            
        }


        /// <summary>
        /// Método que devuelve todos los carritos de un usuario
        /// </summary>
        /// <param name="userId">Id de usuario</param>
        /// <returns></returns>
        public IQueryable<Order> GetByUserId(string userId)
        {
            return Context.Orders.Where(i => i.User_Id == userId);
        }


        public Order GetByOrderId(int orderId)
        {
            return Context.Orders.Where(i => i.OrderId == orderId).SingleOrDefault();
        }




    }
}
