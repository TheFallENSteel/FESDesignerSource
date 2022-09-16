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
    /// Interaction logic for TextBoxMenu.xaml
    /// </summary>
    public partial class TextBoxMenu : UserControl
    {
        public TextBoxMenu()
        {
            InitializeComponent();
        }
        public CommandType commandType 
        { 
            get 
            {
                if (this.box.SelectedItem != null) 
                { 
                    return (CommandType)this.box.SelectedItem; 
                }
                else
                {
                    System.Windows.MessageBox.Show("Please select command type option");
                    return (CommandType)(-1);
                }
            }
        }
    }
    public enum CommandType 
    {
        StandartToBlockWrite,
        DirectVariableWrite,
        DirectCodeWrite
    }
}
