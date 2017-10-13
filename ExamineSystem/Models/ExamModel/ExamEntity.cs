// =================================================================== 
// 项目说明
// ====================================================================
// xuhongbo @Copy Right 2017
// 文件： ExamEntity.cs
// 项目名称：答题系统
// 创建时间：2017/9/19
// 负责人：xuhongbo
// ===================================================================

using System;
using System.Runtime.Serialization;


namespace ExamineSystem.Models.ExamModel
{
    /// <summary>
	///Exam数据实体
	/// </summary>
	[Serializable]
    [DataContract]
    public class ExamEntity
    {
        #region 变量定义
        ///<summary>
        ///
        ///</summary>
        private long _id;
        ///<summary>
        ///
        ///</summary>
        private string _examTitle = String.Empty;
        ///<summary>
        ///题目大类别  专项练习  历年考题等
        ///</summary>
        private short _type;
        ///<summary>
        ///同一套题目中的不同类型 如常识  数字  语言
        ///</summary>
        private short _subType;
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
        private short _isActive;
        #endregion

        #region 构造函数

        ///<summary>
        ///
        ///</summary>
        public ExamEntity()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public ExamEntity
        (
            long id,
            string examTitle,
            short type,
            short subType,
            DateTime createTime,
            DateTime updateTime,
            short isActive
        )
        {
            _id = id;
            _examTitle = examTitle;
            _type = type;
            _subType = subType;
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
        public string ExamTitle
        {
            get { return _examTitle; }
            set { _examTitle = value; }
        }

        ///<summary>
        ///题目大类别  专项练习  历年考题等
        ///</summary>
        [DataMember]
        public short Type
        {
            get { return _type; }
            set { _type = value; }
        }

        ///<summary>
        ///同一套题目中的不同类型 如常识  数字  语言
        ///</summary>
        [DataMember]
        public short SubType
        {
            get { return _subType; }
            set { _subType = value; }
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
        public short IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        #endregion

    }
}