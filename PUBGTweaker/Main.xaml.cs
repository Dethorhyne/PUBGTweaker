using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PUBGTweaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileInfo GameUserSettingsPath;
        FileInfo ScalabilityPath;
        FileInfo EnginePath;

        bool PreviouslyOpenedEditor = false;

        bool AboutOpened = false;

        public MainWindow()
        {
            
            InitializeComponent();
            titleBar.MouseLeftButtonDown += (o, e) => DragMove();

            AppAbout.Visibility = Visibility.Hidden;

            string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\TslGame\Saved\Config\WindowsNoEditor\";

            if(Directory.Exists(folder))
            {
                var files = Directory.GetFiles(folder);
                
                foreach(string path in files)
                {
                    FileInfo fi = new FileInfo(path);
                    switch(fi.Name.ToLower())
                    {
                        case "gameusersettings.ini":
                            GameUserSettingsPath = fi;
                            break;
                        case "engine.ini":
                            EnginePath = fi;
                            break;
                        case "scalability.ini":
                            ScalabilityPath = fi;
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Config files were not found. Have you installed the game and started it at least once?", "Oh-oh!");
                BTN_GUS.IsEnabled = false;
                BTN_S.IsEnabled = false;
                BTN_E.IsEnabled = false;
            }
        }

        private void BTN_Close_MouseUp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BTN_GUS_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Settings_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            Editor EditorWindow;

            switch((string)btn.Tag)
            {
                case "Scalability":
                    EditorWindow = new Editor(ScalabilityPath, ConfigType.Scalability, PreviouslyOpenedEditor);
                    EditorWindow.Owner = this;
                    EditorWindow.ShowDialog();
                    break;
                case "Engine":
                    EditorWindow = new Editor(EnginePath, ConfigType.Engine, PreviouslyOpenedEditor);
                    EditorWindow.Owner = this;
                    EditorWindow.ShowDialog();
                    break;
                case "GameUserSettings":
                    EditorWindow = new Editor(GameUserSettingsPath, ConfigType.GameUserSettings, PreviouslyOpenedEditor);
                    EditorWindow.Owner = this;
                    EditorWindow.ShowDialog();
                    break;
            }
            PreviouslyOpenedEditor = true;

        }

        private void BTN_About_Click(object sender, RoutedEventArgs e)
        {
            if(AboutOpened)
            {
                AppAbout.Visibility = Visibility.Hidden;
                AboutOpened = false;
            }
            else
            {
                AppAbout.Visibility = Visibility.Visible;
                AboutOpened = true;
            }

        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink link = (Hyperlink)sender;
            System.Diagnostics.Process.Start(link.NavigateUri.ToString());
        }
    }
}
