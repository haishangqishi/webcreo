using System;
namespace Model
{
    /// <summary>
    /// parameters:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class parameters
    {
        public parameters()
        { }
        #region Model
        private int _parmid;
        private decimal? _moshu;
        private decimal? _chigaoxishu;
        private string _xuanxiang;
        private decimal? _faxiangyalijiao;
        private decimal? _jingxiangxishu;
        private decimal? _jingduclass;
        private decimal? _waijing;
        private decimal? _kongjing;
        private decimal? _quanchang;
        private decimal? _caoxingangle;
        private string _rongxiecaoxing;
        private int? _rongxienum;
        private decimal? _dingrenangle;
        private decimal? _chiqianangle;
        private decimal? _ztdiameter;
        private decimal? _ztlength;
        private decimal? _ztdaoleng;
        private decimal? _jiancaowidth;
        private decimal? _jiancaoheight;
        private decimal? _jiancaoyuanhu;
        private decimal? _nkdiameter;
        private decimal? _nklength;
        private decimal? _aqz;
        private decimal? _aqy;
        private decimal? _hegq;
        private decimal? _sfzg;
        private decimal? _hgq;
        private decimal? _tz;
        private decimal? _r1;
        private decimal? _r2;
        private decimal? _dfg;
        private decimal? _h;
        private decimal? _lamtaf;
        private decimal? _r0;
        private decimal? _k;
        private decimal? _cerenangle;
        private int _isstandard = 0;
        private int _serail = 1;
        private int _type = 1;
        private int? _memid;
        private int? _dimnum = 0;
        private int _isdelete = 0;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int parmId
        {
            set { _parmid = value; }
            get { return _parmid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? moshu
        {
            set { _moshu = value; }
            get { return _moshu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? chigaoXishu
        {
            set { _chigaoxishu = value; }
            get { return _chigaoxishu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string xuanxiang
        {
            set { _xuanxiang = value; }
            get { return _xuanxiang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? faxiangYaLiJiao
        {
            set { _faxiangyalijiao = value; }
            get { return _faxiangyalijiao; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? jingxiangXiShu
        {
            set { _jingxiangxishu = value; }
            get { return _jingxiangxishu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? jingduClass
        {
            set { _jingduclass = value; }
            get { return _jingduclass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? waijing
        {
            set { _waijing = value; }
            get { return _waijing; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? kongjing
        {
            set { _kongjing = value; }
            get { return _kongjing; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quanchang
        {
            set { _quanchang = value; }
            get { return _quanchang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? caoxingAngle
        {
            set { _caoxingangle = value; }
            get { return _caoxingangle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rongxieCaoXing
        {
            set { _rongxiecaoxing = value; }
            get { return _rongxiecaoxing; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? rongxieNum
        {
            set { _rongxienum = value; }
            get { return _rongxienum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? dingrenAngle
        {
            set { _dingrenangle = value; }
            get { return _dingrenangle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? chiqianAngle
        {
            set { _chiqianangle = value; }
            get { return _chiqianangle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ZTDiameter
        {
            set { _ztdiameter = value; }
            get { return _ztdiameter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ZTlength
        {
            set { _ztlength = value; }
            get { return _ztlength; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ZTdaoleng
        {
            set { _ztdaoleng = value; }
            get { return _ztdaoleng; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? jiancaoWidth
        {
            set { _jiancaowidth = value; }
            get { return _jiancaowidth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? jiancaoHeight
        {
            set { _jiancaoheight = value; }
            get { return _jiancaoheight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? jiancaoYuanHu
        {
            set { _jiancaoyuanhu = value; }
            get { return _jiancaoyuanhu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? NKDiameter
        {
            set { _nkdiameter = value; }
            get { return _nkdiameter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? NKlength
        {
            set { _nklength = value; }
            get { return _nklength; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? aqz
        {
            set { _aqz = value; }
            get { return _aqz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? aqy
        {
            set { _aqy = value; }
            get { return _aqy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? hegq
        {
            set { _hegq = value; }
            get { return _hegq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? sfzg
        {
            set { _sfzg = value; }
            get { return _sfzg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? hgq
        {
            set { _hgq = value; }
            get { return _hgq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? tz
        {
            set { _tz = value; }
            get { return _tz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? r1
        {
            set { _r1 = value; }
            get { return _r1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? r2
        {
            set { _r2 = value; }
            get { return _r2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? dfg
        {
            set { _dfg = value; }
            get { return _dfg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? H
        {
            set { _h = value; }
            get { return _h; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? lamtaf
        {
            set { _lamtaf = value; }
            get { return _lamtaf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? R0
        {
            set { _r0 = value; }
            get { return _r0; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? k
        {
            set { _k = value; }
            get { return _k; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cerenAngle
        {
            set { _cerenangle = value; }
            get { return _cerenangle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int isStandard
        {
            set { _isstandard = value; }
            get { return _isstandard; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int serail
        {
            set { _serail = value; }
            get { return _serail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? memId
        {
            set { _memid = value; }
            get { return _memid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? dimNum
        {
            set { _dimnum = value; }
            get { return _dimnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int isDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        #endregion Model

    }
}

