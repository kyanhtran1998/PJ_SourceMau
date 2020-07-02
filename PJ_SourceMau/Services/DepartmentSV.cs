using PJ_SourceMau.Caption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJ_SourceMau.Services
{
    public class DepartmentSV
    {
        public static async Task<List<DepartmentSVModel>> GetAllDeparments()
        {
            var DeptService = new ServiceReference.Service1Client();
            var listDept = new List<DepartmentSVModel>();
            ServiceReference.getAllGroupNameEmailByTypeResponse DeptFromSv =
                await DeptService.getAllGroupNameEmailByTypeAsync(ConstValue.KeyDeptSv, "ALL");
            if (DeptFromSv.getAllGroupNameEmailByTypeResult != null)
            {
                for (int item = 0; item < DeptFromSv.getAllGroupNameEmailByTypeResult.Length; item++)
                {
                    try
                    {
                        string[] data = DeptFromSv.getAllGroupNameEmailByTypeResult[item].Split("\t");
                        DepartmentSVModel deptTemp = new DepartmentSVModel();
                        if (data.Length > 2)
                        {
                            deptTemp.DeptID = data[0];
                            deptTemp.DeptName = data[1];
                            deptTemp.DeptMail = data[2];
                        }
                        else
                        {
                            continue;
                        }
                        listDept.Add(deptTemp);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            return listDept;
        }
    }
}
