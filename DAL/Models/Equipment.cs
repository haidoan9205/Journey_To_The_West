﻿using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            Calamity = new HashSet<Calamity>();
            History = new HashSet<History>();
        }

        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public bool? IsActive { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Calamity> Calamity { get; set; }
        public virtual ICollection<History> History { get; set; }
    }
}
