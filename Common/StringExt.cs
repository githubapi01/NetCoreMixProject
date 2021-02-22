using System;

namespace NetCoreMixProject.Common
{
    static public class StringExt
    {
        /// <summary>
        /// 将字符输出到控制台，并添加时间前缀
        /// </summary>
        /// <param name="msg"></param>
        static public void C(this String msg)
        {
            System.Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - {msg}");
        }
    }
}
