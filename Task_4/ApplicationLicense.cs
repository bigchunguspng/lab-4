using System;

namespace Task_4
{
    public static class ApplicationLicense
    {
        private static readonly string KeyTrial = "2TUXWTAM5GN29QLL";
        private static readonly string KeyPro = "T1WKHTRC34QUIXSB";
        
        public static License License = License.Common;
        private static int _trialCount;

        private static void AllowCommon()
        {
            License = License.Common;
            Program.Say("Безкоштовна версiя", ConsoleColor.Green);
            Program.Say("Вам доступна лише десяткова система");
        }
        private static void AllowTrial()
        {
            License = License.Trial;
            Program.Say("Трiальний режим", ConsoleColor.Green);
            Program.Say("Необмежена десяткова система та 15 дiй з iншими");
        }
        private static void AllowPro()
        {
            License = License.Pro;
            Program.Say("Платна версiя", ConsoleColor.Green);
            Program.Say("У Вас є всi можливостi програми");
        }

        public static void ChooseLicense(string key)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("У Вас зараз: ");
            if (key.Equals(KeyTrial))
                AllowTrial();
            else if (key.Equals(KeyPro))
                AllowPro();
            else
                AllowCommon();
        }

        public static void UpdateTrial()
        {
            _trialCount++;
            if (_trialCount > 15) 
                ChooseLicense("0");
        }
    }
}