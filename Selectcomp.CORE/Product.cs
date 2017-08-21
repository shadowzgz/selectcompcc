using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selectcomp.CORE
{
    public class Product
    {
        /// <summary>
        /// Identificador del producto
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del producto
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Marca del producto
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Precio del producto
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Descripción del producto
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Imagen del producto
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Stock del producto. true=hay stock
        /// </summary>
        public bool Stock { get; set; }

        /// <summary>
        /// Cantidad de producto
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Tipo de componente de ordenador
        /// </summary>
        public ProductType ProductType { get; set; }

    }
}
