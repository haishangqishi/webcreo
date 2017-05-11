using System;
namespace Model
{
	/// <summary>
	/// machinedetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class machineDetail
	{
		public machineDetail()
		{}
		#region Model
		private int _madeid;
		private int? _machid;
		private string _machpara;
		private string _machparavalue;
		private int _isdelete;
		/// <summary>
		/// 
		/// </summary>
		public int madeId
		{
			set{ _madeid=value;}
			get{return _madeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? machId
		{
			set{ _machid=value;}
			get{return _machid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string machPara
		{
			set{ _machpara=value;}
			get{return _machpara;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string machParaValue
		{
			set{ _machparavalue=value;}
			get{return _machparavalue;}
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

