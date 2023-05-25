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
using System.Windows.Shapes;
using Word = Microsoft.Office.Interop.Word;

namespace Wpf1
{
    /// <summary>
    /// Логика взаимодействия для Basket.xaml
    /// </summary>
    public partial class Basket : Window
    {
        public List<Classes.ProductsInBasket> productsInBaskets;

        Word.Application wordApp;           //Приложение Word
        Word.Document wordDoc;          //Документ Word
        Word.Table wordTable;               //Таблица
        Word.InlineShape wordShape;         //Рисунок
        Word.Paragraph wordPar, tablePar;       //Абзац документа и таблицы
        Word.Range wordRange, tablRange;


        public Basket(List<Classes.ProductsInBasket> productsInBaskets)
        {
            InitializeComponent();
            Basket_Menu.Items.Clear();
            Basket_Menu.ItemsSource = productsInBaskets;
            this.productsInBaskets = productsInBaskets;
            summa_account_basket.Text = App.labelSummaMain.ToString();
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void buttonExitBasket_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIncr_Click(object sender, RoutedEventArgs e)
        {
            var productType = (sender as Button).DataContext as Classes.ProductsInBasket;
            double total = double.Parse(summa_order_basket.Text);
            if (total + productType.Price <= App.labelSummaMain)
            {
                productsInBaskets.Remove(productType);
                productType.Amount++;
                //productType.Total += (int)productType.PriceDisc;
                productType.Total  = productType.Amount * productType.Price;
                //summa_order_basket = productType.Total;
                //App.productPrice += App.productPrice;
                productsInBaskets.Add(productType);
                summa_order_basket.Text = productType.Total.ToString();

                total += productType.PriceDisc;
                summa_order_basket.Text = total.ToString();

                Basket_Menu.Items.Refresh();
            }
            else MessageBox.Show("Insufficient funds");
        }

        private void btnDecr_Click(object sender, RoutedEventArgs e)
        {
            var productType = (sender as Button).DataContext as Classes.ProductsInBasket;
            if (productType.Amount > 1)
            {
                productsInBaskets.Remove(productType);
                productType.Amount--;
                productType.Total -= (int)productType.PriceDisc;
                productsInBaskets.Add(productType);

                double total = double.Parse(summa_order_basket.Text.Split(' ')[2].Replace("₽", "")) - productType.PriceDisc;
                summa_order_basket.Text = total.ToString();

                Basket_Menu.Items.Refresh();
            }
            else MessageBox.Show("x");
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Create_order_basket_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wordApp = new Word.Application();
                wordApp.Visible = false;
            }
            catch
            {
                MessageBox.Show("Товарный чек в Word создать не удалось");
                return;
            }
            //Создание документа Word
            wordDoc = wordApp.Documents.Add();      //Добавить новый пустой документ
            wordDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientPortrait; // Книжная

            //**********Первый параграф – заголовок документа: логотип и дата
            wordPar = wordDoc.Paragraphs.Add();
            wordPar.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            wordRange = wordPar.Range;
            wordPar.set_Style("Заголовок 1");           //Стиль, взятый из Word
                                                        //Текст первого абзаца – заголовка документа
            wordRange.Text = "Дата заказа: " + DateTime.Now.ToLongDateString();
            ////Добавить логитип-картинку
            //wordShape = wordDoc.InlineShapes.AddPicture(App.pathExe + @"\Logo.png",
            //                                                           Type.Missing, Type.Missing, wordRange);
            //wordShape.Width = 100;
            //wordShape.Height = 100;

            //********Второй параграф - просто текст
            wordRange.InsertParagraphAfter();
            wordPar = wordDoc.Paragraphs.Add();
            wordPar.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            wordRange = wordPar.Range;
            wordRange.Font.Size = 16;
            wordRange.Font.Color = Word.WdColor.wdColorBlue;
            wordRange.Font.Name = "Arial";
            wordRange.Text = "Список заказанных блюд";

            //************Третий параграф - таблица
            wordRange = wordPar.Range;
            //Число строк в таблицы совпадает с число строк в таблице заказов формы
            wordTable = wordDoc.Tables.Add(wordRange, productsInBaskets.Count + 1, 4);
            wordTable.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            wordTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleDouble;
            //Заголовков таблицы из ЭУ DataGrid
            Word.Range cellRange;
            for (int col = 1; col <= 4; col++)
            {
                cellRange = wordTable.Cell(1, col).Range;
                cellRange.Text = Basket_Menu.Columns[col - 1].Header.ToString();
            }
            //Можно выполнить заливку заголовка таблицы
            wordTable.Rows[1].Shading.ForegroundPatternColor = Word.WdColor.wdColorLightYellow;
            wordTable.Rows[1].Shading.BackgroundPatternColorIndex = Word.WdColorIndex.wdBlue;
            wordTable.Rows[1].Range.Bold = 1;
            wordTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            wordRange.Font.Size = 14;
            wordRange.Font.Color = Word.WdColor.wdColorBlue;
            wordRange.Font.Name = "Time New Roman";
            //wordRange.Font.Italic = 1;
            //Заполнение ячеек таблицы из списка заказов
            wordPar.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            wordPar.set_Style("Заголовок 2");               //Стиль, взятый из Word
            for (int row = 2; row <= productsInBaskets.Count + 1; row++)
            {
                cellRange = wordTable.Cell(row, 1).Range;
                cellRange.Text = productsInBaskets[row - 2].Name;
                wordRange.Font.Size = 14;
                wordRange.Font.Color = Word.WdColor.wdColorBlack;
                wordRange.Font.Name = "Time New Roman";
                //wordRange.Font.Italic = 0;
                cellRange = wordTable.Cell(row, 2).Range;
                cellRange.Text = productsInBaskets[row - 2].Price.ToString();
                cellRange = wordTable.Cell(row, 3).Range;
                cellRange.Text = productsInBaskets[row - 2].Amount.ToString();
                cellRange = wordTable.Cell(row, 4).Range;
                cellRange.Text = productsInBaskets[row - 2].Total.ToString();
            }

            //*************Четвертый параграф - итоги
            wordRange.InsertParagraphAfter();
            wordPar = wordDoc.Paragraphs.Add();
            wordRange = wordPar.Range;
            wordPar.set_Style("Заголовок 1");               //Стиль, взятый из Word
            wordRange.Font.Color = Word.WdColor.wdColorRed;
            wordRange.Font.Size = 20;
            wordRange.Bold = 3;
            wordRange.Text = "Стоимость заказа: " + summa_order_basket.ToString() + " рублей";
            //wordApp.Visible = true;
            //Сохранение документа
            string fileName = App.pathExe + @"\Чек";
            wordDoc.SaveAs(fileName + ".docx");
            wordDoc.SaveAs(fileName + ".pdf", Word.WdExportFormat.wdExportFormatPDF);
            //Завершение работы с Word
            wordDoc.Close(true, null, null);                //Сначала закрыть документ
            wordApp.Quit();                     //Выход из Word
                                                //Вызвать свою подпрограмму убивания процессов
            releaseObject(wordPar);                 //Уничтожить абзац
            releaseObject(wordDoc);                 //Уничтожить документ
            releaseObject(wordApp);                 //Удалить из Диспетчера задач
        }
        public void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Не могу освободить объект " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        

    }
}
