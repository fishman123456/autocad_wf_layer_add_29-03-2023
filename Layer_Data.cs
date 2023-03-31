using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;

using System;
using System.ComponentModel;

namespace autocad_wf_layer_add_29_03_2023
{

    public class Layer_Data : INotifyPropertyChanged
    {
        string _name;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value.Trim();
                // при изменении свойства  уведомляет всех подписчиков
                // в данном случае подписчиком является форма

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsValid"));
                }
            }
        }
        public bool IsOn { get; set; }
        public bool IsFrozen { get; set; }
        public bool IsValid
        {
            get
            {
                if (!string.IsNullOrEmpty(Name)) return false;
                try
                { 
                    // проверяем название слоя на недопустимые символы
                    // этот метод выдает исключение, 
                    SymbolUtilityServices.ValidateSymbolName(Name, false);
                    return true;
                }
                catch (Exception ex)
                {
                    Application.ShowAlertDialog(ex.Message);
                    return false;
                    // удаляем название
                }

            }
        }

    }
}
