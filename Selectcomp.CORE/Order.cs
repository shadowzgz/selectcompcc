using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selectcomp.CORE
{
    /// <summary>
    /// Clase referente al pedido o carrito
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Identificación del carrito
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Nombre del carrito
        /// </summary>
        public string OrderName { get; set; }

        /// <summary>
        /// Fecha de creación del carrito
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Usuario que crea el carrito
        /// </summary>
        public ApplicationUser User { get; set; }
        [ForeignKey("User")]
        public string User_Id { get; set; }

        /// <summary>
        /// Colección de productos que guarda el carrito
        /// </summary>
        public ICollection<OrderLine> OrderLines { get; set; }

        





    }
}
