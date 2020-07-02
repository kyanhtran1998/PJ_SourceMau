using CAIT.SQLHelper;
using PJ_SourceMau.Caption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace DUAN2NHATHUOC.Repositories
{
    public class AccountGroupsRes
    {

        public static bool Group_Save(object[] value, ref string[] output, ref int errorCode,
        ref string errorMessage)
        {
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.ExecuteData("lp_group_Save", value);
            output = connection.output;
            errorCode = connection.errorCode;
            errorMessage = connection.errorMessage;
            return result;
        }
    }
}
