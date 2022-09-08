using System.Collections.Generic;
using FESScript2.UserControls.SubUserControls;
using FESScript2.Creator.BlockDes;
using System;
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

namespace FESScript2.UserControls
{
    /// <summary>
    /// Struct used to reconstruct block.
    /// </summary>

    public struct BlockType 
    {

        public BlockType(int id, string name = "", FESScript2.UserControls.SubUserControls.Type type = SubUserControls.Type.Error) 
        {
            this.id = id;
            this.name = name;
            this.type = type;
            dots = new List<DotsType>();
            contents = new List<ContentsType>();
        }

        /// <summary>
        /// Global BlockType register.
        /// </summary>

        public static List<BlockType> global = new List<BlockType>();

        /// <summary>
        /// Unique identifier of block type.
        /// </summary>

        public int id;

        /// <summary>
        /// Name of the block type.
        /// </summary>

        public string name;

        /// <summary>
        /// Type of the block.
        /// </summary>

        public FESScript2.UserControls.SubUserControls.Type type;

        /// <summary>
        /// Struct that stores data needed for dot reconstruction.
        /// </summary>
        
        public List<DotsType> dots;

        /// <summary>
        /// Struct that stores data needed for contents of block reconstruction.
        /// </summary>

        public List<ContentsType> contents;
    }

    /// <summary>
    /// The visual block.
    /// </summary>

    public class Block : UserControlPlus
    {

        /// <summary>
        /// Determines if is clicked.
        /// </summary>

        public bool IsClicked
        {
            get 
            {
                return isClicked;
            }
            set 
            {
                isClicked = value;
            }
        }
        private bool isClicked;
        /// <summary>
        /// Block type id.
        /// </summary>

        public int BlockTypeId;

        public string name;

        /// <summary>
        /// Determines whether the block should be shown.
        /// </summary>

        public bool isShown;
        /// <summary>
        /// Whether it should be shown
        /// </summary>
        /// <param name="show">Determines whether Show() should be called.</param>

        public Block() : base()
        {
            Canvas.SetLeft(this, 0);
            Canvas.SetTop(this, 0);
            MinHeight = 40;
            grid = new Grid();
            this.Content = grid;
        }

        public Grid grid;

        public int id;
    }
}
