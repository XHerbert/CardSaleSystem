// =================================================================== 
// 项目说明
// ====================================================================
// xuhongbo @Copy Right 2017
// 文件： ExamLineBll.cs
// 项目名称：答题系统
// 创建时间：2017/9/20
// 负责人：xuhongbo
// ===================================================================

using ExamineSystem.Dal;
using ExamineSystem.Models.ExamModel;
using System.Collections.Generic;

namespace ExamineSystem.Bll
{
    public partial class ExamLineBll
    {

        ExamLineDal examLinedal;
        public ExamLineBll()
        {
            examLinedal = new ExamLineDal();
        }

        public static ExamLineBll GetInstance()
        {
            return new ExamLineBll();
        }

        public long Insert(ExamLineEntity examLineEntity)
        {
            return examLinedal.Insert(examLineEntity);
        }

        public long Update(ExamLineEntity examLineEntity)
        {
            return examLinedal.Update(examLineEntity);
        }
        public long DeleteLogical(long id)
        {
            return examLinedal.DeleteLogical(id);
        }
        /// <summary>
        /// 根据主键ID获取单条数据实体
        /// </summary>
        /// <param name="id">long </param>
        public ExamLineEntity GetAdminSingle(long id)
        {
            return examLinedal.Get_ExamLineEntity(id);
        }
        /// <summary>
        /// 实例化一个新的实体
        /// </summary>
        public ExamLineEntity GetInstantiationEntity()
        {
            return new ExamLineEntity();
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
            IList<ExamLineEntity> examLineList = new List<ExamLineEntity>();
            examLineList = examLinedal.Search(out pageCount, pageIndex, pageSize, where, orderField, isDesc);
            return examLineList;

        }

        /// <summary>
        /// 获取表的所有数据 
        /// </summary>
        public IList<ExamLineEntity> GetExamLineList()
        {
            IList<ExamLineEntity> examLineList = new List<ExamLineEntity>();
            examLineList = examLinedal.Get_ExamLineAll();
            return examLineList;
        }

        public IList<ExamLineEntity> GetExamLineByExamId(long id)
        {
            return examLinedal.GetExamLineByExamId(id);
        }
    }
}