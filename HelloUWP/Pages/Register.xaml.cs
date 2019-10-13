using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Resources;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using HelloUWP.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using Windows.UI.Xaml.Media.Imaging;
using HelloUWP.Constant;
using HelloUWP.Service;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HelloUWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Register : Page
    {
        private MemberService memberService;
        private StorageFile photo;
        private int sex;
        public Register()
        {
            this.InitializeComponent();
            this.memberService = new MemberServiceIpm();
        }

        private void ButtonRegister_OnClick(object sender, RoutedEventArgs e)
        {
            var member = new Member
            {
                firstName = this.firstName.Text,
                lastName = this.lastName.Text,
                avatar = this.ImageUrl.Text,
                phone = this.phone.Text,
                address = this.address.Text,
                introduction = this.introduction.Text,
                gender = sex,
                birthday = this.birthday.Text,
                email = this.email.Text,
                password = this.password.Password
            };

            Dictionary<String, String> errors = member.Validate();
            if (errors.Count == 0)
            {
                member = memberService.Register(member);
                if (member == null)
                {
                    // show error
                }
                else
                {
                    // show success
                }
            }
            else
            {
                ValidateRegister(errors);
            }
        }

        private async void ButtonImage_OnClick(object sender, RoutedEventArgs e)
        {
            // get upload url
            HttpClient client = new HttpClient();
            var uploadUrl = client.GetAsync("https://2-dot-backup-server-003.appspot.com/get-upload-token").Result.Content.ReadAsStringAsync().Result;
            Debug.WriteLine("Upload url: " + uploadUrl);

            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);

            this.photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if (this.photo == null)
            {
                // User cancelled photo capture
                return;
            }

            HttpUploadFile(uploadUrl, "myFile", "image/png");

            //StorageFolder destinationFolder =
            //    await ApplicationData.Current.LocalFolder.CreateFolderAsync("ProfilePhotoFolder",
            //        CreationCollisionOption.OpenIfExists);

            //await photo.CopyAsync(destinationFolder, "ProfilePhoto.jpg", NameCollisionOption.ReplaceExisting);

            //var randomAccessStream = await photo.OpenAsync(FileAccessMode.Read);

            //BitmapImage bitmapImage = new BitmapImage();
            //bitmapImage.SetSource(randomAccessStream);

            //ImageControl.Source = bitmapImage;

        }

        public async void HttpUploadFile(string url, string paramName, string contentType)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";

            Stream rs = await wr.GetRequestStreamAsync();
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string header = string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n", paramName, "path_file", contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            // write file.
            Stream fileStream = await this.photo.OpenStreamForReadAsync();
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);

            WebResponse wresp = null;
            try
            {
                wresp = await wr.GetResponseAsync();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                //Debug.WriteLine(string.Format("File uploaded, server response is: @{0}@", reader2.ReadToEnd()));
                //string imgUrl = reader2.ReadToEnd();
                //Uri u = new Uri(reader2.ReadToEnd(), UriKind.Absolute);
                //Debug.WriteLine(u.AbsoluteUri);
                //ImageUrl.Text = u.AbsoluteUri;
                //MyAvatar.Source = new BitmapImage(u);
                //Debug.WriteLine(reader2.ReadToEnd());
                string imageUrl = reader2.ReadToEnd();
                Debug.WriteLine(imageUrl);
                ImageControl.Source = new BitmapImage(new Uri(imageUrl, UriKind.Absolute));
                ImageUrl.Text = imageUrl;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error uploading file", ex.StackTrace);
                Debug.WriteLine("Error uploading file", ex.InnerException);
                if (wresp != null)
                {
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }
        }

        private void RadioButtonMale_OnChecked(object sender, RoutedEventArgs e)
        {
            sex = 1;
        }

        private void RadioButtonFemale_OnChecked(object sender, RoutedEventArgs e)
        {
            sex = 0;
        }

        private void ValidateRegister(Dictionary<string, string> errors)
        {
            if (errors.ContainsKey("firstName"))
            {
                errorFirstName.Text = errors["firstName"];
                errorFirstName.Visibility = Visibility.Visible;
            }
            else
            {
                errorFirstName.Visibility = Visibility.Collapsed;
            }
            if (errors.ContainsKey("lastName"))
            {
                errorLastName.Text = errors["lastName"];
                errorLastName.Visibility = Visibility.Visible;
            }
            else
            {
                errorLastName.Visibility = Visibility.Collapsed;
            }
            if (errors.ContainsKey("avatar"))
            {
                errorAvatar.Text = errors["avatar"];
                errorAvatar.Visibility = Visibility.Visible;
            }
            else
            {
                errorAvatar.Visibility = Visibility.Collapsed;
            }
            if (errors.ContainsKey("phone"))
            {
                errorPhone.Text = errors["phone"];
                errorPhone.Visibility = Visibility.Visible;
            }
            else
            {
                errorPhone.Visibility = Visibility.Collapsed;
            }
            if (errors.ContainsKey("birthday"))
            {
                errorBirthday.Text = errors["birthday"];
                errorBirthday.Visibility = Visibility.Visible;
            }
            else
            {
                errorBirthday.Visibility = Visibility.Collapsed;
            }
            if (errors.ContainsKey("address"))
            {
                errorAddress.Text = errors["address"];
                errorAddress.Visibility = Visibility.Visible;
            }
            else
            {
                errorAddress.Visibility = Visibility.Collapsed;
            }
            if (errors.ContainsKey("email"))
            {
                errorEmail.Text = errors["email"];
                errorEmail.Visibility = Visibility.Visible;
            }
            else
            {
                errorEmail.Visibility = Visibility.Collapsed;
            }
            if (errors.ContainsKey("password"))
            {
                errorPassword.Text = errors["password"];
                errorPassword.Visibility = Visibility.Visible;
            }
            else
            {
                errorPassword.Visibility = Visibility.Collapsed;
            }
            if (errors.ContainsKey("introduction"))
            {
                errorIntroduction.Text = errors["introduction"];
                errorIntroduction.Visibility = Visibility.Visible;
            }
            else
            {
                errorIntroduction.Visibility = Visibility.Collapsed;
            }
            if (this.gender_male.IsChecked == false && this.gender_female.IsChecked == false)
            {
                errorGender.Text = "Gender is not selected!";
                errorGender.Visibility = Visibility.Visible;
            }
            else
            {
                errorGender.Visibility = Visibility.Collapsed;
            }
        }

        private void ButtonReset_OnClick(object sender, RoutedEventArgs e)
        {
            this.firstName.Text = string.Empty;
            errorFirstName.Visibility = Visibility.Collapsed;
            this.lastName.Text = string.Empty;
            errorLastName.Visibility = Visibility.Collapsed;
            this.email.Text = string.Empty;
            errorEmail.Visibility = Visibility.Collapsed;
            this.password.Password = string.Empty;
            errorPassword.Visibility = Visibility.Collapsed;
            this.birthday.Text = string.Empty;
            errorBirthday.Visibility = Visibility.Collapsed;
            this.phone.Text = string.Empty;
            errorPhone.Visibility = Visibility.Collapsed;
            this.address.Text = string.Empty;
            errorAddress.Visibility = Visibility.Collapsed;
            this.introduction.Text = string.Empty;
            errorIntroduction.Visibility = Visibility.Collapsed;
            this.gender_male.IsChecked = false;
            this.gender_female.IsChecked = false;
            errorGender.Visibility = Visibility.Collapsed;
            this.ImageUrl.Text = string.Empty;
            //this.ImageControl.Visibility = Visibility.Collapsed;
            errorAvatar.Visibility = Visibility.Collapsed;
        }
    }
}
