using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for GlobalVariable.xaml
    /// </summary>
    public partial class GlobalVariable : UserControl
    {
        public delegate void listChange();
        public static ObservableCollection<GlobalVariable> GlobalVariables
        {
            get 
            {
                return globalVariables;
            }
            set 
            {
                globalVariables = value;
            }
        }
        private static ObservableCollection<GlobalVariable> globalVariables = new ObservableCollection<GlobalVariable>();
        public static listChange onGlobalVariablesListChange;
        public GlobalVariable()
        {
            InitializeComponent();
        }

        public void RegisterVariable() 
        {
            GlobalVariables.Add(this);
            onGlobalVariablesListChange?.Invoke();
        }

        public void UnRegisterVariable()
        {
            GlobalVariables.Remove(this);
            onGlobalVariablesListChange?.Invoke();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UnRegisterVariable();
        }
    }
}
