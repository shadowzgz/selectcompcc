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
    /// Clase para manejar los productos
    /// </summary>
    public class ProductManager : Manager<Product>
    {
        /// <summary>
        /// Constructor del manager de productos
        /// </summary>
        /// <param name="context"></param>
        public ProductManager(ApplicationDbContext context) : base(context)
        {

        }
        public Product GetById(int id)
        {
            return Context.Products.Where(i => i.Id == id).SingleOrDefault();
        }

        

    }
}
