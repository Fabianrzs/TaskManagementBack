using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User:BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Collaborator> Collaborators { get; set;}
        [JsonIgnore]
        public ICollection<TaskEntity> Tasks { get; set; }
    }
}
