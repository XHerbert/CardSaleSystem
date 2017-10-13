// =================================================================== 
// 项目说明
// ===================================================================
// xuhongbo @Copy Right 2017
// 文件： ActPriceDal.cs
// 项目名称：
// 创建时间：2017/9/30
// 负责人：xuhongbo
// ===================================================================
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XHB.ActPrice.Entity;
using CardSaleSystem.Utils;
using CardSaleSystem.Models.ExtModel;

namespace XHB.ActPrice.Dal
{
    /// <summary>
    /// 数据层实例化接口类 dbo.ActPrice
    /// </summary>
    public partial class ActPriceDal
    {
        #region 构造函数


        /// <summary>
        /// 
        /// </summary>
        public ActPriceDal()
        {
        }
        #endregion

        #region -----------实例化接口函数-----------

        #region 添加更新删除
        /// <summary>
        /// 向数据库中插入一条新记录。
        /// </summary>
        /// <param name="_ActPriceModel">ActPrice实体</param>
        /// <returns>新插入记录的编号</returns>
        public long Insert(ActPriceEntity _ActPriceModel)
        {
            string sqlStr = "insert into ActPrice([UserId],[ActId],[Price],[CreateTime],[UpdateTime],[IsActive]) values(@UserId,@ActId,@Price,@CreateTime,@UpdateTime,@IsActive) select @@identity";
            long res;
            SqlParameter[] _param ={
            new SqlParameter("@UserId",SqlDbType.BigInt),
            new SqlParameter("@ActId",SqlDbType.BigInt),
            new SqlParameter("@Price",SqlDbType.Float),
            new SqlParameter("@CreateTime",SqlDbType.DateTime),
            new SqlParameter("@UpdateTime",SqlDbType.DateTime),
            new SqlParameter("@IsActive",SqlDbType.Bit)
            };
            _param[0].Value = _ActPriceModel.UserId;
            _param[1].Value = _ActPriceModel.ActId;
            _param[2].Value = _ActPriceModel.Price;
            _param[3].Value = _ActPriceModel.CreateTime;
            _param[4].Value = _ActPriceModel.UpdateTime;
            _param[5].Value = _ActPriceModel.IsActive;
            res = Convert.ToInt64(SqlHelper.ExecuteScalar(SqlHelper.Connection, CommandType.Text, sqlStr, _param));
            return res;
        }


