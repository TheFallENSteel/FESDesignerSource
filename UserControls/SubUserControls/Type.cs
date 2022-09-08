using System.Collections.Generic;
using System.Windows.Media;

namespace FESScript2.UserControls.SubUserControls
{

    /// <summary>
    /// Input output enum.
    /// </summary>

    public enum IO : byte
    { 
        Input = 0,
        Output = 1,
        Error = byte.MaxValue
    }

    /// <summary>
    /// Type enum.
    /// </summary>

    public enum Type : byte
    {
        Action = 0,
        Numerical = 1,
        Textual = 2,
        Console = 3,
        Boolean = 4,
        SubAction = 5,
        Error = byte.MaxValue
    }

    /// <summary>
    /// Binding Types to Colors.
    /// </summary>

    public static class Colors
    {
        public static Dictionary<Type, Brush> TypeToColor = new Dictionary<Type, Brush>();
        static Colors() 
        {
            TypeToColor.Add(Type.Action, Brushes.Peru);
            TypeToColor.Add(Type.Textual, Brushes.OrangeRed);
            TypeToColor.Add(Type.Numerical, Brushes.LimeGreen);
            TypeToColor.Add(Type.Console, Brushes.DarkGreen);
            TypeToColor.Add(Type.Boolean, Brushes.Blue);
            TypeToColor.Add(Type.Error, Brushes.Magenta);
            TypeToColor.Add(Type.SubAction, new SolidColorBrush( new Color() { R = 190, G = 118, B = 51, A = 48 }));
        }
    }
}
