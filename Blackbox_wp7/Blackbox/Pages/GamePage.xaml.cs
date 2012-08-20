using System;
using Blackbox.Utils;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Blackbox
{
    public partial class GamePage : PhoneApplicationPage
    {
        private ApplicationBarIconButton guess;
        private ApplicationBarIconButton debunk;
        private ApplicationBarIconButton restart;
        private Random random = new Random();

        public GamePage()
        {
            InitializeComponent();

            this.ApplicationBar = new ApplicationBar();
            this.ApplicationBar.IsMenuEnabled = true;
            this.ApplicationBar.IsVisible = true;
            this.ApplicationBar.ForegroundColor = 
                BlackboxResources.AppBarForegroundColor;
            this.ApplicationBar.BackgroundColor = 
                BlackboxResources.AppBarBackgroundColor;

            guess = new ApplicationBarIconButton();
            guess.Click += new EventHandler(OnGuessClick);
            guess.IconUri = new Uri("/icons/Appbar/Appbar.guess.png", 
                UriKind.Relative);
            guess.Text = AppResources.GuessApplicationBarText;
            guess.IsEnabled = false;

            debunk = new ApplicationBarIconButton();
            debunk.Click += new EventHandler(OnDebunkClick);
            debunk.IconUri = new Uri("/icons/Appbar/Appbar.debunk.png", 
                UriKind.Relative);
            debunk.Text = AppResources.DebunkApplicationBarText;

            restart = new ApplicationBarIconButton();
            restart.Click += new EventHandler(OnRestartClick);
            restart.IconUri = new Uri("/icons/Appbar/Appbar.restart.png", 
                UriKind.Relative);
            restart.Text = AppResources.RestartApplicationBarText;

            this.ApplicationBar.Buttons.Add(guess);
            this.ApplicationBar.Buttons.Add(debunk);
            this.ApplicationBar.Buttons.Add(restart);

            gameBoardView.SetObserver(this);

            limitedRaysControl1.LimitedRays = !App.Settings.UnlimitedRays;
            limitedRaysControl1.CurrentRays = 0;
        }

        public void StateChanged(object sender, ModelStateEventArgs args)
        {
            switch (args.State)
            {
                case ModelState.NoRayExplored:
                    {
                        flyMessageControl1.AddMessage(
                            AppResources.NoRayExploredPromptText, 
                            FlyMessageType.Prompt
                            );
                        gameBoardView.Accelerate();
                    }
                    break;

                case ModelState.MaxRaysExceed:
                    {
                        flyMessageControl1.AddMessage(
                            AppResources.MaxRaysExceedPromptText,
                            FlyMessageType.Prompt
                            );
                    }
                    break;

                case ModelState.LightBoxActivated:
                    {
                        App.SoundManager.Play(SoundType.LightboxActivated);
                    }
                    break;

                case ModelState.MaxMirrorsExceed: // fall through
                case ModelState.BlackBoxActivated: // fall through
                    break;

                case ModelState.GuessAdded:
                    {
                        App.SoundManager.Play(SoundType.GuessAdded);
                    }
                    break;

                case ModelState.GuessRemoved:
                    {
                        App.SoundManager.Play(SoundType.GuessRemoved);
                        guess.IsEnabled = false;
                    }
                    break;

                case ModelState.GuessCompleted:
                    {
                        guess.IsEnabled = true;
                    }
                    break;

                case ModelState.GuessTransferred:
                    {
                        App.SoundManager.Play(SoundType.GuessTransferred);
                    }
                    break;

                case ModelState.GuessSuccess:
                    {
                        ShowGuessSuccessMessage();
                        App.VibrateManager.Vibrate(VibrateManager.VibrateType.ShortVibrate);
                        App.SoundManager.Play(SoundType.GuessSuccess);
                    }
                    break;

                case ModelState.GuessFailed:
                    {
                        ShowGuessFailedMessage();
                        App.VibrateManager.Vibrate(VibrateManager.VibrateType.ShortVibrate);
                        App.SoundManager.Play(SoundType.GuessFailed);
                    }
                    break;

                case ModelState.RaysCreated:
                    {
                        limitedRaysControl1.CurrentRays += 1;
                    }
                    break;

                case ModelState.GameOver:
                    {
                        ShowGameOverMessage();
                        App.VibrateManager.Vibrate(VibrateManager.VibrateType.LongVibrate);
                        App.SoundManager.Play(SoundType.GameOver);
                        gameBoardView.Debunk();
                        debunk.IsEnabled = false;
                    }
                    break;

                default:
                    break;
            }
        }

        private void ShowGuessSuccessMessage()
        {
            int rand = random.Next(10);
            switch (rand)
            {
                case 0:
                    flyMessageControl1.AddMessage(
                        AppResources.GuessSuccessPrompt1Text, 
                        FlyMessageType.Celebrate
                        );
                    break;
                case 1:
                    flyMessageControl1.AddMessage(
                        AppResources.GuessSuccessPrompt2Text,
                        FlyMessageType.Celebrate
                        );
                    break;
                case 2:
                    flyMessageControl1.AddMessage(
                        AppResources.GuessSuccessPrompt3Text,
                        FlyMessageType.Celebrate
                        );
                    break;
                case 3:
                    flyMessageControl1.AddMessage(
                        AppResources.GuessSuccessPrompt4Text,
                        FlyMessageType.Celebrate
                        );
                    break;
                case 4:
                    flyMessageControl1.AddMessage(
                        AppResources.GuessSuccessPrompt5Text,
                        FlyMessageType.Celebrate
                        );
                    break;
                default:
                    // we don't show message.
                    break;
            }
        }

        private void ShowGuessFailedMessage()
        {
            int rand = random.Next(10);
            switch (rand)
            {
                case 0:
                    flyMessageControl1.AddMessage(
                        AppResources.GuessFailedPrompt1Text,
                        FlyMessageType.Celebrate
                        );
                    break;
                case 1:
                    flyMessageControl1.AddMessage(
                        AppResources.GuessFailedPrompt2Text,
                        FlyMessageType.Celebrate
                        );
                    break;
                case 2:
                    flyMessageControl1.AddMessage(
                        AppResources.GuessFailedPrompt3Text,
                        FlyMessageType.Celebrate
                        );
                    break;
                case 3:
                    flyMessageControl1.AddMessage(
                        AppResources.GuessFailedPrompt4Text,
                        FlyMessageType.Celebrate
                        );
                    break;
                case 4:
                    flyMessageControl1.AddMessage(
                        AppResources.GuessFailedPrompt5Text,
                        FlyMessageType.Celebrate
                        );
                    break;
                default:
                    // we don't show message.
                    break;
            }
        }

        private void ShowGameOverMessage()
        {
            int rand = random.Next(5);
            switch (rand)
            {
                case 0:
                    flyMessageControl1.AddMessage(
                        AppResources.GameOverPrompt1Text,
                        FlyMessageType.Celebrate
                        );
                    break;
                case 1:
                    flyMessageControl1.AddMessage(
                        AppResources.GameOverPrompt2Text,
                        FlyMessageType.Celebrate
                        );
                    break;
                case 2:
                    flyMessageControl1.AddMessage(
                        AppResources.GameOverPrompt3Text,
                        FlyMessageType.Celebrate
                        );
                    break;
                case 3:
                    flyMessageControl1.AddMessage(
                        AppResources.GameOverPrompt4Text,
                        FlyMessageType.Celebrate
                        );
                    break;
                case 4:
                    flyMessageControl1.AddMessage(
                        AppResources.GameOverPrompt5Text,
                        FlyMessageType.Celebrate
                        );
                    break;
                default:
                    // we don't show message.
                    break;
            }
        }

        private void OnGuessClick(object sender, System.EventArgs e)
        {
            gameBoardView.DoGuess();
            guess.IsEnabled = false;
        }

        private void OnDebunkClick(object sender, System.EventArgs e)
        {
            App.VibrateManager.Vibrate(VibrateManager.VibrateType.ShortVibrate);
            App.SoundManager.Play(SoundType.Debunk);
            gameBoardView.Debunk();
            debunk.IsEnabled = false;
        }

        private void OnRestartClick(object sender, System.EventArgs e)
        {
            App.VibrateManager.Vibrate(VibrateManager.VibrateType.ShortVibrate);
            App.SoundManager.Play(SoundType.Restarted);
            guess.IsEnabled = false;
            debunk.IsEnabled = true;
            gameBoardView.Restart();
            limitedRaysControl1.Restart();
        }
    }
}
