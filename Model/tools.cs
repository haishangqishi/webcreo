using System;
namespace Model
{
	/// <summary>
	/// tools:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tools
	{
		public tools()
		{}
		#region Model
		private int _toolid;
		private string _toolname;
		private string _picname;
		private int _isdelete;
		/// <summary>
		/// 
		/// </summary>
		public int toolId
		{
			set{ _toolid=value;}
			get{return _toolid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string toolName
		{
			set{ _toolname=value;}
			get{return _toolname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string picName
		{
			set{ _picname=value;}
			get{return _picname;}
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

