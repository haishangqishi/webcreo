using System;
namespace Model
{
	/// <summary>
	/// machines:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class machines
	{
		public machines()
		{}
		#region Model
		private int _machid;
		private string _machname;
		private string _picname;
		private int _isdelete;
		/// <summary>
		/// 
		/// </summary>
		public int machId
		{
			set{ _machid=value;}
			get{return _machid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string machName
		{
			set{ _machname=value;}
			get{return _machname;}
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

