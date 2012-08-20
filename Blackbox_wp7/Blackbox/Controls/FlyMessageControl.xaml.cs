using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Blackbox
{
    public enum FlyMessageType
    {
        Celebrate,
        Criticism,
        Prompt,
    }

    public partial class FlyMessageControl : UserControl
    {
        private Queue<string> _messageList;
        private Queue<FlyMessageType> _messageTypeList;
        private bool _isRunning;

        public void AddMessage(string message, FlyMessageType type)
        {
            if (!_isRunning)
            {
                _isRunning = true;
                textBlock.Text = message;
                textBlock.Foreground =new SolidColorBrush(Colors.Black);
                SetMessageIcon(type);

                Storyboard.Begin();
            }
            else
            {
                if (message != textBlock.Text && !Contains(message))
                {
                    _messageList.Enqueue(message);
                    _messageTypeList.Enqueue(type);
                }
            }
        }

        public FlyMessageControl()
        {
            InitializeComponent();

            _messageList = new Queue<string>();
            _messageTypeList = new Queue<FlyMessageType>();
            _isRunning = false;

            Storyboard.Completed += new EventHandler(Storyboard_Completed);
        }

        void Storyboard_Completed(object sender, EventArgs e)
        {
            if (_messageList.Count > 0)
            {
                textBlock.Text = _messageList.Dequeue();
                textBlock.Foreground = new SolidColorBrush(Colors.Black);

                FlyMessageType type = _messageTypeList.Dequeue();
                SetMessageIcon(type);

                Storyboard.Begin();
            }
            else
            {
                _isRunning = false;
            }
        }

        private bool Contains(string message)
        {
            bool isContains = false;
            foreach (string msg in _messageList)
            {
                if (message == msg)
                {
                    isContains = true;
                    break;
                }
            }
            return isContains;
        }

        private void SetMessageIcon(FlyMessageType type)
        {
            switch (type)
            {
                case FlyMessageType.Celebrate:
                    image.Source = 
                        BlackboxImageUtils.Image(BlackboxImageType.MessageCelebrate);
                    break;
                case FlyMessageType.Criticism:
                    image.Source =
                        BlackboxImageUtils.Image(BlackboxImageType.MessageCriticism);
                    break;
                case FlyMessageType.Prompt:
                    image.Source =
                        BlackboxImageUtils.Image(BlackboxImageType.MessagePrompt);
                    break;
                default:
                    break;
            }
        }
    }
}
