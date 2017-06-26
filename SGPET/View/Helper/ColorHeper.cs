using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using DevExpress.Xpf.Core;
using SGPET.Annotations;
using PropertyChanged;

namespace SGPET.View.Helper
{
    
    public class ColorHelper : INotifyPropertyChanged
    {
        private static readonly SolidColorBrush DefaultThemeBackgroundColor =
            new SolidColorBrush(Color.FromRgb(0xA3, 0xC3, 0xEC));

        private static readonly SolidColorBrush DefaultThemeForegroundColor =
            new SolidColorBrush(Color.FromRgb(0x00, 0x00, 0x00));

        private static ColorHelper _instance;
        private Brush _background;
        private Brush _borderBrush;
        private Brush _foreground;


        public ColorHelper()
        {
            ThemeManager.ThemeChanged += ThemeChanged;
            GetColors(ThemeManager.ActualApplicationThemeName);
        }

        public static ColorHelper Instance => _instance ?? (_instance = new ColorHelper());

        public Brush Background
        {
            get { return _background; }
            set
            {
                if (Equals(_background, value)) return;
                _background = value;
            }
        }

        public Brush Foreground
        {
            get { return _foreground; }
            set
            {
                if (Equals(_foreground, value)) return;
                _foreground = value;
            }
        }

        public Brush BorderBrush
        {
            get { return _borderBrush; }
            set
            {
                if (Equals(_borderBrush, value)) return;
                _borderBrush = value;
            }
        }

        private static void ThemeChanged(DependencyObject sender, ThemeChangedRoutedEventArgs e)
        {
            Instance.GetColors(e.ThemeName);
        }

        private void GetColors(string name)
        {
            if (name == "DeepBlue")
            {
                Background = DefaultThemeBackgroundColor;
                Foreground = DefaultThemeForegroundColor;
                BorderBrush = DefaultThemeBackgroundColor;
                return;
            }

            ThemeManager.ThemeChanged -= ThemeChanged;
            var p = new BackgroundPanel();
            ThemeManager.SetThemeName(p, name);
            Background = p.Background;
            Foreground = p.Foreground;
            BorderBrush = p.BorderBrush;
            ThemeManager.ThemeChanged += ThemeChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}