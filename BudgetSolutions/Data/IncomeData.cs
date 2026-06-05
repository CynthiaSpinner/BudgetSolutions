using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BudgetSolutions
{
    class IncomeData
    {
        string stringConnection = Program.ConnectionString;

        public int ID { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string NickName { get; set; }
        public string DepositDate { get; set; }
        public string Amount { get; set; }

        public List<IncomeData> IncomeListData()
        {
            List<IncomeData> listIncome = new List<IncomeData>();

            using (SqlConnection connect = new SqlConnection(stringConnection))
            {
                connect.Open();

                string selectIncomeData = "SELECT * FROM income";

                using (SqlCommand cmd = new SqlCommand(selectIncomeData, connect))
                {
                    SqlDataReader iReader = cmd.ExecuteReader();

                    while (iReader.Read())
                    {
                        IncomeData iData = new IncomeData();
                        iData.ID = (int)iReader["ID"];
                        iData.Category = iReader["category"].ToString();
                        iData.Type = iReader["Type"].ToString();
                        iData.NickName = iReader["name"].ToString();
                        iData.DepositDate = ((DateTime)iReader["date"]).ToString("MM-dd-yyyy");
                        iData.Amount = iReader["amount"].ToString();
                        

                        listIncome.Add(iData);
                    }
                }
            }
            return listIncome;
        }
    }
}
