using System;
using System.Collections.Generic;
using System.Text;

namespace HyperGistDomain.Entity
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public string Description { get; set; }
    }
}
