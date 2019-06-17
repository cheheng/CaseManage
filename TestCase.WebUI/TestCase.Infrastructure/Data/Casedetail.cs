using System;
using System.Collections.Generic;

namespace TestCase.Infrastructure.Data
{
    public partial class Casedetail
    {
        public int Cid { get; set; }
        public int? Uid { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? Prior { get; set; }
        public string Detail { get; set; }
        public string Previous { get; set; }
        public string Result { get; set; }
    }
}
