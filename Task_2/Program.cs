using System;
using System.Diagnostics;

namespace Task_2
{
    internal class Program
    {
        public static int Account;
        
        public static void Main(string[] args)
        {
            Account = 10000;

            SailingShip fluyt = new SailingShip(350, 11, 150, 200, 280, 16);
            SailingShip dhow = new SailingShip(80, 15, 20, 50, 65, 4);
            SailingShip carrack = new SailingShip(400, 13, 200, 280, 350, 40);
            
            A convoy1451 = new A(fluyt, dhow, carrack);
            convoy1451.Info();
            convoy1451.SailTheRoute(12);
            convoy1451.Info();
            Debug.WriteLine(Account);
            
            // 516 years later
            Account = 150000;
            
            Steamship victory = new Steamship(2150, 17, 250, 1200, 1800, 1, 50000);
            Motorship cargoship = new Motorship(6000, 16, 200, 1500, 1600, 45000);
            
            A convoy1967 = new A(victory, cargoship);
            convoy1967.Info();
            convoy1967.SailTheRoute(42);
            convoy1967.Info();
            Debug.WriteLine(Account);
        }
    }
}