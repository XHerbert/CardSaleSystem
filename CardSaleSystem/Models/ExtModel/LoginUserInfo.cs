using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardSaleSystem.Models.ExtModel
{
    [Serializable]
    public class LoginUserInfo
    {
        public static LoginUserInfo Current { get; private set; }
        public string CurrentUser { get; set; }

        public long Id { get; set; }

        public int Point { get; set; }

        public bool IsAdmin { get; set; }

        public int PreUserId { get; set; }

        public string PreUserCode { get; set; }

        public static LoginUserInfo GetInstance()
        {
            if(null == Current)
            {
                return new LoginUserInfo();
            }
            return Current;
        }
    }
}