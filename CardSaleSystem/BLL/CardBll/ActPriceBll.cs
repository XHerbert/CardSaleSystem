// =================================================================== 
// 项目说明
// ===================================================================
// xuhongbo。@Copy Right 2017
// 文件： ActPriceBll.cs
// 项目名称：
// 创建时间：2017/9/30
// 负责人：xuhongbo
// ===================================================================
using CardSaleSystem.Models.ExtModel;
using System.Collections.Generic;
using XHB.ActPrice.Dal;
using XHB.ActPrice.Entity;

namespace XHB.ActPrice.Bll
{
    public partial class ActPriceBll
    {

        #region MyRegion
        ActPriceDal actPricedal;
        public ActPriceBll()
        {
            actPricedal = new ActPriceDal();
        }

        public static ActPriceBll GetInstance()
        {
            return new ActPriceBll();
        }

        public long Insert(ActPriceEntity actPriceEntity)
        {
            return actPricedal.Insert(actPriceEntity);
        }

        public long Update(ActPriceEntity actPriceEntity)
        {
            return actPricedal.Update(actPriceEntity);
        }

        public long DeleteLogical(long id)
        {
            return actPricedal.DeleteLogical(id);
        }

        /// <summary>
        /// 根据主键ID获取单条数据实体
        /// </summary>
        /// <param name="id">long </param>
        public ActPriceEntity GetAdminSingle(long id)
        {
            return actPricedal.Get_ActPriceEntity(id);
        }

        /// <summary>
        /// 实例化一个新的实体
        /// </summary>
        public ActPriceEntity GetInstantiationEntity()
        {
            return new ActPriceEntity();
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
        public IList<ActPriceEntity> Search(out int pageCount, int pageIndex, int pageSize, string where, string orderField, bool isDesc)
        {
            IList<ActPriceEntity> actPriceList = new List<ActPriceEntity>();
            actPriceList = actPricedal.Search(out pageCount, pageIndex, pageSize, where, orderField, isDesc);
            return actPriceList;

        }

        /// <summary>
        /// 获取表的所有数据 
        /// </summary>
        public IList<ActPriceEntity> GetActPriceList()
        {
            IList<ActPriceEntity> actPriceList = new List<ActPriceEntity>();
            actPriceList = actPricedal.Get_ActPriceAll();
            return actPriceList;
        }

        #endregion

        #region 自定义操作
        public long IsExistActPrice(long actId,bool need = true)
        {
            return actPricedal.IsExistActPrice(actId, need);
        }

        public ActPriceEntity GetActPriceByActId(long actId)
        {
            return actPricedal.GetActPriceByActId(actId);
        }

        public IList<ActPriceEntityExt> GetActPriceExt(long uuid)
        {
            return actPricedal.GetActPriceExt(uuid);
        }

        #endregion

    }
}