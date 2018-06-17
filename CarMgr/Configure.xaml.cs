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
        public Configure(Car c)
        {
            InitializeComponent();
            Load(c);
        }

        private void Load(Car c)
        {
            CarName.Text = c.Brand.Name + " " + c.Name;
            MaxPower.Text = c.Engine.MaxPower + " PS";
            MaxTorque.Text = c.Engine.MaxTorque + " Nm";
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
