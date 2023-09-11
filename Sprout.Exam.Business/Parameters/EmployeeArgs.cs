using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Business.Parameters
{
    public class CalculateSalaryArgs
    {
        public int Id { get; set; }
        public decimal AbsentDays { get; set; }
        public decimal WorkedDays { get; set; }
    }
}
