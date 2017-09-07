namespace VirtualDesktop
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtPic1 = new System.Windows.Forms.TextBox();
            this.txtPic2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn2 = new System.Windows.Forms.Button();
            this.txtPic3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn3 = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblCopy = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(370, 14);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(51, 23);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "...";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desktop 1:";
            // 
            // txtPic1
            // 
            this.txtPic1.Location = new System.Drawing.Point(77, 15);
            this.txtPic1.Name = "txtPic1";
            this.txtPic1.Size = new System.Drawing.Size(287, 20);
            this.txtPic1.TabIndex = 2;
            // 
            // txtPic2
            // 
            this.txtPic2.Location = new System.Drawing.Point(77, 51);
            this.txtPic2.Name = "txtPic2";
            this.txtPic2.Size = new System.Drawing.Size(287, 20);
            this.txtPic2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Desktop 2:";
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(370, 50);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(51, 23);
            this.btn2.TabIndex = 3;
            this.btn2.Text = "...";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // txtPic3
            // 
            this.txtPic3.Location = new System.Drawing.Point(77, 90);
            this.txtPic3.Name = "txtPic3";
            this.txtPic3.Size = new System.Drawing.Size(287, 20);
            this.txtPic3.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Desktop 3:";
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(370, 89);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(51, 23);
            this.btn3.TabIndex = 6;
            this.btn3.Text = "...";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(346, 138);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // lblCopy
            // 
            this.lblCopy.AutoSize = true;
            this.lblCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCopy.Location = new System.Drawing.Point(3, 149);
            this.lblCopy.Name = "lblCopy";
            this.lblCopy.Size = new System.Drawing.Size(56, 15);
            this.lblCopy.TabIndex = 10;
            this.lblCopy.Text = "copyright";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 173);
            this.Controls.Add(this.lblCopy);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtPic3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.txtPic2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.txtPic1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Virtual Desktop";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPic1;
        private System.Windows.Forms.TextBox txtPic2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.TextBox txtPic3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label lblCopy;
    }
}

