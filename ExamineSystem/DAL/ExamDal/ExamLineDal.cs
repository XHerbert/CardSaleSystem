// =================================================================== 
// 项目说明
// ====================================================================
// xuhongbo @Copy Right 2017
// 文件： ExamLineDal.cs
// 项目名称：答题系统
// 创建时间：2017/9/20
// 负责人：xuhongbo
// ===================================================================
using ExamineSystem.Models.ExamModel;
using ExamineSystem.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace ExamineSystem.Dal
{
    /// <summary>
    /// 数据层实例化接口类 dbo.ExamLine
    /// </summary>
    public partial class ExamLineDal
    {
        #region 构造函数


        /// <summary>
        /// 
        /// </summary>
        public ExamLineDal()
        {
        }
        #endregion

        #region -----------实例化接口函数-----------

        #region 添加更新删除
        /// <summary>
        /// 向数据库中插入一条新记录。
        /// </summary>
        /// <param name="_ExamLineModel">ExamLine实体</param>
        /// <returns>新插入记录的编号</returns>
        public long Insert(ExamLineEntity _ExamLineModel)
        {
            string sqlStr = "insert into ExamLine([Id],[ExamId],[ExamContent],[OptionA],[OptionB],[OptionC],[OptionD],[Answer],[SelectedOption],[SubType],[CreateTime],[UpdateTime],[IsActive]) values(@Id,@ExamId,@ExamContent,@OptionA,@OptionB,@OptionC,@OptionD,@Answer,@SelectedOption,@SubType,@CreateTime,@UpdateTime,@IsActive) select @Id";
            long res;
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt),
            new SqlParameter("@ExamId",SqlDbType.BigInt),
            new SqlParameter("@ExamContent",SqlDbType.VarChar),
            new SqlParameter("@OptionA",SqlDbType.VarChar),
            new SqlParameter("@OptionB",SqlDbType.VarChar),
            new SqlParameter("@OptionC",SqlDbType.VarChar),
            new SqlParameter("@OptionD",SqlDbType.VarChar),
            new SqlParameter("@Answer",SqlDbType.VarChar),
            new SqlParameter("@SelectedOption",SqlDbType.VarChar),
            new SqlParameter("@SubType",SqlDbType.SmallInt),
            new SqlParameter("@CreateTime",SqlDbType.DateTime),
            new SqlParameter("@UpdateTime",SqlDbType.DateTime),
            new SqlParameter("@IsActive",SqlDbType.SmallInt)
            };
            _param[0].Value = _ExamLineModel.Id;
            _param[1].Value = _ExamLineModel.ExamId;
            _param[2].Value = _ExamLineModel.ExamContent;
            _param[3].Value = _ExamLineModel.OptionA;
            _param[4].Value = _ExamLineModel.OptionB;
            _param[5].Value = _ExamLineModel.OptionC;
            _param[6].Value = _ExamLineModel.OptionD;
            _param[7].Value = _ExamLineModel.Answer;
            _param[8].Value = _ExamLineModel.SelectedOption;
            _param[9].Value = _ExamLineModel.SubType;
            _param[10].Value = _ExamLineModel.CreateTime;
            _param[11].Value = _ExamLineModel.UpdateTime;
            _param[12].Value = _ExamLineModel.IsActive;
            res = Convert.ToInt64(SqlHelper.ExecuteScalar(SqlHelper.Connection, CommandType.Text, sqlStr, _param));
            return res;
        }


        /// <summary>
        /// 向数据表ExamLine更新一条记录。
        /// </summary>
        /// <param name="_ExamLineModel">_ExamLineModel</param>
        /// <returns>影响的行数</returns>
        public int Update(ExamLineEntity _ExamLineModel)
        {
            string sqlStr = "update ExamLine set [ExamId]=@ExamId,[ExamContent]=@ExamContent,[OptionA]=@OptionA,[OptionB]=@OptionB,[OptionC]=@OptionC,[OptionD]=@OptionD,[Answer]=@Answer,[SelectedOption]=@SelectedOption,[SubType]=@SubType,[CreateTime]=@CreateTime,[UpdateTime]=@UpdateTime,[IsActive]=@IsActive where Id=@Id";
            SqlParameter[] _param ={
                new SqlParameter("@Id",SqlDbType.BigInt),
                new SqlParameter("@ExamId",SqlDbType.BigInt),
                new SqlParameter("@ExamContent",SqlDbType.VarChar),
                new SqlParameter("@OptionA",SqlDbType.VarChar),
                new SqlParameter("@OptionB",SqlDbType.VarChar),
                new SqlParameter("@OptionC",SqlDbType.VarChar),
                new SqlParameter("@OptionD",SqlDbType.VarChar),
                new SqlParameter("@Answer",SqlDbType.VarChar),
                new SqlParameter("@SelectedOption",SqlDbType.VarChar),
                new SqlParameter("@SubType",SqlDbType.SmallInt),
                new SqlParameter("@CreateTime",SqlDbType.DateTime),
                new SqlParameter("@UpdateTime",SqlDbType.DateTime),
                new SqlParameter("@IsActive",SqlDbType.SmallInt)
                };
            _param[0].Value = _ExamLineModel.Id;
            _param[1].Value = _ExamLineModel.ExamId;
            _param[2].Value = _ExamLineModel.ExamContent;
            _param[3].Value = _ExamLineModel.OptionA;
            _param[4].Value = _ExamLineModel.OptionB;
            _param[5].Value = _ExamLineModel.OptionC;
            _param[6].Value = _ExamLineModel.OptionD;
            _param[7].Value = _ExamLineModel.Answer;
            _param[8].Value = _ExamLineModel.SelectedOption;
            _param[9].Value = _ExamLineModel.SubType;
            _param[10].Value = _ExamLineModel.CreateTime;
            _param[11].Value = _ExamLineModel.UpdateTime;
            _param[12].Value = _ExamLineModel.IsActive;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        /// <summary>
        /// 删除数据表ExamLine中的一条记录
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>影响的行数</returns>
        public int DeleteLogical(long Id)
        {
            string sqlStr = "update ExamLine set isactive=0, updatetime=getdate() where [Id]=@Id";
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt),

            };
            _param[0].Value = Id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        /// <summary>
        /// 删除数据表ExamLine中的一条记录
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>影响的行数</returns>
        public int Delete(long Id)
        {
            string sqlStr = "delete from ExamLine where [Id]=@Id";
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt),

            };
            _param[0].Value = Id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.Connection, CommandType.Text, sqlStr, _param);
        }


        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  examline 数据实体
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>examline 数据实体</returns>
        public ExamLineEntity Populate_ExamLineEntity_FromDr(DataRow row)
        {
            ExamLineEntity Obj = new ExamLineEntity();
            if (row != null)
            {
                Obj.Id = ((row["Id"]) == DBNull.Value) ? 0 : (long)row["Id"];
                Obj.ExamId = ((row["ExamId"]) == DBNull.Value) ? 0 : (long)row["ExamId"];
                Obj.ExamContent = row["ExamContent"].ToString();
                Obj.OptionA = row["OptionA"].ToString();
                Obj.OptionB = row["OptionB"].ToString();
                Obj.OptionC = row["OptionC"].ToString();
                Obj.OptionD = row["OptionD"].ToString();
                Obj.Answer = row["Answer"].ToString();
                Obj.SelectedOption = row["SelectedOption"].ToString();
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
        /// 得到  examline 数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>examline 数据实体</returns>
        public ExamLineEntity Populate_ExamLineEntity_FromDr(IDataReader dr)
        {
            ExamLineEntity Obj = new ExamLineEntity();

            Obj.Id = ((dr["Id"]) == DBNull.Value) ? 0 : (long)dr["Id"];
            Obj.ExamId = ((dr["ExamId"]) == DBNull.Value) ? 0 : (long)dr["ExamId"];
            Obj.ExamContent = dr["ExamContent"].ToString();
            Obj.OptionA = dr["OptionA"].ToString();
            Obj.OptionB = dr["OptionB"].ToString();
            Obj.OptionC = dr["OptionC"].ToString();
            Obj.OptionD = dr["OptionD"].ToString();
            Obj.Answer = dr["Answer"].ToString();
            Obj.SelectedOption = dr["SelectedOption"].ToString();
            Obj.SubType = ((dr["SubType"]) == DBNull.Value) ? (short)0 : (short)dr["SubType"];
            Obj.CreateTime = ((dr["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["CreateTime"]);
            Obj.UpdateTime = ((dr["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdateTime"]);
            Obj.IsActive = ((dr["IsActive"]) == DBNull.Value) ? (short)0 : (short)dr["IsActive"];

            return Obj;
        }
        #endregion

        /// <summary>
        /// 根据ID,返回一个ExamLine对象
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>ExamLine对象</returns>
        public ExamLineEntity Get_ExamLineEntity(long id)
        {
            ExamLineEntity _obj = null;
            SqlParameter[] _param ={
            new SqlParameter("@Id",SqlDbType.BigInt)
            };
            _param[0].Value = id;
            string sqlStr = "select * from ExamLine with(nolock) where Id=@Id  and isactive=1 ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_ExamLineEntity_FromDr(dr);
                }

                if (!dr.IsClosed)
                {
                    dr.Close();
                }
            }
            return _obj;
        }
        /// <summary>
        /// 得到数据表ExamLine所有记录
        /// </summary>
        /// <returns>数据集</returns>
        public IList<ExamLineEntity> Get_ExamLineAll()
        {
            IList<ExamLineEntity> Obj = new List<ExamLineEntity>();
            string sqlStr = "select * from ExamLine";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.Text, sqlStr))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_ExamLineEntity_FromDr(dr));
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
        public IList<ExamLineEntity> Search(out int pageCount, int pageIndex, int pageSize, string where, string orderField, bool isDesc)
        {
            IList<ExamLineEntity> list = new List<ExamLineEntity>();
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
            _param[5].Value = "ExamLine";
            _param[6].Value = "*";
            _param[7].Direction = ParameterDirection.Output;

            using (IDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, CommandType.StoredProcedure, "sp_OF_Page", _param))
            {
                while (dr.Read())
                {
                    ExamLineEntity info = Populate_ExamLineEntity_FromDr(dr);
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
        public bool IsExistExamLine(long id)
        {
            SqlParameter[] _param ={
                                      new SqlParameter("@id",SqlDbType.BigInt)
                                  };
            _param[0].Value = id;
            string sqlStr = "select Count(*) from ExamLine where Id=@id";
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
        /// 根据试卷ID获取题目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<ExamLineEntity> GetExamLineByExamId(long id)
        {
            IList<ExamLineEntity> Obj = new List<ExamLineEntity>();
            string sqlStr = "select * from ExamLine WITH(NOLOCK ) where ExamId= @ExamId";

            SqlParameter[] paras =
            {
                new SqlParameter("@ExamId",id)
            };

            var dataset = SqlHelper.ExecuteDataset(SqlHelper.Connection, CommandType.Text, sqlStr, paras);

            if(null != dataset && dataset.Tables.Count > 0)
            {
                var table = dataset.Tables[0];
                foreach (DataRow dr in table.Rows)
                {
                    ExamLineEntity entity = new ExamLineEntity();
                    entity.Id = ((dr["Id"]) == DBNull.Value) ? 0 : (long)dr["Id"];
                    entity.ExamId = ((dr["ExamId"]) == DBNull.Value) ? 0 : (long)dr["ExamId"];
                    entity.ExamContent = dr["ExamContent"].ToString();
                    entity.OptionA = dr["OptionA"].ToString();
                    entity.OptionB = dr["OptionB"].ToString();
                    entity.OptionC = dr["OptionC"].ToString();
                    entity.OptionD = dr["OptionD"].ToString();
                    entity.Answer = dr["Answer"].ToString();
                    entity.SelectedOption = dr["SelectedOption"].ToString();
                    entity.SubType = ((dr["SubType"]) == DBNull.Value) ? (short)0 : (short)dr["SubType"];
                    entity.CreateTime = ((dr["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["CreateTime"]);
                    entity.UpdateTime = ((dr["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdateTime"]);
                    entity.IsActive = ((dr["IsActive"]) == DBNull.Value) ? (short)0 : (short)dr["IsActive"];

                    Obj.Add(entity);
                }
            }

            return Obj;
        }

        #endregion
    }
}