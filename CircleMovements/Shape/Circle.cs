using System;

namespace CircleMovements.Shape
{
    public class Circle : IShape
    {
        private readonly int _radius;
        private readonly double _speed;
        private double _angle;

        public Circle(int radius, double speed)
        {
            if (radius <= 0) throw new ArgumentOutOfRangeException(nameof(radius));
            _radius = radius;
            _speed = speed;
            _angle = - Math.PI / 2;
            Y = 0;
            X = radius;
            UpdatePosition();
        }

        public void UpdatePosition()
        {
            X = _radius + (int) (_radius * Math.Cos(_angle));
            Y = _radius + (int) (_radius * Math.Sin(_angle));
            _angle += _speed * Math.PI / 180.0;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
    }
}
