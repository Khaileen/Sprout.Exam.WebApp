using Sprout.Exam.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sprout.Exam.Business.Models
{
    public class EmployeeModel : IEmployee
    {
        public DateTime Birthdate { get; set; }
        public int EmployeeTypeId { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        public string FullName { get; set; }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Tin { get; set; }
        internal Employee ToEntity(Employee employee = null)
        {
            Employee result = employee ?? new Employee();
            result.FullName = FullName;
            result.Tin = Tin;
            result.Birthdate = Birthdate;
            result.EmployeeTypeId = EmployeeTypeId;
            result.IsDeleted = false;

            return result;
        }
    }
}
