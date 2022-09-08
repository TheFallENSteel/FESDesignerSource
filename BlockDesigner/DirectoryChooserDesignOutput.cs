using System;
using System.Collections.Generic;
using System.Text;

namespace FESScript2.Creator.BlockDesigner
{
    public class DirectoryChooserDesignOutput : FESScript2.Settings.Support.DirectoryChooser
    {
        protected new string Path
        {
            set 
            {
                textBox.Text = value;
            }
        }
        public string LabelText 
        {
            set 
            {
                label.Content = value;
            }
        }
    }
}
