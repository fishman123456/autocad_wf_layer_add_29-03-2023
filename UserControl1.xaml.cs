using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using AcadApp = Autodesk.AutoCAD.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace autocad_wf_layer_add_29_03_2023
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : System.Windows.Window
    {
        Layer_Data _data;
        public UserControl1(Layer_Data data)
        {
            InitializeComponent();
            _data = data;
            this.DataContext = _data;
            
        }

        private void button_cancel_Click(object sender, RoutedEventArgs e)
        {

                this.DialogResult = false;
            // не понятно чем Hide отличается от Close
                this.Hide();
        }

        private void button_ok_Click(object sender, RoutedEventArgs e)
        {
           this.DialogResult= true;
            this.Close();
        }
    }
}
