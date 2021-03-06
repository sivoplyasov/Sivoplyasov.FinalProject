﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sivoplyasov.FinalProject.Common.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public int CountOfPosts { get; set; }

        public bool IsBaned { get; set; }

        public DateTime DateOfRegistration { get; set; }
    }
}
