using Sprout.Exam.Business.Models;
using Sprout.Exam.Business.Parameters;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;


namespace Sprout.Exam.Business.Logic
{
    public static class EmployeeLogic
    {
        public static List<IEmployee> Get()
        {
            using (var context = new SproutExamDbContext())
            {
                return context.Employees.Where(x => !x.IsDeleted).ToList<IEmployee>();
            }
        }

        public static IEmployee GetById(int id)
        {
            using(var context = new SproutExamDbContext())
            {
                return context.Employees.FirstOrDefault(x => x.Id == id);
            }
        }

        public static int Create(EmployeeModel employee)
        {
            using(var context = new SproutExamDbContext())
            {
                var entity = employee.ToEntity();
                context.Employees.Add(entity);
                context.SaveChanges();
                return entity.Id;
            }
        }

        public static EmployeeModel Update(EmployeeModel employee)
        {
            using (var context = new SproutExamDbContext())
            {
                var entity = context.Employees.FirstOrDefault(x => x.Id == employee.Id);
                if (entity != null)
                {
                    employee.ToEntity(entity);
                    context.SaveChanges();
                    return employee;
                }

                return null;
            }
        }

        public static int Delete(int id)
        {
            int result = 0;
            using (var context = new SproutExamDbContext())
            {
                var employee = context.Employees.FirstOrDefault(x => x.Id == id);
                if (employee != null)
                {
                    employee.IsDeleted = true;
                    context.SaveChanges();
                    result = id;
                }
            }

            return result;
        }

        public static object CalculateSalary(CalculateSalaryArgs args)
        {
            object result = null;

            using(var context = new SproutExamDbContext())
            {
                var employee = context.Employees.FirstOrDefault(x=> x.Id == args.Id);
                if (employee == null)
                {
                    return result;
                }
                                
                var type = (Common.Enums.EmployeeType)employee.EmployeeTypeId;                
                switch (type)
                {
                    case Common.Enums.EmployeeType.Regular:
                        decimal salary = 20000;
                        decimal deductions = args.AbsentDays * (salary / 22);
                        decimal taxBase = salary - deductions;

                        /// NET PAY
                        /// Tax should be deducted AFTER deductions are applied.
                        result = taxBase - (taxBase * 0.12M);
                        break;
                    case Common.Enums.EmployeeType.Contractual:
                        decimal dailyRate = 500;
                        result = dailyRate * args.WorkedDays;
                        break;
                    default:
                        break;
                }
            }

            return result;
        }
    }
}
