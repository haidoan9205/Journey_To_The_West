using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ActorList
    {
        public int Id { get; set; }
        public string Character { get; set; }
        public int ActorId { get; set; }
        public int CalamityId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Calamity Calamity { get; set; }
    }
}
