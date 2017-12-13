namespace ADO.NET_Import_Export
{
    partial class Form1
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
            this.btnImport1 = new System.Windows.Forms.Button();
            this.btnImport2 = new System.Windows.Forms.Button();
            this.btnImport3 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // btnImport1
            // 
            this.btnImport1.Location = new System.Drawing.Point(84, 35);
            this.btnImport1.Name = "btnImport1";
            this.btnImport1.Size = new System.Drawing.Size(75, 23);
            this.btnImport1.TabIndex = 0;
            this.btnImport1.Text = "导入数据1";
            this.btnImport1.UseVisualStyleBackColor = true;
            this.btnImport1.Click += new System.EventHandler(this.btnImport1_Click);
            // 
            // btnImport2
            // 
            this.btnImport2.Location = new System.Drawing.Point(84, 83);
            this.btnImport2.Name = "btnImport2";
            this.btnImport2.Size = new System.Drawing.Size(75, 23);
            this.btnImport2.TabIndex = 0;
            this.btnImport2.Text = "导入数据2";
            this.btnImport2.UseVisualStyleBackColor = true;
            this.btnImport2.Click += new System.EventHandler(this.btnImport2_Click);
            // 
            // btnImport3
            // 
            this.btnImport3.Location = new System.Drawing.Point(84, 131);
            this.btnImport3.Name = "btnImport3";
            this.btnImport3.Size = new System.Drawing.Size(75, 23);
            this.btnImport3.TabIndex = 0;
            this.btnImport3.Text = "导入数据3";
            this.btnImport3.UseVisualStyleBackColor = true;
            this.btnImport3.Click += new System.EventHandler(this.btnImport3_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(84, 227);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "数据导出2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(84, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "数据导出1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 289);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnImport3);
            this.Controls.Add(this.btnImport2);
            this.Controls.Add(this.btnImport1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImport1;
        private System.Windows.Forms.Button btnImport2;
        private System.Windows.Forms.Button btnImport3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

