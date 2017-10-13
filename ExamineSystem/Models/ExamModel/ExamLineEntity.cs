// =================================================================== 
// 项目说明
// ====================================================================
// xuhongbo @Copy Right 2017
// 文件： ExamLineEntity.cs
// 项目名称：答题系统
// 创建时间：2017/9/20
// 负责人：xuhongbo
// ===================================================================

using System;
using System.Runtime.Serialization;


namespace ExamineSystem.Models.ExamModel
{
    /// <summary>
    ///ExamLine数据实体
    /// </summary>
    [Serializable]
    [DataContract]
    public class ExamLineEntity
    {
        #region 变量定义
        ///<summary>
        ///题目ID
        ///</summary>
        private long _id;
        ///<summary>
        ///与之关联的试卷ID
        ///</summary>
        private long _examId;
        ///<summary>
        ///题目内容
        ///</summary>
        private string _examContent = String.Empty;
        ///<summary>
        ///选项A
        ///</summary>
        private string _optionA = String.Empty;
        ///<summary>
        ///选项B
        ///</summary>
        private string _optionB = String.Empty;
        ///<summary>
        ///选项C
        ///</summary>
        private string _optionC = String.Empty;
        ///<summary>
        ///选项D
        ///</summary>
        private string _optionD = String.Empty;
        ///<summary>
        ///正确答案选项
        ///</summary>
        private string _answer = String.Empty;
        ///<summary>
        ///答题选项
        ///</summary>
        private string _selectedOption = String.Empty;
        ///<summary>
        ///题目所属子类
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
        public ExamLineEntity()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public ExamLineEntity
        (
            long id,
            long examId,
            string examContent,
            string optionA,
            string optionB,
            string optionC,
            string optionD,
            string answer,
            string selectedOption,
            short subType,
            DateTime createTime,
            DateTime updateTime,
            short isActive
        )
        {
            _id = id;
            _examId = examId;
            _examContent = examContent;
            _optionA = optionA;
            _optionB = optionB;
            _optionC = optionC;
            _optionD = optionD;
            _answer = answer;
            _selectedOption = selectedOption;
            _subType = subType;
            _createTime = createTime;
            _updateTime = updateTime;
            _isActive = isActive;

        }
        #endregion

        #region 公共属性


        ///<summary>
        ///题目ID
        ///</summary>
        [DataMember]
        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        ///<summary>
        ///与之关联的试卷ID
        ///</summary>
        [DataMember]
        public long ExamId
        {
            get { return _examId; }
            set { _examId = value; }
        }

        ///<summary>
        ///题目内容
        ///</summary>
        [DataMember]
        public string ExamContent
        {
            get { return _examContent; }
            set { _examContent = value; }
        }

        ///<summary>
        ///选项A
        ///</summary>
        [DataMember]
        public string OptionA
        {
            get { return _optionA; }
            set { _optionA = value; }
        }

        ///<summary>
        ///选项B
        ///</summary>
        [DataMember]
        public string OptionB
        {
            get { return _optionB; }
            set { _optionB = value; }
        }

        ///<summary>
        ///选项C
        ///</summary>
        [DataMember]
        public string OptionC
        {
            get { return _optionC; }
            set { _optionC = value; }
        }

        ///<summary>
        ///选项D
        ///</summary>
        [DataMember]
        public string OptionD
        {
            get { return _optionD; }
            set { _optionD = value; }
        }

        ///<summary>
        ///正确答案选项
        ///</summary>
        [DataMember]
        public string Answer
        {
            get { return _answer; }
            set { _answer = value; }
        }

        ///<summary>
        ///答题选项
        ///</summary>
        [DataMember]
        public string SelectedOption
        {
            get { return _selectedOption; }
            set { _selectedOption = value; }
        }

        ///<summary>
        ///题目所属子类
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