using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HammerInjector.Injector
{
    public class Reflective
    {
        public static void Inject(Process p, string dllPath)
        {
            var fileName = (IntPtr.Size == 8) ? "Reflective\\inject.x64.exe" : "Reflective\\inject.exe";
            var args = String.Format("{0} \"{1}\"", (long)p.Handle, dllPath);
            var psi = new ProcessStartInfo(fileName, args);
            var reflectiveProcess = Process.Start(psi);
            reflectiveProcess.WaitForExit(3000);
        }
        public static void Inject2(Process p, string dllPath)
        {
            IntPtr threadId;
            var fileName = (IntPtr.Size == 8) ? "Reflective\\reflective_dll.x64.dll" : "Reflective\\reflective_dll.dll";
            var libData = File.ReadAllBytes(fileName);
            var basePtr = Common.RemoteWrite(p, libData);
            var ptrDllPath = Common.RemoteWrite(p, dllPath);
            long rlOffset = Common.GetDllProcOffset(fileName, "_ReflectiveLoader@4");
            if (rlOffset == 0) throw new InjectException("Could not locate ReflectiveLoader");
            var lpStart = basePtr + rlOffset;
            WinApi.CreateRemoteThread(p.Handle, IntPtr.Zero, 0, (IntPtr)lpStart, (IntPtr)0 /* ptrDllPath */, 0, out threadId);
        }
    }
}
