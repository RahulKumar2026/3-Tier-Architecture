using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogicLayer.DTOs
{
    public class GetEmployeeDto
    {

        public string? EmployeeName { get; set; }

        public decimal? Salary { get; set; }

        public int? DepartmentId { get; set; }

        public string? DepartmentName { get; set; }
    }
}
