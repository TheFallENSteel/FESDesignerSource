using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FESScript2.Settings.Support
{
    /// <summary>
    /// Interaction logic for CustomtitleBar.xaml
    /// </summary>
    public partial class CustomtitleBar : UserControl
    {
        public CustomtitleBar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Button to close the application.
        /// </summary>

        private void CloseButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (shutDownApp) 
            { 
                Application.Current.Shutdown();
            }
            else 
            { 
                Window.GetWindow(this).Close();
            }
            
        }

        /// <summary>
        /// True shuts down app on click. Default is false.
        /// </summary>

        bool shutDownApp = false;

        /// <summary>
        /// True shuts down app on click. Default is false.
        /// </summary>

        public bool ShutDownApp 
        { 
            get 
            {
                return shutDownApp;
            }
            set 
            {
                shutDownApp = value;
            }
        }

        /// <summary>
        /// Gets or sets Title of Window.
        /// </summary>
        
        public string TitleText
        {
            set 
            {
                titleText.Text = value;
            }
            get 
            {
                return titleText.Text;
            }
        }

        /// <summary>
        /// Allows user to move with window while click is pressed.
        /// </summary>
        
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((Window)((Grid)this.Parent).Parent).DragMove();
        }
    }
}
