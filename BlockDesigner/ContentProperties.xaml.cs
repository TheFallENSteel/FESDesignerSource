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

namespace FESScript2.Creator.BlockDes
{
    /// <summary>
    /// Interaction logic for ContentProperties.xaml
    /// </summary>
    public partial class ContentProperties : UserControl
    {
        public event RoutedEventHandler OnDelete;
        public ContentProperties()
        {
            InitializeComponent();
        }
        public void GetCurrentValues(ref UserControls.SubUserControls.ContentsType contentType) 
        {
            int collumn = 0;
            int.TryParse(this.collumn.Text, out collumn);
            contentType.collumn = collumn;
            int id = 0;
            int.TryParse(this.id.Text, out id);
            contentType.id = id;
            contentType.text = text.Text;
            if (this.Args != null) 
            { 
                contentType.ContentArgs = new UserControls.SubUserControls.ContentArgs.ComboBoxArgs(new List<string>(this.Args.Text.Split(@"\n")));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnDelete?.Invoke(null, null);
        }
    }
}
