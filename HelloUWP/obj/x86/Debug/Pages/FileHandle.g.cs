﻿#pragma checksum "C:\Users\Admin\source\repos\Assignment-UWP\HelloUWP\Pages\FileHandle.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DF374493C8F42E4C53094A81D17ED1BC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HelloUWP.Pages
{
    partial class FileHandle : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Pages\FileHandle.xaml line 13
                {
                    this.Email = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // Pages\FileHandle.xaml line 14
                {
                    this.Password = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 4: // Pages\FileHandle.xaml line 15
                {
                    global::Windows.UI.Xaml.Controls.Button element4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element4).Click += this.ButtonBase_OnClick;
                }
                break;
            case 5: // Pages\FileHandle.xaml line 16
                {
                    this.ImageUrl = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // Pages\FileHandle.xaml line 17
                {
                    this.ImageControl = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 7: // Pages\FileHandle.xaml line 18
                {
                    global::Windows.UI.Xaml.Controls.Button element7 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element7).Click += this.ButtonRegister_OnClick;
                }
                break;
            case 8: // Pages\FileHandle.xaml line 19
                {
                    global::Windows.UI.Xaml.Controls.Button element8 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element8).Click += this.ButtonReset_OnClick;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

