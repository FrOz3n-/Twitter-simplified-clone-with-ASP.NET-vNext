using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nexTwitter.Domain.Entities
{
    public class UserWithFollower : BaseEntity
    {
        public int UserId { get; set; }
        public int FollowerId { get; set; }

        public virtual User User { get; set; }
        public virtual User UserFollower { get; set; }
    }
}
