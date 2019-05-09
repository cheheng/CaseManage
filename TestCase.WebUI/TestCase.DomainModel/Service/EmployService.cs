using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCase.Infrastructure.Data;

namespace TestCase.DomainModel.Service
{
    public class EmployService
    {
        public Employ ShowDetail(Employ employ)
        {
            using (var dbContext = new CasemanaContext())
            {
                employ = dbContext.Employ.FirstOrDefault(x => x.Eid == employ.Eid);
            }
            return employ;
        }
    }
}
