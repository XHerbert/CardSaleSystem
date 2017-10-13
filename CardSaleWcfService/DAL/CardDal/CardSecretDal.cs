// =================================================================== 
// 项目说明
// ===================================================================
// xuhongbo @Copy Right 2017
// 文件： CardSecretDal.cs
// 项目名称：kaika
// 创建时间：2017/9/22
// 负责人：xuhongbo
// ===================================================================
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XHB.Card.Entity;
using CardSaleSystem.Utils;
using System.Text;

namespace XHB.Card.Dal
{
    /// <summary>
    /// 数据层实例化接口类 dbo.CardSecret
    /// </summary>
    public partial class CardSecretDal
    {
        #region 构造函数


        /// <summary>
        /// 
        /// </summary>
        public CardSecretDal()
        {
        }
        #endregion

        #region -----------实例化接口函数-----------

        #region 添加更新删除
        /// <summary>
        /// 向数据库中插入一条新记录。
        /// </summary>
        /// <param name="_CardSecretModel">CardSecret实体</param>
        /// <returns>新插入记录的编号</returns>
        public long Insert(CardSecretEntity _CardSecretModel)
        {
            string sqlStr = "insert into CardSecret([CardId],[ActId],[CardSecret],[IsUsed],[UsedBy],[SaleStatus],[Memo],[CreateTime],[UpdatTime],[IsActive]) values(@CardId,@ActId,@CardSecret,@IsUsed,@UsedBy,@SaleStatus,@Memo,@CreateTime,@UpdatTime,@IsActive) select @@identity";
            long res;
            SqlParameter[] _param ={
            new SqlParameter("@CardId",SqlDbType.VarChar),
            new SqlParameter("@ActId",SqlDbType.BigInt),
            new SqlParameter("@CardSecret",SqlDbType.VarChar),
            new SqlParameter("@IsUsed",SqlDbType.Bit),
            new SqlParameter("@UsedBy",SqlDbType.VarChar),
            new SqlParameter("@SaleStatus",SqlDbType.SmallInt),
            new SqlParameter("@Memo",SqlDbType.VarChar),
            new SqlParameter("@CreateTime",SqlDbType.DateTime),
            new SqlParameter("@UpdatTime",SqlDbType.DateTime),
            new SqlParameter("@IsActive",SqlDbType.Bit)
            };
            _param[0].Value = _CardSecretModel.CardId;
            _param[1].Value = _CardSecretModel.ActId;
            _param[2].Value = _CardSecretModel.CardSecret;
            _param[3].Value = _CardSecretModel.IsUsed;
            _param[4].Value = _CardSecretModel.UsedBy;
            _param[5].Value = _CardSecretModel.SaleStatus;
            _param[6].Value = _CardSecretModel.Memo;
            _param[7].Value = _CardSecretModel.CreateTime;
            _param[8].Value = _CardSecretModel.UpdatTime;
            _param[9].Value = _CardSecretModel.IsActive;
            res = Convert.ToInt64(SqlHelper.ExecuteScalar(SqlHelper.Connection, CommandType.Text, sqlStr, _param));
            return res;
        }


