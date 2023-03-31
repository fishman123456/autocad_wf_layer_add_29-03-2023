using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;

using System.Windows;

using AcadApp = Autodesk.AutoCAD.ApplicationServices;

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
            // Создаём форму
            Layer_Data layerData = new Layer_Data();
            layerData.Name = "NewLayer";
            layerData.IsOn = true;
            layerData.IsFrozen = false;
            // пытаемся открыть форму

            //Win_Form windows = new Win_Form(layerData);
            UserControl1 wpf_1 = new UserControl1(layerData);

            AcadApp.Application.ShowModalWindow(wpf_1);
            
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
