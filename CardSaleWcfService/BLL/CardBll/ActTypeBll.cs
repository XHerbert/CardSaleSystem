// =================================================================== 
// 项目说明
// ===================================================================
// xuhongbo。@Copy Right 2017
// 文件： ActTypeBll.cs
// 项目名称：
// 创建时间：2017/9/24
// 负责人：xuhongbo
// ===================================================================
using System.Collections.Generic;
using XHB.Card.Dal;
using XHB.Card.Entity;

namespace XHB.Card.BLL.Bll
{
    public partial class ActTypeBll
    {
        ActTypeDal actTypedal;
        public ActTypeBll()
        {
            actTypedal = new ActTypeDal();
        }

        public static ActTypeBll GetInstance()
        {
            return new  ActTypeBll();
        }

        public long Insert(ActTypeEntity actTypeEntity)
        {
            return actTypedal.Insert(actTypeEntity);
        }

        public long Update(ActTypeEntity actTypeEntity)
        {
            return actTypedal.Update(actTypeEntity);
        }

        public long DeleteLogical(long id)
        {
            return actTypedal.DeleteLogical(id);
        }

        /// <summary>
        /// 根据主键ID获取单条数据实体
        /// </summary>
        /// <param name="id">long </param>
        public ActTypeEntity GetAdminSingle(long id)
        {
            return actTypedal.Get_ActTypeEntity(id);
        }

        /// <summary>
        /// 实例化一个新的实体
        /// </summary>
        public ActTypeEntity GetInstantiationEntity()
        {
            return new ActTypeEntity();
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
        public IList<ActTypeEntity> Search(out int pageCount, int pageIndex, int pageSize, string where, string orderField, bool isDesc)
        {
            IList<ActTypeEntity> actTypeList = new List<ActTypeEntity>();
            actTypeList = actTypedal.Search(out pageCount, pageIndex, pageSize, where, orderField, isDesc);
            return actTypeList;

        }

        /// <summary>
        /// 获取表的所有数据 
        /// </summary>
        public IList<ActTypeEntity> GetActTypeList()
        {
            IList<ActTypeEntity> actTypeList = new List<ActTypeEntity>();
            actTypeList = actTypedal.Get_ActTypeAll();
            return actTypeList;
        }

        public IList<ActTypeEntity> GetActTypeListActive()
        {
            IList<ActTypeEntity> actTypeList = new List<ActTypeEntity>();
            actTypeList = actTypedal.Get_ActType();
            return actTypeList;
        }

        /// <summary>
        /// 定价
        /// </summary>
        /// <param name="id"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public bool UpdateActPrice(long id, double price)
        {
            return actTypedal.UpdateActPrice(id, price);
        }
    }
}