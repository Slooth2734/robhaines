﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    internal class Line : Shape
    {
        internal int otherX { get; set; }
        internal int otherY { get; set; }

        /// <summary>
        ///     The line object that is created as a template for future
        ///     lines to created in line with.
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="otherX"></param>
        /// <param name="otherY"></param>
        public Line(Color colour, int x, int y, int otherX, int otherY) : base(colour, x, y)
        {
            this.colour = colour;
            this.otherX = otherX;
            this.otherY = otherY;
        }

        /// <summary>
        ///     Draw command for the line shape class.
        ///     The line will only be drawn when 4 numbers are specified due 
        ///     to two coordinated being needed to know where to draw the line
        ///     to and from. If not, the line will not be drawn. The color will
        ///     use the stored color.
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(Graphics graphics)
        {
            Pen p = new Pen(Color.Black, 2);
            graphics.DrawLine(p, x, y, otherX, otherY);
        }

        /// <summary>
        ///     Fill command for the line shape class.
        ///     The line will only be drawn when 4 numbers are specified due 
        ///     to two coordinated being needed to know where to draw the line
        ///     to and from. If not, the line will not be drawn. The color will
        ///     use the stored color.
        ///     The fill method only dfferts to the draw method by making the
        ///     line much thicker.
        /// </summary>
        /// <param name="graphics"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Fill(Graphics graphics)
        {
            Pen p = new Pen(Color.Black, 7);
            graphics.DrawLine(p, x, y, otherX, otherY);
        }
    }
}
