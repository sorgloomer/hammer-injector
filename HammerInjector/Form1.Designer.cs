namespace HammerInjector
{
    partial class HammerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbProcesses = new System.Windows.Forms.ComboBox();
            this.btnRefreshProcesses = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDllPath = new System.Windows.Forms.TextBox();
            this.btnBrowseDll = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnInjectReflective = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbProcParam = new System.Windows.Forms.TextBox();
            this.tbProcName = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnInjectRegular = new System.Windows.Forms.Button();
            this.dlgBrowseDll = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // cbProcesses
            // 
            this.cbProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbProcesses.FormattingEnabled = true;
            this.cbProcesses.Location = new System.Drawing.Point(15, 25);
            this.cbProcesses.Name = "cbProcesses";
            this.cbProcesses.Size = new System.Drawing.Size(606, 21);
            this.cbProcesses.TabIndex = 0;
            // 
            // btnRefreshProcesses
            // 
            this.btnRefreshProcesses.Location = new System.Drawing.Point(627, 23);
            this.btnRefreshProcesses.Name = "btnRefreshProcesses";
            this.btnRefreshProcesses.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshProcesses.TabIndex = 1;
            this.btnRefreshProcesses.Text = "Refresh";
            this.btnRefreshProcesses.UseVisualStyleBackColor = true;
            this.btnRefreshProcesses.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Process";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "DLL";
            // 
            // tbDllPath
            // 
            this.tbDllPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDllPath.Location = new System.Drawing.Point(15, 65);
            this.tbDllPath.Name = "tbDllPath";
            this.tbDllPath.Size = new System.Drawing.Size(606, 20);
            this.tbDllPath.TabIndex = 4;
            // 
            // btnBrowseDll
            // 
            this.btnBrowseDll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseDll.Location = new System.Drawing.Point(627, 63);
            this.btnBrowseDll.Name = "btnBrowseDll";
            this.btnBrowseDll.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDll.TabIndex = 5;
            this.btnBrowseDll.Text = "Browse";
            this.btnBrowseDll.UseVisualStyleBackColor = true;
            this.btnBrowseDll.Click += new System.EventHandler(this.btnBrowseDll_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Inject";
            // 
            // btnInjectReflective
            // 
            this.btnInjectReflective.Location = new System.Drawing.Point(96, 104);
            this.btnInjectReflective.Name = "btnInjectReflective";
            this.btnInjectReflective.Size = new System.Drawing.Size(75, 23);
            this.btnInjectReflective.TabIndex = 7;
            this.btnInjectReflective.Text = "Reflective";
            this.btnInjectReflective.UseVisualStyleBackColor = true;
            this.btnInjectReflective.Click += new System.EventHandler(this.btnInjectReflective_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Proc name, parameter";
            // 
            // tbProcParam
            // 
            this.tbProcParam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProcParam.Location = new System.Drawing.Point(180, 146);
            this.tbProcParam.Name = "tbProcParam";
            this.tbProcParam.Size = new System.Drawing.Size(441, 20);
            this.tbProcParam.TabIndex = 9;
            // 
            // tbProcName
            // 
            this.tbProcName.Location = new System.Drawing.Point(15, 146);
            this.tbProcName.Name = "tbProcName";
            this.tbProcName.Size = new System.Drawing.Size(159, 20);
            this.tbProcName.TabIndex = 10;
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Location = new System.Drawing.Point(627, 144);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 11;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnInjectRegular
            // 
            this.btnInjectRegular.Location = new System.Drawing.Point(15, 104);
            this.btnInjectRegular.Name = "btnInjectRegular";
            this.btnInjectRegular.Size = new System.Drawing.Size(75, 23);
            this.btnInjectRegular.TabIndex = 12;
            this.btnInjectRegular.Text = "Regular";
            this.btnInjectRegular.UseVisualStyleBackColor = true;
            this.btnInjectRegular.Click += new System.EventHandler(this.btnInjectRegular_Click);
            // 
            // dlgBrowseDll
            // 
            this.dlgBrowseDll.Filter = "DLL Files|*.dll|All files|*";
            // 
            // HammerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 283);
            this.Controls.Add(this.btnInjectRegular);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.tbProcName);
            this.Controls.Add(this.tbProcParam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnInjectReflective);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBrowseDll);
            this.Controls.Add(this.tbDllPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefreshProcesses);
            this.Controls.Add(this.cbProcesses);
            this.Name = "HammerForm";
            this.Text = "Hammer Inject";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbProcesses;
        private System.Windows.Forms.Button btnRefreshProcesses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDllPath;
        private System.Windows.Forms.Button btnBrowseDll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInjectReflective;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbProcParam;
        private System.Windows.Forms.TextBox tbProcName;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnInjectRegular;
        private System.Windows.Forms.OpenFileDialog dlgBrowseDll;
    }
}

