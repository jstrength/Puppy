﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PuppyFramework.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PuppyFramework.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Puppy.
        /// </summary>
        internal static string _appTitle {
            get {
                return ResourceManager.GetString("_appTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File.
        /// </summary>
        internal static string _fileMenuHeader {
            get {
                return ResourceManager.GetString("_fileMenuHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Help.
        /// </summary>
        internal static string _helpMenuHeader {
            get {
                return ResourceManager.GetString("_helpMenuHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This method is not allowed. Use Run(RunstrapConfig) method instead..
        /// </summary>
        internal static string _invalidRunOperationException {
            get {
                return ResourceManager.GetString("_invalidRunOperationException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ShellView must a subclass of Window..
        /// </summary>
        internal static string _invalidShellTypeException {
            get {
                return ResourceManager.GetString("_invalidShellTypeException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid top level menu position {0}.
        /// </summary>
        internal static string _invalidTopLevelPositionException {
            get {
                return ResourceManager.GetString("_invalidTopLevelPositionException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You asked to add a main menu in your custom shell but there doesn&apos;t seem to be a region name {0} for adding the menu. Please add a ContentControl with a region name {0} in your shell..
        /// </summary>
        internal static string _noMainMenuContentRegionException {
            get {
                return ResourceManager.GetString("_noMainMenuContentRegionException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parameter can&apos;t be null. {0} Called from: Line #{1} {2} in {3.
        /// </summary>
        internal static string _parameterNullException {
            get {
                return ResourceManager.GetString("_parameterNullException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} Called from: Line #{1} {2} in {3}.
        /// </summary>
        internal static string _valueNullExceptionPattern {
            get {
                return ResourceManager.GetString("_valueNullExceptionPattern", resourceCulture);
            }
        }
    }
}
