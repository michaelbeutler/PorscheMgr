using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
            CarList.RowDefinitions.Add(new RowDefinition());
            foreach (Car c in Program.GetAllCars())
            {
                AddCar(c);
                SetDetails(c);
            }
            Details_Button.Click += delegate (object sender, RoutedEventArgs e) { ButtonConfigure_Click(sender, e, selectedCar); };
        }

        private int x = 0;
        private int y = 0;
        private void AddCar(Car c)
        {
            Border border = new Border();
            border.Style = (Style)FindResource("BorderCar");
            RoutedEventHandler h = delegate (object sender, RoutedEventArgs e) { ShowDetails_Click(sender, e, c); };
            border.AddHandler(Border.MouseDownEvent,  h);

            StackPanel panel  = new StackPanel();

            Image image = new Image();
            //image.Source = new BitmapImage(new Uri(c.Image));
            if (File.Exists(c.Image))
            {
                image.Source = new BitmapImage(new Uri(c.Image, UriKind.RelativeOrAbsolute));
            }
            image.Width = 150;
            image.SetValue(Grid.RowProperty, 0);

            TextBlock textblockName = new TextBlock();
            textblockName.Text = c.Brand.Name + " " + c.Name;
            textblockName.HorizontalAlignment = HorizontalAlignment.Center;
            textblockName.FontSize = 12;
            textblockName.FontWeight = FontWeights.Bold;
            textblockName.Margin = new Thickness(2, 2, 2, 2);
            textblockName.SetValue(Grid.RowProperty, 1);

            TextBlock textblockPrice = new TextBlock();
            textblockPrice.Text = "CHF " + c.Price +  " exkl. MwST.";
            textblockPrice.HorizontalAlignment = HorizontalAlignment.Center;
            textblockPrice.SetValue(Grid.RowProperty, 2);

            Button button = new Button();
            button.Content = "Konfigurieren";
            button.Margin = new Thickness(0, 10, 0, 0);
            button.Width = 150;
            button.Style = (Style)FindResource("WhiteButtonBorder");
            button.Click += delegate (object sender, RoutedEventArgs e) { ButtonConfigure_Click(sender, e, c); };
            button.SetValue(Grid.RowProperty, 3);

            panel.Children.Add(image);
            panel.Children.Add(textblockName);
            panel.Children.Add(textblockPrice);
            panel.Children.Add(button);

            border.Child = panel;
            border.SetValue(Grid.ColumnProperty, x);
            border.SetValue(Grid.RowProperty, y);
            CarList.Children.Add(border);

            if (x < 3)
            { 
                x++;
            } else
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

        private void ButtonConfigure_Click(object sender, RoutedEventArgs e, Car c)
        {
            new Configure(c).Show();
        }

        private Car selectedCar = null;
        private void ShowDetails_Click(object sender, RoutedEventArgs e, Car c)
        {
            SetDetails(c);
        }

        private void SetDetails(Car c)
        {
            selectedCar = c;
            Details_Name.Text = c.Brand.Name + " " + c.Name;
            Details_PS.Text = c.Engine.MaxPower + " PS";
            Details_PS_At_Rpm.Text = c.Engine.MaxPowerAtRpm + " 1/min";
            Details_Nm.Text = c.Engine.MaxTorque + " Nm";
            Details_Nm_At_Rpm.Text = c.Engine.MaxPowerAtRpm + " 1/min";
            Details_ZeroToSixyt.Text = c.Performance.ZeroToSixty + " s";
            Details_MaxTrackSpeed.Text = c.Performance.TopTrackSpeed + " km/h";
            Details_CylinderNum.Text = c.Engine.CylinderNum.ToString();
            Details_Displacment.Text = c.Engine.Displacement + " cm³";
            Details_DriveTrain.Text = c.Transmission.Drivetrain;
        }
    }
}
