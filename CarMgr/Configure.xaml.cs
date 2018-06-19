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
using System.Windows.Shapes;

namespace CarMgr
{
    /// <summary>
    /// Interaktionslogik für Configure.xaml
    /// </summary>
    public partial class Configure : Window
    {
        private Car car;
        private double priceParts = 0.0;
        private double horsepower = 0.0;
        public Configure(Car c)
        {
            car = c;
            InitializeComponent();
            Load(c);
            foreach (Part part in Program.GetAllParts(c))
            {
                AddPartToList(part);
            }
        }

        private void Load(Car c)
        {
            CarName.Text = c.Brand.Name + " " + c.Name;
            BasePrice.Text = "Fahrzeuggrundpreis: " + c.Price + " CHF";
            PartPrice.Text = "Gesamtpreis Ausstattung: " + priceParts + " CHF";
            TotalPrice.Text = "Gesamtpreis*: " + (c.Price + priceParts) + " CHF";
            MaxPower.Text = c.Engine.MaxPower + " PS";
            MaxTorque.Text = c.Engine.MaxTorque + " Nm";
            Displacment.Text = c.Engine.Displacement + " cm³";
            ZeroToSixty.Text = c.Performance.ZeroToSixty + " s";
            MaxTrackSpeed.Text = c.Performance.TopTrackSpeed + " km/h";
        }

        private void AddPartToList(Part part)
        {
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;

            TextBlock name = new TextBlock();
            name.Text = part.Name;
            name.Margin = new Thickness(0, 0, 100, 0);
            name.FontSize = 16;

            TextBlock price = new TextBlock();
            price.Text = "CHF " + part.Price;
            price.Margin = new Thickness(0, 0, 500, 0);
            price.FontSize = 16;

            Button add = new Button();
            add.Content = "+";
            add.Style = (Style)FindResource("WhiteButton");
            add.FontSize = 16;
            add.Width = 50;
            add.HorizontalAlignment = HorizontalAlignment.Left;
            add.Click += delegate (object sender, RoutedEventArgs e) { ButtonAdd_Click(sender, e, part); };

            panel.Children.Add(name);
            panel.Children.Add(price);
            panel.Children.Add(add);

            PartList.Children.Add(panel);
        }

        private void AddPartToCar(Part p)
        {
            if (p is PerformancePart)
            {
                PerformancePart p1 = p as PerformancePart;
                horsepower += p1.MaxPower;
                car.Engine.MaxPower = car.Engine.MaxPower + p1.MaxPower;
                if (p1.MaxPower < 0)
                {
                    MaxPower_Diff.Foreground = (Brush)new BrushConverter().ConvertFrom("#d5001c");
                    MaxPower_Diff.Text = horsepower.ToString();
                } else if (p1.MaxPower > 0)
                {
                    MaxPower_Diff.Text = "+" + horsepower.ToString() + " PS";
                }
                priceParts += p.Price;
                Load(car);
            }

            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;
            panel.Margin = new Thickness(10, 10, 10, 0);

            TextBlock name = new TextBlock();
            name.Text = p.Name;
            name.Margin = new Thickness(0, 0, 50, 0);

            TextBlock price = new TextBlock();
            price.Text = "CHF " + p.Price;

            panel.Children.Add(name);
            panel.Children.Add(price);
            CarPartList.Children.Add(panel);
             
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e, Part p)
        {
            AddPartToCar(p);
            Button btn = e.Source as Button;
            btn.Content = "-";
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

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
