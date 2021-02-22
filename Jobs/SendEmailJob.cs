using Microsoft.Extensions.Configuration;
using MimeKit;
using NetCoreMixProject.Common;
using NetCoreMixProject.Models;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreMixProject.Jobs
{
    /// <summary>
    /// 查询数据库生产csv文件，并发送到配置邮箱
    /// </summary>
    public class SendEmailJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {
                "Query Data ".C();
                List<sv_collateral_result> lst = null;
                do
                {
                    lst = Dal.Query();
                    if (lst == null || lst.Count == 0)
                    {
                        "No Data  , Sleep 10s".C();
                        Thread.Sleep(10000);
                    }
                    else {
                        $"result count : {lst.Count}".C();
                        break;
                    }
                } while (true);
                string basePath = Directory.GetCurrentDirectory();
                string path = Path.Combine(basePath, $"data_{DateTime.Now.ToString("yyyyMMdd")}.csv");
                $"Build CSV {path}".C();
                ExcelHelper.BuildCSV<sv_collateral_result>(path, lst);
                SendEmail(path);
                LogHelper.Info("Email Job Finished....");
            });
        }

        void SendEmail(String path)
        {
            IConfigurationSection email = ConfigHelper.Get("Email");
            //附件 , 
            var attachment = new MimePart("Excel", "csv")
            {
                Content = new MimeContent(File.OpenRead(path), ContentEncoding.Default),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = Path.GetFileName(path)
            };
            var plain = new TextPart("plain")
            {
                Text = @""
            };
            EmailHelper.SendEmail(email ,plain ,attachment ,(s ,e)=>{
                LogHelper.Info("Mail Send Success...");
            });
        }
    }
}
