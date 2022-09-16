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
            int column = 0;
            int.TryParse(this.column.Text, out column);
            contentType.column = column;
            int id = 0;
            int.TryParse(this.id.Text, out id);
            contentType.id = id;
            contentType.text = text.Text;
            if (contentType.text == "")
            {
                contentType.text = "Sample Text";
            }
            if (this.Args != null)
            {
                List<string> args = new List<string>();
                for (int i = 0; i < ArgsGrid.Children.Count; i++)
                {
                    args.Add(((TextBox)ArgsGrid.Children[i]).Text);
                }
                contentType.ContentArgs = new UserControls.SubUserControls.ContentArgs.ComboBoxArgs(args);
            }
        }

        public void RemoveArgs()
        {
            ArgsGrid.Children.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnDelete?.Invoke(null, null);
        }

        private void Args_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox x = new TextBox() { TextWrapping = TextWrapping.NoWrap, Margin = new Thickness(15, 10, 15, 10), MaxLines = 1, Height = 20};
                x.PreviewKeyDown += TextBoxKeyDown;
                x.KeyUp += Args_KeyUp;
                ArgsGrid.Children.Add(x);
                Keyboard.Focus(x);
            }
        }
        private void TextBoxKeyDown (object sender, KeyEventArgs e) 
        {
            if (e.Key == Key.Back && (((TextBox)sender).Text == "" || ((TextBox)sender).CaretIndex == 0))
            {
                ArgsGrid.Children.Remove((UIElement)sender);
            }
        }
    }
}