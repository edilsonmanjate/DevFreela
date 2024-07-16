using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class Skills : BaseEntity
    {
        public Skills(string description)
        {
            Description = description;
            CreatedAt = DateTime.Now;
        }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}
