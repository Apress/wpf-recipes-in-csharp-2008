using System.Collections.Generic;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Xps;

namespace Recipe_07_04
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private List<Visual> GetVisuals()
        {
            return new List<Visual>(new Visual[] {VisualRoot, VisualRoot, VisualRoot});
        }

        private void btnPrintVisuals_Click(object sender, RoutedEventArgs e)
        {
            //Get hold of the visual you want to print.
            List<Visual> visuals = GetVisuals();

            // Create a Print dialog.
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() != true)
            {
                return;
            }

            // Get the default print queue
            PrintQueue printQueue = printDialog.PrintQueue;

            // Get an XpsDocumentWriter for the default print queue
            XpsDocumentWriter xpsdw = PrintQueue.CreateXpsDocumentWriter(printQueue);

            VisualsToXpsDocument vtxd =
                (VisualsToXpsDocument)xpsdw.CreateVisualsCollator();
            
            //Indicate we want any writes to be performed in a batch operation.
            vtxd.BeginBatchWrite();

            //Write out each visual.
            visuals.ForEach(delegate(Visual visual)
            {
                //Scale the visual
                Visual scaledVisual = ScaleVisual(visual, printQueue);

                vtxd.Write(scaledVisual);
            });

            //Mark the end of the batch operation.
            vtxd.EndBatchWrite();
        }

        //We want to be able to scale the visual so it fits within the page.
        private Visual ScaleVisual(Visual visual, PrintQueue printQueue)
        {
            ContainerVisual root = new ContainerVisual();

            //An inch is 96 DIPs, use this to scale up sizes given in inches.
            double inch = 96;

            //Calculate our margins.
            double xMargin = 1.25 * inch;
            double yMargin = 1 * inch;

            //Get the current print ticket from which the paper size can be
            //obtained.
            PrintTicket printTicket = printQueue.UserPrintTicket;

            //Retrieve the dimensions of the target page.
            double pageWidth = printTicket.PageMediaSize.Width.Value;
            double pageHeight = printTicket.PageMediaSize.Height.Value;

            double xScale = (pageWidth - xMargin * 2) / pageWidth;
            double yScale = (pageHeight - yMargin * 2) / pageHeight;

            root.Children.Add(visual);

            root.Transform = new MatrixTransform(xScale, 0, 0, yScale, xMargin, yMargin);

            return root;
        }
    }
}
