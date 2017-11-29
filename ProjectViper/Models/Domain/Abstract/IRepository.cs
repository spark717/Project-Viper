using ProjectViper.Models.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViper.Models.Domain.Abstract
{
    public interface IRepository
    {
        IFileManager FileManager { get; set; }

        IQueryable<Tag> Tags { get; }
        IQueryable<FileMeta> Files { get; }

        void AddTag(Tag tag);
        bool DeleteTag(string name);
    }
}
