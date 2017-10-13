// =================================================================== 
// 项目说明
// ====================================================================
// xuhongbo @Copy Right 2017
// 文件： ActTypeEntity.cs
// 项目名称：
// 创建时间：2017/9/24
// 负责人：xuhongbo
// ===================================================================
using System;
using System.Runtime.Serialization;
namespace XHB.Card.Entity
{
    /// <summary>
	///ActType数据实体
	/// </summary>
	[Serializable]
    [DataContract]
    public class ActTypeEntity
    {
        #region 变量定义
        ///<summary>
        ///
        ///</summary>
        private long _id;
        ///<summary>
        ///编码
        ///</summary>
        private string _typeCode = String.Empty;
        ///<summary>
        ///名称
        ///</summary>
        private string _typeName = String.Empty;
        ///<summary>
        ///当前价格
        ///</summary>
        private double _curPrice;
        ///<summary>
        ///上级价格
        ///</summary>
        private double _prePrice;
        ///<summary>
        ///类型描述
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
        public ActTypeEntity()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public ActTypeEntity
        (
            long id,
            string type,
            string typeName,
            double curPrice,
            double prePrice,
            string description,
            DateTime createTime,
            DateTime updateTime,
            bool isActive
        )
        {
            _id = id;
            _typeCode = type;
            _typeName = typeName;
            _curPrice = curPrice;
            _prePrice = prePrice;
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
        ///编码
        ///</summary>
        [DataMember]
        public string TypeCode
        {
            get { return _typeCode; }
            set { _typeCode = value; }
        }

        ///<summary>
        ///名称
        ///</summary>
        [DataMember]
        public string TypeName
        {
            get { return _typeName; }
            set { _typeName = value; }
        }

        ///<summary>
        ///当前价格
        ///</summary>
        [DataMember]
        public double CurPrice
        {
            get { return _curPrice; }
            set { _curPrice = value; }
        }

        ///<summary>
        ///上级价格
        ///</summary>
        [DataMember]
        public double PrePrice
        {
            get { return _prePrice; }
            set { _prePrice = value; }
        }

        ///<summary>
        ///类型描述
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