using System;

namespace Domain.Models
{
    public class BaseModel
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _createAt;
        public DateTime CreateAt
        {
            get { return _createAt; }
            set
            {
                _createAt = value == null ? DateTime.UtcNow : value;
            }
        }

        private DateTime _updatedAt;
        public DateTime UpdateAt
        {
            get { return _updatedAt; }
            set { _updatedAt = value; }
        }
    }
}
