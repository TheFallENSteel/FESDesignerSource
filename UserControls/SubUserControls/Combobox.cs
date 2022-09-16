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

namespace FESScript2.UserControls.SubUserControls
{
    public class Combobox : UserControl
    {
        public ContentsType contentType;
        public ComboBox comboBox;
        public Combobox(ContentsType contentType) :base()
        {
            comboBox = new ComboBox();
            Grid grid = new Grid();
            grid.Children.Add(comboBox);
            this.Content = grid;
            this.MouseDown += UserControl_MouseDown; 
            this.contentType = contentType;
            comboBox.MinWidth = 25;
            comboBox.Height = 15;
            comboBox.Margin = new Thickness(7.5, 5, 7.5, 5);
            comboBox.VerticalAlignment = VerticalAlignment.Center;
            comboBox.FontSize = 12.5;
            comboBox.FontFamily = new FontFamily("Times New Roman");
            comboBox.BorderThickness = new Thickness(0);
        }

        public bool QuotationMarks
        {
            get
            {
                return quotationMarks;
            }
        }

        const bool quotationMarks = true;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        private int id;

        public new string Name
        {
            get
            {
                return $"M{Id}";
            }
        }

        public string RelativeName
        {
            get
            {
                return "$" + Name;
            }
        }

        public string Text
        {
            get
            {
                return (string)comboBox.SelectedItem;
            }
            set
            {
                comboBox.SelectedItem = value;
            }
        }
        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (BlockDesign.MainWindow.isTypingContents)
            {
                if ((FESScript2.Creator.BlockDes.CommandType)BlockDesign.MainWindow.mainWindow.commandType.box.SelectedItem == FESScript2.Creator.BlockDes.CommandType.StandartToBlockWrite || BlockDesign.MainWindow.mainWindow.commandType.box.SelectedItem == null)
                {
                    BlockDesign.MainWindow.writeEvent.Invoke(Name);
                }
                else
                {
                    BlockDesign.MainWindow.writeEvent.Invoke(RelativeName);
                }
            }
            else
            {
                FESScript2.Creator.BlockDes.DesignContentWindow window = new FESScript2.Creator.BlockDes.DesignContentWindow(ref this.contentType, typeof(Combobox));
                window.Show();
            }
        }
    }
}
