using System;
using System.Collections.Generic;

namespace VILT_AUGUST_DBFirstApp.DatabaseEntity
{
    public partial class TblStudent
    {
        public int StudId { get; set; }
        public string? Name { get; set; }
        public int? DeptId { get; set; }

        public virtual TblDepartment? Dept { get; set; }
    }
}
