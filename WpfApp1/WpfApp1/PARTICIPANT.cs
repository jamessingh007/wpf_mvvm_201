//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class PARTICIPANT
    {
        public int ParticipantID { get; set; }
        public string ParticipantName { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<int> BatchID { get; set; }
        public string CourseRegistered { get; set; }
        public Nullable<System.DateTime> DateofRegistration { get; set; }
    
        public virtual BATCH BATCH { get; set; }
    }
}
