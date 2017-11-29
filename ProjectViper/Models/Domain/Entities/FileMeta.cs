using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViper.Models.Domain.Entities
{
    [Table("Files")]
    public class FileMeta
    {
        public FileMeta()
        {
            Tags = new List<Tag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Dir { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
