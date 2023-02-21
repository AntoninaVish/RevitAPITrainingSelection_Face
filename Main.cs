using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITrainingSelection_Face
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand

    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            UIApplication uiapp = commandData.Application;//создаем переменную, таким образом как будто заходим в приложение Revit
            UIDocument uidoc = uiapp.ActiveUIDocument;//добираемся до свойства класса UIDocument,
            //обращаемся к переменной uiapp и забираем ActiveUIDocument т.е интерфейс текущего документа

            Document doc = uidoc.Document;//обращаемся к своему документу, к его базе данных

            //вызываем метод, который позволит выбрать элемент с помощью данного приложения
            //создаем переменную типа Reference обращаемся к uidoc
            Reference selectedElementRef = uidoc.Selection.PickObject(ObjectType.Face, "Выберите элемент по грани");

            //преобразовать переменную класса Reference в переменную класса Element
            //создаем переменную класса Element, обращаемся к документу, вызываем метод GetElement, указываем переменную selectedElementRef
            Element element = doc.GetElement(selectedElementRef);

            //в диалоговом окне выводим информацию по выбранному елементу
            //вызываем класс TaskDialog, обращаемся к статическому методу Show
            //$ - это фукция инстрополяции строк, в {} указываем свойства которые хотим выводить в данное окно
            //перемещаемся на следующую строку для этого обращаемся к {Enviroment.NewLine} выводим идентификатор Id{element.Id}
            TaskDialog.Show("Selection", $"Имя:{element.Name}{Environment.NewLine} Id{element.Id}");

            //таким образом мы обратились к UIApplication к Revit целиком, далее обратились к интерфейсу текущего документа uidoc
            //и через интерфейс текущего документа обратились к самому документу к его базе, далее с помощью переменной uidoc
            //мы выбрали ссылку на этот елемент - Reference selectedElementRef = uidoc.Selection.PickObject(ObjectType.Element, "Выберите элемент");


            return Result.Succeeded;
        }
    }
}
