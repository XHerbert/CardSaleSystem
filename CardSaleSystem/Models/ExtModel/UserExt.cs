using CardSaleSystem.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardSaleSystem.Models.ExtModel
{
    public class UserExt
    {
        public IList<UsersEntity> UsersEntity { get; set; }
    }
}