﻿namespace CircleMovements.Shape
{
    public class ComplexShape : IShape
    {
        private readonly Circle _circleX;
        private readonly Circle _circleY;

        public ComplexShape(Circle circleX, Circle circleY)
        {
            _circleX = circleX;
            _circleY = circleY;
            UpdatePosition();
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public void UpdatePosition()
        {
            X = _circleX.X;
            Y = _circleY.Y;
        }
    }
}