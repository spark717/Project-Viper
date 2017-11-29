using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViper.Models.Domain.Entities
{
    public class Tag
    {
        public Tag()
        {
            Files = new List<FileMeta>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<FileMeta> Files { get; set; }
    }
}