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
            // Add RowDefinition to CarList
            CarList.RowDefinitions.Add(new RowDefinition());

            // Loop throw each Car object in return value of GetAllCars();
            foreach (Car c in Program.GetAllCars())
            {
                // Add car to list
                AddCar(c);

                // Set the data on the details site
                SetDetails(c);
            }

            // Set selected car and update the click event on the Details button
            if (selectedCar != null)
            {
                Details_Button.Click += delegate (object sender, RoutedEventArgs e) { ButtonConfigure_Click(sender, e, selectedCar); };
            } else
            {
                Details_Button.IsEnabled = false;
            }
            
        }

        /// <summary>
        /// Add a car to CarList and if needed create a new row.
        /// </summary>
        private int x = 0;
        private int y = 0;
        private void AddCar(Car c)
        {
            Border border = new Border
            {
                Style = (Style)FindResource("BorderCar")
            };
            RoutedEventHandler h = delegate (object sender, RoutedEventArgs e) { ShowDetails_Click(sender, e, c); };
            border.AddHandler(Border.MouseDownEvent,  h);

            StackPanel panel  = new StackPanel();

            Image image = new Image();
            var fullFilePath = c.Image;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bitmap.EndInit();

            image.Source = bitmap;
            image.Width = 150;
            image.SetValue(Grid.RowProperty, 0);

            TextBlock textblockName = new TextBlock
            {
                Text = c.Brand.Name + " " + c.Name,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 12,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(2, 2, 2, 2)
            };
            textblockName.SetValue(Grid.RowProperty, 1);

            TextBlock textblockPrice = new TextBlock
            {
                Text = "CHF " + c.Price + " exkl. MwST.",
                HorizontalAlignment = HorizontalAlignment.Center
            };
            textblockPrice.SetValue(Grid.RowProperty, 2);

            Button button = new Button
            {
                Content = "Konfigurieren",
                Margin = new Thickness(0, 10, 0, 0),
                Width = 150,
                Style = (Style)FindResource("WhiteButtonBorder")
            };
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

            // If there are more than 3 cars in one row go to the next row
            if (x < 2)
            { 
                x++;
            } else
            {
                x = 0;
                y++;
                CarList.RowDefinitions.Add(new RowDefinition());
            }
        }

        /// <summary>
        /// Make the window draggble
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        /// <summary>
        /// Close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Open the configure window with the selected car
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="c"></param>
        private void ButtonConfigure_Click(object sender, RoutedEventArgs e, Car c)
        {
            new Configure(c).Show();
        }

        /// <summary>
        /// Selected car
        /// </summary>
        private Car selectedCar = null;

        /// <summary>
        /// Set the data in the details part of the window on the left site by calling the SetDetails method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="c"></param>
        private void ShowDetails_Click(object sender, RoutedEventArgs e, Car c)
        {
            SetDetails(c);
        }

        /// <summary>
        /// Set the data in the details part of the window on the left site
        /// </summary>
        /// <param name="c"></param>
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
