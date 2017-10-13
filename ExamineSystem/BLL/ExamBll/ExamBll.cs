// =================================================================== 
// 项目说明
// ====================================================================
// xuhongbo @Copy Right 2017
// 文件： ExamBll.cs
// 项目名称：答题系统
// 创建时间：2017/9/19
// 负责人：xuhongbo
// ===================================================================
using ExamineSystem.Dal;
using ExamineSystem.Models.ExamModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamineSystem.Bll
{
    public class ExamBll
    {

        ExamDal examdal;
        public ExamBll()
        {
            examdal = new ExamDal();
        }

        public static ExamBll GetInstance()
        {
            return new ExamBll();
        }

        public long Insert(ExamEntity examEntity)
        {
            return examdal.Insert(examEntity);
        }

        public long Update(ExamEntity examEntity)
        {
            return examdal.Update(examEntity);
        }
        public long DeleteLogical(long id)
        {
            return examdal.DeleteLogical(id);
        }
        /// <summary>
        /// 根据主键ID获取单条数据实体
        /// </summary>
        /// <param name="id">long </param>
        public ExamEntity GetAdminSingle(long id)
        {
            return examdal.Get_ExamEntity(id);
        }
        /// <summary>
        /// 实例化一个新的实体
        /// </summary>
        public ExamEntity GetInstantiationEntity()
        {
            return new ExamEntity();
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
            IList<ExamEntity> examList = new List<ExamEntity>();
            examList = examdal.Search(out pageCount, pageIndex, pageSize, where, orderField, isDesc);
            return examList;
        }

        /// <summary>
        /// 获取表的所有数据 
        /// </summary>
        public IList<ExamEntity> GetExamList()
        {
            IList<ExamEntity> examList = new List<ExamEntity>();
            examList = examdal.Get_ExamAll();
            return examList;
        }
    }
}