        /// <summary>
        /// 向数据表CardSecret更新一条记录。
        /// </summary>
        /// <param name="_CardSecretModel">_CardSecretModel</param>
        /// <returns>影响的行数</returns>
        public int Update(CardSecretEntity _CardSecretModel)
        {
            string sqlStr = "update CardSecret set [CardId]=@CardId,[ActId]=@ActId,[CardSecret]=@CardSecret,[IsUsed]=@IsUsed,[UsedBy]=@UsedBy,[SaleStatus]=@SaleStatus,[Memo]=@Memo,[CreateTime]=@CreateTime,[UpdatTime]=@UpdatTime,[IsActive]=@IsActive where Id=@Id";
            SqlParameter[] _param ={
                new SqlParameter("@Id",SqlDbType.BigInt),
                new SqlParameter("@CardId",SqlDbType.VarChar),
                new SqlParameter("@ActId",SqlDbType.BigInt),
                new SqlParameter("@CardSecret",SqlDbType.VarChar),
                new SqlParameter("@IsUsed",SqlDbType.Bit),
                new SqlParameter("@UsedBy",SqlDbType.VarChar),
                new SqlParameter("@SaleStatus",SqlDbType.SmallInt),
                new SqlParameter("@Memo",SqlDbType.VarChar),
                new SqlParameter("@CreateTime",SqlDbType.DateTime),
                new SqlParameter("@UpdatTime",SqlDbType.DateTime),
                new SqlParameter("@IsActive",SqlDbType.Bit)
                };
            _param[0].Value = _CardSecretModel.Id;
            _param[1].Value = _CardSecretModel.CardId;
            _param[2].Value = _CardSecretModel.ActId;
            _param[3].Value = _CardSecretModel.CardSecret;
            _param[4].Value = _CardSecretModel.IsUsed;
            _param[5].Value = _CardSecretModel.UsedBy;
            _param[6].Value = _CardSecretModel.SaleStatus;
            _param[7].Value = _CardSecretModel.Memo;
            _param[8].Value = _CardSecretModel.CreateTime;
            _param[9].Value = _CardSecretModel.UpdatTime;
            _param[10].Value = _CardSecretModel.IsActive;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        /// <summary>
        /// 删除数据表CardSecret中的一条记录
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>影响的行数</returns>
        public int DeleteLogical(long Id)
        {
            string sqlStr = "update CardSecret set isactive=0, updatetime=getdate() where [Id]=@Id";
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt),

            };
            _param[0].Value = Id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        /// <summary>
        /// 删除数据表CardSecret中的一条记录
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>影响的行数</returns>
        public int Delete(long Id)
        {
            string sqlStr = "delete from CardSecret where [Id]=@Id";
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt),

            };
            _param[0].Value = Id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  cardsecret 数据实体
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>cardsecret 数据实体</returns>
        public CardSecretEntity Populate_CardSecretEntity_FromDr(DataRow row)
        {
            CardSecretEntity Obj = new CardSecretEntity();
            if (row != null)
            {
                Obj.Id = ((row["Id"]) == DBNull.Value) ? 0 : (long)row["Id"];
                Obj.CardId = row["CardId"].ToString();
                Obj.ActId = ((row["ActId"]) == DBNull.Value) ? 0 : (long)row["ActId"];
                Obj.CardSecret = row["CardSecret"].ToString();
                Obj.IsUsed = ((row["IsUsed"]) == DBNull.Value) ? false : Convert.ToBoolean(row["IsUsed"]);
                Obj.UsedBy = row["UsedBy"].ToString();
                Obj.SaleStatus = ((row["SaleStatus"]) == DBNull.Value) ? (short)0 : (short)row["SaleStatus"];
                Obj.Memo = row["Memo"].ToString();
                Obj.CreateTime = ((row["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(row["CreateTime"]);
                Obj.UpdatTime = ((row["UpdatTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(row["UpdatTime"]);
                Obj.IsActive = ((row["IsActive"]) == DBNull.Value) ? false : Convert.ToBoolean(row["IsActive"]);
            }
            else
            {
                return null;
            }
            return Obj;
        }

        /// <summary>
        /// 得到  cardsecret 数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>cardsecret 数据实体</returns>
        public CardSecretEntity Populate_CardSecretEntity_FromDr(IDataReader dr)
        {
            CardSecretEntity Obj = new CardSecretEntity();

            Obj.Id = ((dr["Id"]) == DBNull.Value) ? 0 : (long)dr["Id"];
            Obj.CardId = dr["CardId"].ToString();
            Obj.ActId = ((dr["ActId"]) == DBNull.Value) ? 0 : (long)dr["ActId"];
            Obj.CardSecret = dr["CardSecret"].ToString();
            Obj.IsUsed = ((dr["IsUsed"]) == DBNull.Value) ? false : Convert.ToBoolean(dr["IsUsed"]);
            Obj.UsedBy = dr["UsedBy"].ToString();
            Obj.SaleStatus = ((dr["SaleStatus"]) == DBNull.Value) ? (short)0 : (short)dr["SaleStatus"];
            Obj.Memo = dr["Memo"].ToString();
            Obj.CreateTime = ((dr["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["CreateTime"]);
            Obj.UpdatTime = ((dr["UpdatTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdatTime"]);
            Obj.IsActive = ((dr["IsActive"]) == DBNull.Value) ? false : Convert.ToBoolean(dr["IsActive"]);

            return Obj;
        }
        #endregion

        /// <summary>
        /// 根据ID,返回一个CardSecret对象
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>CardSecret对象</returns>
        public CardSecretEntity Get_CardSecretEntity(long id)
        {
            CardSecretEntity _obj = null;
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt)
            };
            _param[0].Value = id;
            string sqlStr = "select * from CardSecret with(nolock) where Id=@Id  and isactive=1 ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_CardSecretEntity_FromDr(dr);
                }

                if (!dr.IsClosed)
                {
                    dr.Close();
                }
            }
            return _obj;
        }
        /// <summary>
        /// 得到数据表CardSecret所有记录
        /// </summary>
        /// <returns>数据集</returns>
        public IList<CardSecretEntity> Get_CardSecretAll()
        {
            IList<CardSecretEntity> Obj = new List<CardSecretEntity>();
            string sqlStr = "select * from CardSecret";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.Text, sqlStr))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_CardSecretEntity_FromDr(dr));
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
        public IList<CardSecretEntity> Search(out int pageCount, int pageIndex, int pageSize, string where, string orderField, bool isDesc)
        {
            IList<CardSecretEntity> list = new List<CardSecretEntity>();
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
            _param[5].Value = "CardSecret";
            _param[6].Value = "*";
            _param[7].Direction = ParameterDirection.Output;

            using (IDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.StoredProcedure, "sp_OF_Page", _param))
            {
                while (dr.Read())
                {
                    CardSecretEntity info = Populate_CardSecretEntity_FromDr(dr);
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
        public bool IsExistCardSecret(long id)
        {
            SqlParameter[] _param ={
                                      new SqlParameter("@id",SqlDbType.BigInt)
                                  };
            _param[0].Value = id;
            string sqlStr = "select Count(*) from CardSecret where Id=@id";
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

        public IList<CardSecretEntity> GetGetCardSecretListByUser(string userCode)
        {
            string sql = " SELECT * FROM dbo.CardSecret WITH(NOLOCK) WHERE UsedBy = @UsedBy AND IsActive = 1";
            SqlParameter[] para =
            {
                new SqlParameter("@UsedBy",userCode)
            };

            var ds = SqlHelper.ExecuteDataset(SqlHelper.Connection, CommandType.Text, sql, para);

            IList<CardSecretEntity> list = new List<CardSecretEntity>();

            if(null != ds && ds.Tables.Count >0 && ds.Tables[0].Rows.Count > 0)
            {
                list = DataHelper.GetEntities<CardSecretEntity>(ds.Tables[0]);
            }

            return list;
        }

        /// <summary>
        /// 买家购买卡密
        /// </summary>
        /// <param name="buyerCode"></param>
        /// <param name="sellerCode"></param>
        /// <param name="saleStatus"></param>
        /// <param name="topLine"></param>
        /// <returns></returns>
        public bool BuyCard(string buyerCode , long buyerId ,long sellerId, long cardId, short saleStatus ,int count )
        {
            //StringBuilder builder = new StringBuilder();
            //builder.Append(" UPDATE dbo.CardSecret SET UsedBy = @UsedBy, ");
            //builder.Append(" SaleStatus=@SaleStatus,UpdatTime = GETDATE()  WHERE CardId IN ");
            //builder.Append(" (SELECT TOP @N CardId FROM dbo.CardSecret ORDER BY Id ASC)  ");
            //builder.Append(" UPDATE dbo.Users SET Point = Point + @Point , UpdateTime = GETDATE() WHERE Id=@Id ");
            //builder.Append(" UPDATE dbo.Users SET Point = Point - @Point , UpdateTime = GETDATE() WHERE Id=@Id ");

            SqlParameter[] paras =
            {
                new SqlParameter("@Buyer",buyerId),
                new SqlParameter("@Seller",sellerId),
                new SqlParameter("@ActId",cardId),
                new SqlParameter("@UsedBy",buyerCode),
                new SqlParameter("@SaleStatus",saleStatus),
                new SqlParameter("@Top" ,count)
            };

            var ret = SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.StoredProcedure, "P_CardTransfer", paras);

            return ret > 0 ;
        }


        public bool InputPoint(string cid , string pd ,string ucode)
        {
            string str = "InputPoint";

            SqlParameter[] para =
            {
                new SqlParameter("@UsedBy",ucode),
                new SqlParameter("@CardId",cid),
                new SqlParameter("@CardSecret",pd)
            };

            int ret = SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.StoredProcedure, str, para);
            return ret > 0;
        }

        //查询可用卡密
        public IList<CardSecretEntity> GetUsedCard(string code, bool used)
        {
            string str = "SELECT * FROM  dbo.CardSecret WHERE UsedBy = @UsedBy AND IsActive =1 AND IsUsed = @IsUsed";
            SqlParameter[] paras =
            {
                new SqlParameter("@UsedBy",code),
                new SqlParameter("@IsUsed",used),
            };

            var ds = SqlHelper.ExecuteDataset(SqlHelper.Connection, CommandType.Text, str, paras);
            IList<CardSecretEntity> list = new List<CardSecretEntity>();

            if (null != ds && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                list = DataHelper.GetEntities<CardSecretEntity>(ds.Tables[0]);
            }
            return list;
        }


        //查询单个卡密
        public IList<CardSecretEntity> GetSpecialCard(string usedBy, string cardId)
        {
            string str = "SELECT * FROM  dbo.CardSecret WHERE UsedBy = @UsedBy AND IsActive =1 AND ((CardId like @CardId) OR (CardSecret like @CardSecret))";
            SqlParameter[] paras =
            {
                new SqlParameter("@UsedBy",usedBy),
                new SqlParameter("@CardId","%"+cardId+"%"),
                new SqlParameter("@CardSecret","%"+cardId+"%"),
            };

            var ds = SqlHelper.ExecuteDataset(SqlHelper.Connection, CommandType.Text, str, paras);
            IList<CardSecretEntity> list = new List<CardSecretEntity>();

            if (null != ds && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                list = DataHelper.GetEntities<CardSecretEntity>(ds.Tables[0]);
            }
            return list;
        }

        #endregion
    }
}
