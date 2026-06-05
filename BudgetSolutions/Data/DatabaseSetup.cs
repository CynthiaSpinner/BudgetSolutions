using System;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace BudgetSolutions
{
    static class DatabaseSetup
    {
        public static void Initialize(string dbPath, string connectionString)
        {
            string masterConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30";

            try
            {
                using (SqlConnection conn = new SqlConnection(masterConnection))
                {
                    conn.Open();

                    string createDb = $@"
                        CREATE DATABASE BudgetSolutions
                        ON PRIMARY (NAME = BudgetSolutions, FILENAME = '{dbPath}')
                        LOG ON (NAME = BudgetSolutions_log, FILENAME = '{Path.ChangeExtension(dbPath, ".ldf")}')";

                    using (SqlCommand cmd = new SqlCommand(createDb, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string[] setupScripts = new string[]
                    {
                        @"CREATE TABLE users (
                            id INT PRIMARY KEY IDENTITY(1,1),
                            username VARCHAR(MAX) NULL,
                            password VARCHAR(MAX) NULL,
                            date_create DATE NULL
                        )",

                        @"CREATE TABLE expenses (
                            id INT PRIMARY KEY IDENTITY(1,1),
                            category VARCHAR(MAX) NULL,
                            type VARCHAR(MAX) NULL,
                            name VARCHAR(MAX) NULL,
                            date DATE NULL,
                            amount DECIMAL(38,2) NULL,
                            grace VARCHAR(MAX) NULL,
                            lateFee DECIMAL(38,2) NULL,
                            passed VARCHAR(MAX) NULL,
                            passedAmount DECIMAL(38,2) NULL,
                            creditIssue VARCHAR(MAX) NULL
                        )",

                        @"CREATE TABLE income (
                            id INT PRIMARY KEY IDENTITY(1,1),
                            category VARCHAR(MAX) NULL,
                            type VARCHAR(MAX) NULL,
                            name VARCHAR(MAX) NULL,
                            date DATE NULL,
                            amount DECIMAL(38,2) NULL
                        )",

                        @"CREATE PROCEDURE AddAndUpdateIncome
                            @category_category VARCHAR(MAX),
                            @category_type VARCHAR(MAX),
                            @category_name VARCHAR(MAX),
                            @category_datepicker DATE,
                            @category_amount DECIMAL(38,2)
                        AS
                        BEGIN
                            IF EXISTS (SELECT 1 FROM income WHERE name = @category_name AND type = @category_type)
                                UPDATE income SET category = @category_category, type = @category_type, name = @category_name,
                                    date = @category_datepicker, amount = @category_amount
                                WHERE name = @category_name AND type = @category_type
                            ELSE
                                INSERT INTO income (category, type, name, date, amount)
                                VALUES (@category_category, @category_type, @category_name, @category_datepicker, @category_amount)
                        END",

                        @"CREATE PROCEDURE AddAndUpdateExpense
                            @category_category VARCHAR(MAX),
                            @category_type2 VARCHAR(MAX),
                            @category_name VARCHAR(MAX),
                            @category_datepicker DATE,
                            @category_amount DECIMAL(38,2),
                            @category_grace VARCHAR(MAX),
                            @category_latefee DECIMAL(38,2),
                            @category_passeddue VARCHAR(MAX),
                            @category_howmuch DECIMAL(38,2),
                            @category_30late VARCHAR(MAX)
                        AS
                        BEGIN
                            IF EXISTS (SELECT 1 FROM expenses WHERE name = @category_name AND type = @category_type2)
                                UPDATE expenses SET category = @category_category, type = @category_type2, name = @category_name,
                                    date = @category_datepicker, amount = @category_amount, grace = @category_grace,
                                    lateFee = @category_latefee, passed = @category_passeddue, passedAmount = @category_howmuch,
                                    creditIssue = @category_30late
                                WHERE name = @category_name AND type = @category_type2
                            ELSE
                                INSERT INTO expenses (category, type, name, date, amount, grace, lateFee, passed, passedAmount, creditIssue)
                                VALUES (@category_category, @category_type2, @category_name, @category_datepicker, @category_amount,
                                    @category_grace, @category_latefee, @category_passeddue, @category_howmuch, @category_30late)
                        END"
                    };

                    foreach (string script in setupScripts)
                    {
                        using (SqlCommand cmd = new SqlCommand(script, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database setup failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
