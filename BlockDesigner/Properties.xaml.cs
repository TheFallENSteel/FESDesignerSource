using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FESScript2.Creator.BlockDes
{
    /// <summary>
    /// Interaction logic for Properties.xaml
    /// </summary>
    public partial class Properties : UserControl
    {
        public event TextChangedEventHandler OnSomeChange;
        public event RoutedEventHandler AddButtonClick;
        private MenuItem contentAdd;
        public Properties()
        {
            InitializeComponent();
            MenuItem dotAdd = new MenuItem() { Header = "Add new dot" };
            dotAdd.Click += DotAdd;
            contentAdd = new MenuItem() { Header = "Add new content" };
            addButton.ContextMenu = new ContextMenu();
            addButton.ContextMenu.Items.Add(dotAdd);
            addButton.ContextMenu.Items.Add(contentAdd);

            MenuItem textBox = new MenuItem() { Header = "Text box" };
            textBox.Click += ContentAdd<FESScript2.UserControls.SubUserControls.TextBox>;
            MenuItem textLabel = new MenuItem() { Header = "Text label" };
            textLabel.Click += ContentAdd<FESScript2.UserControls.SubUserControls.TextLabel>;
            MenuItem comboBox = new MenuItem() { Header = "ComboBox" };
            comboBox.Click += ContentAdd<FESScript2.UserControls.SubUserControls.Combobox>;
            MenuItem checkBox = new MenuItem() { Header = "CheckBox" };
            checkBox.Click += ContentAdd<FESScript2.UserControls.SubUserControls.Checkbox>;

            contentAdd.Items.Add(textBox);
            contentAdd.Items.Add(textLabel);
            contentAdd.Items.Add(checkBox);
            contentAdd.Items.Add(comboBox);
        }

        public DesignBlockType GetCurrentThings()
        {
            int id = 0;
            int.TryParse(BlockID, out id);
            return new DesignBlockType(id, BlockName, blockType);
        }

        public FESScript2.UserControls.SubUserControls.Type blockType 
        { 
            get 
            {
                try 
                {
                    if (comboBox.SelectedItem != null)
                    {
                        return (FESScript2.UserControls.SubUserControls.Type)comboBox.SelectedItem;
                    }
                    else 
                    {
                        return FESScript2.UserControls.SubUserControls.Type.Error;
                    }
                }
                catch 
                {
                    return FESScript2.UserControls.SubUserControls.Type.Error;
                }
            }
        }
        public string BlockName
        {
            get 
            {
                return blockName.Text;
            }
            set 
            {
                blockName.Text = value;
            }
        }
        public string BlockID
        {
            get
            {
                return blockID.Text;
            }
            set
            {
                blockID.Text = value;
            }
        }

        private void ContentAdd<T>(object sender, RoutedEventArgs e)
        {
            UserControls.SubUserControls.ContentsType contentType = null;
            BlockDes.DesignContentWindow window = new DesignContentWindow(ref contentType, typeof(T));
            window.Show();
        }

        private void DotAdd(object sender, RoutedEventArgs e)
        {
            DotDesignerWindow window = new DotDesignerWindow();
            window.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addButton.ContextMenu.IsOpen = true;
            AddButtonClick?.Invoke(sender, e);
        }

        private void OnChange(object sender, TextChangedEventArgs e)
        {
            OnSomeChange?.Invoke(this, null);
        }

        private void OnChange(object sender, SelectionChangedEventArgs e)
        {
            OnSomeChange?.Invoke(this, null);
        }

        private void directoryChooser_Click(object sender, RoutedEventArgs e)
        {
            FileDialog fileDialog = new Microsoft.Win32.SaveFileDialog() {  };
            fileDialog.DefaultExt = ".FESBlock";
            fileDialog.FileName = BlockDesign.MainWindow.blockType.blockType.name + ".FESBlock";
            bool? result = fileDialog.ShowDialog(BlockDesign.MainWindow.GetWindow(this));
            if (result == true) 
            {
                string filePath = fileDialog.FileName;
                BlockDesigning.BlockCreation.SaveBlock.SaveBlockToFile(BlockDesign.MainWindow.blockType.blockType, BlockDesign.MainWindow.mainWindow.contents.Text, filePath);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FESScript2.BlockDesigner.GlobalVariablesWindow globalVariableWindow = new FESScript2.BlockDesigner.GlobalVariablesWindow();
            globalVariableWindow.Show();
        }
        private void Clear(object sender, RoutedEventArgs e)
        {
            BlockDesign.MainWindow.mainWindow.properites.comboBox.SelectedItem = null;
            BlockDesign.MainWindow.mainWindow.properites.blockName.Text = "";
            BlockDesign.MainWindow.mainWindow.properites.blockID.Text = "";
            BlockDesign.MainWindow.mainWindow.contents.Text = "";
            BlockDesign.MainWindow.blockType = new DesignBlockType();
            DesignBlockType.contents = new List<UserControls.SubUserControls.ContentsType>();
            DesignBlockType.dots = new List<UserControls.SubUserControls.DotsType>();
            FESScript2.UserControls.GlobalVariable.GlobalVariables = new System.Collections.ObjectModel.ObservableCollection<UserControls.GlobalVariable>();
            BlockDesign.MainWindow.mainWindow.Properties_OnSomeChange(null, null);

        }
    }
}
