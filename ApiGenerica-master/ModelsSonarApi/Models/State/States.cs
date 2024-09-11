using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi.Models.State
{
    public class States
    {
        public byte Id { get; set; }
        public string? Name { get; set; }
        public bool? IsVisible { get; set; }
        public bool? IsBySystem { get; set; }
        public DateTime? InsertDate { get; set; }
        public Int64? InsertUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Int64? UpdateUserId { get; set; }
    }
}
