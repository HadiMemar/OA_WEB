using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OA_WEB.Common.Base
{
    public class BaseSoftDeletableEntity
    {
        /// <summary>
        /// Gets or Sets if the entity is deleted
        /// </summary>
        [JsonIgnore]
        public bool IsDeleted { get; set; }

        [JsonIgnore]
        public DateTime? DeletedDate { get; set; }

        [JsonIgnore]
        [MaxLength(100)]
        public string DeletedBy { get; set; }
    }
}