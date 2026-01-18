using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDemos.ISP_DI.Before
{
    public class MobileEngineer : IContact
    {
        public string Name { get; set; }
        public string Telephone { get; set; }
        
        // Specific for a MobileEngineer
        public string Vehicle { get; set; }

        // Not needed:
        public string Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        // Problem: Emailer will not work on object of this class! 
        public string EmailAddress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
