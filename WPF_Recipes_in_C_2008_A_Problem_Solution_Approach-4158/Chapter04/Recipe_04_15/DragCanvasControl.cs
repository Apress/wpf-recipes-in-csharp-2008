using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Recipe_04_15
{
    public class DragCanvasControl : Canvas
    {
        private Point startPoint;
        private Point selectedElementOrigins;
        private bool isDragging;
        private UIElement selectedElement;

        static DragCanvasControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(DragCanvasControl),
                new FrameworkPropertyMetadata(
                    typeof(DragCanvasControl)));
        }

        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonDown(e);

            if(e.Source != this)
            {
                if(!isDragging)
                {
                    startPoint = e.GetPosition(this);
                    selectedElement = e.Source as UIElement;
                    this.CaptureMouse();

                    isDragging = true;

                    selectedElementOrigins =
                        new Point(
                            Canvas.GetLeft(selectedElement),
                            Canvas.GetTop(selectedElement));
                }
                e.Handled = true;
            }
        }

        protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonUp(e);

            if(this.IsMouseCaptured)
            {
                isDragging = false;
                this.ReleaseMouseCapture();

                e.Handled = true;
            }
        }

        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            base.OnPreviewMouseMove(e);

            if(this.IsMouseCaptured)
            {
                if(isDragging)
                {
                    Point currentPosition = e.GetPosition(this);

                    double elementLeft = (currentPosition.X - startPoint.X) +
                                         selectedElementOrigins.X;
                    double elementTop = (currentPosition.Y - startPoint.Y) +
                                        selectedElementOrigins.Y;

                    Canvas.SetLeft(selectedElement, elementLeft);
                    Canvas.SetTop(selectedElement, elementTop);
                }
            }
        }
    }
}