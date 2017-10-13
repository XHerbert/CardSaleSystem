// =================================================================== 
// 项目说明
// ====================================================================
// xuhongbo @Copy Right 2017
// 文件： ActPriceEntity.cs
// 项目名称：
// 创建时间：2017/9/30
// 负责人：xuhongbo
// ===================================================================
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
namespace XHB.ActPrice.Entity
{
    /// <summary>
    ///ActPrice数据实体
    /// </summary>
    [Serializable]
    [DataContract]
    public class ActPriceEntity
    {
        #region 变量定义
        ///<summary>
        ///
        ///</summary>
        private long _id;
        ///<summary>
        ///
        ///</summary>
        private long _userId;
        ///<summary>
        ///
        ///</summary>
        private long _actId;
        ///<summary>
        ///
        ///</summary>
        private double _price;
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
        private bool _isActive;
        #endregion

        #region 构造函数

        ///<summary>
        ///
        ///</summary>
        public ActPriceEntity()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public ActPriceEntity
        (
            long id,
            long userId,
            long actId,
            double price,
            DateTime createTime,
            DateTime updateTime,
            bool isActive
        )
        {
            _id = id;
            _userId = userId;
            _actId = actId;
            _price = price;
            _createTime = createTime;
            _updateTime = updateTime;
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
        public long UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        ///<summary>
        ///
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
        public double Price
        {
            get { return _price; }
            set { _price = value; }
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
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        #endregion

    }
}