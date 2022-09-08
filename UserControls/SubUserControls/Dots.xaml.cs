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
    /// Interaction logic for Dots.xaml
    /// </summary>
    public partial class Dots : UserControl, FESScript2.Creator.BlockDes.INameGet
    {
        public new string Name
        {
            get
            {
                return dotName;
            }
            set
            {
                dotName = value;
            }
        }

        public Dots(DotsType dotTypeDotType)
        {
            InitializeComponent();
            MouseDown += OnMouseDown;
            this.dotTypeDotType = dotTypeDotType;
        }

        public DotsType dotTypeDotType;

        public string dotName;

        Type dotType;

        /// <summary>
        /// Sets type of dot and sets color of fill;
        /// </summary>

        public Type DotType
        { 
            get 
            {
                return dotType;
            }
            set 
            {
                dotType = value;
                ellipse.Fill = Colors.TypeToColor[value];
            }
        }

        protected void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (BlockDesign.MainWindow.isTypingContents)
            {
                if (DotType != Type.Action) 
                { 
                    BlockDesign.MainWindow.writeEvent.Invoke(Name);
                }
                else if (dotTypeDotType.io == IO.Output)
                {
                    BlockDesign.MainWindow.writeEvent.Invoke($"\nreturn {id};");
                }
            }
            else
            {
                FESScript2.Creator.BlockDes.DotDesignerWindow window = new FESScript2.Creator.BlockDes.DotDesignerWindow(ref this.dotTypeDotType);
                window.Show();
            }
        }

        /// <summary>
        /// ID of the dot.
        /// </summary>

        public int id;
    }
}
