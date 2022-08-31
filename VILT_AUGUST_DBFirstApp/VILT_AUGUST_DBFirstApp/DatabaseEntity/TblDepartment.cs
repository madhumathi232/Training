using System;
using System.Collections.Generic;

namespace VILT_AUGUST_DBFirstApp.DatabaseEntity
{
    public partial class TblDepartment
    {
        public TblDepartment()
        {
            TblStudents = new HashSet<TblStudent>();
        }

        public int DeptId { get; set; }
        public string? DeptName { get; set; }

        public virtual ICollection<TblStudent> TblStudents { get; set; }
    }
}
