using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalFactory
    {

        static IDAL dl = null;
        public static IDAL GetDal()
        {
            if (dl == null)
                dl = new DalImp();
            return dl;
        }
    }
}

