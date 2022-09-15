using System;
using System.Collections.Generic;

namespace PaymentService.Models
{
    public partial class UserValidationModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
