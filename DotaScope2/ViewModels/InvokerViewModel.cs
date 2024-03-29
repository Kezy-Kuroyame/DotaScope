﻿using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using DotaScope2.Models;
using DotaScope2.Views;
using DynamicData;
using DynamicData.Aggregation;
using Microsoft.CodeAnalysis;
using ReactiveUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotaScope2.ViewModels
{

    internal class InvokerViewModel : NavigationViewModel
    {
        private bool _isPC = true;
        public bool isPC
        {
            get => _isPC;
            set
            {
                this.RaiseAndSetIfChanged(ref _isPC, value);
            }
        }

        private double _widthHeightBall = 100;
        public double widthHeightBall
        {
            get => _widthHeightBall;
            set
            {
                this.RaiseAndSetIfChanged(ref _widthHeightBall, value);
            }
        }

        private double _ballButton = 150;
        public double ballButton
        {
            get => _ballButton;
            set
            {
                this.RaiseAndSetIfChanged(ref _ballButton, value);
            }
        }

        private double _ballButtonText = 40;
        public double ballButtonText
        {
            get => _ballButtonText;
            set
            {
                this.RaiseAndSetIfChanged(ref _ballButtonText, value);
            }
        }

        private double _borderThicknessButtons = 5;
        public double borderThicknessButtons
        {
            get => _borderThicknessButtons;
            set
            {
                this.RaiseAndSetIfChanged(ref _borderThicknessButtons, value);
            }
        }

        private Thickness _marginValue = new Thickness(10, 0, 0, 0);

        public Thickness MarginValue
        {
            get => _marginValue;
            set => this.RaiseAndSetIfChanged(ref _marginValue, value);
        }

        public string InvokerGame => "Invoker Game";
        public string Spells => "Spells";
        private string _startGameButton = "Start Game";
        public string StartGameButton
        {
            get { return _startGameButton; }
            private set => this.RaiseAndSetIfChanged(ref _startGameButton, value);
        }
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

        private bool beginningGame = false;

        public Bitmap? ImageFromBinding { get; set; } = ImageHelper.LoadFromResource(new("avares://DotaScope2/Assets/Exort_icon.png"));

        private Bitmap? _firstBall;
        public Bitmap? FirstBall
        {
            get {
                return _firstBall; }
            private set => this.RaiseAndSetIfChanged(ref _firstBall, value);
        }
        private Bitmap? _secondBall;
        public Bitmap? SecondBall
        {
            get { return _secondBall; }
            private set => this.RaiseAndSetIfChanged(ref _secondBall, value);
        }
        private Bitmap? _thirdBall;
        public Bitmap? ThirdBall
        {
            get { return _thirdBall; }
            private set => this.RaiseAndSetIfChanged(ref _thirdBall, value);
        }

        private Bitmap _gameImageSpell;
        public Bitmap GameImageSpell
        {
            get { return _gameImageSpell; }
            private set => this.RaiseAndSetIfChanged(ref _gameImageSpell, value);
        }

        private string _gameTextSpell;
        public string GameTextSpell
        {
            get { return _gameTextSpell; }
            private set => this.RaiseAndSetIfChanged(ref _gameTextSpell, value);
        }

        private string _countCurrent;
        public string CountCurrent
        {
            get { return _countCurrent; }
            private set => this.RaiseAndSetIfChanged(ref _countCurrent, value);
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

        private int _userId = -1;
        public int UserId
        {
            get => _userId;
            private set => this.RaiseAndSetIfChanged(ref _userId, value);
        }

        private ObservableCollection<UserScore> _leaderBoardCollection;
        public ObservableCollection<UserScore> LeaderBoardCollection
        {
            get
            {
                return _leaderBoardCollection ?? (_leaderBoardCollection = new ObservableCollection<UserScore>());
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _leaderBoardCollection, value);
            }
        }
            
        private ObservableCollection<UserScore> _bestUsersScoreCollection;
        public ObservableCollection<UserScore> BestUsersScoreCollection
        {
            get
            {
                return _bestUsersScoreCollection ?? (_bestUsersScoreCollection = new ObservableCollection<UserScore>());
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _bestUsersScoreCollection, value);

            }
        }

        private bool _isMobile = false;
        public bool IsMobile
        {
            get => _isMobile;
            set
            {
                this.RaiseAndSetIfChanged(ref _isMobile, value);
            }
        }
        //------------------------------------------------ Главный код---------------------------------------------------------- 
        public int setUserId(int userId)
        {
            UserId = userId;
            return UserId;
        }

        public InvokerViewModel(int userId){
            UserId = userId;
            System.Diagnostics.Debug.WriteLine("Invoker UserID: " + UserId);
            LeaderBoardsInitialized();
            
            }


        private async Task LeaderBoardsInitialized()
        {
            DataBase dataBase = new DataBase();
            if (IsMobile)
            {
                dataBase.IsMobile = true;
            }

            List<UserScore> LeaderBoardList = await dataBase.getLeaderBoard();
            System.Diagnostics.Debug.WriteLine(LeaderBoardList.Count);
            foreach (UserScore userScore in LeaderBoardList)
            {
                System.Diagnostics.Debug.WriteLine(userScore);
                await Dispatcher.UIThread.InvokeAsync(() => { LeaderBoardCollection.Add(userScore); });
                
            }

            List<UserScore> BestUsersScoreList = await dataBase.getUserIdRecords(UserId);
            if (BestUsersScoreList == null)
            {
                BestUsersScoreList = [];
            }

            System.Diagnostics.Debug.WriteLine("BestUsersScoreList: " + BestUsersScoreList.Count);
            foreach (UserScore userScore in BestUsersScoreList)
            {
                System.Diagnostics.Debug.WriteLine(userScore);
                
                await Dispatcher.UIThread.InvokeAsync(() => { BestUsersScoreCollection.Add(userScore); });

            }
            return;
        }

        

        private void setImages()
        {
            Dictionary<string, string> ballsImagesMap = new Dictionary<string, string>();

            // Добавляем элементы в карту
            ballsImagesMap["Q"] = "avares://DotaScope2/Assets/Quas_icon.png";
            ballsImagesMap["W"] = "avares://DotaScope2/Assets/Wex_icon.png";
            ballsImagesMap["E"] = "avares://DotaScope2/Assets/Exort_icon.png";

            System.Diagnostics.Debug.WriteLine(ballsImagesMap[BallsCollection[0]] );

            ThirdBall = ImageHelper.LoadFromResource(new Uri(ballsImagesMap[BallsCollection[0]]));
            if (BallsCollection[1] != null) {
                SecondBall = ImageHelper.LoadFromResource(new Uri(ballsImagesMap[BallsCollection[1]]));
            }
            if (BallsCollection[2] != null) {
                FirstBall = ImageHelper.LoadFromResource(new Uri(ballsImagesMap[BallsCollection[2]]));
            }
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

        private int? _secondsLeft;
        public int? SecondsLeft
        {
            get { return _secondsLeft; }
            private set => this.RaiseAndSetIfChanged(ref _secondsLeft, value);
        }  

        private string _score;
        public string Score
        {
            get { return _score; }
            private set => this.RaiseAndSetIfChanged(ref _score, value);
        }

        private System.Threading.Timer timerSeconds;
        private System.Threading.Timer timerGame;
        public void startGame()
        {
            if (!beginningGame)
            {
                Score = string.Empty;
                beginningGame = true;
                StartGameButton = "Stop Game";
                CountCurrent = "0";
                SecondsLeft = 30;

                timerSeconds = new Timer(async _ => await TimerCallbackSeconds(), null, 1000, 1000);
                timerGame = new Timer(async _ => await TimerCallbackGame(), null, 30000, Timeout.Infinite);
                gameLogic();
            }
            else
            {
                SecondsLeft = null;
                timerSeconds.Change(Timeout.Infinite, Timeout.Infinite);
                timerGame.Change(Timeout.Infinite, Timeout.Infinite);
                beginningGame = false;
                GameImageSpell = null;
                GameTextSpell = string.Empty;
                Score = "Score " + CountCurrent;
                StartGameButton = "Start Game";
            }
        }

        // Таймер секунд

        private async Task TimerCallbackSeconds()
        {
            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                System.Diagnostics.Debug.WriteLine("Прошла секунда");
                SecondsLeft--;
            });
            if (SecondsLeft == 0)
            {
                SecondsLeft = null;
                timerSeconds.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }

        // Таймер до конца игры
        private async Task TimerCallbackGame()
        {
           
            System.Diagnostics.Debug.WriteLine("Время таймера истекло.");
            beginningGame = false;
            GameImageSpell = null;
            StartGameButton = "Start Game";
            GameTextSpell = string.Empty;
            Score = "Score " + CountCurrent;

            DataBase dataBase = new DataBase();
            
            if (IsMobile)
            {
                dataBase.IsMobile = true;
            }


            await dataBase.insertGame(UserId, int.Parse(CountCurrent));
            await Dispatcher.UIThread.InvokeAsync(() => { LeaderBoardCollection.Clear(); });
            await Dispatcher.UIThread.InvokeAsync(() => { BestUsersScoreCollection.Clear(); });
            await LeaderBoardsInitialized();
            return;
        }
        
        

        public void gameLogic()
        {
            List<string> spellsList = new List<string>() { "Cold Snap", "Ghost Walk", "Ice Wall", "E.M.P.", "Tornado", "Alacrity", "Sun Strike", "Forge Spirit", "Chaos Meteor", "Deafening Blast" };
            Dictionary<string, string> spellsImagesMap = new Dictionary<string, string>();
            spellsImagesMap["Cold Snap"] = "avares://DotaScope2/Assets/Cold_Snap_icon.png";
            spellsImagesMap["Ghost Walk"] = "avares://DotaScope2/Assets/Ghost_Walk_icon.png";
            spellsImagesMap["Ice Wall"] = "avares://DotaScope2/Assets/Ice_Wall_icon.png";
            spellsImagesMap["E.M.P."] = "avares://DotaScope2/Assets/E.M.P._icon.png";
            spellsImagesMap["Tornado"] = "avares://DotaScope2/Assets/Tornado_icon.png";
            spellsImagesMap["Alacrity"] = "avares://DotaScope2/Assets/Alacrity_icon.png";
            spellsImagesMap["Sun Strike"] = "avares://DotaScope2/Assets/Sun_Strike_icon.png";
            spellsImagesMap["Forge Spirit"] = "avares://DotaScope2/Assets/Forge_Spirit_icon.png";
            spellsImagesMap["Chaos Meteor"] = "avares://DotaScope2/Assets/Chaos_Meteor_icon.png";
            spellsImagesMap["Deafening Blast"] = "avares://DotaScope2/Assets/Deafening_Blast_icon.png";

            Random random = new Random();
            int previosIndex = -1;
            int randomInRange = random.Next(0, 10);
            while (randomInRange == previosIndex)
            {
                randomInRange = random.Next(0, 10);
            }
            GameImageSpell = ImageHelper.LoadFromResource(new Uri(spellsImagesMap[spellsList[randomInRange]]));
            GameTextSpell = spellsList[randomInRange];
        }

        public void castSpell()
        {
            Dictionary<string, int> ballsNameToNumMap = new Dictionary<string, int>();
            ballsNameToNumMap["Q"] = 1;
            ballsNameToNumMap["W"] = 10;
            ballsNameToNumMap["E"] = 100;

            Dictionary<int, string> spellsNumToNameMap = new Dictionary<int, string>();
            spellsNumToNameMap[3] = "Cold Snap";
            spellsNumToNameMap[12] = "Ghost Walk";
            spellsNumToNameMap[102] = "Ice Wall";
            spellsNumToNameMap[30] = "E.M.P.";
            spellsNumToNameMap[21] = "Tornado";
            spellsNumToNameMap[120] = "Alacrity";
            spellsNumToNameMap[300] = "Sun Strike";
            spellsNumToNameMap[201] = "Forge Spirit";
            spellsNumToNameMap[210] = "Chaos Meteor";
            spellsNumToNameMap[111] = "Deafening Blast";

            castSpellWithoutCreating(ballsNameToNumMap, spellsNumToNameMap);
        }
        private void castSpellWithoutCreating(Dictionary<string, int> balls, Dictionary<int, string> spells)
        {
            int spellNum = 0;

            if (!BallsCollection.Any(item => item == null))
            {
                foreach (string ball in BallsCollection)
                {
                    spellNum += balls[ball];
                }

                string spell = spells[spellNum];
                System.Diagnostics.Debug.WriteLine(spell);

                if (beginningGame)
                {
                    if (GameTextSpell == spell)
                    {
                        System.Diagnostics.Debug.WriteLine("Вверно!");
                        CountCurrent = (int.Parse(CountCurrent) + 1).ToString();
                        gameLogic();
                    }
                }
            }
        }
    }
}
