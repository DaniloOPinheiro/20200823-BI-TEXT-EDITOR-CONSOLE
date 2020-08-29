using System;
using System.IO;

namespace TEXT_EDITOR
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();

        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer ?");
            Console.WriteLine("1 - Abrir Arquivo");
            Console.WriteLine("2 - Criar Novo Arquivo");
            Console.WriteLine("");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0 : System.Environment.Exit(0);break;
                case 1 : Abrir(); break;
                case 2 : Editar(); break;
                default: Menu(); break;
            }

            Editar();

        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do  arquivo ?");

            string path = Console.ReadLine();

            using(var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();

                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("----------------------");

            string text = "";
            
            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            // Console.WriteLine(text);
           ///home/daniloopinheiro/RiderProjects/20200823-BI-TEXT-EDITOR-CONSOLE/Saved_Files/exemplo.txt
            Salvar(text);
        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual Caminho Deseja Salvar o Texto ? ");

            var path = Console.ReadLine();

            using(var  file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.Write($"Arquivo {path} Salvo com Sucesso!!!");
            Console.ReadLine();
            Menu();
        }
    }
}
