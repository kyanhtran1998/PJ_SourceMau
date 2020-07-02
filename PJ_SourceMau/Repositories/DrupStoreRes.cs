using CAIT.SQLHelper;
using PJ_SourceMau.Caption;
using PJ_SourceMau.FunctionSupport;
using PJ_SourceMau.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PJ_SourceMau.Repositories
{
    public class DrupStoreRes
    {

        public static List<DrugStore> GetAll()
        {
            List<DrugStore> lstStore = new List<DrugStore>();
            object[] value = null;
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.Select("DrugStore_Getall", value);
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    DrugStore store = new DrugStore()
                    {
                        ID = int.Parse(dr["ID"].ToString()),
                        name = dr["name"].ToString(),
                        address = dr["address"].ToString(),
                        district = int.Parse(dr["district"].ToString()),
                        phone = dr["phone"].ToString(),
                        imgSrc = dr["imgSrc"].ToString(),
                        status = int.Parse(dr["status"].ToString()),
                        categoryId = int.Parse(dr["categoryId"].ToString()),
                        description = dr["description"].ToString(),
                        openTime = dr["openTime"].ToString(),
                        closedTime = dr["closedTime"].ToString(),
                        iduser = int.Parse(dr["iduser"].ToString()),
                        lat = float.Parse(dr["lat"].ToString()),
                        lng = float.Parse(dr["lng"].ToString()),
                        averageRating = int.Parse(dr["AverageRating"].ToString())
                    };
                    lstStore.Add(store);
                }
            }
            return lstStore;
        }
        public static List<DrugStore> GetTopfive()
        {
            List<DrugStore> lstStore = new List<DrugStore>();
            object[] value = null;
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.Select("topfive_Rating", value);
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    DrugStore store = new DrugStore()
                    {
                        ID = int.Parse(dr["ID"].ToString()),
                        name = dr["name"].ToString(),
                        address = dr["address"].ToString(),
                        district = int.Parse(dr["district"].ToString()),
                        imgSrc = dr["imgSrc"].ToString(),
                        openTime = dr["openTime"].ToString(),
                        closedTime = dr["closedTime"].ToString(),
                        averageRating = int.Parse(dr["AverageRating"].ToString())
                    };
                    lstStore.Add(store);
                }
            }
            return lstStore;
        }
        public static List<Comment> GetAllCmt()
        {
            List<Comment> lstCmt = new List<Comment>();
            object[] value = null;
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.Select("Comments_Getall", value);
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    Comment storeComment = new Comment()
                    {
                        cid = int.Parse(dr["cid"].ToString()),
                        name = dr["name"].ToString(),
                        email = dr["email"].ToString(),
                        comment = dr["comment"].ToString(),
                        datetime = Convert.ToDateTime(dr["datePosted"].ToString()),
                        rating = int.Parse(dr["rating"].ToString()),
                        storeId = int.Parse(dr["storeId"].ToString())

                    };
                    lstCmt.Add(storeComment);
                }
            }
            return lstCmt;
        }

        public static bool averageRating(object[] value, ref string[] output, ref int errorCode,
        ref string errorMessage)
        {
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.ExecuteData("DrugStore_AverageRating", value);
            output = connection.output;
            errorCode = connection.errorCode;
            errorMessage = connection.errorMessage;
            return result;
        }

        public static bool InsertStore(object[] value, ref string[] output, ref int errorCode,
        ref string errorMessage)
        {
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.ExecuteData("DrugStore_Insert", value);
            output = connection.output;
            errorCode = connection.errorCode;
            errorMessage = connection.errorMessage;
            return result;
        }

        public static bool DeleteStore(object[] value, ref string[] output, ref int errorCode,
            ref string errorMessage)
        {
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.ExecuteData("DrugStore_Delete", value);
            output = connection.output;
            errorCode = connection.errorCode;
            errorMessage = connection.errorMessage;
            return result;
        }

        public static bool SaveComment(object[] value, ref string[] output, ref int errorCode,
        ref string errorMessage)
        {
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.ExecuteData("Comment_Save", value);
            output = connection.output;
            errorCode = connection.errorCode;
            errorMessage = connection.errorMessage;
            return result;
        }
        public static bool DeleteComment(object[] value, ref string[] output, ref int errorCode,
           ref string errorMessage)
        {
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.ExecuteData("Comment_Delete", value);
            output = connection.output;
            errorCode = connection.errorCode;
            errorMessage = connection.errorMessage;
            return result;
        }
        public static bool SaveStore(object[] value, ref string[] output, ref int errorCode,
       ref string errorMessage)
        {
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.ExecuteData("DrugStore_Save", value);
            output = connection.output;
            errorCode = connection.errorCode;
            errorMessage = connection.errorMessage;
            return result;
        }

        public static List<DrugStore> GetAllSearch(object[] value, ref string[] output, ref int errorCode,
       ref string errorMessage)
        {
            List<DrugStore> lstStore = new List<DrugStore>();
            var connection = new SQLCommand(ConstValue.ConnectionString);
            var result = connection.Select("DrugStore_GetallSearch", value);
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    DrugStore store = new DrugStore()
                    {
                        ID = int.Parse(dr["ID"].ToString()),
                        name = dr["name"].ToString(),
                        address = dr["address"].ToString(),
                        district = int.Parse(dr["district"].ToString()),
                        phone = dr["phone"].ToString(),
                        imgSrc = dr["imgSrc"].ToString(),
                        status = int.Parse(dr["status"].ToString()),
                        categoryId = int.Parse(dr["categoryId"].ToString()),
                        openTime = dr["openTime"].ToString(),
                        closedTime = dr["closedTime"].ToString(),
                        averageRating = int.Parse(dr["AverageRating"].ToString())

                    };
                    lstStore.Add(store);
                }
            }
            return lstStore;
        }
    }
}
