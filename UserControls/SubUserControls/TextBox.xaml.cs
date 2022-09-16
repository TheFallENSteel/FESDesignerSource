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
    public partial class TextBox
    {
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
                return $"B{Id}";
            }
        }
        public string RelativeName
        {
            get
            {
                return "$" + Name;
            }
        }

        public ContentsType ContentsType;

        /// <summary>
        /// Creates textbox for blocks.
        /// </summary>
        /// <param name="OnlyNumbers">Specifies if user is able to write just numbers.</param>
        
        public TextBox(ContentsType contentsType)
        {
            this.ContentsType = contentsType;
            InitializeComponent();
        }


        /// <summary>
        /// Text string.
        /// </summary>

        public string Text
        {
            get 
            {
                return textBox.Text;
            }
            set
            {
                textBox.Text = value;
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
                FESScript2.Creator.BlockDes.DesignContentWindow window = new FESScript2.Creator.BlockDes.DesignContentWindow(ref this.ContentsType, typeof(TextBox));
                window.Show();
            }
        }

        /*
        /// <summary>
        /// If TextBox.OnlyNumbers == true tests if user types letter and removes it.
        /// </summary>

        protected override void OnPreviewTextInput(TextCompositionEventArgs e) 
        {
            double x;
            bool y = double.TryParse(e.Text, out x);
            if (y || Text.Length == 0)
            {
                base.OnPreviewTextInput(e);
            }
            else 
            {
                e.Handled = true;
            }
        }*/

        /*private void textBox_TextChanged(object sender, TextChangedEventArgs args)
        {

            if (OnlyNumbers)
            {
                args.Handled = true;
                double x;
                if (!double.TryParse(Text, out x) && Text.Length != 0)
                {
                    int selectionStart = this.textBox.SelectionStart;
                    int changeStart = 0;
                    int changeLength = 0;
                    string strTextTemp = "";
                    bool hasSplitter = false;
                    for (int i = 0; i < Text.Length; i++) 
                    {
                        char character = Text[i];
                        if (char.IsDigit(character))
                        {
                            strTextTemp += character;
                            changeLength++;
                            if (i == 0) 
                            { 
                                changeStart = i;
                            }
                        }
                        else if (character == '.' && !hasSplitter)
                        {
                            strTextTemp += character;
                            hasSplitter = true;
                        }
                        else if (i == 0 && character == '-') 
                        {
                            strTextTemp += character;
                        } 
                    }
                    Text = strTextTemp;
                    this.textBox.SelectionStart = selectionStart;
                }
            }
        }*/
    }
}
