using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PUBGTweaker
{
    public static class AppStyle
    {
        public static event PropertyChangedEventHandler StaticPropertyChanged;
        private static void OnStaticPropertyChanged(string propertyName)
        {
            var handler = StaticPropertyChanged;
            if (handler != null)
            {
                handler(null, new PropertyChangedEventArgs(propertyName));
            }
        }

        static SolidColorBrush accentMain = new BrushConverter().ConvertFromString("#212121") as SolidColorBrush;
        static SolidColorBrush accentText = new BrushConverter().ConvertFromString("#BDBDBD") as SolidColorBrush;
        static SolidColorBrush accentFocus = new BrushConverter().ConvertFromString("#2A2A2A") as SolidColorBrush;
        static SolidColorBrush accentHover = new BrushConverter().ConvertFromString("#343434") as SolidColorBrush;
        static SolidColorBrush accentTextDown = new BrushConverter().ConvertFromString("#EDEDED") as SolidColorBrush;
        static SolidColorBrush accentBackground = new BrushConverter().ConvertFromString("#191919") as SolidColorBrush;
        static SolidColorBrush accentButtonDown = new BrushConverter().ConvertFromString("#0E0E0E") as SolidColorBrush;

        public static SolidColorBrush AccentMain
        {
            get { return accentMain; }
            set
            {
                accentMain = value;
                OnStaticPropertyChanged("AccentMain");
            }
        }
        public static SolidColorBrush AccentText
        {
            get { return accentText; }
            set
            {
                accentText = value;
                OnStaticPropertyChanged("AccentText");
            }
        }
        public static SolidColorBrush AccentFocus
        {
            get { return accentFocus; }
            set
            {
                accentFocus = value;
                OnStaticPropertyChanged("AccentFocus");
            }
        }
        public static SolidColorBrush AccentHover
        {
            get { return accentHover; }
            set
            {
                accentHover = value;
                OnStaticPropertyChanged("AccentHover");
            }
        }
        public static SolidColorBrush AccentTextDown
        {
            get { return accentTextDown; }
            set
            {
                accentTextDown = value;
                OnStaticPropertyChanged("AccentTextDown");
            }
        }
        public static SolidColorBrush AccentBackground
        {
            get { return accentBackground; }
            set
            {
                accentBackground = value;
                OnStaticPropertyChanged("AccentBackground");
            }
        }
        public static SolidColorBrush AccentButtonDown
        {
            get { return accentButtonDown; }
            set
            {
                accentButtonDown = value;
                OnStaticPropertyChanged("AccentButtonDown");
            }
        }
    }
}
