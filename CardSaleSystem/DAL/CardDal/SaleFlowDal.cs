// =================================================================== 
// 项目说明
// ===================================================================
// xuhongbo @Copy Right 2017
// 文件： SaleFlowDal.cs
// 项目名称：
// 创建时间：2017/9/26
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
    /// 数据层实例化接口类 dbo.SaleFlow
    /// </summary>
    public partial class SaleFlowDal
    {
        #region 构造函数


        /// <summary>
        /// 
        /// </summary>
        public SaleFlowDal()
        {
        }
        #endregion

        #region -----------实例化接口函数-----------

        #region 添加更新删除
        /// <summary>
        /// 向数据库中插入一条新记录。
        /// </summary>
        /// <param name="_SaleFlowModel">SaleFlow实体</param>
        /// <returns>新插入记录的编号</returns>
        public long Insert(SaleFlowEntity _SaleFlowModel)
        {
            string sqlStr = "insert into SaleFlow([CardId],[CurrentUser],[AdminPrice],[ProxyPrice],[DistributionPrice],[StallsPrice],[CustomPrice],[IsApproved],[CreateTime],[UpdateTime],[Memo],[IsActive]) values(@CardId,@CurrentUser,@AdminPrice,@ProxyPrice,@DistributionPrice,@StallsPrice,@CustomPrice,@IsApproved,@CreateTime,@UpdateTime,@Memo,@IsActive) select @@identity";
            long res;
            SqlParameter[] _param ={
            new SqlParameter("@CardId",SqlDbType.BigInt),
            new SqlParameter("@CurrentUser",SqlDbType.BigInt),
            new SqlParameter("@AdminPrice",SqlDbType.Float),
            new SqlParameter("@ProxyPrice",SqlDbType.Float),
            new SqlParameter("@DistributionPrice",SqlDbType.Float),
            new SqlParameter("@StallsPrice",SqlDbType.Float),
            new SqlParameter("@CustomPrice",SqlDbType.Float),
            new SqlParameter("@IsApproved",SqlDbType.Bit),
            new SqlParameter("@CreateTime",SqlDbType.DateTime),
            new SqlParameter("@UpdateTime",SqlDbType.DateTime),
            new SqlParameter("@Memo",SqlDbType.VarChar),
            new SqlParameter("@IsActive",SqlDbType.VarChar)
            };
            _param[0].Value = _SaleFlowModel.CardId;
            _param[1].Value = _SaleFlowModel.CurrentUser;
            _param[2].Value = _SaleFlowModel.AdminPrice;
            _param[3].Value = _SaleFlowModel.ProxyPrice;
            _param[4].Value = _SaleFlowModel.DistributionPrice;
            _param[5].Value = _SaleFlowModel.StallsPrice;
            _param[6].Value = _SaleFlowModel.CustomPrice;
            _param[7].Value = _SaleFlowModel.IsApproved;
            _param[8].Value = _SaleFlowModel.CreateTime;
            _param[9].Value = _SaleFlowModel.UpdateTime;
            _param[10].Value = _SaleFlowModel.Memo;
            _param[11].Value = _SaleFlowModel.IsActive;
            res = Convert.ToInt64(SqlHelper.ExecuteScalar(SqlHelper.Connection, CommandType.Text, sqlStr, _param));
            return res;
        }


        /// <summary>
        /// 向数据表SaleFlow更新一条记录。
        /// </summary>
        /// <param name="_SaleFlowModel">_SaleFlowModel</param>
        /// <returns>影响的行数</returns>
        public int Update(SaleFlowEntity _SaleFlowModel)
        {
            string sqlStr = "update SaleFlow set [CardId]=@CardId,[CurrentUser]=@CurrentUser,[AdminPrice]=@AdminPrice,[ProxyPrice]=@ProxyPrice,[DistributionPrice]=@DistributionPrice,[StallsPrice]=@StallsPrice,[CustomPrice]=@CustomPrice,[IsApproved]=@IsApproved,[CreateTime]=@CreateTime,[UpdateTime]=@UpdateTime,[Memo]=@Memo,[IsActive]=@IsActive where Id=@Id";
            SqlParameter[] _param ={
                new SqlParameter("@Id",SqlDbType.BigInt),
                new SqlParameter("@CardId",SqlDbType.BigInt),
                new SqlParameter("@CurrentUser",SqlDbType.BigInt),
                new SqlParameter("@AdminPrice",SqlDbType.Float),
                new SqlParameter("@ProxyPrice",SqlDbType.Float),
                new SqlParameter("@DistributionPrice",SqlDbType.Float),
                new SqlParameter("@StallsPrice",SqlDbType.Float),
                new SqlParameter("@CustomPrice",SqlDbType.Float),
                new SqlParameter("@IsApproved",SqlDbType.Bit),
                new SqlParameter("@CreateTime",SqlDbType.DateTime),
                new SqlParameter("@UpdateTime",SqlDbType.DateTime),
                new SqlParameter("@Memo",SqlDbType.VarChar),
                new SqlParameter("@IsActive",SqlDbType.VarChar)
                };
            _param[0].Value = _SaleFlowModel.Id;
            _param[1].Value = _SaleFlowModel.CardId;
            _param[2].Value = _SaleFlowModel.CurrentUser;
            _param[3].Value = _SaleFlowModel.AdminPrice;
            _param[4].Value = _SaleFlowModel.ProxyPrice;
            _param[5].Value = _SaleFlowModel.DistributionPrice;
            _param[6].Value = _SaleFlowModel.StallsPrice;
            _param[7].Value = _SaleFlowModel.CustomPrice;
            _param[8].Value = _SaleFlowModel.IsApproved;
            _param[9].Value = _SaleFlowModel.CreateTime;
            _param[10].Value = _SaleFlowModel.UpdateTime;
            _param[11].Value = _SaleFlowModel.Memo;
            _param[12].Value = _SaleFlowModel.IsActive;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        /// <summary>
        /// 删除数据表SaleFlow中的一条记录
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>影响的行数</returns>
        public int DeleteLogical(long Id)
        {
            string sqlStr = "update SaleFlow set isactive=0, updatetime=getdate() where [Id]=@Id";
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt),

            };
            _param[0].Value = Id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        /// <summary>
        /// 删除数据表SaleFlow中的一条记录
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>影响的行数</returns>
        public int Delete(long Id)
        {
            string sqlStr = "delete from SaleFlow where [Id]=@Id";
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt),

            };
            _param[0].Value = Id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  saleflow 数据实体
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>saleflow 数据实体</returns>
        public SaleFlowEntity Populate_SaleFlowEntity_FromDr(DataRow row)
        {
            SaleFlowEntity Obj = new SaleFlowEntity();
            if (row != null)
            {
                Obj.Id = ((row["Id"]) == DBNull.Value) ? 0 : (long)row["Id"];
                Obj.CardId = ((row["CardId"]) == DBNull.Value) ? 0 : (long)row["CardId"];
                Obj.CurrentUser = ((row["CurrentUser"]) == DBNull.Value) ? 0 : (long)row["CurrentUser"];
                Obj.AdminPrice = ((row["AdminPrice"]) == DBNull.Value) ? 0 : Convert.ToDouble(row["AdminPrice"]);
                Obj.ProxyPrice = ((row["ProxyPrice"]) == DBNull.Value) ? 0 : Convert.ToDouble(row["ProxyPrice"]);
                Obj.DistributionPrice = ((row["DistributionPrice"]) == DBNull.Value) ? 0 : Convert.ToDouble(row["DistributionPrice"]);
                Obj.StallsPrice = ((row["StallsPrice"]) == DBNull.Value) ? 0 : Convert.ToDouble(row["StallsPrice"]);
                Obj.CustomPrice = ((row["CustomPrice"]) == DBNull.Value) ? 0 : Convert.ToDouble(row["CustomPrice"]);
                Obj.IsApproved = ((row["IsApproved"]) == DBNull.Value) ? false : Convert.ToBoolean(row["IsApproved"]);
                Obj.CreateTime = ((row["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(row["CreateTime"]);
                Obj.UpdateTime = ((row["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(row["UpdateTime"]);
                Obj.Memo = row["Memo"].ToString();
                Obj.IsActive = row["IsActive"].ToString();
            }
            else
            {
                return null;
            }
            return Obj;
        }

        /// <summary>
        /// 得到  saleflow 数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>saleflow 数据实体</returns>
        public SaleFlowEntity Populate_SaleFlowEntity_FromDr(IDataReader dr)
        {
            SaleFlowEntity Obj = new SaleFlowEntity();

            Obj.Id = ((dr["Id"]) == DBNull.Value) ? 0 : (long)dr["Id"];
            Obj.CardId = ((dr["CardId"]) == DBNull.Value) ? 0 : (long)dr["CardId"];
            Obj.CurrentUser = ((dr["CurrentUser"]) == DBNull.Value) ? 0 : (long)dr["CurrentUser"];
            Obj.AdminPrice = ((dr["AdminPrice"]) == DBNull.Value) ? 0 : Convert.ToDouble(dr["AdminPrice"]);
            Obj.ProxyPrice = ((dr["ProxyPrice"]) == DBNull.Value) ? 0 : Convert.ToDouble(dr["ProxyPrice"]);
            Obj.DistributionPrice = ((dr["DistributionPrice"]) == DBNull.Value) ? 0 : Convert.ToDouble(dr["DistributionPrice"]);
            Obj.StallsPrice = ((dr["StallsPrice"]) == DBNull.Value) ? 0 : Convert.ToDouble(dr["StallsPrice"]);
            Obj.CustomPrice = ((dr["CustomPrice"]) == DBNull.Value) ? 0 : Convert.ToDouble(dr["CustomPrice"]);
            Obj.IsApproved = ((dr["IsApproved"]) == DBNull.Value) ? false : Convert.ToBoolean(dr["IsApproved"]);
            Obj.CreateTime = ((dr["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["CreateTime"]);
            Obj.UpdateTime = ((dr["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdateTime"]);
            Obj.Memo = dr["Memo"].ToString();
            Obj.IsActive = dr["IsActive"].ToString();

            return Obj;
        }
        #endregion

        /// <summary>
        /// 根据ID,返回一个SaleFlow对象
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>SaleFlow对象</returns>
        public SaleFlowEntity Get_SaleFlowEntity(long id)
        {
            SaleFlowEntity _obj = null;
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt)
            };
            _param[0].Value = id;
            string sqlStr = "select * from SaleFlow with(nolock) where Id=@Id  and isactive=1 ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_SaleFlowEntity_FromDr(dr);
                }

                if (!dr.IsClosed)
                {
                    dr.Close();
                }
            }
            return _obj;
        }
        /// <summary>
        /// 得到数据表SaleFlow所有记录
        /// </summary>
        /// <returns>数据集</returns>
        public IList<SaleFlowEntity> Get_SaleFlowAll()
        {
            IList<SaleFlowEntity> Obj = new List<SaleFlowEntity>();
            string sqlStr = "select * from SaleFlow";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.Text, sqlStr))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_SaleFlowEntity_FromDr(dr));
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
        public IList<SaleFlowEntity> Search(out int pageCount, int pageIndex, int pageSize, string where, string orderField, bool isDesc)
        {
            IList<SaleFlowEntity> list = new List<SaleFlowEntity>();
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
            _param[5].Value = "SaleFlow";
            _param[6].Value = "*";
            _param[7].Direction = ParameterDirection.Output;

            using (IDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.StoredProcedure, "sp_OF_Page", _param))
            {
                while (dr.Read())
                {
                    SaleFlowEntity info = Populate_SaleFlowEntity_FromDr(dr);
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
        public bool IsExistSaleFlow(long id)
        {
            SqlParameter[] _param ={
                                      new SqlParameter("@id",SqlDbType.BigInt)
                                  };
            _param[0].Value = id;
            string sqlStr = "select Count(*) from SaleFlow where Id=@id";
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
        #endregion
    }
}
