using Avalonia.Media.Imaging;
using DotaScope2.Models;
using DotaScope2.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaScope2.ViewModels
{

    internal class InvokerViewModel : ViewModelBase
    {
        public string InvokerGame => "Invoker Game";
        public string Spells => "Spells";
        public string StartGame => "StartGame";
        public string ColdSnap => "Cold snap";
        public string GhostWalk => "Ghost Walk";
        public string IceWall => "Ice Wall";
        public string EMP => "EMP";
        public string Tornado => "Tornado";
        public string Alacrity => "Alacrity";
        public string SunStrike => "Sun Strike";
        public string ForgeSpirit => "Forge Spirit";
        public string ChaosMeteor => "Chaos Meteor";
        public string DeafeningBlast => "Deafening Blast";

        public Bitmap? ImageFromBinding { get; set; } = ImageHelper.LoadFromResource(new("avares://DotaScope2/Assets/Exort_icon.png"));

        private Bitmap? _FirstBall;
        public Bitmap? FirstBall
        {
            get {
                return _FirstBall; }
            private set => this.RaiseAndSetIfChanged(ref _FirstBall, value);
        }
        private Bitmap? _SecondBall;
        public Bitmap? SecondBall
        {
            get { return _SecondBall; }
            private set => this.RaiseAndSetIfChanged(ref _SecondBall, value);
        }
        private Bitmap? _ThirdBall;
        public Bitmap? ThirdBall
        {
            get { return _ThirdBall; }
            private set => this.RaiseAndSetIfChanged(ref _ThirdBall, value);
        }
        private ObservableCollection<string> _ballsCollection;
        public ObservableCollection<string> BallsCollection
        {
            get
            {
                return _ballsCollection ?? (_ballsCollection = new ObservableCollection<string> { null, null, null });
            }
            set
            {
                _ballsCollection = value;
                OnPropertyChanged(nameof(String));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
        private void setImages()
        {
            Dictionary<string, string> ballsImagesMap = new Dictionary<string, string>();

            // Добавляем элементы в карту
            ballsImagesMap["Q"] = "avares://DotaScope2/Assets/Quas_icon.png";
            ballsImagesMap["W"] = "avares://DotaScope2/Assets/Wex_icon.png";
            ballsImagesMap["E"] = "avares://DotaScope2/Assets/Exort_icon.png";

            System.Diagnostics.Debug.WriteLine(ballsImagesMap[BallsCollection[0]] );

            FirstBall = ImageHelper.LoadFromResource(new Uri(ballsImagesMap[BallsCollection[0]]));
            if (BallsCollection[1] != null) {
                SecondBall = ImageHelper.LoadFromResource(new Uri(ballsImagesMap[BallsCollection[1]]));
            }
            if (BallsCollection[2] != null) {
                ThirdBall = ImageHelper.LoadFromResource(new Uri(ballsImagesMap[BallsCollection[2]]));
            }
            System.Diagnostics.Debug.WriteLine("пук");
        }

        public void addBallToCache(string Ball)
        {
            BallsCollection[2] = BallsCollection[1];
            BallsCollection[1] = BallsCollection[0];
            BallsCollection[0] = Ball;
            setImages();
            System.Diagnostics.Debug.WriteLine(BallsCollection.ToString());
        }

        // [e q w]

    }
}
