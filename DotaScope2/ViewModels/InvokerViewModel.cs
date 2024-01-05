using Avalonia.Media.Imaging;
using ReactiveUI;
using System;
using System.Collections.Generic;
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

        private Task<Bitmap?> _FirstBall;
        public Task<Bitmap?> FirstBall
        {
            get { return _FirstBall; }
            private set
            {
                this.RaiseAndSetIfChanged(ref _FirstBall, value);
                System.Diagnostics.Debug.WriteLine(_FirstBall.ToString());
            }
        }
        private Task<Bitmap?> _SecondBall;
        public Task<Bitmap?> SecondBall
        {
            get { return _SecondBall; }
            private set
            {
                this.RaiseAndSetIfChanged(ref _SecondBall, value);
                System.Diagnostics.Debug.WriteLine(_SecondBall.ToString());
            }
        }
        private Task<Bitmap?> _ThirdBall;
        public Task<Bitmap?> ThirdBall
        {
            get { return _ThirdBall; }
            private set
            {
                this.RaiseAndSetIfChanged(ref _ThirdBall, value);
                System.Diagnostics.Debug.WriteLine(_ThirdBall.ToString());
            }
        }



    }
}
