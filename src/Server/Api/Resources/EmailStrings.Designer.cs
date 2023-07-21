﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bit.AdminPanel.Server.Api.Resources {
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
    public class EmailStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal EmailStrings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Bit.AdminPanel.Server.Api.Resources.EmailStrings", typeof(EmailStrings).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Bit.AdminPanel.
        /// </summary>
        public static string AppName {
            get {
                return ResourceManager.GetString("AppName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Bit.AdminPanel - Confirm your email address.
        /// </summary>
        public static string ConfirmationEmailSubject {
            get {
                return ResourceManager.GetString("ConfirmationEmailSubject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Confirm email.
        /// </summary>
        public static string ConfirmEmail {
            get {
                return ResourceManager.GetString("ConfirmEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Or, copy the link below to your browser address bar:.
        /// </summary>
        public static string CopyLink {
            get {
                return ResourceManager.GetString("CopyLink", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You&apos;re receiving this message because recently you have signed up for a Bit.AdminPanel account.
        ///                    Confirm your email address by clicking the button below..
        /// </summary>
        public static string EmailConfirmationMessageBody {
            get {
                return ResourceManager.GetString("EmailConfirmationMessageBody", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Bit.AdminPanel - Reset your password.
        /// </summary>
        public static string ResetPasswordEmailSubject {
            get {
                return ResourceManager.GetString("ResetPasswordEmailSubject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hello {0}.
        /// </summary>
        public static string ResetPasswordHello {
            get {
                return ResourceManager.GetString("ResetPasswordHello", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Someone has requested a link to change your password..
        /// </summary>
        public static string ResetPasswordMessage {
            get {
                return ResourceManager.GetString("ResetPasswordMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your password won&apos;t change until you access the link above and create a new one..
        /// </summary>
        public static string ResetPasswordNote {
            get {
                return ResourceManager.GetString("ResetPasswordNote", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Reset your password.
        /// </summary>
        public static string ResetYourPassword {
            get {
                return ResourceManager.GetString("ResetYourPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Welcome to Bit.AdminPanel!.
        /// </summary>
        public static string WelcomeToApp {
            get {
                return ResourceManager.GetString("WelcomeToApp", resourceCulture);
            }
        }
    }
}
