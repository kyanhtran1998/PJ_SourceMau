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
    public class DrugCategoryRes
    {
        public static List<DrugCategory> GetAll()
        {
            List<DrugCategory> lstStore = new List<DrugCategory>();
            object[] value = null;
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.Select("DrugCategory_Getall", value);
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    DrugCategory store = new DrugCategory()
                    {
                        categoryId = int.Parse(dr["categoryId"].ToString()),
                        categoryName = dr["categoryName"].ToString(),

                    };
                    lstStore.Add(store);
                }
            }
            return lstStore;
        }

        public static bool SaveDrugCategory(object[] value, ref string[] output, ref int errorCode,
         ref string errorMessage)
        {
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.ExecuteData("DrugCategory_Save", value);
            output = connection.output;
            errorCode = connection.errorCode;
            errorMessage = connection.errorMessage;
            return result;
        }

        public static bool DeleteDrugCategory(object[] value, ref string[] output, ref int errorCode,
           ref string errorMessage)
        {
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.ExecuteData("DrugCategory_Delete", value);
            output = connection.output;
            errorCode = connection.errorCode;
            errorMessage = connection.errorMessage;
            return result;
        }

    }
}
