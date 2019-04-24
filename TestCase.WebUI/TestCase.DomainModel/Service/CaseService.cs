using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCase.Infrastructure.Data;

namespace TestCase.DomainModel.Service
{
   public class CaseService
    { 
    
        #region Action
        /// <summary>
        /// 获取用例列表
        /// </summary>
        /// <returns></returns>
        public List<Thecase> GetAll()
        {
            List<Thecase> cases = null;
            using (var dbContet = new casemanaContext())
            {
                cases = dbContet.Thecase.ToList();
            }
            return cases;
        }

        //public int AddCase()
        //{
        //    int count = 0;
        //    var tcase=new Tcase()
        //    {

        //    }
        //}
        #endregion


    }
}
