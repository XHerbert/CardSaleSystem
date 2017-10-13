// =================================================================== 
// 项目说明
// ====================================================================
// xuhongbo @Copy Right 2017
// 文件： CardSecretEntity.cs
// 项目名称：kami
// 创建时间：2017/9/22
// 负责人：xuhongbo
// ===================================================================
using System;
using System.Runtime.Serialization;
namespace XHB.Card.Entity
{
    /// <summary>
	///CardSecret数据实体
	/// </summary>
	[Serializable]
    [DataContract]
    public class CardSecretEntity
    {
        #region 变量定义
        ///<summary>
        ///
        ///</summary>
        private long _id;
        ///<summary>
        ///
        ///</summary>
        private string _cardId = String.Empty;
        ///<summary>
        ///关联的节目包ID
        ///</summary>
        private long _actId;
        ///<summary>
        ///
        ///</summary>
        private string _cardSecret = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private bool _isUsed;
        ///<summary>
        ///
        ///</summary>
        private string _usedBy = String.Empty;
        ///<summary>
        ///1 未出售  2 售卖中 3 已售出
        ///</summary>
        private short _saleStatus;
        ///<summary>
        ///
        ///</summary>
        private string _memo = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private DateTime _createTime;
        ///<summary>
        ///
        ///</summary>
        private DateTime _updatTime;
        ///<summary>
        ///
        ///</summary>
        private bool _isActive;
        #endregion

        #region 构造函数

        ///<summary>
        ///
        ///</summary>
        public CardSecretEntity()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public CardSecretEntity
        (
            long id,
            string cardId,
            long actId,
            string cardSecret,
            bool isUsed,
            string usedBy,
            short saleStatus,
            string memo,
            DateTime createTime,
            DateTime updatTime,
            bool isActive
        )
        {
            _id = id;
            _cardId = cardId;
            _actId = actId;
            _cardSecret = cardSecret;
            _isUsed = isUsed;
            _usedBy = usedBy;
            _saleStatus = saleStatus;
            _memo = memo;
            _createTime = createTime;
            _updatTime = updatTime;
            _isActive = isActive;

        }
        #endregion

        #region 公共属性


        ///<summary>
        ///
        ///</summary>
        [DataMember]
        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        public string CardId
        {
            get { return _cardId; }
            set { _cardId = value; }
        }

        ///<summary>
        ///关联的节目包ID
        ///</summary>
        [DataMember]
        public long ActId
        {
            get { return _actId; }
            set { _actId = value; }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        public string CardSecret
        {
            get { return _cardSecret; }
            set { _cardSecret = value; }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        public bool IsUsed
        {
            get { return _isUsed; }
            set { _isUsed = value; }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        public string UsedBy
        {
            get { return _usedBy; }
            set { _usedBy = value; }
        }

        ///<summary>
        ///1 未出售  2 售卖中 3 已售出
        ///</summary>
        [DataMember]
        public short SaleStatus
        {
            get { return _saleStatus; }
            set { _saleStatus = value; }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        public DateTime UpdatTime
        {
            get { return _updatTime; }
            set { _updatTime = value; }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        #endregion

    }
}