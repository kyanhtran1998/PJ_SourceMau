using CAIT.SQLHelper;
using PJ_SourceMau.Caption;
using PJ_SourceMau.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PJ_SourceMau.Repositories
{
    public class AccountRes
    {
        public static List<Account> GetAll()
        {
            List<Account> lstStore = new List<Account>();
            object[] value = null;
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.Select("Account_Getall", value);
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    Account store = new Account()
                    {
                        id = int.Parse(dr["id"].ToString()),
                        username = dr["username"].ToString(),
                        password = dr["password"].ToString(),
                        groupId = int.Parse(dr["groupId"].ToString())
                    };
                    lstStore.Add(store);
                }
            }
            
            return lstStore;
        }


        public static bool InsertAccount(object[] value, ref string[] output, ref int errorCode,
        ref string errorMessage)
        {
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.ExecuteData("InsertAccount", value);
            output = connection.output;
            errorCode = connection.errorCode;
            errorMessage = connection.errorMessage;
            return result;
        }
        public static bool DeleteAccount(object[] value, ref string[] output, ref int errorCode,
          ref string errorMessage)
        {
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.ExecuteData("Account_Delete", value);
            output = connection.output;
            errorCode = connection.errorCode;
            errorMessage = connection.errorMessage;
            return result;
        }
		
		public static int InsertRegisterAccount(string Username, string Password)
        {
            SqlConnection conn = new SqlConnection(ConstValue.ConnectionString);
            try
            {
                string strQuery = "INSERT INTO Account OUTPUT inserted.id VALUES (@Username, @Password,  @GroupId)";
                conn.Open();
                SqlCommand com = new SqlCommand(strQuery, conn);
                com.Parameters.Add(new SqlParameter("@Username", Username));
                com.Parameters.Add(new SqlParameter("@Password", Password));
                com.Parameters.Add(new SqlParameter("@GroupId", 2));
                int result = (int)com.ExecuteScalar();
                conn.Close();
                return result;
            }
            catch (Exception ex)
            {
                conn.Close();
                return 0; ;
            }
        }

        public static int InsertRegisterDetails(string UserName, string Name, string Email, string PhoneNumber, string Address, int IdUser)
        {
            SqlConnection conn = new SqlConnection(ConstValue.ConnectionString);
            try
            {
                string strQuery = "INSERT INTO AccountDetail OUTPUT inserted.id VALUES(@Name, @Email, @PhoneNumber, @Address, @IdUser)";
                SqlCommand com = new SqlCommand(strQuery, conn);
                conn.Open();
                com.Parameters.Add(new SqlParameter("@Name", Name));
                com.Parameters.Add(new SqlParameter("@Email", Email));
                com.Parameters.Add(new SqlParameter("@PhoneNumber", PhoneNumber));
                com.Parameters.Add(new SqlParameter("@Address", Address));
                com.Parameters.Add(new SqlParameter("@IdUser", IdUser));
                int result = (int)com.ExecuteScalar();
                conn.Close();
                return result;
            }
            catch (Exception ex)
            {
                conn.Close();
                return 0;
            }
        }
    }
}
