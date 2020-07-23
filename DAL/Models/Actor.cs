using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Actor
    {
        public Actor()
        {
            Calamity = new HashSet<Calamity>();
            History = new HashSet<History>();
            User = new HashSet<User>();
        }

        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Calamity> Calamity { get; set; }
        public virtual ICollection<History> History { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
