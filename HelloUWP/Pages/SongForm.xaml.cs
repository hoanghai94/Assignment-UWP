using System;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Navigation;
using HelloUWP.Entity;
using HelloUWP.Service;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HelloUWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SongForm : Page
    {
        private ISongService songService;
        public SongForm()
        {
            this.InitializeComponent();
            songService = new SongServiceIpm();
        }

        private void ButtonUpload_OnClick(object sender, RoutedEventArgs e)
        {
            Song song = new Song()
            {
                name = this.name.Text,
                description = this.description.Text,
                singer = this.singer.Text,
                author = this.author.Text,
                thumbnail = this.thumbnail.Text,
                link = this.link.Text
            };

            Dictionary<String, String> errors = song.Validate();
            if (errors.Count == 0)
            {
                songService.PostSongFree(song);
            }
            else
            {
                if (errors.ContainsKey("name"))
                {
                    errorName.Text = errors["name"];
                    errorName.Visibility = Visibility.Visible;
                }
                else
                {
                    errorName.Visibility = Visibility.Collapsed;
                }
                if (errors.ContainsKey("thumbnail"))
                {
                    errorThumbnail.Text = errors["thumbnail"];
                    errorThumbnail.Visibility = Visibility.Visible;
                }
                else
                {
                    errorThumbnail.Visibility = Visibility.Collapsed;

                }
                if (errors.ContainsKey("link"))
                {
                    errorLink.Text = errors["link"];
                    errorLink.Visibility = Visibility.Visible;
                }
                else
                {
                    errorLink.Visibility = Visibility.Collapsed;

                }
            }
        }

        private void ButtonReset_OnClick(object sender, RoutedEventArgs e)
        {
            this.name.Text = string.Empty;
            this.errorName.Text = string.Empty;
            this.description.Text = string.Empty;
            this.singer.Text = string.Empty;
            this.author.Text = string.Empty;
            this.thumbnail.Text = string.Empty;
            this.errorThumbnail.Text = string.Empty;
            this.link.Text = string.Empty;
            this.errorLink.Text = string.Empty;
        }
    }
}
