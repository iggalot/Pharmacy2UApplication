using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Threading;
using System.Xml;

namespace Pharmacy2UApplication.Core
{
    public class Printer
    {
        public static FlowDocument Clone(FlowDocument originalDocument)
        {
            FlowDocument clonedDocument = new FlowDocument();
            TextRange sourceDocumentRange = new TextRange(originalDocument.ContentStart, originalDocument.ContentEnd);
            TextRange clonedDocumentRange = new TextRange(clonedDocument.ContentStart, clonedDocument.ContentEnd);
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    sourceDocumentRange.Save(ms, DataFormats.XamlPackage);
                    clonedDocumentRange.Load(ms, DataFormats.XamlPackage);
                }

                clonedDocument.ColumnWidth = originalDocument.ColumnWidth;
                clonedDocument.PageWidth = originalDocument.PageWidth;
                clonedDocument.PageHeight = originalDocument.PageHeight;
                clonedDocument.PagePadding = originalDocument.PagePadding;
                clonedDocument.LineStackingStrategy = clonedDocument.LineStackingStrategy;

                return clonedDocument;
            }
            catch (Exception)
            {

            }
            return null;
        }

        private static string ForceRenderFlowDocumentXaml =
            @"<Window xmlns=""http://schemas.microsoft.com/netfx/2007/xaml/presentation""
                      xmlns:x=""http://schemas.microsft.com/winfx/2006/xaml"">
                    <FlowDocumentScrollViewer Name=""viewer""/>
              </Window>";

        public static void ForceRenderFlowDocument(FlowDocument document)
        {
            using (var reader = new XmlTextReader(new StringReader(ForceRenderFlowDocumentXaml)))
            {
                Window window = XamlReader.Load(reader) as Window;
                FlowDocumentScrollViewer viewer = LogicalTreeHelper.FindLogicalNode(window, "viewer") as FlowDocumentScrollViewer;
                viewer.Document = document;
                // Show the window way off-screen
                window.WindowStartupLocation = WindowStartupLocation.Manual;
                window.Top = Int32.MaxValue;
                window.Left = Int32.MaxValue;
                window.ShowInTaskbar = false;
                window.Show();

                // Ensure the dispatcher has done the layout and render passes
                Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Loaded, new Action(() => { } ));
                viewer.Document = null;
                window.Close();

            }
        }
        public void DoPrint()
        {
            
        }
    }
}
