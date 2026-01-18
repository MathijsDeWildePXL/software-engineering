using SolidDemos.ISP.After;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDemos.ISP.After
{
    public class Scanner : IScanner, IEmail
    {
        public void Scan()
        {
            // SCAN DOCUMENT
        }

        public void SendEmail()
        {
            // EMAIL DOCUMENT
        }
    }
}
