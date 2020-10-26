using System;
using System.Collections.Generic;
using System.Text;

namespace Dym.Popular.Application.Contracts.Models
{
    public class UserInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public string Avatar { get; set; }

        public DateTime SysteDate { get; set; }

    }
}
