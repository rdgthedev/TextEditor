using TextEditor;

namespace TextEditor
{
    public static class Menu
    {
        public static void ShowMenuMain() => OptionsMainMenu();

        private static void OptionsMainMenu()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\tMenu\n");
                Console.WriteLine("1 - Abrir Arquivo");
                Console.WriteLine("2 - Criar Arquivo");
                Console.WriteLine("3 - Editar Arquivo");
                Console.WriteLine("0 - Sair\n");
                Console.Write("Digite uma opção: ");
                short option = short.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Clear();
                        FileManipulation.Open();
                        break;

                    case 2:
                        Console.Clear();
                        FileManipulation.Create();
                        break;

                    case 3:
                        Console.Clear();
                        FileManipulation.Edit();
                        break;

                    case 0:
                        Console.Clear();
                        Console.WriteLine("Saindo ...");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Opção inválida\n");
                        Console.WriteLine("Aperte qualquer tecla para voltar ao Menu");
                        Console.ReadKey();
                        Console.Clear();
                        ShowMenuMain();
                        break;
                }
            }
            catch (FormatException e)
            {
                Console.Clear();
                Console.WriteLine($"Aconteceu um erro do tipo: {e.Message}");
                Console.WriteLine("\nAperte qualquer tecla para retonar ao menu");
                Console.ReadKey();
                ShowMenuMain();
            }
        }

        public static void MenuQuestionForTheUser(string content)
        {
            Console.Clear();
            Console.WriteLine("Deseja salvar o que escreveu?\n");
            Console.WriteLine("1 - SIM");
            Console.WriteLine("2 - NÃO");
            Console.Write("\nEscolha uma opção: ");
            short option = short.Parse(Console.ReadLine());

            try
            {
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        FileManipulation.Save(content);
                        Console.WriteLine("\nConteúdo salvo com sucesso!...");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Voltando ao menu inicial ...");
                        Thread.Sleep(1500);
                        Console.Clear();
                        ShowMenuMain();
                        break;
                }
            }
            catch (FormatException e)
            {
                Console.Clear();
                Console.WriteLine($"Aconteceu um erro do tipo: {e.Message}");
                Console.WriteLine("\nAperte qualquer tecla para retonar ao menu");
                Console.ReadKey();
                ShowMenuMain();
            }

        }
    }
}

