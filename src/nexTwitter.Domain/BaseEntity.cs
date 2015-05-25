using System;

namespace nexTwitter.Domain
{
    public class BaseEntity
    {
		public int Id { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime LastModified { get; set; }
		public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}