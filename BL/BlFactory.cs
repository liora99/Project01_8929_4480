using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BlFactory
    {
        static IBL bl = null;
        public static IBL GetBL()
        {
            if (bl == null)
                bl = new BLImp();
            return bl;
        }
    }
}

