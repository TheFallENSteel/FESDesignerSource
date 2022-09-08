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
using System.Windows.Shapes;
using FESScript2.UserControls;

namespace FESScript2.BlockDesigner
{
    /// <summary>
    /// Interaction logic for GlobalVariablesWindow.xaml
    /// </summary>
    public partial class GlobalVariablesWindow : Window
    {
        public GlobalVariablesWindow()
        {
            InitializeComponent();
            /*Binding binding = new Binding();
            binding.Source = FESScript2.UserControls.GlobalVariable.globalVariables;
            binding.Mode = BindingMode.TwoWay;
            binding.Path = new PropertyPath()
            globalVariablesList.SetBinding(ItemsControl.ItemsSourceProperty, binding);
            //FESScript2.UserControls.GlobalVariable.globalVariables;*/
            GlobalVariable.onGlobalVariablesListChange += onListChange;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariable variable = new GlobalVariable();
            variable.RegisterVariable();
        }

        private void onListChange() 
        {
            globalVariablesList.GetBindingExpression(ItemsControl.ItemsSourceProperty).UpdateSource();
        }
    }
}
