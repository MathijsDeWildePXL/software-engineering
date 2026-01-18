using System;
using System.Collections.Generic;
using System.Text;

namespace SolidDemos.ISP_DI.After
{
    public class MobileEngineer : IDiallable
    {
        public string Name { get; set; }
        public string Telephone { get; set; }
        
        public string Vehicle { get; set; }
    }
}
