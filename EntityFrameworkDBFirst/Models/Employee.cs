﻿using System;
using System.Collections.Generic;

namespace EntityFrameworkDBFirst.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
