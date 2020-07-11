using System;
using System.Drawing;
using System.Windows.Forms;
using CircleMovements.Shape;

namespace CircleMovements.Drawing
{
    public class ShapeDrawer : IShapeDrawer
    {
        private readonly IShape _shape;
        private readonly Pen _previousPen;
        private readonly Graphics _graphics;
        private readonly int _thickness;
        private readonly int _baseX;
        private readonly int _baseY;
        private readonly PictureBox _currentPlace;

        public ShapeDrawer(IShape shape, Graphics graphics, int thickness, int baseX, int baseY, PictureBox currentPlace)
        {
            if (thickness <= 0) throw new ArgumentOutOfRangeException(nameof(thickness));
            _shape = shape;
            _graphics = graphics ?? throw new ArgumentNullException(nameof(graphics));
            _thickness = thickness;
            _baseX = baseX;
            _baseY = baseY;
            _currentPlace = currentPlace ?? throw new ArgumentNullException(nameof(currentPlace));
            _previousPen = new Pen(Color.Green, _thickness);
        }

        public void Draw()
        {
            Point previous = new Point(_baseX + _shape.X - _thickness / 2, _baseY + _shape.Y - _thickness / 2);
            _shape.UpdatePosition();
            Point current = new Point(_baseX + _shape.X - _thickness / 2, _baseY + _shape.Y - _thickness / 2);
            _currentPlace.Location = current;
            _graphics.DrawLine(_previousPen, previous, current);
            //current.X -= _thickness / 2;
            //current.Y -= _thickness / 2;
            
            //_graphics.DrawRectangle(_currentPen, current.X, current.Y, 1, 1);
            //DrawWith(_currentBrush);
        }

        private void DrawWith(Brush brush)
        {
            int x = _baseX + _shape.X - _thickness / 2;
            int y = _baseY + _shape.Y - _thickness / 2;
            _graphics.FillEllipse(brush, x, y, _thickness, _thickness);
        }
    }
}
