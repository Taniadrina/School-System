using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;


namespace LIVEX.Class
{
    class Print
    {
        public static void print()
        {
            //PrintDialog printDlg = new PrintDialog();

            //FlowDocument doc = new FlowDocument(new Paragraph(new Run("Some text goes here")));
            //doc.Name = "FlowDoc";
            //IDocumentPaginatorSource idpSource = doc;
            //// Call PrintDocument method to send document to printer
            //printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");
        }

        /// <summary>
        /// This method creates a dynamic FlowDocument. You can add anything to this
        /// FlowDocument that you would like to send to the printer
        /// </summary>
        /// <returns></returns>
        public static void CreateFlowDocument(LIVEX.UserControls.NominaMaestros nom)
        {
            // Create a FlowDocument
            FlowDocument doc = new FlowDocument();

            // Create a Section
            Section sec = new Section();

          

            BlockUIContainer Contenido = new BlockUIContainer();
            Contenido.Child = nom.stkContent;
            sec.Blocks.Add(Contenido);


            // Add Paragraph to Section
            //sec.Blocks.Add(nom);

            // Add Section to FlowDocument
            doc.Blocks.Add(sec);
            doc.Name = "FlowDoc";
            PrintDialog printDlg = new PrintDialog();
            IDocumentPaginatorSource idpSource = doc;
            printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");
        }

        //private void PrintSimpleTextButton_Click(object sender, RoutedEventArgs e)
        //{
        //    // Create a PrintDialog
        //    PrintDialog printDlg = new PrintDialog();

        //    // Create a FlowDocument dynamically.
        //    FlowDocument doc = CreateFlowDocument();
        //    doc.Name = "FlowDoc";

        //    // Create IDocumentPaginatorSource from FlowDocument
        //    IDocumentPaginatorSource idpSource = doc;

        //    // Call PrintDocument method to send document to printer
        //    printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");
        //}
    }
}
