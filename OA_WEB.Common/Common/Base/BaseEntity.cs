using System;
using System.ComponentModel.DataAnnotations;

namespace OA_WEB.Common.Base
{
    public class BaseEntity
    {
        [MaxLength(100)]
        public virtual string CreatedBy { get; set; }

        [MaxLength(100)]
        public virtual string ModifiedBy { get; set; }

        public virtual DateTime? CreatedDate { get; set; }

        public virtual DateTime? ModifiedDate { get; set; }
    }
}