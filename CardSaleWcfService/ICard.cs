using CardSaleSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using XHB.Card.Entity;

namespace CardSaleWcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ICard”。
    [ServiceContract]
    public interface ICard
    {
        [OperationContract]
        CardQueryExt GetPackList();

        [OperationContract]
        CardSecretEntityExt GetUsedCardList(string user, bool userd = true);

        [OperationContract]
        IList<CardSecretEntity> GetSpecialCard(string code, string CardSecret);

        [OperationContract]
        bool InputPoint(string cid, string pwd, string ucode);

        [OperationContract]
        bool BuyCard(string buyerCode, long buyerId, long sellerId, long cardId, short status, int count);


    }
}
