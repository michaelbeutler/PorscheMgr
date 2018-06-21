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
        private ConfCar configuration;
        
        public Configure(Car c)
        {
            configuration = new ConfCar(c);
            InitializeComponent();
            Load();
            foreach (Part part in Program.GetAllParts(c))
            {
                AddPartToList(part);
            }
        }

        private void Load()
        {
            CarName.Text = configuration.CarBase.Brand.Name + " " + configuration.CarBase.Name;
            BasePrice.Text = "Fahrzeuggrundpreis: " + configuration.GetCarBasePrice();
            PartPrice.Text = "Gesamtpreis Ausstattung: " + configuration.GetPartPrice();
            TotalPrice.Text = "Gesamtpreis*: " + configuration.GetTotalPrice();
            MaxPower.Text = (configuration.CarBase.Engine.MaxPower + configuration.Horsepower) + " PS";
            MaxTorque.Text = (configuration.CarBase.Engine.MaxTorque + configuration.Torque) + " Nm";
            Displacment.Text = (configuration.CarBase.Engine.Displacement + configuration.Displacment) + " cm³";
            ZeroToSixty.Text = (configuration.CarBase.Performance.ZeroToSixty + configuration.ZeroToSixty) + " s";
            MaxTrackSpeed.Text = (configuration.CarBase.Performance.TopTrackSpeed + configuration.TopTrackSpeed) + " km/h";
        }

        private void GetDiffString(String request)
        {
            double diffValue = 0;
            char plusOperator = '+';
            char minusOperator = '-';
            TextBlock diffField = null;
            string suffix = "";
            switch (request)
            {
                case "MAXPOWER":
                    diffValue = configuration.Horsepower;
                    diffField = MaxPower_Diff;
                    suffix = "PS";
                    break; ;
            }

            string text = "";
            if (diffValue == 0)
            {
                text = "";
            } else if (diffValue > 0)
            {
                text = plusOperator + " " + diffValue + " " + suffix;
                diffField.Foreground = 
            } else if (diffValue < 0)
            {
                text = minusOperator + " " + diffValue + " " + suffix;
                diffField.Foreground = 
            }

            diffField.Text = text;
        }

        private string GetDiffValue()
        {
            return null;
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
            add.Click += delegate (object sender, RoutedEventArgs e) { ButtonAddRemove_Click(sender, e, part); };

            panel.Children.Add(name);
            panel.Children.Add(price);
            panel.Children.Add(add);

            PartList.Children.Add(panel);
        }

        int y = 0;
        private void AddPartToCar(Part p)
        {
            configuration.AddPart(p);
            Load();
            LoadCarParts();
        }

        private void LoadCarParts()
        {
            y = 0;
            CarPartList.Children.RemoveRange(0, CarPartList.Children.Count);
            foreach (Part p in configuration.Parts)
            {
                TextBlock name = new TextBlock();
                name.Text = p.Name;
                name.Margin = new Thickness(0, 0, 50, 0);
                name.SetValue(Grid.ColumnProperty, 0);
                name.SetValue(Grid.RowProperty, y);

                TextBlock price = new TextBlock();
                price.Text = "CHF " + p.Price;
                price.SetValue(Grid.ColumnProperty, 1);
                price.SetValue(Grid.RowProperty, y);

                CarPartList.RowDefinitions.Add(new RowDefinition());
                CarPartList.Children.Add(name);
                CarPartList.Children.Add(price);
                y++;
                _Scrollviewer.ScrollToEnd();
            }
            
        }

        private void RemovePartFromCar(Part p)
        {
            configuration.RemovePart(p);
            Load();
            LoadCarParts();
        }

        private void ButtonAddRemove_Click(object sender, RoutedEventArgs e, Part p)
        {
            
            Button btn = e.Source as Button;

            if (btn.Content.Equals("+"))
            {
                AddPartToCar(p);
                btn.Content = "-";
            } else
            {
                RemovePartFromCar(p);
                btn.Content = "+";
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

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
