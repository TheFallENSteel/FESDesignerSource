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
    /// <summary>
    /// Interaction logic for TextLabel.xaml
    /// </summary>
    public partial class TextLabel : UserControl
    {
        ContentsType ContentsType;
        public TextLabel(ContentsType contentsType)
        {
            this.ContentsType = contentsType;
            InitializeComponent();
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

        public new string Name
        {
            get
            {
                return $"L{Id}";
            }
        }

        public string RelativeName
        {
            get
            {
                return "$" + Name;
            }
        }

        /// <summary>
        /// Text string.
        /// </summary>

        public string Text 
        { 
            set 
            {
                text.Text = value;
            }
            get 
            {
                return text.Text;
            }
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FESScript2.Creator.BlockDes.DesignContentWindow window = new FESScript2.Creator.BlockDes.DesignContentWindow(ref this.ContentsType, typeof(TextLabel));
            window.Show();
        }
    }
}
