using AcadApplication = Autodesk.AutoCAD.ApplicationServices;

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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Markup;

namespace autocad_wf_layer_add_29_03_2023
{
    /// <summary>
    /// Логика взаимодействия для Win_Form.xaml
    /// </summary>
    public partial class Win_Form : Window
    {
        Layer_Data _data;
        public Win_Form()
        {
            InitializeComponent();
        }
        public Win_Form(Layer_Data data)
        {
            InitializeComponent();
            _data = data;
            // this.Window_1_Create_Layer.DataContext = data;
        }
        
       

        private void button_ok_Click(object sender, RoutedEventArgs e)
        {
            if (_data.IsValid) 
            {
                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("Валидный текест");
            }
        }
        private void button_cancel_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
