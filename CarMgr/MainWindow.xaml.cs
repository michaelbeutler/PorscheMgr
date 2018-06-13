using System;
using System.Collections.Generic;
using System.Linq;
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

namespace CarMgr
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 3; i++)
            {
                AddCar();
            }
        }

        private int x = 1;
        private int y = 0;
        private void AddCar()
        {

            StackPanel panel = new StackPanel();

            Image image = new Image
            {
                //image.Source = new BitmapImage(new Uri("C:\\Users\\winmed\\Documents\\Visual Studio 2015\\Projects\\PorscheConfigurator\\PorscheConfigurator\\images\\911\\911_Carrera\\911_Carrera.jpg"));
                Width = 150
            };

            TextBlock textblockName = new TextBlock
            {
                Text = "Porsche 911 Carrera",
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 12,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(2, 2, 2, 2)
            };

            TextBlock textblockPrice = new TextBlock
            {
                Text = "CHF 90'000.0 exkl. MwST.",
                HorizontalAlignment = HorizontalAlignment.Center
            };

            Button button = new Button
            {
                Content = "Konfigurieren",
                Margin = new Thickness(0, 10, 0, 0),
                Width = 150,
                Style = (Style)FindResource("WhiteButtonBorder")
            };
            button.Click += new RoutedEventHandler(ButtonConfigure_Click);

            panel.Children.Add(image);
            panel.Children.Add(textblockName);
            panel.Children.Add(textblockPrice);
            panel.Children.Add(button);

 
            panel.SetValue(Grid.ColumnProperty, x);
            panel.SetValue(Grid.RowProperty, y);
            CarList.Children.Add(panel);

            if (x < 3)
            {
                x++;
            }
            else
            {
                x = 0;
                y++;
                CarList.RowDefinitions.Add(new RowDefinition());
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonConfigure_Click(object sender, RoutedEventArgs e)
        {
            new Configure().Show();
        }
    }
}
