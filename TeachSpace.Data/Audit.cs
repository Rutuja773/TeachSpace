//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeachSpace.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Audit
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ScheduleID { get; set; }
        public string Operation { get; set; }
        public string NewValue { get; set; }
        public string OldValue { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
    }
}
