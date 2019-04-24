using System;
using System.Collections.Generic;

namespace TestCase.Infrastructure.Data
{
    public partial class Userdetail
    {
        public int Uid { get; set; }
        public string Uname { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public DateTime? Birth { get; set; }
        public string Passwod { get; set; }
    }
}
