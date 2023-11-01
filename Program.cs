using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZapisDoSouboru
{
    internal class Program
    {
        static string cesta = @"C:\Ctechitas\";
        static void Main(string[] args)
        {
            if (!Directory.Exists(cesta)) Directory.CreateDirectory(cesta);
            VyberMenu();
        }
        static void VyberMenu()
        {
            int volba;
            Console.WriteLine("Vyber číselnou volbu: \n 1) Vypsat soubor \n 2) Přepsat soubor \n 3) Přidat do souboru \n 4) Ukonči \n");
            while (!int.TryParse(Console.ReadLine(), out volba) || (volba < 1) || (volba > 4))Console.WriteLine("Zadej číslo od 1 do 4.");
            Console.Write("Tvoje volba je ");
            switch (volba) {
                case 1: Console.WriteLine("vypsat soubor.\n");
                    VypsaniSouboru();
                    break;
                case 2:
                    Console.WriteLine("přepsat soubor.\n");
                    PrepsaniSouboru();
                    break;
                case 3:
                    Console.WriteLine("přidání zápisu do souboru.\n");
                    ZapisdoSouboru();
                    break;
                case 4:
                    Console.WriteLine("ukončit.\n");
                    break;
            }
        }
        static void ZapisdoSouboru()
        {
            Console.WriteLine("Zadej text k přidání do souboru:");
            string text;
            while (!String.IsNullOrEmpty(text = Console.ReadLine())) File.AppendAllText(cesta + "ZapisDoSouboru.txt", text + "\n");
            VyberMenu();
        }
        static void PrepsaniSouboru()
        {
            Console.WriteLine("Zadej text k přepsání souboru:");
            string text;
            File.WriteAllText(cesta + "ZapisDoSouboru.txt", Console.ReadLine() + "\n");
            while (!String.IsNullOrEmpty(text = Console.ReadLine())) File.AppendAllText(cesta + "ZapisDoSouboru.txt", text + "\n");
            VyberMenu();
        }
        static void VypsaniSouboru()
        {
            Console.WriteLine("Vypisuji uložený soubor:\n");
            Console.WriteLine(File.ReadAllText(cesta + "ZapisDoSouboru.txt"));
            VyberMenu();
        }
    }
}
