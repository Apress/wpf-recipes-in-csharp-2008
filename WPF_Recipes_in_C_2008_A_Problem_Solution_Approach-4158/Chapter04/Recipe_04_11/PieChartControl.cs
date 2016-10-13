using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Recipe_04_11
{
    public class PieChartControl : FrameworkElement
    {
        #region Slices

        public List<double> Slices
        {
            get
            {
                return (List<double>) GetValue(SlicesProperty);
            }
            set
            {
                SetValue(SlicesProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for slices. 
        // This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SlicesProperty =
            DependencyProperty.Register("Slices",
                                        typeof(List<double>),
                                        typeof(PieChartControl),
                                        new FrameworkPropertyMetadata(
                                            null,
                                            FrameworkPropertyMetadataOptions.AffectsRender,
                                            new PropertyChangedCallback(OnPropertyChanged)));
        #endregion

        /// <summary>
        /// Override the OnRender and draw the slices
        /// for the pie chart
        /// </summary>
        /// <param name="drawingContext"></param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            List<double> segments = this.Slices;

            if(segments != null)
            {
                Size radius = new Size(
                    this.RenderSize.Width * 0.5,
                    this.RenderSize.Height * 0.5);

                Point startPoint = new Point(radius.Width, 0);

                foreach(double slice in segments)
                {
                    startPoint = DrawSlice(
                        drawingContext,
                        slice,
                        startPoint,
                        radius);
                }
            }
        }

        private Point DrawSlice(DrawingContext drawingContext, double slice, Point startPoint, Size radius)
        {
            // double theta = (slice.Percentage / 100) * 360;
            double theta = (slice / 100) * 360;

            // nb. This caters for the condition where we have one slice
            theta = (theta == 360) ? 359.99 : theta;

            //Note - we need to translate the point first. 
            // Could be rolled into a single affine transformation.
            Point endPoint =
                RotatePoint(
                    new Point(
                        startPoint.X - radius.Width,
                        startPoint.Y - radius.Height),
                    theta);

            endPoint = new Point(
                endPoint.X + radius.Width,
                endPoint.Y + radius.Height);

            bool isLargeArc = (theta > 180);

            PathGeometry geometry = new PathGeometry();
            PathFigure figure = new PathFigure();

            geometry.Figures.Add(figure);

            figure.IsClosed = true;
            figure.StartPoint = startPoint;

            figure.Segments.Add(new ArcSegment(endPoint, radius, 0, isLargeArc, SweepDirection.Clockwise, false));
            figure.Segments.Add(new LineSegment(startPoint, false));
            figure.Segments.Add(new LineSegment(endPoint, false));
            figure.Segments.Add(new LineSegment(new Point(radius.Width, radius.Height), false));

            SolidColorBrush brush = new SolidColorBrush(GetRandomColor());
            drawingContext.DrawGeometry(brush, new Pen(brush, 1), geometry);

            startPoint = endPoint;
            return startPoint;
        }

        private const double _pi_by180 = Math.PI / 180;

        private Point RotatePoint(Point a, double phi)
        {
            double theta = phi * _pi_by180;
            double x = Math.Cos(theta) * a.X + -Math.Sin(theta) * a.Y;
            double y = Math.Sin(theta) * a.X + Math.Cos(theta) * a.Y;
            return new Point(x, y);
        }

        protected static void OnPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            PieChartControl pcc = o as PieChartControl;
            if(null != pcc)
                pcc.InvalidateVisual();
        }

        private static Random seed = new Random();

        private Color GetRandomColor()
        {
            Color newColor = new Color();

            newColor.A = (byte) 255;
            newColor.R = (byte) seed.Next(0, 256);
            newColor.G = (byte) seed.Next(0, 256);
            newColor.B = (byte) seed.Next(0, 256);

            return newColor;
        }
    }
}