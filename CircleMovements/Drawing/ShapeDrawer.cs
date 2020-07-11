using System;
using System.Drawing;
using CircleMovements.Shape;

namespace CircleMovements.Drawing
{
    public class ShapeDrawer : IShapeDrawer
    {
        private readonly IShape _shape;
        private readonly SolidBrush _previousBrush = new SolidBrush(Color.Green);
        private readonly SolidBrush _currentBrush = new SolidBrush(Color.Red);
        private readonly Graphics _graphics;
        private readonly int _thickness;
        private readonly int _baseX;
        private readonly int _baseY;

        public ShapeDrawer(IShape shape, Graphics graphics, int thickness, int baseX, int baseY)
        {
            _shape = shape;
            _graphics = graphics ?? throw new ArgumentNullException(nameof(graphics));
            _thickness = thickness;
            _baseX = baseX;
            _baseY = baseY;
        }

        public void Draw()
        {
            DrawWith(_previousBrush);
            _shape.UpdatePosition();
            DrawWith(_currentBrush);
        }

        private void DrawWith(Brush brush)
        {
            int x = _baseX + _shape.X - _thickness / 2;
            int y = _baseY + _shape.Y - _thickness / 2;
            _graphics.FillEllipse(brush, x, y, _thickness, _thickness);
        }
    }
}
