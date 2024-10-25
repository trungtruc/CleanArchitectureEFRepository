using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class AuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public bool IsDeleted { get; set; } = false;  // For soft delete
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
