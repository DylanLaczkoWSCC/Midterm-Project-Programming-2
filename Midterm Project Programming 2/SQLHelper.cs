using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Midterm_Project_Programming_2
{
    public static class SQLHelper
    {

        // Methods for the rest of the program to call for.


        // Function: Checks the database and returns with the current balance for a given account number.
        public static void CheckBalance(string AccNum)
        {
            // SQL Interaction
            string connectionString;
            SqlConnection cnn;
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\laczk\Downloads\WSCC\Programming 2\Midterm Programming 2\Midterm Project Programming 2\Midterm Project Programming 2\Database Mid.mdf"";Integrated Security=True;Connect Timeout=30;";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command = new SqlCommand("SELECT Balance FROM Account WHERE AccountNumber = @AccNum", cnn);
            command.Parameters.AddWithValue("@AccNum", AccNum);
            SqlDataReader reader = command.ExecuteReader();

            //Output
            if (reader.Read())
            {
                decimal balance = (decimal)reader["Balance"];
                MessageBox.Show($"Account Balance for Account Number {AccNum}: ${balance}", "Balance");
            }
            else
            {
                MessageBox.Show("Account not found.");
            }

            reader.Close();
            cnn.Close();

        }

        //Function: Withdraws a given amount from 1 account, or given another account in a transfer, 2 accounts..
        public static void WithdrawAmount(string AccNum, string Withdraw, string AccNum2)
        {
            // SQL Interaction
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\laczk\Downloads\WSCC\Programming 2\Midterm Programming 2\Midterm Project Programming 2\Midterm Project Programming 2\Database Mid.mdf"";Integrated Security=True;Connect Timeout=30;";
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                if (decimal.TryParse(Withdraw, out decimal withdrawAmount))
                {
                    string sql = "SELECT Balance FROM Account WHERE AccountNumber = @AccNum";
                    SqlCommand checkBalanceCommand = new SqlCommand(sql, cnn);
                    checkBalanceCommand.Parameters.AddWithValue("@AccNum", AccNum);
                    decimal balance = (decimal)checkBalanceCommand.ExecuteScalar();

                    if (withdrawAmount <= balance)
                    {
                        // Sufficient funds in checking account, proceed with withdrawal
                        balance -= withdrawAmount;
                        // SQL Interaction
                        sql = "UPDATE Account SET Balance = @Balance WHERE AccountNumber = @AccNum";
                        SqlCommand updateCommand = new SqlCommand(sql, cnn);
                        updateCommand.Parameters.AddWithValue("@Balance", balance);
                        updateCommand.Parameters.AddWithValue("@AccNum", AccNum);
                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        //Output
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Withdrawal successful.", "Success");
                        }
                        else
                        {
                            MessageBox.Show("Withdrawal failed.");
                        }
                    }
                    else
                    {
                        // Insufficient funds in checking account, try withdrawing from savings account
                        string savingsAccountNumber = AccNum2; // Provide the savings account number with AccNum 2 in the other textbox.
                        decimal remainingAmount = withdrawAmount - balance;
                        // SQL Interaction
                        sql = "SELECT Balance FROM Account WHERE AccountNumber = @SavingsAccNum";
                        SqlCommand checkSavingsBalanceCommand = new SqlCommand(sql, cnn);
                        checkSavingsBalanceCommand.Parameters.AddWithValue("@SavingsAccNum", savingsAccountNumber);
                        decimal savingsBalance = (decimal)checkSavingsBalanceCommand.ExecuteScalar();

                        if (savingsBalance >= remainingAmount)
                        {
                            // Sufficient balance in savings account, proceed with withdrawal
                            savingsBalance -= remainingAmount;
                            balance = 0;
                            // SQL Interaction
                            sql = "UPDATE Account SET Balance = 0 WHERE AccountNumber = @AccNum; " +
                                   "UPDATE Account SET Balance = @SavingsBalance WHERE AccountNumber = @SavingsAccNum";
                            SqlCommand transactionCommand = new SqlCommand(sql, cnn);
                            transactionCommand.Parameters.AddWithValue("@SavingsBalance", savingsBalance);
                            transactionCommand.Parameters.AddWithValue("@AccNum", AccNum);
                            transactionCommand.Parameters.AddWithValue("@SavingsAccNum", savingsAccountNumber);
                            int transactionRowsAffected = transactionCommand.ExecuteNonQuery();

                            //Output
                            if (transactionRowsAffected > 0)
                            {
                                MessageBox.Show("Withdrawal successful with overdraft from Savings Account.", "Success");
                            }
                            else
                            {
                                MessageBox.Show("Withdrawal failed.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Insufficient funds in both Checking and Savings Accounts");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid withdrawal amount.");
                }
            }
        }



        //Function: completes a transfer between 2 accounts given a certain amount of money.
        public static void TransferFund(string AccNum, string TransferAccount, string TransferAmount)
        {
            // SQL Interaction
            string connectionString;
            SqlConnection cnn;
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\laczk\Downloads\WSCC\Programming 2\Midterm Programming 2\Midterm Project Programming 2\Midterm Project Programming 2\Database Mid.mdf"";Integrated Security=True;Connect Timeout=30;";
            try
            {
                using (cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    // SQL Interaction
                    // Update command to deduct the amount from the source transfer.
                    SqlCommand command = new SqlCommand("UPDATE Account SET Balance = Balance - @TransferAmount WHERE AccountNumber = @AccNum", cnn);
                    command.Parameters.AddWithValue("@TransferAmount", TransferAmount);
                    command.Parameters.AddWithValue("@AccNum", AccNum);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("Source account not found.");
                        return;
                    }
                    // SQL Interaction
                    // Update command to add the amount to the destination account.
                    command = new SqlCommand("UPDATE Account SET Balance = Balance + @TransferAmount WHERE AccountNumber = @TransferAccount", cnn);
                    command.Parameters.AddWithValue("@TransferAmount", TransferAmount);
                    command.Parameters.AddWithValue("@TransferAccount", TransferAccount);
                    rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        // SQL Interaction
                        // if no rows were affected in the database, then the originating amount gets returned to the source.
                        command = new SqlCommand("UPDATE Account SET Balance = Balance + @TransferAmount WHERE AccountNumber = @AccNum", cnn);
                        command.Parameters.AddWithValue("@TransferAmount", TransferAmount);
                        command.Parameters.AddWithValue("@AccNum", AccNum);
                        command.ExecuteNonQuery();

                        //Output
                        MessageBox.Show("Destination account not found.");
                        return;
                    }

                    MessageBox.Show("Transfer successful.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }
    }
}

