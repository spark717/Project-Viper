using ProjectViper.Models.Domain.Abstract;
using ProjectViper.Models.Domain.Concrete;
using ProjectViper.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectViper.Controllers
{
    /// <summary>
    /// Remote acces to file system of pc
    /// </summary>
    public class FileManagerController : Controller
    {
        public FileManagerController(IRepository repo)
        {
            this.repo = repo;
        }

        IRepository repo;
        IFileManager FM => repo.FileManager;

        /// <summary>
        /// Main page
        /// </summary>
        [HttpGet]
        public ActionResult FileBrowser()
        {
            return View();
        }

        /// <summary>
        /// AJAX request for input dir elemets
        /// </summary>
        [HttpPost]
        public JsonResult GetDirElements(string path)
        {
            FileBrowserViewModel model = new FileBrowserViewModel();

            if (path == "root")
            {
                model.ChildDirs = FM.GetRootDirs();
                model.ChildFiles = new List<FileInfo>();
                model.CurrentDir = new FileInfo()
                {
                    Name = "Root",
                    FullPath = "root"
                };
            }
            else
            {
                FM.SetPath(path);

                model.ChildDirs = FM.GetChildDirs();
                model.ChildFiles = FM.GetChildFiles();
                model.CurrentDir = new FileInfo()
                {
                    Name = FM.GetDirName(),
                    FullPath = path
                };
            }

            return Json(model);
        }
    }
}