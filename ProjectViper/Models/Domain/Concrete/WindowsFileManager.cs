using ProjectViper.Models.Domain.Abstract;
using System;
using System.Collections.Generic;
using io = System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectViper.Models.Domain.Concrete
{
    public class WindowsFileManager : IFileManager
    {
        io.DirectoryInfo dirInfo = null;

        public IFileManager SetPath(string path)
        {
            dirInfo = new io.DirectoryInfo(path);

            return this;
        }

        public ICollection<FileInfo> GetRootDirs()
        {
            return io.Directory.GetLogicalDrives().Select(d => new FileInfo() {
                Name = d,
                FullPath = d
            }).ToList();
        }

        public ICollection<FileInfo> GetChildDirs()
        {
            if (dirInfo == null)
                throw new NullReferenceException("first set path");

            return dirInfo.GetDirectories().Select(d => new FileInfo() {
                FullPath = d.FullName,
                Name = d.Name
            }).ToList();
        }

        public ICollection<FileInfo> GetChildFiles()
        {
            if (dirInfo == null)
                throw new NullReferenceException("first set path");

            return dirInfo.GetFiles().Select(d => new FileInfo()
            {
                FullPath = d.FullName,
                Name = d.Name
            }).ToList();
        }

        public string GetDirName()
        {
            if (dirInfo == null)
                throw new NullReferenceException("first set path");

            return dirInfo.Name;
        }     
    }
}
