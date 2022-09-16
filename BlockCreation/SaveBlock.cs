using System.IO;
using FESScript2.UserControls.SubUserControls;
using FESScript2.Creator.BlockDes;

namespace BlockDesigning.BlockCreation
{
    public static class SaveBlock
    {
        private static string BlockString(FESScript2.UserControls.BlockType blockType, string contents) 
        {
            string returnString = "";
            returnString += $"U{blockType.id}";
            returnString += $"\nT{(int)blockType.type}";
            foreach (var x in blockType.contents) 
            {
                //returnString += $"\n{(x.type == typeof(TextBox) ? "B" : "L")}{x.id}|{x.column}|{x.text}";
                if (x.type == typeof(TextBox)) 
                {
                    returnString += $"\nB{x.id}|{x.column}|{((x.text == "Sample Text") ? "" : x.text)}";
                }
                else if (x.type == typeof(TextLabel)) 
                {
                    returnString += $"\nL{x.id}|{x.column}|{((x.text == "Sample Text") ? "" : x.text)}";
                }
                else if (x.type == typeof(Combobox))
                {
                    string elements = "";
                    for (int i = 0; i < ((FESScript2.UserControls.SubUserControls.ContentArgs.ComboBoxArgs)x.ContentArgs).elements.Count; i++)
                    {
                        string element = ((FESScript2.UserControls.SubUserControls.ContentArgs.ComboBoxArgs)x.ContentArgs).elements[i];
                        elements += $"{element}{((i + 1 == ((FESScript2.UserControls.SubUserControls.ContentArgs.ComboBoxArgs)x.ContentArgs).elements.Count) ? "" : "|") }";
                    }
                    returnString += $"\nM{x.id}|{x.column}|{((x.text == "Sample Text") ? "" : x.text)}&{elements}";
                }
                else if (x.type == typeof(Checkbox))
                {
                    returnString += $"\nC{x.id}|{x.column}|{((x.text == "Sample Text") ? "" : x.text)}";
                }
            }
            foreach (var x in blockType.dots)
            {
                returnString += $"\n{(x.io == IO.Input ? "I" : (x.io == IO.Output ? "O" : "E"))}{x.id}|{(int)x.dotType}";
            }
            switch(BlockDesign.MainWindow.mainWindow.commandType.commandType)
            {
                case (CommandType.StandartToBlockWrite):
                    returnString += "\nEND\n";
                    break;
                case (CommandType.DirectCodeWrite):
                    returnString += "\nFU\n";
                    break;
                case (CommandType.DirectVariableWrite):
                    returnString += "\nFAKE\n";
                    break;
                default:
                    returnString += "\nNotSelectedCommandType\n";
                    break;
            }
            returnString += contents;
            return returnString;
        }
        public static void SaveBlockToFile(FESScript2.UserControls.BlockType blockType, string contents, string path) 
        {
            File.WriteAllText(path, BlockString(blockType, contents));
        }
    }
}
