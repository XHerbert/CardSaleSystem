// =================================================================== 
// 项目说明
// ====================================================================
// xuhongbo。@Copy Right 2017
// 文件： UsersBll.cs
// 项目名称：答题系统
// 创建时间：2017/9/21
// 负责人：xuhongbo
// ===================================================================
using CardSaleSystem.Dal;
using CardSaleSystem.Models.UserModel;
using System.Collections.Generic;


namespace CardSaleSystem.Bll
{
    public partial class UsersBll
    {
        UsersDal usersdal;
        public UsersBll()
        {
            usersdal = new UsersDal();
        }

        public static UsersBll GetInstance()
        {
            return new UsersBll();
        }

        public long Insert(UsersEntity usersEntity)
        {
            return usersdal.Insert(usersEntity);
        }

        public long Update(UsersEntity usersEntity)
        {
            return usersdal.Update(usersEntity);
        }

        public long DeleteLogical(long id)
        {
            return usersdal.DeleteLogical(id);
        }

        /// <summary>
        /// 根据主键ID获取单条数据实体
        /// </summary>
        /// <param name="id">long </param>
        public UsersEntity GetAdminSingle(long id)
        {
            return usersdal.Get_UsersEntity(id);
        }

        /// <summary>
        /// 实例化一个新的实体
        /// </summary>
        public UsersEntity GetInstantiationEntity()
        {
            return new UsersEntity();
        }

        /// <summary>
        /// 通用单表列表翻页+where字符串拼接查询。（op后台使用，不适合高并发因为拼接sql没有参数化）
        /// </summary>
        /// <param name="pageCount">记录数</param>
        /// <param name="pageIndex">页号</param>
        /// <param name="pageSize">页码</param>
        /// <param name="where">查询条件</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="isDesc">排序规则（true正序false倒序）</param>
        /// <returns></returns>
        public IList<UsersEntity> Search(out int pageCount, int pageIndex, int pageSize, string where, string orderField, bool isDesc)
        {
            IList<UsersEntity> usersList = new List<UsersEntity>();
            usersList = usersdal.Search(out pageCount, pageIndex, pageSize, where, orderField, isDesc);
            return usersList;

        }

        /// <summary>
        /// 获取表的所有数据 
        /// </summary>
        public IList<UsersEntity> GetUsersList()
        {
            IList<UsersEntity> usersList = new List<UsersEntity>();
            usersList = usersdal.Get_UsersAll();
            return usersList;
        }

        /// <summary>
        /// 是否允许登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsAllowedLogin(UsersEntity user)
        {
            return usersdal.IsAllowedLogin(user);
        }

        /// <summary>
        /// 获取当前分销商下线用户
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public IList<UsersEntity> GetSpecialUsers(string userCode)
        {
            return usersdal.GetSpecialUsers(userCode);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public bool ChangePassword(string userCode,string newPassword)
        {
            var entity = usersdal.GetUserByCode(userCode);
            if (null == entity) return false;
            return usersdal.ChangePassword(entity, newPassword);
        }

        /// <summary>
        /// 通过编码获取用户
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public UsersEntity GetUserByCode(string code)
        {
            return usersdal.GetUserByCode(code);
        }

        public IList<UsersEntity> GetSearchUser(string createBy, string userinfo)
        {
            return usersdal.GetSearchUser(createBy, userinfo);
        }
    }
}