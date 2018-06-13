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
            foreach (Car c in Program.GetAllCars())
            {
                AddCar(c);
            }
        }

        private int x = 1;
        private int y = 0;
        private void AddCar(Car c)
        {

            StackPanel panel = new StackPanel();

            Image image = new Image();
            image.Source = new BitmapImage(new Uri(c.Image));
            image.Width = 150;

            TextBlock textblockName = new TextBlock();
            textblockName.Text = c.Brand.Name + " " + c.Name;
            textblockName.HorizontalAlignment = HorizontalAlignment.Center;
            textblockName.FontSize = 12;
            textblockName.FontWeight = FontWeights.Bold;
            textblockName.Margin = new Thickness(2, 2, 2, 2);

            TextBlock textblockPrice = new TextBlock();
            textblockPrice.Text = "CHF " + c.Price +  " exkl. MwST.";
            textblockPrice.HorizontalAlignment = HorizontalAlignment.Center;

            Button button = new Button();
            button.Content = "Konfigurieren";
            button.Margin = new Thickness(0, 10, 0, 0);
            button.Width = 150;
            button.Style = (Style)FindResource("WhiteButtonBorder");
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
