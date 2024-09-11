using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi.Models.Employee
{
    public class Employees
    {
        public int Id { get; set; }
        public byte[]? Photograph { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public int? PositionId { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HiringDate { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public byte? StateId { get; set; }
        public bool? IsVisible { get; set; }
        public bool? IsBySystem { get; set; }
        public DateTime? InsertDate { get; set; }
        public Int64? InsertUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Int64? UpdateUserId { get; set; }

    }
}
