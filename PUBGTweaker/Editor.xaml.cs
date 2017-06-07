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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PUBGTweaker
{

    /// <summary>
    /// Interaction logic for Editor.xaml
    /// </summary>
    public partial class Editor : Window
    {
        public FileInfo FI;
        public ConfigType CT;
        bool HelpOpened = false;

        public Editor(FileInfo fi, ConfigType ct, bool previouslyopenededitor)
        {
            InitializeComponent();
            titleBar.MouseLeftButtonDown += (o, e) => DragMove();

            FI = fi;
            CT = ct;

            if(previouslyopenededitor)
            {
                AppHelp.Visibility = Visibility.Hidden;
                HelpOpened = false;
            }
            else
            {
                AppHelp.Visibility = Visibility.Visible;
                HelpOpened = true;
            }


            switch (ct)
            {
                case ConfigType.Engine:
                    Title += " [Engine.ini]";
                    TXT_AppTitle.Text += " [Engine.ini]";
                    SuggestedText.Text = Properties.Resources.Engine;
                    break;
                case ConfigType.Scalability:
                    Title += " [Scalability.ini]";
                    TXT_AppTitle.Text += " [Scalability.ini]";
                    SuggestedText.Text = Properties.Resources.Scalability;
                    break;
                case ConfigType.GameUserSettings:
                    Title += " [GameUserSettings.ini]";
                    TXT_AppTitle.Text += " [GameUserSettings.ini]";
                    SuggestedText.Text = Properties.Resources.GameUserSettings;
                    break;
            }

            using (StreamReader rs = new StreamReader(fi.FullName))
            {
                ConfigEditor.Text = rs.ReadToEnd();
            }
            
        }

        private void BTN_Close_MouseUp(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BTN_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BTN_Save(object sender, RoutedEventArgs e)
        {
            if(FI.IsReadOnly)
            {
                FI.IsReadOnly = false;
            }

            using (StreamWriter sw = new StreamWriter(FI.FullName,false))
            {
                sw.Write(ConfigEditor.Text);
            }

            FI.IsReadOnly = true;

            Close();
        }

        private void BTN_Help_Click(object sender, RoutedEventArgs e)
        {
            if (HelpOpened)
            {
                AppHelp.Visibility = Visibility.Hidden;
                HelpOpened = false;
            }
            else
            {
                AppHelp.Visibility = Visibility.Visible;
                HelpOpened = true;
            }

        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink link = (Hyperlink)sender;
            System.Diagnostics.Process.Start(link.NavigateUri.ToString());
        }
    }
}
