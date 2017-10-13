// =================================================================== 
// 项目说明
// ===================================================================
// xuhongbo。@Copy Right 2017
// 文件： SaleFlowBll.cs
// 项目名称：答题系统
// 创建时间：2017/9/26
// 负责人：xuhongbo
// ===================================================================
using System.Collections.Generic;
using XHB.Card.Dal;
using XHB.Card.Entity;

namespace XHB.Card.Bll
{
    public partial class SaleFlowBll
    {
        SaleFlowDal saleFlowdal;
        public SaleFlowBll()
        {
            saleFlowdal = new SaleFlowDal();
        }

        public static SaleFlowBll GetInstance()
        {
            return new SaleFlowBll();
        }

        public long Insert(SaleFlowEntity saleFlowEntity)
        {
            return saleFlowdal.Insert(saleFlowEntity);
        }

        public long Update(SaleFlowEntity saleFlowEntity)
        {
            return saleFlowdal.Update(saleFlowEntity);
        }

        public long DeleteLogical(long id)
        {
            return saleFlowdal.DeleteLogical(id);
        }

        /// <summary>
        /// 根据主键ID获取单条数据实体
        /// </summary>
        /// <param name="id">long </param>
        public SaleFlowEntity GetAdminSingle(long id)
        {
            return saleFlowdal.Get_SaleFlowEntity(id);
        }

        /// <summary>
        /// 实例化一个新的实体
        /// </summary>
        public SaleFlowEntity GetInstantiationEntity()
        {
            return new SaleFlowEntity();
        }

        /// <summary>
        /// 通用单表列表翻页+where字符串拼接查询。（不适合高并发因为拼接sql没有参数化）
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
            IList<SaleFlowEntity> saleFlowList = new List<SaleFlowEntity>();
            saleFlowList = saleFlowdal.Search(out pageCount, pageIndex, pageSize, where, orderField, isDesc);
            return saleFlowList;

        }

        /// <summary>
        /// 获取表的所有数据 
        /// </summary>
        public IList<SaleFlowEntity> GetSaleFlowList()
        {
            IList<SaleFlowEntity> saleFlowList = new List<SaleFlowEntity>();
            saleFlowList = saleFlowdal.Get_SaleFlowAll();
            return saleFlowList;
        }
    }
}