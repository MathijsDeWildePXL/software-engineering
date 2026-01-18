using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDemos.ISP.Before
{
    public class Scanner : IMachine
    {
        public void SendEmail()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            throw new NotImplementedException();
        }

        public void Scan()
        {
            // SCAN DOCUMENT
        }
    }
}
