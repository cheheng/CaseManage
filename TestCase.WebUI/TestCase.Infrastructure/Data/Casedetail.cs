using System;
using System.Collections.Generic;

namespace TestCase.Infrastructure.Data
{
    public partial class Casedetail
    {
        public int Id { get; set; }
        public int? Cid { get; set; }
        public int? Uid { get; set; }
        public int? Pid { get; set; }
        public int? Proid { get; set; }
        public int? Unid { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? Prior { get; set; }
        public string Detail { get; set; }
    }
}
