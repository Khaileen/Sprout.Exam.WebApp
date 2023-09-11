﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Sprout.Exam.DataAccess.Entities
{
    public partial class Employee : IEmployee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Tin { get; set; }
        public int EmployeeTypeId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
