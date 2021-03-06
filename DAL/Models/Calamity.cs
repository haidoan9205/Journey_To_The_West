﻿using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Calamity
    {
        public Calamity()
        {
            History = new HashSet<History>();
        }

        public int CalamityId { get; set; }
        public string CalamityName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? NumberOfFilming { get; set; }
        public string RoleSpecification { get; set; }
        public int? Status { get; set; }
        public bool? IsActive { get; set; }
        public int? ActorId { get; set; }
        public int? EquipmentId { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual StatusDetailed StatusNavigation { get; set; }
        public virtual ICollection<History> History { get; set; }
    }
}
