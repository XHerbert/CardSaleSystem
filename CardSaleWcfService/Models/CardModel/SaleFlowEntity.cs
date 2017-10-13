// =================================================================== 
// 项目说明
// ====================================================================
// xuhongbo @Copy Right 2017
// 文件： SaleFlowEntity.cs
// 项目名称：
// 创建时间：2017/9/26
// 负责人：xuhongbo
// ===================================================================
using System;
using System.Runtime.Serialization;
namespace XHB.Card.Entity
{
    /// <summary>
    ///SaleFlow数据实体
    /// </summary>
    [Serializable]
    [DataContract]
    public class SaleFlowEntity
    {
        #region 变量定义
        ///<summary>
        ///
        ///</summary>
        private long _id;
        ///<summary>
        ///卡密ID
        ///</summary>
        private long _cardId;
        ///<summary>
        ///当前所属人
        ///</summary>
        private long _currentUser;
        ///<summary>
        ///管理员定价
        ///</summary>
        private double _adminPrice;
        ///<summary>
        ///代理定价
        ///</summary>
        private double _proxyPrice;
        ///<summary>
        ///分销定价
        ///</summary>
        private double _distributionPrice;
        ///<summary>
        ///档口定价
        ///</summary>
        private double _stallsPrice;
        ///<summary>
        ///售出价格
        ///</summary>
        private double _customPrice;
        ///<summary>
        ///管理员是否审核
        ///</summary>
        private bool _isApproved;
        ///<summary>
        ///
        ///</summary>
        private DateTime _createTime;
        ///<summary>
        ///
        ///</summary>
        private DateTime _updateTime;
        ///<summary>
        ///
        ///</summary>
        private string _memo = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _isActive = String.Empty;
        #endregion

        #region 构造函数

        ///<summary>
        ///
        ///</summary>
        public SaleFlowEntity()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public SaleFlowEntity
        (
            long id,
            long cardId,
            long currentUser,
            double adminPrice,
            double proxyPrice,
            double distributionPrice,
            double stallsPrice,
            double customPrice,
            bool isApproved,
            DateTime createTime,
            DateTime updateTime,
            string memo,
            string isActive
        )
        {
            _id = id;
            _cardId = cardId;
            _currentUser = currentUser;
            _adminPrice = adminPrice;
            _proxyPrice = proxyPrice;
            _distributionPrice = distributionPrice;
            _stallsPrice = stallsPrice;
            _customPrice = customPrice;
            _isApproved = isApproved;
            _createTime = createTime;
            _updateTime = updateTime;
            _memo = memo;
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
        ///卡密ID
        ///</summary>
        [DataMember]
        public long CardId
        {
            get { return _cardId; }
            set { _cardId = value; }
        }

        ///<summary>
        ///当前所属人
        ///</summary>
        [DataMember]
        public long CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        ///<summary>
        ///管理员定价
        ///</summary>
        [DataMember]
        public double AdminPrice
        {
            get { return _adminPrice; }
            set { _adminPrice = value; }
        }

        ///<summary>
        ///代理定价
        ///</summary>
        [DataMember]
        public double ProxyPrice
        {
            get { return _proxyPrice; }
            set { _proxyPrice = value; }
        }

        ///<summary>
        ///分销定价
        ///</summary>
        [DataMember]
        public double DistributionPrice
        {
            get { return _distributionPrice; }
            set { _distributionPrice = value; }
        }

        ///<summary>
        ///档口定价
        ///</summary>
        [DataMember]
        public double StallsPrice
        {
            get { return _stallsPrice; }
            set { _stallsPrice = value; }
        }

        ///<summary>
        ///售出价格
        ///</summary>
        [DataMember]
        public double CustomPrice
        {
            get { return _customPrice; }
            set { _customPrice = value; }
        }

        ///<summary>
        ///管理员是否审核
        ///</summary>
        [DataMember]
        public bool IsApproved
        {
            get { return _isApproved; }
            set { _isApproved = value; }
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
        public DateTime UpdateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; }
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
        public string IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        #endregion
    }
}