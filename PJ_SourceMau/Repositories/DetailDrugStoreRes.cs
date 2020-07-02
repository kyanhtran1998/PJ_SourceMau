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
    public class DetailDrugStoreRes
    {

        public static List<DrugDetails> GetAll()
        {
            List<DrugDetails> lstStore = new List<DrugDetails>();
            object[] value = null;
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.Select("DrugDetails_Getall", value);
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    DrugDetails store = new DrugDetails()
                    {
                        id = int.Parse(dr["id"].ToString()),
                        drugname = dr["drugname"].ToString(),
                        price = int.Parse(dr["price"].ToString()),
                        note = dr["note"].ToString(),
                        iddrugstore = int.Parse(dr["iddrugstore"].ToString())

                    };
                    lstStore.Add(store);
                }
            }
            return lstStore;
        }

       public static bool SaveDrugDetail(object[] value, ref string[] output, ref int errorCode,
       ref string errorMessage)
        {
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.ExecuteData("DrugDetails_Save", value);
            output = connection.output;
            errorCode = connection.errorCode;
            errorMessage = connection.errorMessage;
            return result;
        }
        public static bool DeleteDetailDrugStore(object[] value, ref string[] output, ref int errorCode,
       ref string errorMessage)
        {
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.ExecuteData("DrugDetails_Delete", value);
            output = connection.output;
            errorCode = connection.errorCode;
            errorMessage = connection.errorMessage;
            return result;
        }
    }
}
