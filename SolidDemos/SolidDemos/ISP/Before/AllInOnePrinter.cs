
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDemos.ISP.Before
{
    public class AllInOnePrinter : IMachine
    {
        public void SendEmail()
        {
            // SEND EMAIL
        }

        public void Print()
        {
            // PRINT DOCUMENT
        }

        public void Scan()
        {
            // SCAN DOCUMENT
        }
    }
}
