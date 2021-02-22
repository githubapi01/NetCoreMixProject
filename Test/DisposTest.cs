using NetCoreMixProject.Common;
using System;
using System.Runtime.InteropServices;

namespace NetCoreMixProject.Test
{
    public class DisposTest : IDisposable , ITest
    {
        /// <summary>
        /// 模拟一个非托管资源
        /// </summary>
        private IntPtr NativeResource { get; set; } = Marshal.AllocHGlobal(100);
        /// <summary>
        /// 模拟一个托管资源
        /// </summary>
        public Random ManagedResource { get; set; } = new Random();
        /// <summary>
        /// 释放标记
        /// </summary>
        private bool disposed;
        ~DisposTest()
        {
            //必须为false
            Dispose(false);
        }
        public void Dispose()
        {
            "DisposTest Dispose...".C();
            //必须为true
            Dispose(true);
            //通知垃圾回收器不再调用终结器
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 非必需的，只是为了更符合其他语言的规范，如C++、java
        /// </summary>
        public void Close()
        {
            Dispose();
        }
        /// <summary>
        /// 非密封类可重写的Dispose方法，方便子类继承时可重写
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            //清理托管资源
            if (disposing)
            {
                if (ManagedResource != null)
                {
                    ManagedResource = null;
                }
            }
            //清理非托管资源
            if (NativeResource != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(NativeResource);
                NativeResource = IntPtr.Zero;
            }
            //告诉自己已经被释放
            disposed = true;
        }

        public void Test()
        {
            "Nothing to do...".C();
        }
    }
}
