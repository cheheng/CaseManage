using System;
using System.Collections.Generic;

namespace TestCase.Infrastructure.Data
{
    public partial class Project
    {
        public int Proid { get; set; }
        public string Proname { get; set; }
        public string State { get; set; }
        public int? Pretime { get; set; }
        public int? Realtime { get; set; }
    }
}
