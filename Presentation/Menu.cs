using static System.Console;
public class Menu
{
    private int SelectedIndex;
    private string[] Options;
    private string Prompt;

    public Menu(string prompt, string[] options)
    {
        Prompt = prompt;
        Options = options;
        SelectedIndex = 0;
    }

    private void DisplayOptions()
    {
        for (int i = 0; i < Options.Length; i++)
        {
            string currentOption = Options[i];
            string prefix;
            CursorTop = i + 10;

            if (i == SelectedIndex)
            {
                prefix = "*";
                ForegroundColor = ConsoleColor.Black;
                BackgroundColor = ConsoleColor.White;
            }
            else
            {
                prefix = " ";
                ForegroundColor = ConsoleColor.White;
                BackgroundColor = ConsoleColor.Black;
            }
            WriteLine($"<< {prefix} {currentOption} >>");


        }
        ResetColor();
    }

    public int Run()
    {
        WriteLine(Prompt);
        ConsoleKey keypressed;
        do
        {
            DisplayOptions();
            ConsoleKeyInfo keyInfo = ReadKey(true);
            keypressed = keyInfo.Key;
            if (keypressed == ConsoleKey.UpArrow)
            {
                SelectedIndex--;
                if (SelectedIndex == -1)
                {
                    SelectedIndex = Options.Length - 1;
                }
                
            }
            else if (keypressed == ConsoleKey.DownArrow)
            {
                SelectedIndex++;
                if (SelectedIndex == Options.Length)
                {
                    SelectedIndex = 0;
                }

            }
            
        } while (keypressed != ConsoleKey.Enter);
        return SelectedIndex;
    }
}