using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTOs
{
    public class OrderUpdateDTO
    {
        public int OrderId { get; set; }
        public string Status { get; set; } = default!;
        public string? Notes { get; set; }
    }
}
