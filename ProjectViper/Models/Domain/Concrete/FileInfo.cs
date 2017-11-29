using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViper.Models.Domain.Concrete
{
    /// <summary>
    /// Information about file
    /// </summary>
    public class FileInfo
    {
        public string FullPath { get; set; }
        public string Name { get; set; }
        public FileElementType ElementType { get; set; }

        public enum FileElementType
        {
            file = 1,
            dir = 2
        }
    }
}
