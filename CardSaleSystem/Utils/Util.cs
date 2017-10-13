using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardSaleSystem.Utils
{
    public class Util
    {
        public static int GetRandomNumber(int min = 100000000, int max = 999999999)
        {
            int rtn = 0;
            Random r = new Random();
            byte[] buffer = Guid.NewGuid().ToByteArray();
            int iSeed = BitConverter.ToInt32(buffer, 0);
            r = new Random(iSeed);
            rtn = r.Next(min, max + 1);
            return rtn;
        }

        public static string GetUserType(int type)
        {
            string userType = string.Empty;
            switch (type)
            {
                case 0:
                    userType = "管理员";
                    break;
                case 1:
                    userType = "代理";
                    break;
                case 3:
                    userType = "分销";
                    break;
                case 4:
                    userType = "档口";
                    break;
                default:
                    break;
            }
            return userType;
        }
    }
}