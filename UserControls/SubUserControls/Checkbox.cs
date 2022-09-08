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
    public class Checkbox : UserControl
    {
        public ContentsType contentType;
        public CheckBox checkBox;

        public Checkbox(ContentsType contentsType) : base()
        {
            checkBox = new CheckBox();
            Grid grid = new Grid();
            grid.Children.Add(checkBox);
            this.Content = grid;
            checkBox.IsEnabled = false;
            this.contentType = contentsType;
            MouseDown += UserControl_MouseDown;
        }

        public bool QuotationMarks 
        { 
            get 
            {
                return quotationMarks;
            }
        }

        const bool quotationMarks = false;

        public string Text 
        { 
            get 
            { 
                if ((bool)checkBox.IsChecked) 
                {
                    return "true";
                }
                else 
                {
                    return "false";
                }
            }
            set 
            {
                if (value == "true")
                {
                    checkBox.IsChecked = true;
                }
                else if (value == "false")
                {
                    checkBox.IsChecked = false;
                }
            }
        }
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

        public string Name
        {
            get
            {
                return $"C{Id}";
            }
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FESScript2.Creator.BlockDes.DesignContentWindow window = new FESScript2.Creator.BlockDes.DesignContentWindow(ref this.contentType, typeof(Checkbox));
            window.Show();
        }

    }
}
