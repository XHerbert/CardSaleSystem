// =================================================================== 
// 项目说明
//====================================================================
// xuhongbo @Copy Right 2017
// 文件： ExamDal.cs
// 项目名称：kaika
// 创建时间：2017/9/19
// 负责人：xuhongbo
// ===================================================================
using ExamineSystem.Models.ExamModel;
using ExamineSystem.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ExamineSystem.Dal
{
    public class ExamDal
    {
        #region 构造函数


        /// <summary>
        /// 
        /// </summary>
        public ExamDal()
        {
        }
        #endregion

        #region -----------实例化接口函数-----------

        #region 添加更新删除
        /// <summary>
        /// 向数据库中插入一条新记录。
        /// </summary>
        /// <param name="_ExamModel">Exam实体</param>
        /// <returns>新插入记录的编号</returns>
        public long Insert(ExamEntity _ExamModel)
        {
            string sqlStr = "insert into Exam([Id],[ExamTitle],[Type],[SubType],[CreateTime],[UpdateTime],[IsActive]) values(@Id,@ExamTitle,@Type,@SubType,@CreateTime,@UpdateTime,@IsActive) select @Id";
            long res;
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt),
            new SqlParameter("@ExamTitle",SqlDbType.VarChar),
            new SqlParameter("@Type",SqlDbType.SmallInt),
            new SqlParameter("@SubType",SqlDbType.SmallInt),
            new SqlParameter("@CreateTime",SqlDbType.DateTime),
            new SqlParameter("@UpdateTime",SqlDbType.DateTime),
            new SqlParameter("@IsActive",SqlDbType.SmallInt)
            };
            _param[0].Value = _ExamModel.Id;
            _param[1].Value = _ExamModel.ExamTitle;
            _param[2].Value = _ExamModel.Type;
            _param[3].Value = _ExamModel.SubType;
            _param[4].Value = _ExamModel.CreateTime;
            _param[5].Value = _ExamModel.UpdateTime;
            _param[6].Value = _ExamModel.IsActive;
            res = Convert.ToInt64(SqlHelper.ExecuteScalar(SqlHelper.Connection, CommandType.Text, sqlStr, _param));
            return res;
        }


        /// <summary>
        /// 向数据表Exam更新一条记录。
        /// </summary>
        /// <param name="_ExamModel">_ExamModel</param>
        /// <returns>影响的行数</returns>
        public int Update(ExamEntity _ExamModel)
        {
            string sqlStr = "update Exam set [ExamTitle]=@ExamTitle,[Type]=@Type,[SubType]=@SubType,[CreateTime]=@CreateTime,[UpdateTime]=@UpdateTime,[IsActive]=@IsActive where Id=@Id";
            SqlParameter[] _param ={
                new SqlParameter("@Id",SqlDbType.BigInt),
                new SqlParameter("@ExamTitle",SqlDbType.VarChar),
                new SqlParameter("@Type",SqlDbType.SmallInt),
                new SqlParameter("@SubType",SqlDbType.SmallInt),
                new SqlParameter("@CreateTime",SqlDbType.DateTime),
                new SqlParameter("@UpdateTime",SqlDbType.DateTime),
                new SqlParameter("@IsActive",SqlDbType.SmallInt)
                };
            _param[0].Value = _ExamModel.Id;
            _param[1].Value = _ExamModel.ExamTitle;
            _param[2].Value = _ExamModel.Type;
            _param[3].Value = _ExamModel.SubType;
            _param[4].Value = _ExamModel.CreateTime;
            _param[5].Value = _ExamModel.UpdateTime;
            _param[6].Value = _ExamModel.IsActive;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        /// <summary>
        /// 删除数据表Exam中的一条记录
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>影响的行数</returns>
        public int DeleteLogical(long Id)
        {
            string sqlStr = "update Exam set isactive=0, updatetime=getdate() where [Id]=@Id";
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt),

            };
            _param[0].Value = Id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        /// <summary>
        /// 删除数据表Exam中的一条记录
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>影响的行数</returns>
        public int Delete(long Id)
        {
            string sqlStr = "delete from Exam where [Id]=@Id";
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt),

            };
            _param[0].Value = Id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  exam 数据实体
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>exam 数据实体</returns>
        public ExamEntity Populate_ExamEntity_FromDr(DataRow row)
        {
            ExamEntity Obj = new ExamEntity();
            if (row != null)
            {
                Obj.Id = ((row["Id"]) == DBNull.Value) ? 0 : (long)row["Id"];
                Obj.ExamTitle = row["ExamTitle"].ToString();
                Obj.Type = ((row["Type"]) == DBNull.Value) ? (short)0 : (short)row["Type"];
                Obj.SubType = ((row["SubType"]) == DBNull.Value) ? (short)0 : (short)row["SubType"];
                Obj.CreateTime = ((row["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(row["CreateTime"]);
                Obj.UpdateTime = ((row["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(row["UpdateTime"]);
                Obj.IsActive = ((row["IsActive"]) == DBNull.Value) ? (short)0 : (short)row["IsActive"];
            }
            else
            {
                return null;
            }
            return Obj;
        }

        /// <summary>
        /// 得到  exam 数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>exam 数据实体</returns>
        public ExamEntity Populate_ExamEntity_FromDr(IDataReader dr)
        {
            ExamEntity Obj = new ExamEntity();

            Obj.Id = ((dr["Id"]) == DBNull.Value) ? 0 : (long)dr["Id"];
            Obj.ExamTitle = dr["ExamTitle"].ToString();
            Obj.Type = ((dr["Type"]) == DBNull.Value) ? (short)0 : (short)dr["Type"];
            Obj.SubType = ((dr["SubType"]) == DBNull.Value) ? (short)0 : (short)dr["SubType"];
            Obj.CreateTime = ((dr["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["CreateTime"]);
            Obj.UpdateTime = ((dr["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdateTime"]);
            Obj.IsActive = ((dr["IsActive"]) == DBNull.Value) ? (short)0 : (short)dr["IsActive"];

            return Obj;
        }
        #endregion

        /// <summary>
        /// 根据ID,返回一个Exam对象
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Exam对象</returns>
        public ExamEntity Get_ExamEntity(long id)
        {
            ExamEntity _obj = null;
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt)
            };
            _param[0].Value = id;
            string sqlStr = "select * from Exam with(nolock) where Id=@Id  and isactive=1 ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_ExamEntity_FromDr(dr);
                }

                if (!dr.IsClosed)
                {
                    dr.Close();
                }
            }
            return _obj;
        }
        /// <summary>
        /// 得到数据表Exam所有记录
        /// </summary>
        /// <returns>数据集</returns>
        public IList<ExamEntity> Get_ExamAll()
        {
            IList<ExamEntity> Obj = new List<ExamEntity>();
            string sqlStr = "select * from Exam";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.Text, sqlStr))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_ExamEntity_FromDr(dr));
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
        public IList<ExamEntity> Search(out int pageCount, int pageIndex, int pageSize, string where, string orderField, bool isDesc)
        {
            IList<ExamEntity> list = new List<ExamEntity>();
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
            _param[5].Value = "Exam";
            _param[6].Value = "*";
            _param[7].Direction = ParameterDirection.Output;

            using (IDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.StoredProcedure, "sp_OF_Page", _param))
            {
                while (dr.Read())
                {
                    ExamEntity info = Populate_ExamEntity_FromDr(dr);
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
        public bool IsExistExam(long id)
        {
            SqlParameter[] _param ={
                                      new SqlParameter("@id",SqlDbType.BigInt)
                                  };
            _param[0].Value = id;
            string sqlStr = "select Count(*) from Exam where Id=@id";
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
    }
}