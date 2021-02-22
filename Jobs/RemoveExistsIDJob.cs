using NetCoreMixProject.Common;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreMixProject.Jobs
{
    /// <summary>
    /// 移除返回积分后，修改的客户订单记录，使同步数据任务不会异常
    /// </summary>
    public class RemoveExistsIDJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(()=> {
                RemoveExistsId();
                LogHelper.Info("RemoveExistsIDJob Finished...");
            });
        }

        void RemoveExistsId()
        {
            List<long> ids = Dal.QueryId();
            if (ids != null && ids.Count > 0)
            {                
                string sql = "delete from r_retail_customer_product_buy_log where id in(";
                ids.ForEach(p => {
                    sql += "'" + p + "',";
                });
                sql = sql.Substring(0, sql.Length - 1);
                sql += ")";
                Dal.ExcelSql(sql);
                LogHelper.Info($"Remove Data Count :{ids.Count}");
            }
        }
    }
}
