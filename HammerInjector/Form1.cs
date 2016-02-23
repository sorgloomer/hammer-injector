using HammerInjector.Injector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HammerInjector
{
    public partial class HammerForm : Form
    {
        private class ProcessItemView
        {
            public int Pid { get; set; }
            public String ProcessName { get; set; }
            public ProcessItemView() { }
            public ProcessItemView(Process p) {
                this.Pid = p.Id;
                this.ProcessName = p.ProcessName;
                // this.ImageName = p.Modules[0].FileName;
            }

            public override string ToString()
            {
                return String.Format("{0} ({1})", this.ProcessName, this.Pid);
            }

        }
        public HammerForm()
        {
            InitializeComponent();
        }

        private void RefreshProcesses()
        {
            var ps = Process.GetProcesses().Select(p => new ProcessItemView(p)).OrderBy(i => i.ProcessName).ToArray();
            this.cbProcesses.Items.Clear();
            this.cbProcesses.Items.AddRange(ps);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RefreshProcesses();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowseDll_Click(object sender, EventArgs e)
        {
            if (this.dlgBrowseDll.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                var file = this.dlgBrowseDll.FileName;
                this.tbDllPath.Text = file;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            RefreshProcesses();
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.ExceptionObject.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInjectRegular_Click(object sender, EventArgs e)
        {
            InjectBy(Regular.Inject);
        }

        private void btnInjectReflective_Click(object sender, EventArgs e)
        {
            InjectBy(Reflective.Inject2);
        }

        private void InjectBy(Action<Process, string> injector)
        {
            injector(SelectedProcess(), this.tbDllPath.Text);
        }
        private Process SelectedProcess()
        {
            var selected = (ProcessItemView)cbProcesses.SelectedItem;
            return Process.GetProcessById(selected.Pid);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Common.RemoteRun(SelectedProcess(), this.tbDllPath.Text, this.tbProcName.Text, this.tbProcParam.Text);
        }
    }
}
