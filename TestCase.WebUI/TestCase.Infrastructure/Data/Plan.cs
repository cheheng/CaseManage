using System;
using System.Collections.Generic;

namespace TestCase.Infrastructure.Data
{
    public partial class Plan
    {
        public int Pid { get; set; }
        public int? Proid { get; set; }
        public string Pname { get; set; }
        public string PStorage { get; set; }
        public string State { get; set; }
        public int? Pretime { get; set; }
        public int? Realtime { get; set; }
    }
}
