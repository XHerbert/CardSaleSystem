// =================================================================== 
// 项目说明
// ====================================================================
// xuhongbo @Copy Right 2017
// 文件： UsersEntity.cs
// 项目名称：
// 创建时间：2017/9/21
// 负责人：xuhongbo
// ===================================================================

using System;
using System.Runtime.Serialization;

namespace CardSaleSystem.Models.UserModel
{
    /// <summary>
	///Users数据实体
	/// </summary>
	[Serializable]
    [DataContract]
    public class UsersEntity
    {
        #region 变量定义
        ///<summary>
        ///
        ///</summary>
        private long _id;
        ///<summary>
        ///登录名
        ///</summary>
        private string _userCode = String.Empty;
        ///<summary>
        ///用户名
        ///</summary>
        private string _userName = String.Empty;
        ///<summary>
        ///用户密码
        ///</summary>
        private string _password = String.Empty;
        ///<summary>
        ///用户类型：1管理员、2代理、3分销、4档口
        ///</summary>
        private string _userType = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private int _point;
        ///<summary>
        ///
        ///</summary>
        private string _phone = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _createBy = String.Empty;
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
        ///<summary>
        ///
        ///</summary>
        private string _memo = String.Empty;
        #endregion

        #region 构造函数

        ///<summary>
        ///
        ///</summary>
        public UsersEntity()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public UsersEntity
        (
            long id,
            string userCode,
            string userName,
            string password,
            string userType,
            int point,
            string phone,
            string createBy,
            DateTime createTime,
            DateTime updateTime,
            short isActive,
            string memo
        )
        {
            _id = id;
            _userCode = userCode;
            _userName = userName;
            _password = password;
            _userType = userType;
            _point = point;
            _phone = phone;
            _createBy = createBy;
            _createTime = createTime;
            _updateTime = updateTime;
            _isActive = isActive;
            _memo = memo;

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
        ///登录名
        ///</summary>
        [DataMember]
        public string UserCode
        {
            get { return _userCode; }
            set { _userCode = value; }
        }

        ///<summary>
        ///用户名
        ///</summary>
        [DataMember]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        ///<summary>
        ///用户密码
        ///</summary>
        [DataMember]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        ///<summary>
        ///用户类型：1管理员、2代理、3分销、4档口
        ///</summary>
        [DataMember]
        public string UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        public int Point
        {
            get { return _point; }
            set { _point = value; }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        public string CreateBy
        {
            get { return _createBy; }
            set { _createBy = value; }
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

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }

        #endregion

    }
}