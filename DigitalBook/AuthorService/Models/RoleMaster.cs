using MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuthorService.Models
{
    public partial class RoleMaster
    {
        public RoleMaster()
        {
            UserTables = new HashSet<UserTable>();
        }

        [System.ComponentModel.DataAnnotations.Key]
        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        public virtual ICollection<UserTable> UserTables { get; set; }
    }
}
