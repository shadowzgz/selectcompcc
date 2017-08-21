using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selectcomp.CORE
{
    /// <summary>
    /// Esta clase almacena todos los ratos referentes a la compra de un usuario
    /// </summary>
    public class Purchase
    {
        /// <summary>
        /// Identificafor de la compra
        /// </summary>
        public int PurchaseId { get; set; }


        /// <summary>
        /// Identificador del carrito que se compra
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Nombre del usuario que realiza la compra
        /// </summary>
        public string PurchaseUserName { get; set; }

        /// <summary>
        /// Apellido del usuario que realiza la compra
        /// </summary>
        public string PurchaseUserSurname { get; set; }

        /// <summary>
        /// Precio total de la compra
        /// </summary>
        public string PurchasePrice { get; set; }

        /// <summary>
        /// Fecha en la que se realiza la compra
        /// </summary>
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// Número de la tarjeta con la que el usuario realiza la compra
        /// </summary>
        public long PurchaseCardNumber { get; set; }
        
        /// <summary>
        /// Dirección del usuario que realiza la compra
        /// </summary>
        public string PurchaseAddress { get; set; }

        /// <summary>
        /// Ciudad del usuario que realiza la compra
        /// </summary>
        public string PurchaseCity { get; set; }
        
        /// <summary>
        /// País del usuario que realiza la compra
        /// </summary>
        public string PurchaseCountry { get; set; }

        /// <summary>
        /// Código postal del usuario que realiza la compra
        /// </summary>
        public int PurchasePostalCode { get; set; }

        /// <summary>
        /// Primer nº de teléfono del usuario que realiza la compra
        /// </summary>
        public long PurchaseTlfNumber1 { get; set; }

        /// <summary>
        /// Segundo nº de teléfono del usuario que realiza la compra
        /// </summary>
        public long PurchaseTlfNumber2 { get; set; }

        /// <summary>
        /// Email del usuario que realiza la compra
        /// </summary>
        public string PurchaseEmail { get; set; }

        /// <summary>
        /// Usuario que realiza la compra [Clave foránea]
        /// </summary>
        public ApplicationUser User { get; set; }
        [ForeignKey("User")]
        public string User_Id { get; set; }


    }
}
