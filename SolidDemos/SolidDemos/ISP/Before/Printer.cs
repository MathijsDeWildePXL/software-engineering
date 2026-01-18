using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDemos.ISP.Before
{
    public class Printer : IMachine
    {
        public void SendEmail()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            // PRINT DOCUMENT
        }

        public void Scan()
        {
            throw new NotImplementedException();
        }
    }
}
