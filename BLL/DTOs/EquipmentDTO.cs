using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class EquipmentDTO
    {
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
    }
}
