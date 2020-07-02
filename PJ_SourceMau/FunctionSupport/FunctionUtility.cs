using PJ_SourceMau.Caption;
using System;
using System.Security.Cryptography;
using System.Text;

namespace PJ_SourceMau.FunctionSupport
{
    public class FunctionUtility
    {
        /// <summary>
        /// Tính toán số dòng hiển thị trên 1 page
        /// </summary>
        /// <param name="rowInDb"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static int CalcTotalPage(int rowInDb, int pageSize)
        {
            int mod = rowInDb % pageSize;
            if (mod > 0)
            {
                return (rowInDb / pageSize) + 1;
            }
            return (rowInDb / pageSize);
        }

        /// <summary>
        /// Chuyển định dạng ngày thánh thành yyyy-mm-dd
        /// VD: 2018-08-20
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy-MM-dd");
        }


        /// <summary>
        /// Chuyển định dạng ngày thánh thành yyyy-mm-dd
        /// VD: 2018-08-20
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String ConvertDateTimeToString(DateTime value)
        {
            return value.ToString("yyyyMMdd");
        }

        /// <summary>
        /// mã hóa mật khẩu
        /// </summary>
        /// <param name="toEncrypt">chuỗi cần mã hóa</param>
        /// <returns>chuỗi đã được mã hóa</returns>
        public static string Encrypt(string toEncrypt)
        {
            bool useHashing = true;
            byte[] keyArray;
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(ConstValue.KeyEncrypt));
            }
            else
                keyArray = Encoding.UTF8.GetBytes(ConstValue.KeyEncrypt);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// giải mã mật khẩu
        /// </summary>
        /// <param name="toDecrypt">chuỗi cần giải mã</param>
        /// <returns>chuỗi đã được giải mã</returns>
        public static string Decrypt(string toDecrypt)
        {
            bool useHashing = true;
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(ConstValue.KeyEncrypt));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(ConstValue.KeyEncrypt);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}
