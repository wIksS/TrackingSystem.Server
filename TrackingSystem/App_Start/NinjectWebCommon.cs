[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TrackingSystem.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TrackingSystem.App_Start.NinjectWebCommon), "Stop")]

namespace TrackingSystem.App_Start
{
    using System;
    using System.Web;
    using System.Reflection;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;
    using Data;
    using Ninject.Web.WebApi;
    using System.Web.Http;
    using TrackingSystem.Services;
    using TrackingSystem.Services.Contracts;
    using TrackingSystem.Common;
    using TrackingSystem.Services.Web;
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel
                .Bind<ITrackingSystemData>()
                .To<TrackingSystemData>()
                .InRequestScope();
            
            // Call DistanceCalculatorByFormula here if you want to use it
            kernel
                .Bind<IDistanceCalculator>()
                .To<DistanceCalculator>()
                .InRequestScope();

            kernel
                .Bind<ICacheService>()
                .To<HttpCacheService>()
                .InRequestScope();

            kernel.Bind(b => b.From(Assembly.GetAssembly(typeof(StudentsService)))
               .SelectAllClasses()
               .BindDefaultInterface());
        }        
    }
}
