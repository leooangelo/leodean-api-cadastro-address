using System;

namespace MS.Address.Domain.Base
{
    public abstract class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public void SetCreatedAt(DateTime dateTime)
        {
            if (CreatedAt == null || CreatedAt == DateTime.MinValue)
                CreatedAt = dateTime;
        }

        public void SetUpdatedAt(DateTime dateTime)
        {
            UpdatedAt = dateTime;
        }
    }
}
