// =================================================================== 
// 项目说明
// ===================================================================
// xuhongbo @Copy Right 2017
// 文件： ActTypeDal.cs
// 项目名称：
// 创建时间：2017/9/24
// 负责人：xuhongbo
// ===================================================================
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XHB.Card.Entity;
using CardSaleSystem.Utils;

namespace XHB.Card.Dal
{
    /// <summary>
    /// 数据层实例化接口类 dbo.ActType
    /// </summary>
    public partial class ActTypeDal
    {
        #region 构造函数


        /// <summary>
        /// 
        /// </summary>
        public ActTypeDal()
        {
        }
        #endregion

        #region -----------实例化接口函数-----------

        #region 添加更新删除
        /// <summary>
        /// 向数据库中插入一条新记录。
        /// </summary>
        /// <param name="_ActTypeModel">ActType实体</param>
        /// <returns>新插入记录的编号</returns>
        public long Insert(ActTypeEntity _ActTypeModel)
        {
            string sqlStr = "insert into ActType([TypeCode],[TypeName],[CurPrice],[PrePrice],[Description],[CreateTime],[UpdateTime],[IsActive]) values(@TypeCode,@TypeName,@CurPrice,@PrePrice,@Description,@CreateTime,@UpdateTime,@IsActive) select @@identity";
            long res;
            SqlParameter[] _param ={
            new SqlParameter("@TypeCode",SqlDbType.VarChar),
            new SqlParameter("@TypeName",SqlDbType.VarChar),
            new SqlParameter("@CurPrice",SqlDbType.Float),
            new SqlParameter("@PrePrice",SqlDbType.Float),
            new SqlParameter("@Description",SqlDbType.VarChar),
            new SqlParameter("@CreateTime",SqlDbType.DateTime),
            new SqlParameter("@UpdateTime",SqlDbType.DateTime),
            new SqlParameter("@IsActive",SqlDbType.Bit)
            };
            _param[0].Value = _ActTypeModel.TypeCode;
            _param[1].Value = _ActTypeModel.TypeName;
            _param[2].Value = _ActTypeModel.CurPrice;
            _param[3].Value = _ActTypeModel.PrePrice;
            _param[4].Value = _ActTypeModel.Description;
            _param[5].Value = _ActTypeModel.CreateTime;
            _param[6].Value = _ActTypeModel.UpdateTime;
            _param[7].Value = _ActTypeModel.IsActive;
            res = Convert.ToInt64(SqlHelper.ExecuteScalar(SqlHelper.Connection, CommandType.Text, sqlStr, _param));
            return res;
        }


