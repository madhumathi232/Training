using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AuthorService.Models
{
    public partial class UserTable
    {
        public UserTable()
        {
            Books = new HashSet<Book>();
        }
        [Key]
        public int UserId { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? EmailId { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        private int? roleId;
        public int? RoleId {
            get { return roleId; } set{ roleId = 1; } }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
    
        public bool? Active { get; set; }

        public virtual RoleMaster? Role { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
