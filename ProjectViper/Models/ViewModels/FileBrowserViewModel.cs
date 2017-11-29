using ProjectViper.Models.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViper.Models.ViewModels
{
    /// <summary>
    /// Data for view. Contains information about current directory
    /// </summary>
    public class FileBrowserViewModel
    {
        public FileInfo CurrentDir { get; set; }
        public ICollection<FileInfo> ChildDirs { get; set; }
        public ICollection<FileInfo> ChildFiles { get; set; }
        public string PathType { get; set; }    // win or linux
    }
}
