﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    public class Square : Shape
    {
        public static readonly int DeafultSide = 30;
        internal int Side { get; set; }

        public Square() : this(DeafultSide)
        {
            Side = DeafultSide;
        }

        public Square(int side)
        {
            Side = side;
        }

        public Square(Point position, int side) : base(position)
        {
            position.X = (base.CurrentPoint.X);
            position.Y = (base.CurrentPoint.Y);
            Side = side;
        }

        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(Color.Black, 2);
            if (Side == 0)
            {
                graphics.DrawRectangle(pen, CurrentPoint.X, CurrentPoint.Y, DeafultSide, DeafultSide);
            }
            else
            {
                graphics.DrawRectangle(pen, CurrentPoint.X, CurrentPoint.Y, Side, Side);
            }
        }

        public override void Fill(Graphics graphics)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            if (Side == 0)
            {
                graphics.FillRectangle(brush, CurrentPoint.X, CurrentPoint.Y, DeafultSide, DeafultSide);
            }
            else
            {
                graphics.FillRectangle(brush, CurrentPoint.X, CurrentPoint.Y, Side, Side);
            }
        }
        public Square(IEnumerable<int> arguments)
        {
            //check if there are 1 or 3 ints
            //set the first two int to the position
            //set the last int to the side length
        }
    }
}