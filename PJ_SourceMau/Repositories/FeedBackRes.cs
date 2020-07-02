using CAIT.SQLHelper;
using PJ_SourceMau.Caption;
using PJ_SourceMau.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PJ_SourceMau.Repositories
{
    public class FeedBackRes
    {
        public static List<FeedBack> GetAll()
        {
            List<FeedBack> lstStore = new List<FeedBack>();
            object[] value = null;
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.Select("Feedback_Getall", value);
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    FeedBack store = new FeedBack()
                    {
                        fbId = int.Parse(dr["fbId"].ToString()),
                        fbName = dr["fbName"].ToString(),
                        fbEmail = dr["fbEmail"].ToString(),
                        fbPhone = dr["fbPhone"].ToString(),
                        fbContent = dr["fbContent"].ToString()
                    };
                    lstStore.Add(store);
                }
            }
            return lstStore;
        }

        public static bool SaveFeedBack(object[] value, ref string[] output, ref int errorCode,
         ref string errorMessage)
        {
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.ExecuteData("Feedback_Save", value);
            output = connection.output;
            errorCode = connection.errorCode;
            errorMessage = connection.errorMessage;
            return result;
        }

        public static bool DeleteFeedback(object[] value, ref string[] output, ref int errorCode,
           ref string errorMessage)
        {
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.ExecuteData("Feedback_Delete", value);
            output = connection.output;
            errorCode = connection.errorCode;
            errorMessage = connection.errorMessage;
            return result;
        }

    }
}
