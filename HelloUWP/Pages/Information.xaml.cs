using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using HelloUWP.Entity;
using HelloUWP.Service;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HelloUWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Information : Page
    {
        private MemberService memberService;

        public Information()
        {
            this.InitializeComponent();
            memberService = new MemberServiceIpm();
            var member = memberService.GetInformation();
            this.Avatar.ProfilePicture = new BitmapImage(new Uri(member.avatar));
            this.Name.Text = "  " + member.firstName + " " + member.lastName;
            this.Birthday.Text = "  " + member.birthday;
            this.Phone.Text = "  " + member.phone;
            this.Email.Text = "  " + member.email;
            this.Gender.Text = "  " + (member.gender == 1 ? "Male" : "Female");
            this.Address.Text = "  " + member.address;
            this.Introduction.Text = "  " + member.introduction;
        }
    }
}
