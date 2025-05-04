using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTOs
{
    public class OrderCreateDTO
    {
        public string Username { get; set; } = string.Empty;
        public List<OrderItemCreateDTO> Items { get; set; } = new();
    }

    public class OrderItemCreateDTO
    {
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
    }

}
