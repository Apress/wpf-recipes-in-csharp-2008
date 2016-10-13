using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Xps;

namespace Recipe_07_03
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

        private Visual GetVisual()
        {
            return new Grid();
        }

        private void btnPrintVisual_Click(object sender, RoutedEventArgs e)
        {
            //Get hold of the visual you want to print.
            Visual visual = GetVisual();

            // Create a Print dialog.
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() != true)
            {
                return;
            }

            // Get the default print queue
            PrintQueue pq = printDialog.PrintQueue;

            //Scale the visual
            Visual scaledVisual = ScaleVisual(visual, pq);

            // Get an XpsDocumentWriter for the default print queue
            XpsDocumentWriter xpsdw = PrintQueue.CreateXpsDocumentWriter(pq);

            xpsdw.Write(scaledVisual);
        }

        //We want to be able to scale the visual so it fits within the page.
        private Visual ScaleVisual(Visual v, PrintQueue pq)
        {
            ContainerVisual root = new ContainerVisual();
            const double inch = 96;

            // Set the margins.
            double xMargin = 1.25 * inch;
            double yMargin = 1 * inch;

            PrintTicket pt = pq.UserPrintTicket;
            double printableWidth = pt.PageMediaSize.Width.Value;
            double printableHeight = pt.PageMediaSize.Height.Value;
            
            double xScale = (printableWidth - xMargin * 2) / printableWidth;
            double yScale = (printableHeight - yMargin * 2) / printableHeight;

            root.Children.Add(v);
            root.Transform = new MatrixTransform(xScale, 0, 0, yScale, xMargin, yMargin);

            return root;
        }
    }
}
