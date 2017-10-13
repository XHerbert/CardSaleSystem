// =================================================================== 
// 项目说明
// ===================================================================
// xuhongbo。@Copy Right 2017
// 文件： PackTypeBll.cs
// 项目名称：
// 创建时间：2017/9/24
// 负责人：xuhongbo
// ===================================================================
using System.Collections.Generic;
using XHB.Card.Dal;
using XHB.Card.Entity;

namespace XHB.Card.BLL.Bll
{
    public partial class PackTypeBll
    {
        PackTypeDal packTypedal;
        public PackTypeBll()
        {
            packTypedal = new PackTypeDal();
        }

        public static PackTypeBll GetInstance()
        {
            return new PackTypeBll();
        }

        public long Insert(PackTypeEntity packTypeEntity)
        {
            return packTypedal.Insert(packTypeEntity);
        }

        public long Update(PackTypeEntity packTypeEntity)
        {
            return packTypedal.Update(packTypeEntity);
        }

        public long DeleteLogical(long id)
        {
            return packTypedal.DeleteLogical(id);
        }

        /// <summary>
        /// 根据主键ID获取单条数据实体
        /// </summary>
        /// <param name="id">long </param>
        public PackTypeEntity GetAdminSingle(long id)
        {
            return packTypedal.Get_PackTypeEntity(id);
        }

        /// <summary>
        /// 实例化一个新的实体
        /// </summary>
        public PackTypeEntity GetInstantiationEntity()
        {
            return new PackTypeEntity();
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
            IList<PackTypeEntity> packTypeList = new List<PackTypeEntity>();
            packTypeList = packTypedal.Search(out pageCount, pageIndex, pageSize, where, orderField, isDesc);
            return packTypeList;

        }

        /// <summary>
        /// 获取表的所有数据 
        /// </summary>
        public IList<PackTypeEntity> GetPackTypeList()
        {
            IList<PackTypeEntity> packTypeList = new List<PackTypeEntity>();
            packTypeList = packTypedal.Get_PackTypeAll();
            return packTypeList;
        }
    }
}