using System;
using System.Collections.Generic;
using System.Text;
using FESScript2.UserControls;

namespace FESScript2.Creator.BlockDes
{
    public struct DesignBlockType
    {
        public static List<FESScript2.UserControls.SubUserControls.ContentsType> contents = new List<FESScript2.UserControls.SubUserControls.ContentsType>();
        public static List<FESScript2.UserControls.SubUserControls.DotsType> dots = new List<FESScript2.UserControls.SubUserControls.DotsType>();
        public DesignBlockType(int id, string name, FESScript2.UserControls.SubUserControls.Type type)
        {
            blockType = new BlockType(id, name, type);
            blockType.contents = contents;
            blockType.dots = dots;
        }
        public BlockType blockType;
        public List<FESScript2.UserControls.SubUserControls.DotsType> Dots 
        {
            get 
            {
                return blockType.dots;
            }
            set 
            {
                blockType.dots = value;
            }
        }

        public List<FESScript2.UserControls.SubUserControls.ContentsType> Contents
        {
            get
            {
                return blockType.contents;
            }
            set
            {
                blockType.contents = value;
            }
        }
    }
}
