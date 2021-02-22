using NetCoreMixProject.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Data.SqlClient;
using NetCoreMixProject.Common;

namespace NetCoreMixProject
{
    public class Dal
    {
        public static List<sv_collateral_result> Query() {
            List<sv_collateral_result> result = null;

            try
            {
                string date = DateTime.Now.ToString("yyyyMMdd");
                int bussDate = int.Parse(date);
                using (var db = new HQContext())
                {
                    result = db.sv_collateral_results.Where(p => p.type.Value == 1 && p.dc_business_date == bussDate).ToList();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error( System.Reflection.MethodBase.GetCurrentMethod().Name , ex);
            }

            return result;
        }

        public static List<long> QueryId()
        {
            List<long> result = new List<long>();

            try
            {
                DateTime today = Convert.ToDateTime( DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 00:00:00"));
                DateTime tomorrow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
                using (var db = new QQTContext())
                {
                    result = db.CustomerProductBuyLogs.Where(p =>
                        (p.RestoreTime > today && p.RestoreTime < tomorrow)
                    ).Select(p=>p.Id).ToList();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }

            return result;
        }

        public static bool ExcelSql(String sql ,SqlParameter[] parameters = null)
        {
            bool result = false;
            IDbContextTransaction trans = null;
            try
            {
                if (parameters == null)
                {
                    parameters = new SqlParameter[] { };
                }
                using (var db = new HQContext())
                {
                    trans = db.Database.BeginTransaction();
                    db.Database.ExecuteSqlRaw(sql, parameters);
                    trans.Commit();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                if (trans != null) {
                    trans.Rollback();
                }
            }

            return result;
        }
    }
}
