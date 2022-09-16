using System;
using System.Collections.Generic;
using System.Text;

namespace FESScript2.UserControls.SubUserControls
{

    /// <summary>
    /// Struct ro reconstruct dots.
    /// </summary>

    public class DotsType
    {
        public Type dotType;
        public IO io;
        public int id;

        public string Name
        {
            get
            {
                return (io == IO.Input ? "I" : io == IO.Output ? "O" : "E") + id;
            }
        }
        public string RelativeName
        {
            get
            {
                return "$" + Name;
            }
        }
    }
}
