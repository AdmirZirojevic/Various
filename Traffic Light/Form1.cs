using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semafor
{
    public partial class Form1 : Form
    {    
        decimal carCounter = 0.0m;

        Timer trafficLight = new Timer();             
        Car verticalAuto;
        Car horizontalAuto;

        public Form1()
        {
            InitializeComponent();
        }

        private void updateVerticalLocation()
        {
            pictureVerticalCar.Location = verticalAuto.Location;
        }

        public void updateHorizontalLocation()
        {
            pictureHorizontalCar.Location = horizontalAuto.Location;
        }

        private void start_Click_1(object sender, EventArgs e)
        {
            verticalAuto = new Car(carAxis.Vertical);
            horizontalAuto = new Car(carAxis.Horizontal);
            red1.BackColor = Color.Red;
            green2.BackColor = Color.Green;
            updateVerticalLocation();
            updateHorizontalLocation();

            trafficLight.Interval = 100;
            trafficLight.Tick += TrafficLight_Tick;

            trafficLight.Start();
        }

        private void TrafficLight_Tick(object sender, EventArgs e)
        {
            carCounter += 0.1m;

            //provjere za vertikalno auto
            if(red1.BackColor != Color.Red&& pictureVerticalCar.Location.Y != 185 || yellow1.BackColor != Color.Yellow && pictureVerticalCar.Location.Y != 185) //provjera za vertikalno auto da ako je crveno da stane
            {
                verticalAuto.changeYLocation();
                updateVerticalLocation();
            }
            else if(green1.BackColor==Color.Green&& pictureVerticalCar.Location.Y == 185) //provjera ako vertikalno auto stoji a zeleno je, da krene
            {
                verticalAuto.changeYLocation();
                updateVerticalLocation();
            }

            if (pictureVerticalCar.Location.Y == 10) //kad dodje do kraja vraca na pocetak vertikalno auto
            {
                verticalAuto.setYLocation();
                updateVerticalLocation();
            }

            //provjere za horizontalno auto
            if ((red2.BackColor != Color.Red && pictureHorizontalCar.Location.X != 340) || (yellow2.BackColor != Color.Yellow && pictureHorizontalCar.Location.X != 340)) //provjera za horizontalno auto da ako je crveno da stane 
            {
                horizontalAuto.changeXLocation();
                updateHorizontalLocation();
            }
            else if (green2.BackColor == Color.Green && pictureHorizontalCar.Location.X == 340) //provjera ako horizontalno auto stoji a zeleno je, da krene
            {
                horizontalAuto.changeXLocation();
                updateHorizontalLocation();
            }

            if (pictureHorizontalCar.Location.X == 580) //kad dodje do kraja vraca na pocetak horizontalno auto
            {
                horizontalAuto.setXLocation();
                updateHorizontalLocation();
            }

            switch ((int)carCounter) //manipulisanje za semafor
            {
                case 1:
                    green1.BackColor = Control.DefaultBackColor;
                    red1.BackColor = Color.Red;
                    green2.BackColor = Color.Green;
                    yellow2.BackColor = Control.DefaultBackColor;
                    red2.BackColor = Control.DefaultBackColor;
                        break;               
                case 3:
                    red1.BackColor = Control.DefaultBackColor;
                    yellow1.BackColor = Color.Yellow;                   
                    green2.BackColor= Control.DefaultBackColor;
                    red2.BackColor = Color.Red;
                    break;
                case 4:
                    red1.BackColor = Control.DefaultBackColor;
                    yellow1.BackColor = Control.DefaultBackColor;
                    green1.BackColor = Color.Green;
                    break;
                case 5:
                    yellow2.BackColor = Color.Yellow;
                    red2.BackColor = Control.DefaultBackColor;
                    carCounter = 0.0m;//cisto samo da bi zeleno svjetlo trajalo sekundu duze
                    break;            
            }
            start.Text = carCounter.ToString();
        }     
    }
}
