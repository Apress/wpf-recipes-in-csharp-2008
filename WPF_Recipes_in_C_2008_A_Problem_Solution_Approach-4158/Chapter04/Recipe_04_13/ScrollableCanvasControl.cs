using System;
using System.Windows;
using System.Windows.Controls;

namespace Recipe_04_13
{
    public class ScrollableCanvasControl : Canvas
    {
        static ScrollableCanvasControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(ScrollableCanvasControl), 
                new FrameworkPropertyMetadata(
                    typeof(ScrollableCanvasControl)));
        }

        protected override Size MeasureOverride(
            Size constraint)
        {
            double bottomMost = 0d;
            double rightMost = 0d;

            // Loop through the child FrameworkElements,
            // and track the highest Top and Left value
            // amongst them.
            foreach(object obj in Children)
            {
                FrameworkElement child = obj as FrameworkElement;

                if(child != null)
                {
                    child.Measure(constraint);

                    bottomMost = Math.Max(
                        bottomMost, 
                        GetTop(child) +
                        child.DesiredSize.Height);
                    rightMost = Math.Max(
                        rightMost, 
                        GetLeft(child) + 
                        child.DesiredSize.Width);
                }
            }

            if(double.IsNaN(bottomMost) 
               || double.IsInfinity(bottomMost))
            {
                bottomMost = 0d;
            }

            if(double.IsNaN(rightMost) 
               || double.IsInfinity(rightMost))
            {
                rightMost = 0d;
            }
            
            // Return the new size
            return new Size(rightMost, bottomMost);
        }
    }
}