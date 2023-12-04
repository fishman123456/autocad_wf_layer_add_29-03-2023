using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;

namespace autocad_wf_layer_add_29_03_2023
{
    public class Command
    {
        public class Commands : IExtensionApplication
        {
            // эта функция будет вызываться при выполнении в AutoCAD команды "TestCommand"
            [CommandMethod("TestCommand")]
            public void MyCommand()
            {
                // получаем текущий документ и его БД
                Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
                Database acCurDb = acDoc.Database;

                // блокируем документ
                using (DocumentLock docloc = acDoc.LockDocument())
                {
                    // начинаем транзакцию
                    using (Transaction tr = acCurDb.TransactionManager.StartTransaction())
                    {
                        // открываем таблицу слоев документа
                        LayerTable acLyrTbl = tr.GetObject(acCurDb.LayerTableId, OpenMode.ForWrite) as LayerTable;

                        // создаем новый слой и задаем ему имя
                        LayerTableRecord acLyrTblRec = new LayerTableRecord();
                        acLyrTblRec.Name = "HabrLayer";

                        // заносим созданный слой в таблицу слоев
                        acLyrTbl.Add(acLyrTblRec);

                        // добавляем созданный слой в документ
                        tr.AddNewlyCreatedDBObject(acLyrTblRec, true);

                        // фиксируем транзакцию
                        tr.Commit();
                    }
                }
            }

            // эта функция будет вызываться при выполнении в AutoCAD команды "NewCommand"
            [CommandMethod("NewCommand")]
            public void NewCommand()
            {
                // получаем текущий документ и его БД
                Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
                Database acCurDb = acDoc.Database;

                // блокируем документ
                using (DocumentLock docloc = acDoc.LockDocument())
                {
                    // начинаем транзакцию
                    using (Transaction tr = acCurDb.TransactionManager.StartTransaction())
                    {
                        // открываем таблицу слоев документа
                        LayerTable acLyrTbl = tr.GetObject(acCurDb.LayerTableId, OpenMode.ForWrite) as LayerTable;

                        // если в таблице слоев нет нашего слоя - прекращаем выполнение команды
                        if (acLyrTbl.Has("HabrLayer") == false)
                        {
                            return;
                        }

                        // получаем запись слоя для изменения
                        LayerTableRecord acLyrTblRec = tr.GetObject(acLyrTbl["HabrLayer"], OpenMode.ForWrite) as LayerTableRecord;

                        // скрываем и блокируем слой
                        acLyrTblRec.Name = "test";
                        acLyrTblRec.IsOff = true;
                        acLyrTblRec.IsLocked = true;

                        // фиксируем транзакцию
                        tr.Commit();
                    }
                }
            }

            // Функции Initialize() и Terminate() необходимы, чтобы реализовать интерфейс IExtensionApplication
            public void Initialize()
            {

            }

            public void Terminate()
            {

            }
        }



    }
}
