using System.Windows;

namespace autocad_wf_layer_add_29_03_2023
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : Window
    {
        Layer_Data _data;
        public UserControl1(Layer_Data data)
        {
            InitializeComponent();
            _data = data;
            this.DataContext = _data;
        }
        private void button_ok_Click(object sender, RoutedEventArgs e)
        {
                this.DialogResult = true;
                this.Close();
        }
        private void button_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult= false;
            this.Close();
        }
    }
}
