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
    /// Interaction logic for DotProperties.xaml
    /// </summary>
    public partial class DotProperties : UserControl
    {
        public event RoutedEventHandler OnDelete;
        public DotProperties()
        {
            InitializeComponent();
        }

        public void GetCurrentValues(ref UserControls.SubUserControls.DotsType dotType)
        {
            int id = 0;
            int.TryParse(this.dotID.Text, out id);
            dotType.id = id;
            if (type.SelectedItem != null) 
            { 
                dotType.dotType = (UserControls.SubUserControls.Type)type.SelectedItem;
            }
            if (io.SelectedItem != null)
            {
                dotType.io = (UserControls.SubUserControls.IO)io.SelectedItem;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnDelete?.Invoke(null, null);
        }
    }
}
