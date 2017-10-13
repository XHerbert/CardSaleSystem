// =================================================================== 
// 项目说明
// ====================================================================
// xuhongbo @Copy Right 2017
// 文件： UsersDal.cs
// 项目名称：答题系统
// 创建时间：2017/9/21
// 负责人：xuhongbo
// ===================================================================
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CardSaleSystem.Utils;
using CardSaleSystem.Models.UserModel;

namespace CardSaleSystem.Dal
{
    /// <summary>
    /// 数据层实例化接口类 dbo.Users
    /// </summary>
    public partial class UsersDal
    {
        #region 构造函数


        /// <summary>
        /// 
        /// </summary>
        public UsersDal()
        {
        }
        #endregion

        #region -----------实例化接口函数-----------

        #region 添加更新删除
        /// <summary>
        /// 向数据库中插入一条新记录。
        /// </summary>
        /// <param name="_UsersModel">Users实体</param>
        /// <returns>新插入记录的编号</returns>
        public long Insert(UsersEntity _UsersModel)
        {
            string sqlStr = "insert into Users([UserCode],[UserName],[Password],[UserType],[Point],[Phone],[CreateBy],[CreateTime],[UpdateTime],[IsActive],[Memo]) values(@UserCode,@UserName,@Password,@UserType,@Point,@Phone,@CreateBy,@CreateTime,@UpdateTime,@IsActive,@Memo) select @@identity";
            long res;
            SqlParameter[] _param ={
            new SqlParameter("@UserCode",SqlDbType.VarChar),
            new SqlParameter("@UserName",SqlDbType.VarChar),
            new SqlParameter("@Password",SqlDbType.VarChar),
            new SqlParameter("@UserType",SqlDbType.VarChar),
            new SqlParameter("@Point",SqlDbType.Int),
            new SqlParameter("@Phone",SqlDbType.VarChar),
            new SqlParameter("@CreateBy",SqlDbType.VarChar),
            new SqlParameter("@CreateTime",SqlDbType.DateTime),
            new SqlParameter("@UpdateTime",SqlDbType.DateTime),
            new SqlParameter("@IsActive",SqlDbType.SmallInt),
            new SqlParameter("@Memo",SqlDbType.VarChar)
            };
            _param[0].Value = _UsersModel.UserCode;
            _param[1].Value = _UsersModel.UserName;
            _param[2].Value = _UsersModel.Password;
            _param[3].Value = _UsersModel.UserType;
            _param[4].Value = _UsersModel.Point;
            _param[5].Value = _UsersModel.Phone;
            _param[6].Value = _UsersModel.CreateBy;
            _param[7].Value = _UsersModel.CreateTime;
            _param[8].Value = _UsersModel.UpdateTime;
            _param[9].Value = _UsersModel.IsActive;
            _param[10].Value = _UsersModel.Memo;
            res = Convert.ToInt64(SqlHelper.ExecuteScalar(SqlHelper.Connection, CommandType.Text, sqlStr, _param));
            return res;
        }


