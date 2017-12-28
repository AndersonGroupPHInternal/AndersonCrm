using AndersonCRMData;
using AndersonCRMFunction;
using System;

using Unity;
using Unity.Mvc;

namespace AndersonCRMWeb
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            #region Data
            container.RegisterType<IDCompany, DCompany>(new PerRequestLifetimeManager());
            container.RegisterType<IDDepartment, DDepartment>(new PerRequestLifetimeManager());
            container.RegisterType<IDEmployee, DEmployee>(new PerRequestLifetimeManager());
            container.RegisterType<IDEmployeeDepartment, DEmployeeDepartment>(new PerRequestLifetimeManager());
            container.RegisterType<IDEmployeeTeam, DEmployeeTeam>(new PerRequestLifetimeManager());
            container.RegisterType<IDJobTitle, DJobTitle>(new PerRequestLifetimeManager());
            container.RegisterType<IDAsset, DAsset>(new PerRequestLifetimeManager());
            container.RegisterType<IDAssetHistory, DAssetHistory>(new PerRequestLifetimeManager());
            container.RegisterType<IDAssetType, DAssetType>(new PerRequestLifetimeManager());
            container.RegisterType<IDTeam, DTeam>(new PerRequestLifetimeManager());
            #endregion

            #region Function
            container.RegisterType<IFCompany, FCompany>(new PerRequestLifetimeManager());
            container.RegisterType<IFDepartment, FDepartment>(new PerRequestLifetimeManager());
            container.RegisterType<IFEmployee, FEmployee>(new PerRequestLifetimeManager());
            container.RegisterType<IFEmployeeDepartment, FEmployeeDepartment>(new PerRequestLifetimeManager());
            container.RegisterType<IFEmployeeTeam, FEmployeeTeam>(new PerRequestLifetimeManager());
            container.RegisterType<IFJobTitle, FJobTitle>(new PerRequestLifetimeManager());
            container.RegisterType<IFAsset, FAsset>(new PerRequestLifetimeManager());
            container.RegisterType<IFAssetType, FAssetType>(new PerRequestLifetimeManager());
            container.RegisterType<IFTeam, FTeam>(new PerRequestLifetimeManager());
            #endregion
        }
    }
}