        /// <summary>
        /// 向数据表ActType更新一条记录。
        /// </summary>
        /// <param name="_ActTypeModel">_ActTypeModel</param>
        /// <returns>影响的行数</returns>
        public int Update(ActTypeEntity _ActTypeModel)
        {
            string sqlStr = "update ActType set [TypeCode]=@TypeCode,[TypeName]=@TypeName,[CurPrice]=@CurPrice,[PrePrice]=@PrePrice,[Description]=@Description,[CreateTime]=@CreateTime,[UpdateTime]=@UpdateTime,[IsActive]=@IsActive where Id=@Id";
            SqlParameter[] _param ={
                new SqlParameter("@Id",SqlDbType.BigInt),
                new SqlParameter("@TypeCode",SqlDbType.VarChar),
                new SqlParameter("@TypeName",SqlDbType.VarChar),
                new SqlParameter("@CurPrice",SqlDbType.Float),
                new SqlParameter("@PrePrice",SqlDbType.Float),
                new SqlParameter("@Description",SqlDbType.VarChar),
                new SqlParameter("@CreateTime",SqlDbType.DateTime),
                new SqlParameter("@UpdateTime",SqlDbType.DateTime),
                new SqlParameter("@IsActive",SqlDbType.Bit)
                };
            _param[0].Value = _ActTypeModel.Id;
            _param[1].Value = _ActTypeModel.TypeCode;
            _param[2].Value = _ActTypeModel.TypeName;
            _param[3].Value = _ActTypeModel.CurPrice;
            _param[4].Value = _ActTypeModel.PrePrice;
            _param[5].Value = _ActTypeModel.Description;
            _param[6].Value = _ActTypeModel.CreateTime;
            _param[7].Value = _ActTypeModel.UpdateTime;
            _param[8].Value = _ActTypeModel.IsActive;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        /// <summary>
        /// 删除数据表ActType中的一条记录
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>影响的行数</returns>
        public int DeleteLogical(long Id)
        {
            string sqlStr = "update ActType set isactive=0, updatetime=getdate() where [Id]=@Id";
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt),

            };
            _param[0].Value = Id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        /// <summary>
        /// 删除数据表ActType中的一条记录
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>影响的行数</returns>
        public int Delete(long Id)
        {
            string sqlStr = "delete from ActType where [Id]=@Id";
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt),

            };
            _param[0].Value = Id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  acttype 数据实体
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>acttype 数据实体</returns>
        public ActTypeEntity Populate_ActTypeEntity_FromDr(DataRow row)
        {
            ActTypeEntity Obj = new ActTypeEntity();
            if (row != null)
            {
                Obj.Id = ((row["Id"]) == DBNull.Value) ? 0 : (long)row["Id"];
                Obj.TypeCode = row["TypeCode"].ToString();
                Obj.TypeName = row["TypeName"].ToString();
                Obj.CurPrice = ((row["CurPrice"]) == DBNull.Value) ? 0 : Convert.ToDouble(row["CurPrice"]);
                Obj.PrePrice = ((row["PrePrice"]) == DBNull.Value) ? 0 : Convert.ToDouble(row["PrePrice"]);
                Obj.Description = row["Description"].ToString();
                Obj.CreateTime = ((row["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(row["CreateTime"]);
                Obj.UpdateTime = ((row["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(row["UpdateTime"]);
                Obj.IsActive = ((row["IsActive"]) == DBNull.Value) ? false : Convert.ToBoolean(row["IsActive"]);
            }
            else
            {
                return null;
            }
            return Obj;
        }

        /// <summary>
        /// 得到  acttype 数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>acttype 数据实体</returns>
        public ActTypeEntity Populate_ActTypeEntity_FromDr(IDataReader dr)
        {
            ActTypeEntity Obj = new ActTypeEntity();

            Obj.Id = ((dr["Id"]) == DBNull.Value) ? 0 : (long)dr["Id"];
            Obj.TypeCode = dr["TypeCode"].ToString();
            Obj.TypeName = dr["TypeName"].ToString();
            Obj.CurPrice = ((dr["CurPrice"]) == DBNull.Value) ? 0 : Convert.ToDouble(dr["CurPrice"]);
            Obj.PrePrice = ((dr["PrePrice"]) == DBNull.Value) ? 0 : Convert.ToDouble(dr["PrePrice"]);
            Obj.Description = dr["Description"].ToString();
            Obj.CreateTime = ((dr["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["CreateTime"]);
            Obj.UpdateTime = ((dr["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdateTime"]);
            Obj.IsActive = ((dr["IsActive"]) == DBNull.Value) ? false : Convert.ToBoolean(dr["IsActive"]);

            return Obj;
        }
        #endregion

        /// <summary>
        /// 根据ID,返回一个ActType对象
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>ActType对象</returns>
        public ActTypeEntity Get_ActTypeEntity(long id)
        {
            ActTypeEntity _obj = null;
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt)
            };
            _param[0].Value = id;
            string sqlStr = "select * from ActType with(nolock) where Id=@Id  and isactive=1 ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_ActTypeEntity_FromDr(dr);
                }

                if (!dr.IsClosed)
                {
                    dr.Close();
                }
            }
            return _obj;
        }
        /// <summary>
        /// 得到数据表ActType所有记录
        /// </summary>
        /// <returns>数据集</returns>
        public IList<ActTypeEntity> Get_ActTypeAll()
        {
            IList<ActTypeEntity> Obj = new List<ActTypeEntity>();
            string sqlStr = "select * from ActType";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.Text, sqlStr))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_ActTypeEntity_FromDr(dr));
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
        public IList<ActTypeEntity> Search(out int pageCount, int pageIndex, int pageSize, string where, string orderField, bool isDesc)
        {
            IList<ActTypeEntity> list = new List<ActTypeEntity>();
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
            _param[5].Value = "ActType";
            _param[6].Value = "*";
            _param[7].Direction = ParameterDirection.Output;

            using (IDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.StoredProcedure, "sp_OF_Page", _param))
            {
                while (dr.Read())
                {
                    ActTypeEntity info = Populate_ActTypeEntity_FromDr(dr);
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
        public bool IsExistActType(long id)
        {
            SqlParameter[] _param ={
                                      new SqlParameter("@id",SqlDbType.BigInt)
                                  };
            _param[0].Value = id;
            string sqlStr = "select Count(*) from ActType where Id=@id";
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
        /// 定价
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public bool UpdateActPrice(long Id , double price)
        {
            string sql = "  UPDATE  dbo.ActType SET CurPrice = @CurPrice WHERE Id = @Id";

            SqlParameter[] para =
            {
                new SqlParameter("@CurPrice" , price),
                new SqlParameter("@Id" , Id)
            };

            var ret = SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sql, para);
            return ret > 0;
        }

        public IList<ActTypeEntity> Get_ActType()
        {
            IList<ActTypeEntity> Obj = new List<ActTypeEntity>();
            string sqlStr = "select * from ActType where IsActive =1";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.Text, sqlStr))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_ActTypeEntity_FromDr(dr));
                }

                if (!dr.IsClosed)
                {
                    dr.Close();
                }
            }
            return Obj;
        }

        #endregion
    }
}
