using System.Collections.ObjectModel;
using HelloUWP.Entity;

namespace HelloUWP.Service
{
    interface ISongService
    {
        Song PostSongFree(Song song);

        ObservableCollection<Song> GetFreeSongs();
    }
}