using System;
namespace Model
{
	/// <summary>
	/// tooldetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class toolDetail
	{
		public toolDetail()
		{}
		#region Model
		private int _todeid;
		private int? _toolid;
		private string _toolpara;
		private string _toolparavalue;
		private int _isdelete;
		/// <summary>
		/// 
		/// </summary>
		public int todeId
		{
			set{ _todeid=value;}
			get{return _todeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? toolId
		{
			set{ _toolid=value;}
			get{return _toolid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string toolPara
		{
			set{ _toolpara=value;}
			get{return _toolpara;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string toolParaValue
		{
			set{ _toolparavalue=value;}
			get{return _toolparavalue;}
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

