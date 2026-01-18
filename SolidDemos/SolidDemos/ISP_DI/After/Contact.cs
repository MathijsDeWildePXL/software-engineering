using System;
using System.Collections.Generic;
using System.Text;

namespace SolidDemos.ISP_DI.After
{
    public class Contact : IEmailable, IDiallable
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Telephone { get; set; }
    }
}
