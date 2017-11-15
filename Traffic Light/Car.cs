using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Semafor
{
    enum carAxis
    {
        Vertical,
        Horizontal
    }

    class Car
    {       
        private Point location;
        
        public Car(carAxis carAxis)
        {
            if (carAxis == carAxis.Vertical)
            {
                this.location.X = 378;
                this.location.Y = 300;
            }
            if (carAxis==carAxis.Horizontal)
            {
                this.location.X = 150;
                this.location.Y = 149;
            }                       
        }

        public Point Location { get { return location; } }

        public void changeYLocation()
        {
            location.Y = location.Y - 5;
        }

        public void setYLocation()
        {
            location.Y = 300;
        }

        public void changeXLocation()
        {
            location.X = location.X + 10;
        }

        public void setXLocation()
        {
            location.X = 150;
        }
    }
}
