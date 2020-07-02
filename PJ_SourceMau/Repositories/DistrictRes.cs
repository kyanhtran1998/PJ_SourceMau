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
    public class DistrictRes
    {
        public static List<District> GetAll()
        {
            List<District> lstStore = new List<District>();
            object[] value = null;
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.Select("District_Getall", value);
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    District store = new District()
                    {
                        ID = int.Parse(dr["ID"].ToString()),
                        Name = dr["Name"].ToString(),

                    };
                    lstStore.Add(store);
                }
            }
            return lstStore;
        }

        public static bool SaveDistrict(object[] value, ref string[] output, ref int errorCode,
         ref string errorMessage)
        {
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.ExecuteData("District_Save", value);
            output = connection.output;
            errorCode = connection.errorCode;
            errorMessage = connection.errorMessage;
            return result;
        }

        public static bool DeleteDistrict(object[] value, ref string[] output, ref int errorCode,
           ref string errorMessage)
        {
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.ExecuteData("District_Delete", value);
            output = connection.output;
            errorCode = connection.errorCode;
            errorMessage = connection.errorMessage;
            return result;
        }

    }
}
