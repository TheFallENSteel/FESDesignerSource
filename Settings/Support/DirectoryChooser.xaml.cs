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
using Microsoft.WindowsAPICodePack.Dialogs;

namespace FESScript2.Settings.Support
{
    /// <summary>
    /// Interaction logic for DirectoryChooser.xaml
    /// </summary>
    public partial class DirectoryChooser : UserControl
    {
        public event TextChangedEventHandler DirectoryChanged;

        public DirectoryChooser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Path to app directory.
        /// </summary>
        
        protected string Path
        {
            get
            {
                return textBox.Text;
            }
            set
            {
                textBox.Text = value;
            }
        }

        /// <summary>
        /// Allows user to choose directory of the IDE.
        /// </summary>

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog openDirectory = new CommonOpenFileDialog() { IsFolderPicker = true };
            if (openDirectory.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Path = openDirectory.FileName;
            }
        }

        private void textBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            DirectoryChanged?.Invoke(this, null);
        }
    }
}
