using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCase.Infrastructure.Data;

namespace TestCase.DomainModel.Service
{
   public class PlanService
    { 
    
        #region Action
        /// <summary>
        /// 获取用例列表
        /// </summary>
        /// <returns></returns>
        public List<Plan> GetAll()
        {
            List<Plan> plans = null;
            using (var dbContet = new casemanaContext())
            {
                plans = dbContet.Plan.ToList();
            }
            return plans;
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
