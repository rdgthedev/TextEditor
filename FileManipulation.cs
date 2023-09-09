using System.IO;
using System.Linq.Expressions;

namespace TextEditor
{
    public static class FileManipulation
    {
        public static void Create()
        {
            Console.Clear();
            Console.WriteLine("Digite o nome do arquivo: ");
            string userFileName = Console.ReadLine();
            userFileName = string.Concat(userFileName, ".txt");

            try
            {
                using (var file = new FileStream(userFileName, FileMode.Create))
                    Console.WriteLine("\nArquivo criado com sucesso!");

                Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
                Console.ReadKey();
                Menu.ShowMenuMain();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void Open()
        {
            Console.WriteLine("Digite o nome do arquivo: ");
            string userFileName = Console.ReadLine();
            userFileName = string.Concat(userFileName, ".txt");

            if (File.Exists(userFileName))
            {
                try
                {
                    string? text;
                    using var file = new StreamReader(userFileName);
                    text = file.ReadToEnd();
                    Console.WriteLine(text);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Aconteceu um erro do tipo: {e.Message}");
                    Console.WriteLine("\nAperte qualquer tecla para voltar ao menu");
                    Console.ReadKey();
                    Menu.ShowMenuMain();
                }
            }
            else
            {
                Console.WriteLine("O arquivo não existe!");
                Console.WriteLine("\nAperte qualquer tecla para voltar ao menu");
                Console.ReadKey();
                Menu.ShowMenuMain();
            }
        }
        public static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Digite o texto abaixo: ");

            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Menu.MenuQuestionForTheUser(text);
        }
        public static void Save(string content)
        {
            Console.WriteLine("Digite o nome do arquivo: ");
            string userFileName = Console.ReadLine();
            userFileName = string.Concat(userFileName, ".txt");

            if (File.Exists(userFileName))
            {
                try
                {
                    using var file = new StreamWriter(userFileName);
                    file.Write(content);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Aconteceu um erro do tipo: {e.Message}");
                    Console.WriteLine("\nAperte qualquer tecla para voltar ao menu");
                    Console.ReadKey();
                    Menu.ShowMenuMain();
                }
            }
            else
            {
                Console.WriteLine("O arquivo não existe!");
                Console.WriteLine("\nAperte qualquer tecla para voltar ao menu");
                Console.ReadKey();
                Menu.ShowMenuMain();
            }
        }
    }
}






