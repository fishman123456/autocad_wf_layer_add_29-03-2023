using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace autocad_wf_layer_add_29_03_2023
{

    public class Layer_Data : INotifyPropertyChanged
    {
        string _name;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return _name; }
            set { 
                _name = value.Trim();
                // при изменении свойства  уведомляет всех подписчиков
                // в данном случае подписчиком является форма

            if(PropertyChanged != null)
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
                if (string.IsNullOrEmpty(Name)) return false;
                try
                {
                    return !string.IsNullOrEmpty(Name);
                    // проверяем название слоя на недопустимые символы
                    // этот метод выдает исключение, 
                    SymbolUtilityServices.ValidateSymbolName(Name, false);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                    Application.ShowAlertDialog(ex.Message);
                    // удаляем название
                    
                }

            }
        }
       
    }
}
