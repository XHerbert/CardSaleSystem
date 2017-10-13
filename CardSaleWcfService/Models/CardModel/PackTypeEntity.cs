// =================================================================== 
// 项目说明
// ====================================================================
// xuhongbo @Copy Right 2017
// 文件： PackTypeEntity.cs
// 项目名称：
// 创建时间：2017/9/24
// 负责人：xuhongbo
// ===================================================================
using System;
using System.Runtime.Serialization;

namespace XHB.Card.Entity
{
    /// <summary>
	///PackType数据实体
	/// </summary>
	[Serializable]
    [DataContract]
    public class PackTypeEntity
    {
        #region 变量定义
        ///<summary>
        ///
        ///</summary>
        private long _id;
        ///<summary>
        ///
        ///</summary>
        private string _packCode = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _packName = String.Empty;
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
        private string _description = String.Empty;
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
        public PackTypeEntity()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public PackTypeEntity
        (
            long id,
            string packCode,
            string packName,
            long actId,
            double price,
            string description,
            DateTime createTime,
            DateTime updateTime,
            bool isActive
        )
        {
            _id = id;
            _packCode = packCode;
            _packName = packName;
            _actId = actId;
            _price = price;
            _description = description;
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
        public string PackCode
        {
            get { return _packCode; }
            set { _packCode = value; }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        public string PackName
        {
            get { return _packName; }
            set { _packName = value; }
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
        public string Description
        {
            get { return _description; }
            set { _description = value; }
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