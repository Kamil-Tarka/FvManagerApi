using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FvManagerApi.Entities;

namespace FvManagerApi.Models
{
    public class UpdateUserDto
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        [MinLength(8)]
        public string OldPassword { get; set; }
        [MinLength(8)]
        public string NewPassword { get; set; }
        public int RoleId { get; set; }
    }
}
