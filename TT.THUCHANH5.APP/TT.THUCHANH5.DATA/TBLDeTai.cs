//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TT.THUCHANH5.DATA
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLDeTai
    {
        public TBLDeTai()
        {
            this.TBLHuongDans = new HashSet<TBLHuongDan>();
        }
    
        public string Madt { get; set; }
        public string Tendt { get; set; }
        public Nullable<int> Kinhphi { get; set; }
        public string Noithuctap { get; set; }
    
        public virtual ICollection<TBLHuongDan> TBLHuongDans { get; set; }
    }
}
