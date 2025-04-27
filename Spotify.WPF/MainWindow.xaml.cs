using NAudio.Wave;
using Spotify.Application.Interfaces;
using Spotify.Application.Services;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Spotify.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IMusicService _musicService = new MusicManager();

        public MainWindow()
        {
            InitializeComponent();
            LoadMusics();
        }

        private void LoadMusics()
        {
            var musics = _musicService.GetAll();
            cmbMusics.Items.Clear();

            foreach (var music in musics)
            {
                cmbMusics.Items.Add(music.MusicFilePath);
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            string BasePath = "D://";
            string musicPath = BasePath + cmbMusics.SelectedItem.ToString();
            //_musicService.PlayMusic(musicPath);

            using (var ms = File.OpenRead(musicPath))
            using (var rdr = new Mp3FileReader(ms))
            using (var wavStream = WaveFormatConversionStream.CreatePcmStream(rdr))
            using (var baStream = new BlockAlignReductionStream(wavStream))
            using (var waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
            {
                waveOut.Init(baStream);
                waveOut.Play();
                while (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(100);
                }
            }


        }
    }
}