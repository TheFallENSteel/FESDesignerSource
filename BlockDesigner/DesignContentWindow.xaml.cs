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
    /// Interaction logic for DesignContent.xaml
    /// </summary>
    public partial class DesignContentWindow : Window
    {
        Type contentType;
        UserControls.SubUserControls.ContentsType contentsType;
        public DesignContentWindow(ref UserControls.SubUserControls.ContentsType contentsType, Type contentType)
        {
            this.contentsType = contentsType;
            this.contentType = contentType;
            InitializeComponent();
            if (this.contentsType != null) 
            { 
                this.properties.column.Text = this.contentsType.column.ToString();
                this.properties.id.Text = this.contentsType.id.ToString();
                this.properties.text.Text = this.contentsType.text;
            }
            if (this.contentType != typeof(FESScript2.UserControls.SubUserControls.Combobox)) 
            {
                properties.RemoveArgs();
            }
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            if (this.contentsType == null)
            {
                contentsType = new UserControls.SubUserControls.ContentsType();
                DesignBlockType.contents.Add(contentsType);
            }
            properties.GetCurrentValues(ref contentsType);
            contentsType.type = contentType;
            BlockDesign.MainWindow.mainWindow.Properties_OnSomeChange(this, null);
        }

        private void properties_OnDelete(object sender, RoutedEventArgs e)
        {
            DesignBlockType.contents.Remove(contentsType);
            BlockDesign.MainWindow.mainWindow.Properties_OnSomeChange(this, null);
            this.Close();
        }
    }
}
