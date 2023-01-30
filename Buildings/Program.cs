using System;
using System.Collections.Generic;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Building
    {
        protected int floorNum = 1;
        protected float width = 0.0f;
        protected float length = 0.0f;

        public Building(int pNF, float pW, float pL)
        {
            this.floorNum = pNF;
            this.width = pW;
            this.length = pL;
        }

        public int Numberfloors
        {
            get { return floorNum; }
            set { floorNum = value; }
        }

        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        public float Length
        {
            get { return length; }
            set { length = value; }
        }

        public virtual void CalcSize()
        {
            Console.WriteLine("Total floor area = " + (floorNum * width * length));
        }

        public virtual void Display()
        {
            Console.WriteLine("Floors" + this.floorNum + " m");
            Console.WriteLine("Width" + this.width + " m");
            Console.WriteLine("Length" + this.length + " m");
        }
    }

    public class House : Building
    {
        private int bedNum;
        private int bathNum;

        public int NumBedrooms
        {
            get { return bedNum; }
            set { bedNum = value; }
        }

        public House(int pNF, float pW, float pL, int pNB, int pNbath) : base(pNF, pW, pL)
        {
            this.bedNum = pNB;
            this.bathNum = pNbath;
        }

        public override void Display()
        {
            Console.WriteLine("Bedrooms" + this.bedNum + " m");
            Console.WriteLine("Bathrooms" + this.bathNum + " m");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OOP");
            Building s = new Building(5, 3, 3);
            s.Display();

            Building[] street = new Building[10];
            int PropertyNum = 0;

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            docPath = Path.Combine(docPath, "Academic/Computing/C#/property.txt");
            StreamReader input = new StreamReader(docPath);
            //List<float> arr = new List<float>();

            string[] lines = File.ReadAllLines(docPath);

            foreach (string line in lines)
            {
                string[] vals = line.Split(',');
                int floors = Convert.ToInt32(vals[0]);
                float w = Convert.ToSingle(vals[1]);
                float l = Convert.ToSingle(vals[2]);
                if (vals.Length == 3)
                {
                    street[PropertyNum] = new Building(floors, w, l);
                }
                else
                {
                    int numbed = Convert.ToInt32(vals[3]);
                    int numbath = Convert.ToInt32(vals[4]);
                    street[PropertyNum] = new House(floors, w, l, numbed, numbath);
                }
                Console.WriteLine("Num " + PropertyNum + " data " + w + " " + l);
                PropertyNum += 1;
            }

            Console.WriteLine(street);
        }
    }
}