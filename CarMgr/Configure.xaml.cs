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

            var fullFilePath = c.Image2;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bitmap.EndInit();

            CarImage.Source = bitmap;
        }

        private void Load()
        {
            CarName.Text = configuration.CarBase.Brand.Name + " " + configuration.CarBase.Name;
            BasePrice.Text = "Fahrzeuggrundpreis: " + configuration.GetCarBasePrice();
            PartPrice.Text = "Gesamtpreis Ausstattung: " + configuration.GetPartPrice();
            TotalPrice.Text = "Gesamtpreis*: " + configuration.GetTotalPrice();

            MaxPower.Text = (configuration.CarBase.Engine.MaxPower + configuration.Horsepower) + " PS";
            GetDiffString("MAXPOWER");

            MaxTorque.Text = (configuration.CarBase.Engine.MaxTorque + configuration.Torque) + " Nm";
            GetDiffString("MAXTORQUE");

            Displacment.Text = (configuration.CarBase.Engine.Displacement + configuration.Displacment) + " cm³";
            GetDiffString("DISPLACEMENT");

            ZeroToSixty.Text = (configuration.CarBase.Performance.ZeroToSixty + configuration.ZeroToSixty) + " s";
            GetDiffString("ZEROTOSIXTY");

            MaxTrackSpeed.Text = (configuration.CarBase.Performance.TopTrackSpeed + configuration.TopTrackSpeed) + " km/h";
            GetDiffString("TOPTRACKSPEED");
        }

        private void GetDiffString(String request)
        {
            double diffValue = 0;
            char plusOperator = '+';
            char minusOperator = ' ';
            string plusColor = "#16aa2c";
            string minusColor = "#d5001c";
            TextBlock diffField = null;
            string suffix = "";
            switch (request)
            {
                case "MAXPOWER":
                    diffValue = configuration.Horsepower;
                    diffField = MaxPower_Diff;
                    suffix = "PS";
                    break; ;

                case "MAXTORQUE":
                    diffValue = configuration.Torque;
                    diffField = MaxTorque_Diff;
                    suffix = "Nm";
                    break; ;

                case "DISPLACEMENT":
                    diffValue = configuration.Displacment;
                    diffField = Displacment_Diff;
                    suffix = "cm³";
                    break; ;

                case "ZEROTOSIXTY":
                    diffValue = configuration.ZeroToSixty;
                    diffField = ZeroToSixty_Diff;
                    suffix = "s";
                    plusColor = "#d5001c";
                    minusColor = "#16aa2c"; 
                    break; ;

                case "TOPTRACKSPEED":
                    diffValue = configuration.TopTrackSpeed;
                    diffField = MaxTrackSpeed_Diff;
                    suffix = "km/h";
                    break; ;
            }

            string text = "";
            if (diffValue == 0)
            {
                text = "";
            } else if (diffValue > 0)
            {
                text = plusOperator + " " + diffValue + " " + suffix;
                diffField.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(plusColor));
            } else if (diffValue < 0)
            {
                text = minusOperator + " " + diffValue + " " + suffix;
                diffField.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(minusColor));
            }

            diffField.Text = text;
        }

        private string GetDiffValue()
        {
            return null;
        }

        private void AddPartToList(Part part)
        {
            StackPanel panel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };

            TextBlock name = new TextBlock
            {
                Text = part.Name,
                Margin = new Thickness(0, 0, 100, 0),
                FontSize = 16
            };

            TextBlock price = new TextBlock
            {
                Text = "CHF " + part.Price,
                Margin = new Thickness(0, 0, 200, 0),
                FontSize = 16
            };

            Button add = new Button
            {
                Content = "+",
                Style = (Style)FindResource("WhiteButton"),
                FontSize = 16,
                Width = 50,
                HorizontalAlignment = HorizontalAlignment.Left
            };
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
                TextBlock name = new TextBlock
                {
                    Text = p.Name,
                    Margin = new Thickness(0, 0, 50, 0)
                };
                name.SetValue(Grid.ColumnProperty, 0);
                name.SetValue(Grid.RowProperty, y);

                TextBlock price = new TextBlock
                {
                    Text = "CHF " + p.Price
                };
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
