using System;
namespace Model
{
	/// <summary>
	/// member:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class member
	{
		public member()
		{}
		#region Model
		private int _memid;
		private string _username;
		private string _userpwd;
		private int? _userrole;
		private string _email;
		private string _phone;
		private int? _sex;
		private string _cadpath;
		private string _creosetup;
		private string _gundaosetup;
		private int _isdelete=0;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int memId
		{
			set{ _memid=value;}
			get{return _memid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userPwd
		{
			set{ _userpwd=value;}
			get{return _userpwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? userRole
		{
			set{ _userrole=value;}
			get{return _userrole;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cadPath
		{
			set{ _cadpath=value;}
			get{return _cadpath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string creoSetup
		{
			set{ _creosetup=value;}
			get{return _creosetup;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string gundaoSetup
		{
			set{ _gundaosetup=value;}
			get{return _gundaosetup;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int isDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		#endregion Model

	}
}

