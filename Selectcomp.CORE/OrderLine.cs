 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selectcomp.CORE
{
    /// <summary>
    /// Clase referente a la linea de carrito
    /// </summary>
    public class OrderLine
    {
        /// <summary>
        /// Identificador de la linea de carrito
        /// </summary>
        public int OrderLineId { get; set; }

        /// <summary>
        /// Nombre de la linea de carrito
        /// </summary>
         public string OrderLineName { get; set; }

        /// <summary>
        /// Identificador del carrito al que pertenece la linea de carrito
        /// </summary>
        public Order Order { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        /// <summary>
        /// Precio del producto que se añade a la línea de carrito
        /// </summary>
        public decimal OrderLineProductPrice { get; set; }

        /// <summary>
        /// Identificador del producto
        /// </summary>
        public Product Product { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }


        /// <summary>
        /// Numero de unidades de un producto que se añaden en la línea de carrito
        /// </summary>
        public int units { get; set; }

    }
}
