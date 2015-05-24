using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nexTwitter.Business.ApplicationServices
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
