namespace WinFormDemo
{
    partial class AutoRun
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnStep1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSelectFiles = new System.Windows.Forms.Button();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDstPath = new System.Windows.Forms.TextBox();
            this.lblCopyRes = new System.Windows.Forms.Label();
            this.btnStep0 = new System.Windows.Forms.Button();
            this.btnStep2 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // btnStep1
            // 
            this.btnStep1.Location = new System.Drawing.Point(34, 90);
            this.btnStep1.Name = "btnStep1";
            this.btnStep1.Size = new System.Drawing.Size(151, 23);
            this.btnStep1.TabIndex = 8;
            this.btnStep1.Text = "第一步: 拷贝四个文件";
            this.btnStep1.UseVisualStyleBackColor = true;
            this.btnStep1.Click += new System.EventHandler(this.btnStep1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnStep2);
            this.groupBox2.Controls.Add(this.btnStep0);
            this.groupBox2.Controls.Add(this.btnStep1);
            this.groupBox2.Location = new System.Drawing.Point(52, 352);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(839, 255);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // btnSelectFiles
            // 
            this.btnSelectFiles.Location = new System.Drawing.Point(117, 34);
            this.btnSelectFiles.Name = "btnSelectFiles";
            this.btnSelectFiles.Size = new System.Drawing.Size(92, 23);
            this.btnSelectFiles.TabIndex = 1;
            this.btnSelectFiles.Text = "选择源文件";
            this.btnSelectFiles.UseVisualStyleBackColor = true;
            this.btnSelectFiles.Click += new System.EventHandler(this.btnSelectFiles_Click);
            // 
            // lvFiles
            // 
            this.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFiles.Location = new System.Drawing.Point(3, 17);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(722, 155);
            this.lvFiles.TabIndex = 4;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.List;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvFiles);
            this.groupBox1.Location = new System.Drawing.Point(114, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(728, 175);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "我的选择";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(583, 274);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "选择目标文件夹并拷贝";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDstPath
            // 
            this.txtDstPath.Location = new System.Drawing.Point(117, 274);
            this.txtDstPath.Name = "txtDstPath";
            this.txtDstPath.Size = new System.Drawing.Size(434, 21);
            this.txtDstPath.TabIndex = 6;
            // 
            // lblCopyRes
            // 
            this.lblCopyRes.AutoSize = true;
            this.lblCopyRes.Location = new System.Drawing.Point(785, 279);
            this.lblCopyRes.Margin = new System.Windows.Forms.Padding(3);
            this.lblCopyRes.Name = "lblCopyRes";
            this.lblCopyRes.Size = new System.Drawing.Size(0, 12);
            this.lblCopyRes.TabIndex = 7;
            // 
            // btnStep0
            // 
            this.btnStep0.Location = new System.Drawing.Point(34, 47);
            this.btnStep0.Name = "btnStep0";
            this.btnStep0.Size = new System.Drawing.Size(151, 23);
            this.btnStep0.TabIndex = 9;
            this.btnStep0.Text = "第零步: 比较文件夹";
            this.btnStep0.UseVisualStyleBackColor = true;
            this.btnStep0.Click += new System.EventHandler(this.btnStep0_Click);
            // 
            // btnStep2
            // 
            this.btnStep2.Location = new System.Drawing.Point(34, 139);
            this.btnStep2.Name = "btnStep2";
            this.btnStep2.Size = new System.Drawing.Size(151, 23);
            this.btnStep2.TabIndex = 10;
            this.btnStep2.Text = "第二步:拷贝三个文件";
            this.btnStep2.UseVisualStyleBackColor = true;
            this.btnStep2.Click += new System.EventHandler(this.btnStep2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 660);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblCopyRes);
            this.Controls.Add(this.txtDstPath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSelectFiles);
            this.ForeColor = System.Drawing.Color.DarkMagenta;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnStep1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSelectFiles;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtDstPath;
        private System.Windows.Forms.Label lblCopyRes;
        private System.Windows.Forms.Button btnStep0;
        private System.Windows.Forms.Button btnStep2;
    }
}