        /// <summary>
        /// 向数据表ActPrice更新一条记录。
        /// </summary>
        /// <param name="_ActPriceModel">_ActPriceModel</param>
        /// <returns>影响的行数</returns>
        public int Update(ActPriceEntity _ActPriceModel)
        {
            string sqlStr = "update ActPrice set [UserId]=@UserId,[ActId]=@ActId,[Price]=@Price,[CreateTime]=@CreateTime,[UpdateTime]=@UpdateTime,[IsActive]=@IsActive where Id=@Id";
            SqlParameter[] _param ={
                new SqlParameter("@Id",SqlDbType.BigInt),
                new SqlParameter("@UserId",SqlDbType.BigInt),
                new SqlParameter("@ActId",SqlDbType.BigInt),
                new SqlParameter("@Price",SqlDbType.Float),
                new SqlParameter("@CreateTime",SqlDbType.DateTime),
                new SqlParameter("@UpdateTime",SqlDbType.DateTime),
                new SqlParameter("@IsActive",SqlDbType.Bit)
                };
            _param[0].Value = _ActPriceModel.Id;
            _param[1].Value = _ActPriceModel.UserId;
            _param[2].Value = _ActPriceModel.ActId;
            _param[3].Value = _ActPriceModel.Price;
            _param[4].Value = _ActPriceModel.CreateTime;
            _param[5].Value = _ActPriceModel.UpdateTime;
            _param[6].Value = _ActPriceModel.IsActive;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        /// <summary>
        /// 删除数据表ActPrice中的一条记录
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>影响的行数</returns>
        public int DeleteLogical(long Id)
        {
            string sqlStr = "update ActPrice set isactive=0, updatetime=getdate() where [Id]=@Id";
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt),

            };
            _param[0].Value = Id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        /// <summary>
        /// 删除数据表ActPrice中的一条记录
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>影响的行数</returns>
        public int Delete(long Id)
        {
            string sqlStr = "delete from ActPrice where [Id]=@Id";
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt),

            };
            _param[0].Value = Id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  actprice 数据实体
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>actprice 数据实体</returns>
        public ActPriceEntity Populate_ActPriceEntity_FromDr(DataRow row)
        {
            ActPriceEntity Obj = new ActPriceEntity();
            if (row != null)
            {
                Obj.Id = ((row["Id"]) == DBNull.Value) ? 0 : (long)row["Id"];
                Obj.UserId = ((row["UserId"]) == DBNull.Value) ? 0 : (long)row["UserId"];
                Obj.ActId = ((row["ActId"]) == DBNull.Value) ? 0 : (long)row["ActId"];
                Obj.Price = ((row["Price"]) == DBNull.Value) ? 0 : Convert.ToDouble(row["Price"]);
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
        /// 得到  actprice 数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>actprice 数据实体</returns>
        public ActPriceEntity Populate_ActPriceEntity_FromDr(IDataReader dr)
        {
            ActPriceEntity Obj = new ActPriceEntity();

            Obj.Id = ((dr["Id"]) == DBNull.Value) ? 0 : (long)dr["Id"];
            Obj.UserId = ((dr["UserId"]) == DBNull.Value) ? 0 : (long)dr["UserId"];
            Obj.ActId = ((dr["ActId"]) == DBNull.Value) ? 0 : (long)dr["ActId"];
            Obj.Price = ((dr["Price"]) == DBNull.Value) ? 0 : Convert.ToDouble(dr["Price"]);
            Obj.CreateTime = ((dr["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["CreateTime"]);
            Obj.UpdateTime = ((dr["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdateTime"]);
            Obj.IsActive = ((dr["IsActive"]) == DBNull.Value) ? false : Convert.ToBoolean(dr["IsActive"]);

            return Obj;
        }
        #endregion

        /// <summary>
        /// 根据ID,返回一个ActPrice对象
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>ActPrice对象</returns>
        public ActPriceEntity Get_ActPriceEntity(long id)
        {
            ActPriceEntity _obj = null;
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt)
            };
            _param[0].Value = id;
            string sqlStr = "select * from ActPrice with(nolock) where Id=@Id  and isactive=1 ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_ActPriceEntity_FromDr(dr);
                }

                if (!dr.IsClosed)
                {
                    dr.Close();
                }
            }
            return _obj;
        }
        /// <summary>
        /// 得到数据表ActPrice所有记录
        /// </summary>
        /// <returns>数据集</returns>
        public IList<ActPriceEntity> Get_ActPriceAll()
        {
            IList<ActPriceEntity> Obj = new List<ActPriceEntity>();
            string sqlStr = "select * from ActPrice";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.Text, sqlStr))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_ActPriceEntity_FromDr(dr));
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
        public IList<ActPriceEntity> Search(out int pageCount, int pageIndex, int pageSize, string where, string orderField, bool isDesc)
        {
            IList<ActPriceEntity> list = new List<ActPriceEntity>();
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
            _param[5].Value = "ActPrice";
            _param[6].Value = "*";
            _param[7].Direction = ParameterDirection.Output;

            using (IDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.StoredProcedure, "sp_OF_Page", _param))
            {
                while (dr.Read())
                {
                    ActPriceEntity info = Populate_ActPriceEntity_FromDr(dr);
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
        public bool IsExistActPrice(long id)
        {
            SqlParameter[] _param ={
                                      new SqlParameter("@id",SqlDbType.BigInt)
                                  };
            _param[0].Value = id;
            string sqlStr = "select Count(*) from ActPrice where Id=@id";
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

        public long IsExistActPrice(long actId, bool need)
        {
            SqlParameter[] _param ={
                                      new SqlParameter("@ActId",SqlDbType.BigInt)
                                  };
            _param[0].Value = actId;
            string sqlStr = "select Id from ActPrice where ActId=@ActId";
            long  a = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.Connection, CommandType.Text, sqlStr, _param));
            return a;
        }

        public ActPriceEntity GetActPriceByActId(long actId)
        {
            string sqlStr = "select * from ActPrice where ActId=@ActId";

            SqlParameter[] _param ={
                                      new SqlParameter("@ActId",SqlDbType.BigInt)
                                  };
            _param[0].Value = actId;
            var ret = SqlHelper.ExecuteDataset(SqlHelper.Connection, CommandType.Text, sqlStr, _param);

            return DataHelper.GetEntity<ActPriceEntity>(ret.Tables[0]);
        }

        public IList<ActPriceEntityExt> GetActPriceExt(long uuid)
        {
            string sqlStr = @"select case when B.Id IS null then 0 else B.Id end as Id,
                                A.TypeCode,A.TypeName,A.Description,
                                case when B.Price IS null then A.CurPrice else B.Price end as Price,
                                A.PrePrice,A.CreateTime,A.IsActive from ActType A left join ActPrice B on B.ActId=A.Id and B.IsActive=1 and UserId = @UserId";

            SqlParameter[] _param ={
                                      new SqlParameter("@UserId",SqlDbType.BigInt)
                                  };
            _param[0].Value = uuid;
            var ret = SqlHelper.ExecuteDataset(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
            return DataHelper.GetEntities<ActPriceEntityExt>(ret.Tables[0]);
        }

        #endregion
    }
}
