using Microsoft.AspNet.Identity.EntityFramework;
using Selectcomp.CORE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selectcomp.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        /// <summary>
        /// Colección de productos persistibles
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Colección de carritos persistibles
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Colección de lines de carrito persistibles
        /// </summary>
        public DbSet<OrderLine> OrderLines { get; set; }

        /// <summary>
        /// Colección de compras persistibles
        /// </summary>
        public DbSet<Purchase> Purchases { get; set; }

        /// <summary>
        /// Colección de incidencias persistibles
        /// </summary>
        public DbSet<Incidence> Incidences { get; set; }

        /// <summary>
        /// Colección de mensajes persistibles
        /// </summary>
        public DbSet<Message> Messages { get; set; }
    }
}
