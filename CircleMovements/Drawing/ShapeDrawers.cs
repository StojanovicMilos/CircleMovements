using System.Drawing;
using System.Windows.Forms;
using CircleMovements.Shape;

namespace CircleMovements.Drawing
{
    public class ShapeDrawers : IShapeDrawer
    {
        private readonly IShapeDrawer[,] _shapeDrawers;
        
        public ShapeDrawers(int numberOfRowsAndColumns, in int pictureBoxSize, in int baseSpeed,
            Graphics graphics, int thickness, PictureBox[,] pictureBoxes)
        {
            int radius = pictureBoxSize / numberOfRowsAndColumns / 2;
            
            _shapeDrawers = new IShapeDrawer[numberOfRowsAndColumns, numberOfRowsAndColumns];

            _shapeDrawers[0,0] = new DummyShapeDrawer();

            Circle[] circlesX = GetCircles(numberOfRowsAndColumns, radius - thickness, baseSpeed);
            Circle[] circlesY = GetCircles(numberOfRowsAndColumns, radius - thickness, baseSpeed);

            for (int i = 1; i < _shapeDrawers.GetLength(0); i++)
            {
                _shapeDrawers[i, 0] = new ShapeDrawer(circlesX[i], graphics, thickness, i * radius * 2, 0, pictureBoxes[i,0]);
            }

            for (int j = 1; j < _shapeDrawers.GetLength(1); j++)
            {
                _shapeDrawers[0, j] = new ShapeDrawer(circlesY[j], graphics, thickness, 0, j * radius * 2, pictureBoxes[0,j]);
            }

            for (int i = 1; i < _shapeDrawers.GetLength(0); i++)
            {
                for (int j = 1; j < _shapeDrawers.GetLength(1); j++)
                {
                    _shapeDrawers[i, j] = new ShapeDrawer(new ComplexShape(circlesX[i], circlesY[j]), graphics, thickness, i * radius * 2, j * radius * 2, pictureBoxes[i, j]);
                }
            }
        }

        private static Circle[] GetCircles(int numberOfRowsAndColumns, int radius, int baseSpeed)
        {
            Circle[] circles = new Circle[numberOfRowsAndColumns];
            for (int i = 0; i < circles.Length; i++)
            {
                circles[i] = new Circle(radius, baseSpeed + i);
            }

            return circles;
        }

        public void Draw()
        {
            foreach (var shapeDrawer in _shapeDrawers)
            {
                shapeDrawer.Draw();
            }
        }
    }
}
