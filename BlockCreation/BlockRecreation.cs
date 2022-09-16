using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Media;
using FESScript2.UserControls;
using System.Windows.Controls;

namespace FESScript2.CodeWorks.BlockCreation
{
    public static class BlockRecreation
    {
        /// <summary>
        /// Specifies in which row is the context grid.
        /// </summary>

        private const int contentGridColumn = 1;

        /// <summary>
        /// Recreates block from template.
        /// </summary>
        /// <param name="blockTemplate">Template with data to recreate block.</param>
        /// <param name="block">Reference to block.</param>

        public static void RecreateBlock(BlockType blockTemplate, ref Block block, bool subscribeToEvents = true)
        {
            if (block == null) 
            {
                block = new Block();
            }
            else 
            {
                block.grid.ColumnDefinitions.Clear();
                block.grid.RowDefinitions.Clear();
                block.grid.Children.Clear();
            }
            block.grid.ColumnDefinitions.Add(new ColumnDefinition() { Name = "InputDots", Width = System.Windows.GridLength.Auto, MinWidth = 15 }) ;
            block.grid.ColumnDefinitions.Add(new ColumnDefinition() { Name = "Contents", Width = System.Windows.GridLength.Auto, MinWidth = 15 });
            block.grid.ColumnDefinitions.Add(new ColumnDefinition() { Name = "OutputDots", Width = System.Windows.GridLength.Auto, MinWidth = 15 });
            RecreateBackground(blockTemplate.type, ref block);
            RecreateDots(blockTemplate.dots, ref block);
            RecreateContents(blockTemplate.contents, ref block);
            block.BlockTypeId = blockTemplate.id;
            block.name = blockTemplate.name + block.id;
        }

            /// <summary>
            /// Creates background for block.
            /// </summary>
            /// <param name="type">Type of block.</param>
            /// <param name="block">Reference to block.</param>

        private static void RecreateBackground (UserControls.SubUserControls.Type type, ref Block block) 
        {   
            UserControls.SubUserControls.BlockBackground background = new UserControls.SubUserControls.BlockBackground() { Type = type, StrokeThickness = "5", Stroke = Brushes.Gray, MinHeight = 25 };
            Grid.SetColumnSpan(background, int.MaxValue);
            Grid.SetRowSpan(background, int.MaxValue);
            block.grid.Children.Add(background);
        }

        /// <summary>
        /// Struct containing data to recreate dots.
        /// </summary>
        /// <param name="dotTypes">Struct containing data to recreate dots.</param>
        /// <param name="block">Reference to block.</param>

        private static void RecreateDots(List<UserControls.SubUserControls.DotsType> dotTypes, ref Block block) 
        {
            Grid inputGrid = new Grid();
            Grid outputGrid = new Grid();
            inputGrid.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            outputGrid.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            int ioOutCount = 0;
            int ioInCount = 0;

            foreach (UserControls.SubUserControls.DotsType dotType in dotTypes) 
            {
                UserControls.SubUserControls.Dots dot = new UserControls.SubUserControls.Dots(dotType);
                dot.DotType = dotType.dotType;
                dot.id = dotType.id;
                dot.dotName = dotType.Name;
                if (dotType.io == UserControls.SubUserControls.IO.Input)
                {
                    inputGrid.RowDefinitions.Add(new RowDefinition());
                    dot.Margin = new System.Windows.Thickness(10, 2.5, 0, 2.5);
                    inputGrid.Children.Add(dot);
                    Grid.SetRow(dot, ioInCount);
                    ioInCount++;
                }
                else if (dotType.io == UserControls.SubUserControls.IO.Output)
                {
                    outputGrid.RowDefinitions.Add(new RowDefinition());
                    dot.Margin = new System.Windows.Thickness(0, 2.5, 10, 2.5);
                    outputGrid.Children.Add(dot);
                    Grid.SetRow(dot, ioOutCount);
                    ioOutCount++;
                }
            }
            inputGrid.Margin = new System.Windows.Thickness(0, 5, 0, 5);
            outputGrid.Margin = new System.Windows.Thickness(0, 5, 0, 5);
            block.grid.Children.Add(inputGrid);
            block.grid.Children.Add(outputGrid);

            Grid.SetColumn(inputGrid, 0); 
            Grid.SetRow(inputGrid, 0);
            Grid.SetColumn(outputGrid, int.MaxValue);
            Grid.SetRow(outputGrid, 0);
        }

        /// <summary>
        /// Struct containing data to recreate contents.
        /// </summary>
        /// <param name="contentTypes">Struct containing data to recreate contents.</param>
        /// <param name="block">Reference to block.</param>

        private static void RecreateContents(List<UserControls.SubUserControls.ContentsType> contentTypes, ref Block block)
        {
            Grid contentGrid = new Grid();
            Grid.SetColumn(contentGrid, contentGridColumn);
            foreach (UserControls.SubUserControls.ContentsType contentType in contentTypes)
            {
                contentGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = System.Windows.GridLength.Auto });
                if (contentType.type == typeof(UserControls.SubUserControls.TextLabel)) 
                {
                    UserControls.SubUserControls.TextLabel content = new UserControls.SubUserControls.TextLabel(contentType);
                    
                    content.Id = contentType.id;
                    content.Text = contentType.text;
                    Grid.SetColumn(content, contentType.column);
                    contentGrid.Children.Add(content);
                    content.Padding = new System.Windows.Thickness(2.5, 0, 2.5, 0);
                }
                else if (contentType.type == typeof(UserControls.SubUserControls.TextBox))
                {
                    UserControls.SubUserControls.TextBox content = new UserControls.SubUserControls.TextBox(contentType);
                    
                    content.Id = contentType.id;
                    content.Text = contentType.text;
                    Grid.SetColumn(content, contentType.column);
                    contentGrid.Children.Add(content);
                    content.Padding = new System.Windows.Thickness(2.5, 0, 2.5, 0);
                }
                else if (contentType.type == typeof(UserControls.SubUserControls.Combobox))
                {
                    UserControls.SubUserControls.Combobox content = new UserControls.SubUserControls.Combobox(contentType);
                    
                    content.Id = contentType.id;
                    content.Text = contentType.text;
                    content.comboBox.IsEnabled = false;
                    Grid.SetColumn(content, contentType.column);
                    content.Padding = new System.Windows.Thickness(2.5, 0, 2.5, 0);

                    contentGrid.Children.Add(content);
                }
                else if (contentType.type == typeof(UserControls.SubUserControls.Checkbox))
                {
                    UserControls.SubUserControls.Checkbox content = new UserControls.SubUserControls.Checkbox(contentType);
                    
                    content.Id = contentType.id;
                    content.Text = contentType.text;
                    content.checkBox.IsEnabled = false;
                    Grid.SetColumn(content, contentType.column);
                    contentGrid.Children.Add(content);
                    content.Padding = new System.Windows.Thickness(2.5, 12.5, 2.5, 0);
                }
            }
            block.grid.Children.Add(contentGrid);
        }
    }
}
