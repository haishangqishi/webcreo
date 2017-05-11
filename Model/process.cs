using System;
namespace Model
{
	/// <summary>
	/// process:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class process
	{
		public process()
		{}
		#region Model
		private int _procid;
		private int? _machid;
		private int? _toolid;
		private string _procname;
		private int _isdelete;
		/// <summary>
		/// 
		/// </summary>
		public int procId
		{
			set{ _procid=value;}
			get{return _procid;}
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
		public int? toolId
		{
			set{ _toolid=value;}
			get{return _toolid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string procName
		{
			set{ _procname=value;}
			get{return _procname;}
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

