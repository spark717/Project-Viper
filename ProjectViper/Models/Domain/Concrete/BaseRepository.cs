using ProjectViper.Models.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectViper.Models.Domain.Entities;

namespace ProjectViper.Models.Domain.Concrete
{
    /// <summary>
    /// DB + EF repository
    /// </summary>
    public class BaseRepository : IRepository
    {
        // ctor
        public BaseRepository(IFileManager fm)
        {
            context = new EFDBContext();
            FileManager = fm;
        }

        /// <summary>
        /// EntityFramework context
        /// </summary>
        private EFDBContext context;

        /// <summary>
        /// Access to file system
        /// </summary>
        public IFileManager FileManager { get; set; }

        public IQueryable<Tag> Tags => context.Tags;
        public IQueryable<FileMeta> Files => context.Files;

        public void AddTag(Tag tag)
        {
            context.Tags.Add(tag);
            context.SaveChanges();
        }

        public bool DeleteTag(string name)
        {
            Tag tagForDelete = Tags.FirstOrDefault(t => t.Name == name);

            if (tagForDelete == null)
                return false;

            context.Tags.Remove(tagForDelete);
            context.SaveChanges();

            return true;
        }
    }
}