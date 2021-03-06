﻿// =================================================================== 
// 项目说明
// ===================================================================
// xuhongbo @Copy Right 2017
// 文件： PackTypeDal.cs
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
    /// 数据层实例化接口类 dbo.PackType
    /// </summary>
    public partial class PackTypeDal
    {
        #region 构造函数


        /// <summary>
        /// 
        /// </summary>
        public PackTypeDal()
        {
        }
        #endregion

        #region -----------实例化接口函数-----------

        #region 添加更新删除
        /// <summary>
        /// 向数据库中插入一条新记录。
        /// </summary>
        /// <param name="_PackTypeModel">PackType实体</param>
        /// <returns>新插入记录的编号</returns>
        public long Insert(PackTypeEntity _PackTypeModel)
        {
            string sqlStr = "insert into PackType([PackCode],[PackName],[ActId],[Price],[Description],[CreateTime],[UpdateTime],[IsActive]) values(@PackCode,@PackName,@ActId,@Price,@Description,@CreateTime,@UpdateTime,@IsActive) select @@identity";
            long res;
            SqlParameter[] _param ={
            new SqlParameter("@PackCode",SqlDbType.VarChar),
            new SqlParameter("@PackName",SqlDbType.VarChar),
            new SqlParameter("@ActId",SqlDbType.BigInt),
            new SqlParameter("@Price",SqlDbType.Float),
            new SqlParameter("@Description",SqlDbType.VarChar),
            new SqlParameter("@CreateTime",SqlDbType.DateTime),
            new SqlParameter("@UpdateTime",SqlDbType.DateTime),
            new SqlParameter("@IsActive",SqlDbType.Bit)
            };
            _param[0].Value = _PackTypeModel.PackCode;
            _param[1].Value = _PackTypeModel.PackName;
            _param[2].Value = _PackTypeModel.ActId;
            _param[3].Value = _PackTypeModel.Price;
            _param[4].Value = _PackTypeModel.Description;
            _param[5].Value = _PackTypeModel.CreateTime;
            _param[6].Value = _PackTypeModel.UpdateTime;
            _param[7].Value = _PackTypeModel.IsActive;
            res = Convert.ToInt64(SqlHelper.ExecuteScalar(SqlHelper.Connection, CommandType.Text, sqlStr, _param));
            return res;
        }


        /// <summary>
        /// 向数据表PackType更新一条记录。
        /// </summary>
        /// <param name="_PackTypeModel">_PackTypeModel</param>
        /// <returns>影响的行数</returns>
        public int Update(PackTypeEntity _PackTypeModel)
        {
            string sqlStr = "update PackType set [PackCode]=@PackCode,[PackName]=@PackName,[ActId]=@ActId,[Price]=@Price,[Description]=@Description,[CreateTime]=@CreateTime,[UpdateTime]=@UpdateTime,[IsActive]=@IsActive where Id=@Id";
            SqlParameter[] _param ={
                new SqlParameter("@Id",SqlDbType.BigInt),
                new SqlParameter("@PackCode",SqlDbType.VarChar),
                new SqlParameter("@PackName",SqlDbType.VarChar),
                new SqlParameter("@ActId",SqlDbType.BigInt),
                new SqlParameter("@Price",SqlDbType.Float),
                new SqlParameter("@Description",SqlDbType.VarChar),
                new SqlParameter("@CreateTime",SqlDbType.DateTime),
                new SqlParameter("@UpdateTime",SqlDbType.DateTime),
                new SqlParameter("@IsActive",SqlDbType.Bit)
                };
            _param[0].Value = _PackTypeModel.Id;
            _param[1].Value = _PackTypeModel.PackCode;
            _param[2].Value = _PackTypeModel.PackName;
            _param[3].Value = _PackTypeModel.ActId;
            _param[4].Value = _PackTypeModel.Price;
            _param[5].Value = _PackTypeModel.Description;
            _param[6].Value = _PackTypeModel.CreateTime;
            _param[7].Value = _PackTypeModel.UpdateTime;
            _param[8].Value = _PackTypeModel.IsActive;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        /// <summary>
        /// 删除数据表PackType中的一条记录
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>影响的行数</returns>
        public int DeleteLogical(long Id)
        {
            string sqlStr = "update PackType set isactive=0, updatetime=getdate() where [Id]=@Id";
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt),

            };
            _param[0].Value = Id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        /// <summary>
        /// 删除数据表PackType中的一条记录
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>影响的行数</returns>
        public int Delete(long Id)
        {
            string sqlStr = "delete from PackType where [Id]=@Id";
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt),

            };
            _param[0].Value = Id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  packtype 数据实体
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>packtype 数据实体</returns>
        public PackTypeEntity Populate_PackTypeEntity_FromDr(DataRow row)
        {
            PackTypeEntity Obj = new PackTypeEntity();
            if (row != null)
            {
                Obj.Id = ((row["Id"]) == DBNull.Value) ? 0 : (long)row["Id"];
                Obj.PackCode = row["PackCode"].ToString();
                Obj.PackName = row["PackName"].ToString();
                Obj.ActId = ((row["ActId"]) == DBNull.Value) ? 0 : (long)row["ActId"];
                Obj.Price = ((row["Price"]) == DBNull.Value) ? 0 : Convert.ToDouble(row["Price"]);
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
        /// 得到  packtype 数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>packtype 数据实体</returns>
        public PackTypeEntity Populate_PackTypeEntity_FromDr(IDataReader dr)
        {
            PackTypeEntity Obj = new PackTypeEntity();

            Obj.Id = ((dr["Id"]) == DBNull.Value) ? 0 : (long)dr["Id"];
            Obj.PackCode = dr["PackCode"].ToString();
            Obj.PackName = dr["PackName"].ToString();
            Obj.ActId = ((dr["ActId"]) == DBNull.Value) ? 0 : (long)dr["ActId"];
            Obj.Price = ((dr["Price"]) == DBNull.Value) ? 0 : Convert.ToDouble(dr["Price"]);
            Obj.Description = dr["Description"].ToString();
            Obj.CreateTime = ((dr["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["CreateTime"]);
            Obj.UpdateTime = ((dr["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdateTime"]);
            Obj.IsActive = ((dr["IsActive"]) == DBNull.Value) ? false : Convert.ToBoolean(dr["IsActive"]);

            return Obj;
        }
        #endregion

        /// <summary>
        /// 根据ID,返回一个PackType对象
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>PackType对象</returns>
        public PackTypeEntity Get_PackTypeEntity(long id)
        {
            PackTypeEntity _obj = null;
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt)
            };
            _param[0].Value = id;
            string sqlStr = "select * from PackType with(nolock) where Id=@Id  and isactive=1 ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_PackTypeEntity_FromDr(dr);
                }

                if (!dr.IsClosed)
                {
                    dr.Close();
                }
            }
            return _obj;
        }
        /// <summary>
        /// 得到数据表PackType所有记录
        /// </summary>
        /// <returns>数据集</returns>
        public IList<PackTypeEntity> Get_PackTypeAll()
        {
            IList<PackTypeEntity> Obj = new List<PackTypeEntity>();
            string sqlStr = "select * from PackType";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.Text, sqlStr))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_PackTypeEntity_FromDr(dr));
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
        public IList<PackTypeEntity> Search(out int pageCount, int pageIndex, int pageSize, string where, string orderField, bool isDesc)
        {
            IList<PackTypeEntity> list = new List<PackTypeEntity>();
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
            _param[5].Value = "PackType";
            _param[6].Value = "*";
            _param[7].Direction = ParameterDirection.Output;

            using (IDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.StoredProcedure, "sp_OF_Page", _param))
            {
                while (dr.Read())
                {
                    PackTypeEntity info = Populate_PackTypeEntity_FromDr(dr);
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
        public bool IsExistPackType(long id)
        {
            SqlParameter[] _param ={
                                      new SqlParameter("@id",SqlDbType.BigInt)
                                  };
            _param[0].Value = id;
            string sqlStr = "select Count(*) from PackType where Id=@id";
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
