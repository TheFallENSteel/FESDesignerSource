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
using System.Windows.Shapes;

namespace FESScript2.Creator.BlockDes
{
    /// <summary>
    /// Interaction logic for DotDesignerWindow.xaml
    /// </summary>
    public partial class DotDesignerWindow : Window
    {
        public UserControls.SubUserControls.DotsType dotType;

        public DotDesignerWindow(ref UserControls.SubUserControls.DotsType dotType)
        {
            this.dotType = dotType;
            InitializeComponent();
            if(dotProperties.io != null) 
            { 
                dotProperties.io.SelectedItem = dotType.io;
            }
            if (dotProperties.type != null)
            {
                dotProperties.type.SelectedItem = dotType.dotType;
            }
            if (dotProperties.dotID != null) 
            { 
                dotProperties.dotID.Text = dotType.id.ToString();
            }

        }

        public DotDesignerWindow()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (this.dotType == null) 
            {
                dotType = new UserControls.SubUserControls.DotsType();
                DesignBlockType.dots.Add(dotType);
            }
            dotProperties.GetCurrentValues(ref dotType);
            BlockDesign.MainWindow.mainWindow.Properties_OnSomeChange(this, null);
        }

        private void dotProperties_OnDelete(object sender, RoutedEventArgs e)
        {
            DesignBlockType.dots.Remove(dotType);
            BlockDesign.MainWindow.mainWindow.Properties_OnSomeChange(this, null);
            this.Close();
        }
    }
}
