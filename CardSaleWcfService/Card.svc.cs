using CardSaleSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using XHB.Card.Bll;
using XHB.Card.BLL.Bll;
using XHB.Card.Entity;

namespace CardSaleWcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Card”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Card.svc 或 Card.svc.cs，然后开始调试。
    public class Card : ICard
    {
        /// <summary>
        /// 代理商购卡
        /// </summary>
        /// <param name="buyerCode"></param>
        /// <param name="buyerId"></param>
        /// <param name="sellerId"></param>
        /// <param name="cardId"></param>
        /// <param name="status"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public bool BuyCard(string buyerCode, long buyerId, long sellerId, long cardId, short status, int count)
        {
            bool ret = CardSecretBll.GetInstance().BuyCard(buyerCode, buyerId, sellerId, cardId, status, count);
            return ret;
        }

        /// <summary>
        /// 授权查询
        /// </summary>
        /// <returns></returns>
        public CardQueryExt GetPackList()
        {
            var act = ActTypeBll.GetInstance().GetActTypeList();
            CardQueryExt ext = new CardQueryExt();
            ext.ActType = act;
            ext.VPack = new List<XHB.Card.Entity.VPack>();
            return ext;
        }

        /// <summary>
        /// 输入卡号\卡密模糊搜索
        /// </summary>
        /// <param name="code"></param>
        /// <param name="CardSecret"></param>
        /// <returns></returns>
        public IList<CardSecretEntity> GetSpecialCard(string userCode, string cardNo)
        {
            IList<CardSecretEntity> card = CardSecretBll.GetInstance().GetSpecialCard(userCode, cardNo);
            return card;
        }


        /// <summary>
        /// 获取当前用户可用/不可用的卡密
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="used"></param>
        /// <returns></returns>
        public CardSecretEntityExt GetUsedCardList(string userCode, bool used = true)
        {
            CardSecretEntityExt queryExt = new CardSecretEntityExt();
            IList<CardSecretEntity> card = CardSecretBll.GetInstance().GetUsedCard(userCode, used);
            var act = ActTypeBll.GetInstance().GetActTypeList();

            queryExt.ActTypeEntity = act;
            queryExt.CardSecretEntity = card;

            return queryExt;
        }

        /// <summary>
        /// 代理商为游客充值
        /// </summary>
        /// <param name="cid">卡号</param>
        /// <param name="pwd">密码</param>
        /// <param name="ucode">用户</param>
        /// <returns></returns>
        public bool InputPoint(string cid, string pwd, string ucode)
        {
            if (string.IsNullOrEmpty(cid) || string.IsNullOrEmpty(pwd) || string.IsNullOrEmpty(ucode))
                return false;

            return CardSecretBll.GetInstance().InputPoint(cid, pwd, ucode);
        }
    }
}
