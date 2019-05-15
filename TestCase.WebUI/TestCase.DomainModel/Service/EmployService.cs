using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCase.Infrastructure.Data;

namespace TestCase.DomainModel.Service
{
    public class EmployService
    {
        public Employ ShowDetail(int? eid)
        {
            Employ employ = new Employ();
            using (var dbContext = new CasemanaContext())
            {
                employ = dbContext.Employ.FirstOrDefault(x => x.Eid == eid);
            }
            return employ;
        }
    }
}
