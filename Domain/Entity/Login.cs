﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Login
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