        /// <summary>
        /// 向数据表Users更新一条记录。
        /// </summary>
        /// <param name="_UsersModel">_UsersModel</param>
        /// <returns>影响的行数</returns>
        public int Update(UsersEntity _UsersModel)
        {
            string sqlStr = "update Users set [UserCode]=@UserCode,[UserName]=@UserName,[Password]=@Password,[UserType]=@UserType,[Point]=@Point,[Phone]=@Phone,[CreateBy]=@CreateBy,[CreateTime]=@CreateTime,[UpdateTime]=@UpdateTime,[IsActive]=@IsActive,[Memo]=@Memo where Id=@Id";
            SqlParameter[] _param ={
                new SqlParameter("@Id",SqlDbType.BigInt),
                new SqlParameter("@UserCode",SqlDbType.VarChar),
                new SqlParameter("@UserName",SqlDbType.VarChar),
                new SqlParameter("@Password",SqlDbType.VarChar),
                new SqlParameter("@UserType",SqlDbType.VarChar),
                new SqlParameter("@Point",SqlDbType.Int),
                new SqlParameter("@Phone",SqlDbType.VarChar),
                new SqlParameter("@CreateBy",SqlDbType.VarChar),
                new SqlParameter("@CreateTime",SqlDbType.DateTime),
                new SqlParameter("@UpdateTime",SqlDbType.DateTime),
                new SqlParameter("@IsActive",SqlDbType.SmallInt),
                new SqlParameter("@Memo",SqlDbType.VarChar)
                };
            _param[0].Value = _UsersModel.Id;
            _param[1].Value = _UsersModel.UserCode;
            _param[2].Value = _UsersModel.UserName;
            _param[3].Value = _UsersModel.Password;
            _param[4].Value = _UsersModel.UserType;
            _param[5].Value = _UsersModel.Point;
            _param[6].Value = _UsersModel.Phone;
            _param[7].Value = _UsersModel.CreateBy;
            _param[8].Value = _UsersModel.CreateTime;
            _param[9].Value = _UsersModel.UpdateTime;
            _param[10].Value = _UsersModel.IsActive;
            _param[11].Value = _UsersModel.Memo;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        /// <summary>
        /// 删除数据表Users中的一条记录
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>影响的行数</returns>
        public int DeleteLogical(long Id)
        {
            string sqlStr = "update Users set isactive=0, updatetime=getdate() where [Id]=@Id";
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt),

            };
            _param[0].Value = Id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        /// <summary>
        /// 删除数据表Users中的一条记录
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>影响的行数</returns>
        public int Delete(long Id)
        {
            string sqlStr = "delete from Users where [Id]=@Id";
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt),

            };
            _param[0].Value = Id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  users 数据实体
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>users 数据实体</returns>
        public UsersEntity Populate_UsersEntity_FromDr(DataRow row)
        {
            UsersEntity Obj = new UsersEntity();
            if (row != null)
            {
                Obj.Id = ((row["Id"]) == DBNull.Value) ? 0 : (long)row["Id"];
                Obj.UserCode = row["UserCode"].ToString();
                Obj.UserName = row["UserName"].ToString();
                Obj.Password = row["Password"].ToString();
                Obj.UserType = row["UserType"].ToString();
                Obj.Point = ((row["Point"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["Point"]);
                Obj.Phone = row["Phone"].ToString();
                Obj.CreateBy = row["CreateBy"].ToString();
                Obj.CreateTime = ((row["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(row["CreateTime"]);
                Obj.UpdateTime = ((row["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(row["UpdateTime"]);
                Obj.IsActive = ((row["IsActive"]) == DBNull.Value) ? (short)0 : (short)row["IsActive"];
                Obj.Memo = row["Memo"].ToString();
            }
            else
            {
                return null;
            }
            return Obj;
        }

        /// <summary>
        /// 得到  users 数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>users 数据实体</returns>
        public UsersEntity Populate_UsersEntity_FromDr(IDataReader dr)
        {
            UsersEntity Obj = new UsersEntity();

            Obj.Id = ((dr["Id"]) == DBNull.Value) ? 0 : (long)dr["Id"];
            Obj.UserCode = dr["UserCode"].ToString();
            Obj.UserName = dr["UserName"].ToString();
            Obj.Password = dr["Password"].ToString();
            Obj.UserType = dr["UserType"].ToString();
            Obj.Point = ((dr["Point"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["Point"]);
            Obj.Phone = dr["Phone"].ToString();
            Obj.CreateBy = dr["CreateBy"].ToString();
            Obj.CreateTime = ((dr["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["CreateTime"]);
            Obj.UpdateTime = ((dr["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdateTime"]);
            Obj.IsActive = ((dr["IsActive"]) == DBNull.Value) ? (short)0 : (short)dr["IsActive"];
            Obj.Memo = dr["Memo"].ToString();

            return Obj;
        }
        #endregion

        /// <summary>
        /// 根据ID,返回一个Users对象
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Users对象</returns>
        public UsersEntity Get_UsersEntity(long id)
        {
            UsersEntity _obj = null;
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt)
            };
            _param[0].Value = id;
            string sqlStr = "select * from Users with(nolock) where Id=@Id  and isactive=1 ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_UsersEntity_FromDr(dr);
                }

                if (!dr.IsClosed)
                {
                    dr.Close();
                }
            }
            return _obj;
        }
        /// <summary>
        /// 得到数据表Users所有记录
        /// </summary>
        /// <returns>数据集</returns>
        public IList<UsersEntity> Get_UsersAll()
        {
            IList<UsersEntity> Obj = new List<UsersEntity>();
            string sqlStr = "select * from Users";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.Text, sqlStr))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_UsersEntity_FromDr(dr));
                }

                if (!dr.IsClosed)
                {
                    dr.Close();
                }
            }
            return Obj;
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
            IList<UsersEntity> list = new List<UsersEntity>();
            SqlParameter[] _param ={
                new SqlParameter("@pageIndex",SqlDbType.Int),
                new SqlParameter("@pageSize",SqlDbType.Int),
                new SqlParameter("@strWhere",SqlDbType.VarChar),
                new SqlParameter("@fldName",SqlDbType.VarChar),
                new SqlParameter("@OrderType",SqlDbType.Bit),
                new SqlParameter("@tblName",SqlDbType.VarChar),
                new SqlParameter("@strGetFields",SqlDbType.VarChar),
                new SqlParameter("@pageCount",SqlDbType.Int)
                };
            _param[0].Value = pageIndex;
            _param[1].Value = pageSize;
            _param[2].Value = where;
            _param[3].Value = orderField;
            _param[4].Value = isDesc;
            _param[5].Value = "Users";
            _param[6].Value = "*";
            _param[7].Direction = ParameterDirection.Output;

            using (IDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.StoredProcedure, "sp_OF_Page", _param))
            {
                while (dr.Read())
                {
                    UsersEntity info = Populate_UsersEntity_FromDr(dr);
                    list.Add(info);
                }

                if (!dr.IsClosed)
                {
                    dr.Close();
                }

                pageCount = Convert.ToInt32(_param[7].Value.ToString());

            }

            return list;
        }

        /// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>是/否</returns>
        public bool IsExistUsers(long id)
        {
            SqlParameter[] _param ={
                                      new SqlParameter("@id",SqlDbType.BigInt)
                                  };
            _param[0].Value = id;
            string sqlStr = "select Count(*) from Users where Id=@id";
            int a = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.Connection, CommandType.Text, sqlStr, _param));
            if (a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region----------自定义实例化接口函数----------

        /// <summary>
        /// 检查登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsAllowedLogin(UsersEntity user)
        {
            bool allowed = false;
            string str = "select count(1) from Users where UserCode=@UserCode and Password = @Password";
            SqlParameter[] para =
            {
                new SqlParameter("@UserCode",user.UserCode),
                new SqlParameter("@Password",user.Password)
            };

            var obj = SqlHelper.ExecuteScalar(SqlHelper.Connection, CommandType.Text, str, para);
            if (null == obj)
            {
                return allowed;
            }
            int result = 0;
            if (int.TryParse(obj.ToString(), out result))
            {
                if (result > 0)
                {
                    allowed = true;
                }
            }
            return allowed;
        }

        /// <summary>
        /// 获取当前分销商下线用户
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public IList<UsersEntity> GetSpecialUsers(string userCode)
        {
            string sqlstr = "SELECT * FROM dbo.Users WITH(NOLOCK) WHERE CreateBy = @CreateBy AND IsActive=1";
            SqlParameter[] paras =
            {
                new SqlParameter("@CreateBy",userCode)
            };

            var ds = SqlHelper.ExecuteDataset(SqlHelper.Connection, CommandType.Text, sqlstr, paras);

            IList<UsersEntity> users = new List<UsersEntity>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count>0)
            {
                users = DataHelper.GetEntities<UsersEntity>(ds.Tables[0]);
            }
            return users;
        }

        /// <summary>
        /// 根据Code获取用户
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public UsersEntity GetUserByCode(string code)
        {
            string sql = "SELECT * FROM dbo.Users WITH(NOLOCK) WHERE UserCode = @UserCode AND IsActive=1";
            SqlParameter[] paras =
            {
                new SqlParameter("@UserCode",code),
            };

            var ds = SqlHelper.ExecuteDataset(SqlHelper.Connection, CommandType.Text, sql, paras);
            UsersEntity user = null;
            if (null != ds && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                user = DataHelper.GetEntity<UsersEntity>(ds.Tables[0]);
            }
            return user;
        }


        /// <summary>
        /// 修改当前用户密码
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool ChangePassword(UsersEntity user, string newPassword)
        {
            string sql = "UPDATE dbo.Users SET Password= @Password , UpdateTime = GETDATE() WHERE Id = @Id";
            SqlParameter[] paras =
            {
                new SqlParameter("@Password",newPassword),
                new SqlParameter("@Id",user.Id),
            };

            var ret = SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sql, paras);
            return ret > 0;
        }

        /// <summary>
        /// 会员模糊搜索
        /// </summary>
        /// <param name="createBy"></param>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        public IList<UsersEntity> GetSearchUser(string createBy, string userinfo)
        {
            string str = "SELECT * FROM  dbo.Users WHERE CreateBy = @CreateBy AND IsActive =1 AND ((UserCode like @UserCode) OR (UserName like @UserName))";
            SqlParameter[] paras =
            {
                new SqlParameter("@CreateBy",createBy),
                new SqlParameter("@UserCode","%"+userinfo+"%"),
                new SqlParameter("@UserName","%"+userinfo+"%"),
            };

            var ds = SqlHelper.ExecuteDataset(SqlHelper.Connection, CommandType.Text, str, paras);
            IList<UsersEntity> list = new List<UsersEntity>();

            if (null != ds && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                list = DataHelper.GetEntities<UsersEntity>(ds.Tables[0]);
            }
            return list;
        }
        #endregion
    }
}
