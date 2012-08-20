using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Blackbox.Utils
{
    public static class BlackboxResources
    {
        private static Color _appBarForegroundColor;
        private static Color _appBarBackgroundColor;

        static BlackboxResources()
        {
            _appBarForegroundColor = Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF);
            _appBarBackgroundColor = Color.FromArgb(0xFF, 0x31, 0x99, 0xCC);
        }

        public static Color AppBarForegroundColor
        {
            get
            {
                return _appBarForegroundColor;
            }
        }

        public static Color AppBarBackgroundColor
        {
            get
            {
                return _appBarBackgroundColor;
            }
        }
    }
}
