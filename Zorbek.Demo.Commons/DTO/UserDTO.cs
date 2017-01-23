﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zorbek.Demo.Commons.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Account { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsActive { get; set; }
    }
}
