using System.IO;
using FESScript2.UserControls.SubUserControls;

namespace BlockDesigning.BlockCreation
{
    public static class SaveBlock
    {
        private static string BlockString(FESScript2.UserControls.BlockType blockType, string contents) 
        {
            string returnString = "";
            returnString += $"U{blockType.id}";
            returnString += $"\nT{(int)blockType.type}";
            foreach (var x in FESScript2.UserControls.GlobalVariable.GlobalVariables)
            {
                returnString += $@"\nG{(((VariableType)x.variableType.SelectedItem) == VariableType.Number ? "N" : ((VariableType)x.variableType.SelectedItem) == VariableType.String ? "S" : ((VariableType)x.variableType.SelectedItem) == VariableType.Bool ? "X" : "E")}|{x.variableName}|{x.initialValue}";
            }
            foreach (var x in blockType.contents) 
            {
                //returnString += $"\n{(x.type == typeof(TextBox) ? "B" : "L")}{x.id}|{x.collumn}|{x.text}";
                if (x.type == typeof(TextBox)) 
                {
                    returnString += $"\nB{x.id}|{x.collumn}|{x.text}";
                }
                else if (x.type == typeof(TextLabel)) 
                {
                    returnString += $"\nL{x.id}|{x.collumn}|{x.text}";
                }
                else if (x.type == typeof(Combobox))
                {
                    string elements = "";
                    for (int i = 0; i < ((FESScript2.UserControls.SubUserControls.ContentArgs.ComboBoxArgs)x.ContentArgs).elements.Count; i++)
                    {
                        string element = ((FESScript2.UserControls.SubUserControls.ContentArgs.ComboBoxArgs)x.ContentArgs).elements[i];
                        elements += $"{element}{((i + 1 == ((FESScript2.UserControls.SubUserControls.ContentArgs.ComboBoxArgs)x.ContentArgs).elements.Count) ? "" : "|") }";
                    }
                    returnString += $"\nM{x.id}|{x.collumn}|{x.text}&{elements}";
                }
                else if (x.type == typeof(Checkbox))
                {
                    returnString += $"\nC{x.id}|{x.collumn}|{x.text}";
                }
            }
            foreach (var x in blockType.dots)
            {
                returnString += $"\n{(x.io == IO.Input ? "I" : (x.io == IO.Output ? "O" : "E"))}{x.id}|{(int)x.dotType}";
            }
            returnString += "\nEND\n";
            returnString += contents;
            return returnString;
        }
        public static void SaveBlockToFile(FESScript2.UserControls.BlockType blockType, string contents, string path) 
        {
            File.WriteAllText(path, BlockString(blockType, contents));
        }
    }
}
