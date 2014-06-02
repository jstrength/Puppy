﻿#region Usings

using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.ServiceLocation;
using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

#endregion

namespace PuppyFramework.Bootstrap
{
    [Export(typeof(IModuleInitializer))]
    public class PuppyModuleInitializer : MefModuleInitializer
    {
        #region Fields

        private readonly ILoggerFacade _loggerFacade;
        private readonly DevNullModule _devNullModule;
        private IModuleLoader _moduleLoader;

        #endregion

        #region Properties

        [Import(AllowDefault = true)]
        private IModuleLoader ModuleLoader
        {
            get { return _moduleLoader; }
            set
            {
                _moduleLoader = value;
                _loggerFacade.Log(string.Format("ModuleLoader {0} will be used to determine whether a module can be added or not", ModuleLoader.GetType().Name), Category.Info, Priority.Medium);
            }
        }

        #endregion

        #region Constructors

        [ImportingConstructor]
        public PuppyModuleInitializer(IServiceLocator serviceLocator, ILoggerFacade loggerFacade, DownloadedPartCatalogCollection downloadedPartCatalogs, AggregateCatalog aggregateCatalog)
            : base(serviceLocator, loggerFacade, downloadedPartCatalogs, aggregateCatalog)
        {
            _loggerFacade = loggerFacade;
            _devNullModule = new DevNullModule();
            _loggerFacade.Log(string.Format("Custom ModuleInitializer {0} created", GetType().Name), Category.Info, Priority.Low);
        }

        #endregion

        #region Methods

        protected override IModule CreateModule(ModuleInfo moduleInfo)
        {
            if (ModuleLoader == null || ModuleLoader.ShouldAllowNonPuppyModule())
            {
                return base.CreateModule(moduleInfo);
            }
            var type = Type.GetType(moduleInfo.ModuleType,
                name => AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(assembly => assembly.GetName().Name.Equals(name.Name)), null);

            if (type == null)
            {
                _loggerFacade.Log(string.Format("Type for module {0} returned null. This module won't be created and initialized.", moduleInfo.ModuleName), Category.Warn, Priority.High);
                return _devNullModule;
            }

            var exportAttribute = Attribute.GetCustomAttribute(type, typeof(PuppyModuleExportAttribute)) as PuppyModuleExportAttribute;
            if (exportAttribute == null)
            {
                _loggerFacade.Log(string.Format("Module {0} found but it isn't decorated with PuppyModuleExportAttribute. This module won't be created and initialized.", moduleInfo.ModuleName), Category.Warn, Priority.High);
                return _devNullModule;
            }
            if (ModuleLoader.ShouldLoadModuleWithAttribute(exportAttribute))
            {
                _loggerFacade.Log(string.Format("{0} has been accepted.", moduleInfo.ModuleName), Category.Info, Priority.Medium);
                return base.CreateModule(moduleInfo);
            }
            _loggerFacade.Log(string.Format("{0} has been denied. This module won't be created and initialized.", moduleInfo.ModuleName), Category.Warn, Priority.High);
            return _devNullModule;
        }

        #endregion
    }
}
