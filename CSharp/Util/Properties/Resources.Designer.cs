﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moreland.CSharp.Util.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Moreland.CSharp.Util.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Attempt to access left from right source.
        /// </summary>
        internal static string BadEitherAccessLeft {
            get {
                return ResourceManager.GetString("BadEitherAccessLeft", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attempt to access right from left source.
        /// </summary>
        internal static string BadEitherAccessRight {
            get {
                return ResourceManager.GetString("BadEitherAccessRight", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value cannot be empty.
        /// </summary>
        internal static string EmptyNotAllowed {
            get {
                return ResourceManager.GetString("EmptyNotAllowed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Either improply constructed, does not contain either left or right value.
        /// </summary>
        internal static string InvalidEither {
            get {
                return ResourceManager.GetString("InvalidEither", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value not available when query has failed.
        /// </summary>
        internal static string InvalidResultValueAccess {
            get {
                return ResourceManager.GetString("InvalidResultValueAccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value is not present.
        /// </summary>
        internal static string NoSuchValue {
            get {
                return ResourceManager.GetString("NoSuchValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to (null).
        /// </summary>
        internal static string NullValue {
            get {
                return ResourceManager.GetString("NullValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attempt to access unsupported source type.
        /// </summary>
        internal static string UnknownEitherAccess {
            get {
                return ResourceManager.GetString("UnknownEitherAccess", resourceCulture);
            }
        }
    }
}
