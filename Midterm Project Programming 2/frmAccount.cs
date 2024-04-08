using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Midterm_Project_Programming_2
{
    public partial class frmAccount : Form
    {
        public frmAccount()
        {
            InitializeComponent();
        }

        private void txbAccNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string AccNum = txbAccNum.Text;
            string Withdraw = txbWithdraw.Text;
            string AccNum2 = txbTransferAccount.Text;
            SQLHelper.WithdrawAmount(AccNum, Withdraw, AccNum2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string AccNum = txbAccNum.Text;
            SQLHelper.CheckBalance(AccNum);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string AccNum = txbAccNum.Text;
            string TransferAmount = txbTransferAmount.Text;
            string TransferAccount= txbTransferAccount.Text;
            SQLHelper.TransferFund(AccNum,TransferAccount,TransferAmount);
        }
    }
}
