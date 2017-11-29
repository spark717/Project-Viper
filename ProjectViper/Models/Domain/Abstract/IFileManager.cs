using ProjectViper.Models.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViper.Models.Domain.Abstract
{
    /// <summary>
    /// Interface provide access to file system
    /// </summary>
    public interface IFileManager
    {
        IFileManager SetPath(string path);

        ICollection<Concrete.FileInfo> GetRootDirs();

        ICollection<Concrete.FileInfo> GetChildDirs();

        ICollection<Concrete.FileInfo> GetChildFiles();

        string GetDirName();
    }
}