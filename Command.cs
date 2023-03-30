using AcadApp = Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Markup;

namespace autocad_wf_layer_add_29_03_2023
{
    public class Command
    {
        [CommandMethod("Create_Layer_WPF")]
        public void CreateLayerRun()
        {
            AcadApp.Document adoc = AcadApp.Application.DocumentManager.MdiActiveDocument;
            Database db = adoc.Database;
            Editor ed = adoc.Editor;
            // Создаём обьект
            Layer_Data layerData = new Layer_Data();
            layerData.Name = "NewLayer";
            layerData.IsOn = true;
            layerData.IsFrozen = false;
            // пытаемся открыть форму


            UserControl1 wpf_1 = new UserControl1(layerData);
            // 30-03-2023 19:47 application надо автокадовское брать скорее всего. Я был прав
            AcadApp.Application.ShowModalWindow(wpf_1);
            //30-03-2023 работает со stackpanel
            //try
            //{
            //    if (AcadApp.Application.ShowModalWindow(wpf_1) != true) return;
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            // открываем транзакцию
            using (Transaction tr = db.TransactionManager.StartTransaction())
            // получаем таблицу слоёв
            {
                LayerTable lt = (LayerTable)tr.GetObject(db.LayerTableId, OpenMode.ForRead);
                // если название не удалено и такого еще нет в таблице слоев
                if (!lt.Has(layerData.Name))
                {
                    LayerTableRecord ltr = new LayerTableRecord();
                    ltr.Name = layerData.Name;
                    ltr.IsOff = !layerData.IsOn;
                    ltr.IsFrozen = layerData.IsFrozen;
                    lt.UpgradeOpen();
                    lt.Add(ltr);
                    tr.AddNewlyCreatedDBObject(ltr, true);
                }
                else
                {
                    AcadApp.Application.ShowAlertDialog("Такой слой уже есть!");
                }
                tr.Commit();
            }

        }
    }
}
