using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HammerInjector.Injector
{
    public class Common
    {
        public static long GetLoadLibraryRelAddr()
        {
            var result = GetDllProcOffset("kernel32.dll", "LoadLibraryA");
            if (result == 0) throw new InjectException("Cannot find LoadLibraryA in local kernel32");
            return result;
        }
        public static long GetDllProcOffset(string dll, string proc)
        {
            var hModule = WinApi.LoadLibrary(dll);
            if (hModule == IntPtr.Zero) return 0;
            var procAddr = WinApi.GetProcAddress(hModule, proc);
            if (procAddr == IntPtr.Zero) return 0;
            WinApi.FreeLibrary(hModule);
            return (long)procAddr - (long)hModule;
        }
        public static void RemoteRun(Process p, string dllPath, string procName, string parameters = null)
        {
            long ptr = 0;
            if (parameters != null) {
                ptr = RemoteWrite(p, parameters);
            }

            IntPtr threadId, hThread;
            var injected = p.Modules.Cast<ProcessModule>().Single(m => string.Equals(m.FileName, dllPath, StringComparison.OrdinalIgnoreCase));
            var targetAddr = Common.GetDllProcOffset(dllPath, procName) + (long)injected.BaseAddress;
            hThread = WinApi.CreateRemoteThread(p.Handle, IntPtr.Zero, 0, (IntPtr)targetAddr, (IntPtr)ptr, 0, out threadId);
            if (hThread == IntPtr.Zero) throw new InjectException("Couldn't start injected process");
        }

        public static long RemoteWrite(Process p, string value)
        {
            var concat = new Concatenated(value);
            return RemoteWrite(p, concat.Bytes);
        }
        public static long RemoteWrite(Process p, byte[] value)
        {
            IntPtr written;
            var ptr = WinApi.VirtualAllocEx(
                p.Handle, IntPtr.Zero, value.Length,
                WinApi.AllocationType.Commit | WinApi.AllocationType.Reserve,
                WinApi.MemoryProtection.ExecuteReadWrite);
            WinApi.WriteProcessMemory(p.Handle, ptr, value, value.Length, out written);
            if ((long)written != value.Length)
            {
                throw new InjectException("Couldn't write target memory");
            }
            return (long)ptr;
        }
    }

    class Concatenated
    {
        public byte[] Bytes;
        public int[] Indices;
        public Concatenated(params string[] strings)
        {
            var empty_bytes = new byte[0];
            byte[][] asciies = strings.Select(s => s == null ? empty_bytes : Encoding.ASCII.GetBytes(s)).ToArray();
            // Null terminated
            var total = asciies.Select(b => b.Length).Sum() + asciies.Length;
            this.Bytes = new byte[total];
            this.Indices = new int[strings.Length];
            int index = 0, ptr = 0;
            foreach (var bs in asciies)
            {
                this.Indices[index] = ptr;
                Array.Copy(asciies[index], 0, this.Bytes, ptr, asciies[index].Length);
                // Null terminated
                ptr += bs.Length + 1;
                index++;
            }
        }
        public IntPtr Base(IntPtr bse, int index)
        {
            return (IntPtr)((int)bse + this.Indices[index]);
        }
    }
    public class InjectException : Exception
    {
        public InjectException() { }
        public InjectException(string message) : base(message) { }
    }
}
