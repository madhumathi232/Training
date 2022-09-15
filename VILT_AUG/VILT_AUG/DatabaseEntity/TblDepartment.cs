using System;
using System.Collections.Generic;

namespace VILT_AUG.DatabaseEntity
{
    public partial class TblDepartment
    {
        public TblDepartment()
        {
            TblStudent1s = new HashSet<TblStudent1>();
        }

        public int DeptId { get; set; }
        public string? DeptName { get; set; }

        public virtual ICollection<TblStudent1> TblStudent1s { get; set; }
    }
}
