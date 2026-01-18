using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDemos.ISP.Before
{
    public interface IMachine
    {
        void Print();
        void Scan();
        void SendEmail(); 
    }
}
