﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationPlannerWPFApp.Models
{
    public class RegisterModel
    {
        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? Info { get; set; } = string.Empty;
    }
}
