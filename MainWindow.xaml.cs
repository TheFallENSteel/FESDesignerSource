using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FESScript2.UserControls;

namespace BlockDesign
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;
            writeEvent += onWriteName;
        }
        public delegate void WriteEvent(string name);
        public static WriteEvent writeEvent;
        private static int selectionIndex;
        public static bool isTypingContents;
        private static bool skippDefocus;
        public static MainWindow mainWindow;
        public static FESScript2.UserControls.Block block;
        public static FESScript2.Creator.BlockDes.DesignBlockType blockType;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            blockType = new FESScript2.Creator.BlockDes.DesignBlockType(0, "NoName", FESScript2.UserControls.SubUserControls.Type.Error);
            FESScript2.CodeWorks.BlockCreation.BlockRecreation.RecreateBlock(blockType.blockType, ref block, false);
            blockWatch.Children.Add(block);
            blockWatch.HorizontalAlignment = HorizontalAlignment.Center;
            blockWatch.VerticalAlignment = VerticalAlignment.Center;
            blockWatch.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            blockWatch.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        }

        public void Properties_OnSomeChange(object sender, TextChangedEventArgs e)
        {
            blockType = properites.GetCurrentThings();
            FESScript2.CodeWorks.BlockCreation.BlockRecreation.RecreateBlock(blockType.blockType, ref block, false);
        }

        private new void GotFocus(object sender, RoutedEventArgs e)
        {
            isTypingContents = true;
        }

        private new void LostFocus(object sender, RoutedEventArgs e)
        {
            isTypingContents = false;
        }
        private void onWriteName(string name) 
        {
            selectionIndex = contents.CaretIndex;
            contents.Text = contents.Text.Insert(selectionIndex, name);
            FocusManager.SetFocusedElement(this, contents);
            Keyboard.Focus(contents);
            contents.CaretIndex = selectionIndex + name.Length;
            skippDefocus = true;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!skippDefocus) 
            { 
                FocusManager.SetFocusedElement(this, this);
            }
            skippDefocus = false;
            //Keyboard.ClearFocus();
        }
    }
}
