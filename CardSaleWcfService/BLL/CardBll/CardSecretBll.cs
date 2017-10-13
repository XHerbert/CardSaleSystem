// =================================================================== 
// 项目说明
// ===================================================================
// xuhongbo。@Copy Right 2017
// 文件： CardSecretBll.cs
// 项目名称：kaika
// 创建时间：2017/9/22
// 负责人：xuhongbo
// ===================================================================
using System.Collections.Generic;
using XHB.Card.Dal;
using XHB.Card.Entity;

namespace XHB.Card.Bll
{
    public partial class CardSecretBll
    {
        #region --------实例化接口函数----------


        CardSecretDal cardSecretdal;
        public CardSecretBll()
        {
            cardSecretdal = new CardSecretDal();
        }

        public static CardSecretBll GetInstance()
        {
            return new CardSecretBll ();
        }

        public long Insert(CardSecretEntity cardSecretEntity)
        {
            return cardSecretdal.Insert(cardSecretEntity);
        }

        public long Update(CardSecretEntity cardSecretEntity)
        {
            return cardSecretdal.Update(cardSecretEntity);
        }

        public long DeleteLogical(long id)
        {
            return cardSecretdal.DeleteLogical(id);
        }

        /// <summary>
        /// 根据主键ID获取单条数据实体
        /// </summary>
        /// <param name="id">long </param>
        public CardSecretEntity GetAdminSingle(long id)
        {
            return cardSecretdal.Get_CardSecretEntity(id);
        }

        /// <summary>
        /// 实例化一个新的实体
        /// </summary>
        public CardSecretEntity GetInstantiationEntity()
        {
            return new CardSecretEntity();
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
            IList<CardSecretEntity> cardSecretList = new List<CardSecretEntity>();
            cardSecretList = cardSecretdal.Search(out pageCount, pageIndex, pageSize, where, orderField, isDesc);
            return cardSecretList;

        }

        /// <summary>
        /// 获取表的所有数据 
        /// </summary>
        public IList<CardSecretEntity> GetCardSecretList()
        {
            IList<CardSecretEntity> cardSecretList = new List<CardSecretEntity>();
            cardSecretList = cardSecretdal.Get_CardSecretAll();
            return cardSecretList;
        }
        #endregion


        #region -------自定义实例化接口函数--------

        public IList<CardSecretEntity> GetGetCardSecretListByUser(string code)
        {
            return cardSecretdal.GetGetCardSecretListByUser(code);
        }

        public bool BuyCard(string buyerCode, long buyerId , long sellerId , long cardId, short status , int count )
        {
            return cardSecretdal.BuyCard(buyerCode, buyerId, sellerId, cardId, status, count);
        }

        public bool InputPoint(string cid,string pd,string ucode)
        {
            return cardSecretdal.InputPoint(cid, pd, ucode);
        }

        public IList<CardSecretEntity> GetUsedCard(string code, bool used)
        {
            return cardSecretdal.GetUsedCard(code, used);
        }

        public IList<CardSecretEntity> GetSpecialCard(string code, string CardSecret)
        {
            return cardSecretdal.GetSpecialCard(code, CardSecret);
        }
        #endregion


    }
}