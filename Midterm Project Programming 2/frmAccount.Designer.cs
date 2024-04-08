namespace Midterm_Project_Programming_2
{
    partial class frmAccount
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
            this.txbAccNum = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbWithdraw = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.txbTransferAccount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbTransferAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txbAccNum
            // 
            this.txbAccNum.Location = new System.Drawing.Point(30, 109);
            this.txbAccNum.Name = "txbAccNum";
            this.txbAccNum.Size = new System.Drawing.Size(263, 20);
            this.txbAccNum.TabIndex = 0;
            this.txbAccNum.TextChanged += new System.EventHandler(this.txbAccNum_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(304, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 47);
            this.button1.TabIndex = 1;
            this.button1.Text = "Check Balance";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(30, 308);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(193, 47);
            this.button2.TabIndex = 2;
            this.button2.Text = "Withdraw Amount";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Checking Account Number or Any Account Number:";
            // 
            // txbWithdraw
            // 
            this.txbWithdraw.Location = new System.Drawing.Point(30, 206);
            this.txbWithdraw.Name = "txbWithdraw";
            this.txbWithdraw.Size = new System.Drawing.Size(263, 20);
            this.txbWithdraw.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Withdraw Amount:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(549, 308);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(184, 44);
            this.button3.TabIndex = 6;
            this.button3.Text = "Transfer Funds";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txbTransferAccount
            // 
            this.txbTransferAccount.Location = new System.Drawing.Point(404, 109);
            this.txbTransferAccount.Name = "txbTransferAccount";
            this.txbTransferAccount.Size = new System.Drawing.Size(246, 20);
            this.txbTransferAccount.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Saving Account Number/Transfer Account Number:";
            // 
            // txbTransferAmount
            // 
            this.txbTransferAmount.Location = new System.Drawing.Point(404, 206);
            this.txbTransferAmount.Name = "txbTransferAmount";
            this.txbTransferAmount.Size = new System.Drawing.Size(246, 20);
            this.txbTransferAmount.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(401, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Transfer Amount:";
            // 
            // frmAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbTransferAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbTransferAccount);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbWithdraw);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txbAccNum);
            this.Name = "frmAccount";
            this.Text = "frmAccount";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbAccNum;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbWithdraw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txbTransferAccount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbTransferAmount;
        private System.Windows.Forms.Label label4;
    }
}