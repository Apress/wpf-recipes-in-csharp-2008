using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Recipe_10_04
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        //Handler for the Window1.Loaded event
        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            //Get a reference to the triangleMesh defined in markup
            MeshGeometry3D triangleMesh
                = (MeshGeometry3D)TryFindResource("triangleMesh");
            //Create our pattern of triangles for each Viewport3D
            CreateTriangles(vp1, 4, triangleMesh);
            CreateTriangles(vp2, 4, triangleMesh);
            CreateTriangles(vp3, 4, triangleMesh);
            CreateTriangles(vp4, 4, triangleMesh);
        }

        private void CreateTriangles(Viewport3D viewport3D, 
            int triangleCount, MeshGeometry3D triangleMesh)
        {
            //Create four triangles
            for (int i = 0; i < 4; i++)
            {
                //Create a new model and geometry object
                ModelVisual3D modelVisual3D = new ModelVisual3D();
                GeometryModel3D geometryModel3D
                    = new GeometryModel3D();
                //Set the GeometryModel3D's Geomtry to the triangleMesh
                geometryModel3D.Geometry = triangleMesh;
                //Give the model a material
                geometryModel3D.Material
                    = new DiffuseMaterial(Brushes.Firebrick);
                //Set the content of the ModelVisual3D
                modelVisual3D.Content = geometryModel3D;
                //We want to rotate each triangle so that they overlap 
                //and intersect
                RotateTransform3D rotateTransform
                    = new RotateTransform3D();
                rotateTransform.Rotation
                    = new AxisAngleRotation3D(new Vector3D(0, 0, -1),
                                              i * 90);
                //Apply the transformation
                modelVisual3D.Transform = rotateTransform;
                //Add the new model to the Viewport3D's children
                viewport3D.Children.Add(modelVisual3D);
            }
        }
    }
}
