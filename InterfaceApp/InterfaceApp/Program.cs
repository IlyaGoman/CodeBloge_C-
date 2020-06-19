using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceApp
{
    class Program
    {
        public delegate int MyDelegate();
        static void Main(string[] args)
        {
            Human hm = new Human("Ilya");
            hm.GoToWalk += Hm_GoToWalk;
            hm.CheckToTime(DateTime.Parse("18/06/2020 12:00:00"));


            hm.SendEmail += Hm_SendEmail;
            hm.CheckPosition("Home");
            Console.ReadKey();
        }

        private static void Hm_SendEmail(object sender, EventArgs e)
        {
            Console.WriteLine($"{((Human)sender).Name} sent email");
        }

        private static void Hm_GoToWalk(object sender, EventArgs e)
        {
            Console.WriteLine($"{((Human)sender).Name} went to walk");
        }
    }

    class Human
    {
        public string Name { get; set; }

        public Human(string name)
        {
            Name = name;
        }

        public event EventHandler GoToWalk;

        public event EventHandler SendEmail;

        public void CheckToTime(DateTime dt)
        {
            if(dt.Hour >= 8 && dt.Hour <=22)
            {
                GoToWalk?.Invoke(this, null);
            }
        }

        public void CheckPosition(string position)
        {
            switch (position)
            {
                case "Home":
                    
                    break;
                case "Work":
                    SendEmail?.Invoke(this, null);
                    break;
            }
        }
    }
}
