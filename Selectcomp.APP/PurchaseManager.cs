using Selectcomp.CORE;
using Selectcomp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selectcomp.APP
{
    public class PurchaseManager : Manager<Purchase>
    {

        public PurchaseManager(ApplicationDbContext context) : base(context)
        {

        }




    }
}
