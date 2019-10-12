using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using HelloUWP.Entity;
using HelloUWP.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using String = System.String;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HelloUWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        private MemberService memberService;
        public Login()
        {
            this.InitializeComponent();
            memberService = new MemberServiceIpm();
        }

        private void ButtonLogin_OnClick(object sender, RoutedEventArgs e)
        {
            memberService.Login(Email.Text, Password.Password);
            ResetLoginForm();
        }

        private void ButtonReset_OnClick(object sender, RoutedEventArgs e)
        {
            ResetLoginForm();
        }

        private void ResetLoginForm()
        {
            this.Email.Text = string.Empty;
            this.Password.Password = string.Empty;
        }
    }
}
