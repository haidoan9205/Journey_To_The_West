using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs.CalamityDTOs
{
    public class CalamityViewDTO
    {
        public int CalamityId { get; set; }
        public string CalamityName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int NumberOfFilming { get; set; }
        public string RoleSpecification { get; set; }
        public int Status { get; set; }
       // public bool IsActive { get; set; }


    }
}
