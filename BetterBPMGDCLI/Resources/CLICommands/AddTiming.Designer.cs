﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BetterBPMGDCLI.Resources.CLICommands {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class AddTiming {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal AddTiming() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BetterBPMGDCLI.Resources.CLICommands.AddTiming", typeof(AddTiming).Assembly);
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
        ///   Looks up a localized string similar to Adds new timing to the project. Note: current project must be specified first.
        /// </summary>
        internal static string COMMAND_DESCRIPTION {
            get {
                return ResourceManager.GetString("COMMAND_DESCRIPTION", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to timing,ti.
        /// </summary>
        internal static string COMMAND_NAME_ALIASES {
            get {
                return ResourceManager.GetString("COMMAND_NAME_ALIASES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Current project must be specified.
        /// </summary>
        internal static string ERROR_CURRENTPROJECTMUSTBESPECIFIED {
            get {
                return ResourceManager.GetString("ERROR_CURRENTPROJECTMUSTBESPECIFIED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Color patter can not be an empty string.
        /// </summary>
        internal static string ERROR_MEMBERCANNOTBEANEMPTYSTRING {
            get {
                return ResourceManager.GetString("ERROR_MEMBERCANNOTBEANEMPTYSTRING", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Color patter can not be longer than 3 characters.
        /// </summary>
        internal static string ERROR_MEMBERCANNOTBELONGERTHAN {
            get {
                return ResourceManager.GetString("ERROR_MEMBERCANNOTBELONGERTHAN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Color patter can not be any other character that o, g, y and n.
        /// </summary>
        internal static string ERROR_MEMBERCANNOTINCLUDE {
            get {
                return ResourceManager.GetString("ERROR_MEMBERCANNOTINCLUDE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Successfully added new timing.
        /// </summary>
        internal static string MESSAGE_SUCCESS {
            get {
                return ResourceManager.GetString("MESSAGE_SUCCESS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to --subdivide,-d.
        /// </summary>
        internal static string OPTION_BOOLEAN_ALIASES {
            get {
                return ResourceManager.GetString("OPTION_BOOLEAN_ALIASES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Specifies whether to subdivide beats.
        /// </summary>
        internal static string OPTION_BOOLEAN_DESCRIPTION {
            get {
                return ResourceManager.GetString("OPTION_BOOLEAN_DESCRIPTION", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to --bpm,-b.
        /// </summary>
        internal static string OPTION_DOUBLE_ALIASES {
            get {
                return ResourceManager.GetString("OPTION_DOUBLE_ALIASES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Specifies bpm for the timing.
        /// </summary>
        internal static string OPTION_DOUBLE_DESCRIPTION {
            get {
                return ResourceManager.GetString("OPTION_DOUBLE_DESCRIPTION", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to --speed,-s.
        /// </summary>
        internal static string OPTION_INT32_1_ALIASES {
            get {
                return ResourceManager.GetString("OPTION_INT32_1_ALIASES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Specifies speed for the timing. Available speeds: 0 - HALFSPEED, 1 - NORMAL SPEED, 2 - DOUBLE SPEED, 3 - TRPLE SPEED, 4 - QUADRUPLE SPEED.
        /// </summary>
        internal static string OPTION_INT32_1_DESCRIPTION {
            get {
                return ResourceManager.GetString("OPTION_INT32_1_DESCRIPTION", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to --subdivision,-n.
        /// </summary>
        internal static string OPTION_INT32_ALIASES {
            get {
                return ResourceManager.GetString("OPTION_INT32_ALIASES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Specifies beat subdivision for the timing.
        /// </summary>
        internal static string OPTION_INT32_DESCRIPTION {
            get {
                return ResourceManager.GetString("OPTION_INT32_DESCRIPTION", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to --colors,-c.
        /// </summary>
        internal static string OPTION_STRING_ALIASES {
            get {
                return ResourceManager.GetString("OPTION_STRING_ALIASES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Specifies color pattern for the guidelines. Available colors: o - orange, g - green, y - yellow, n - none. Pattern can not be longer than 3 symbols. Example: ogo (orange - green - orange).
        /// </summary>
        internal static string OPTION_STRING_DESCRIPTION {
            get {
                return ResourceManager.GetString("OPTION_STRING_DESCRIPTION", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to --offset,-o.
        /// </summary>
        internal static string OPTION_UINT64_ALIASES {
            get {
                return ResourceManager.GetString("OPTION_UINT64_ALIASES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Specifies offset for the timing.
        /// </summary>
        internal static string OPTION_UINT64_DESCRIPTION {
            get {
                return ResourceManager.GetString("OPTION_UINT64_DESCRIPTION", resourceCulture);
            }
        }
    }
}
