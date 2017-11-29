using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using ProjectViper.Models.Domain.Abstract;
using ProjectViper.Models.Domain.Concrete;

namespace ProjectViper.DI
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        public NinjectControllerFactory()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        IKernel kernel;

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return null;
            else
                return (IController)kernel.Get(controllerType);
        }

        /// <summary>
        /// Set interface to object bindings
        /// </summary>
        private void AddBindings()
        {
            kernel.Bind<IFileManager>().To<WindowsFileManager>();
            kernel.Bind<IRepository>().ToConstant(new BaseRepository(kernel.Get<IFileManager>()));
        }
    }
}
