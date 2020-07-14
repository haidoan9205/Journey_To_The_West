using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class ActorDTO
    {
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
    }
}
