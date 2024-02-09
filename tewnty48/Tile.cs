using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tewnty48
{
    internal class Tile
    {
        public bool IsTaken { get; set; }
        public Point Coordinate { get; set; }
        public int Value { get; set; }
        public System.Windows.Forms.Label label { get; set; }
        public Tile() {
            IsTaken = false;

        }
        public Tile(int x,int y)
        {
            Random rnd = new Random();
            int rand = rnd.Next(1, 11);
            if (rand == 10)
                Value = 4;
            else
                Value = 2;
            Coordinate = new Point(x,y);
            IsTaken = true;
        }
        public void AddValue()
        {
            Random rnd = new Random();
            Value = rnd.Next(1, 3) * 2;
        }
        public void MoveX(int x) 
        { 

            Coordinate = new Point(x,Coordinate.Y);
        }
        public void MoveY(int y)
        {
            Coordinate = new Point(Coordinate.X,y);
        }



    }
}
