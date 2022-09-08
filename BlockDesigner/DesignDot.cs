using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace FESScript2.Creator.BlockDes
{
    public class DesignDot : FESScript2.UserControls.SubUserControls.Dots
    {
        public DesignDot(UserControls.SubUserControls.DotsType dotType) : base(dotType)
        {
            MouseDown += OnMouseDown;
        }
        protected new void OnMouseDown(object sender, MouseEventArgs e)
        {
            DotDesignerWindow window = new DotDesignerWindow(ref this.dotTypeDotType);
            window.Show();
        }
    }
}
