using System;

namespace Sprout.Exam.DataAccess.Entities
{
    public interface IEmployee
    {
        DateTime Birthdate { get; set; }
        int EmployeeTypeId { get; set; }
        string FullName { get; set; }
        int Id { get; set; }
        bool IsDeleted { get; set; }
        string Tin { get; set; }
    }
}