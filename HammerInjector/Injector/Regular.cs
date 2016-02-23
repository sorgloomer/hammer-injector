using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HammerInjector.Injector
{
    public class Regular
    {

        private static int Align4K(int x)
        {
            return ((x - 1) | 0x0fff) + 1;
        }
        public static void Inject(Process p, string dllPath)
        {
            var kernel32 = p.Modules.Cast<ProcessModule>().Single(m =>
                string.Equals(m.ModuleName, "kernel32.dll", StringComparison.OrdinalIgnoreCase)
                );
            var loadBase = (long)kernel32.BaseAddress + Common.GetLoadLibraryRelAddr();

            long ptr = Common.RemoteWrite(p, dllPath);
            IntPtr hThread, threadId;

            hThread = WinApi.CreateRemoteThread(p.Handle, IntPtr.Zero, 0, (IntPtr)loadBase, (IntPtr)ptr, 0, out threadId);
            if (hThread == IntPtr.Zero) throw new InjectException("Couldn't start remote LoadLibrary");
            WinApi.WaitForSingleObject(hThread, 3000);
        }
    }
}
