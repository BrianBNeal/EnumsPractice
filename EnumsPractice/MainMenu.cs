using System.Text;

namespace EnumsPractice;

public class MainMenu
{
    private enum MenuOption //keep Exit last, add new options in desired order
    {
        None = 0,
        Greet,
        Calculate,
        Weather,
        Insult,
        Joke,
        Exit,
    }
    
    //ADVANCED TIP: use #region to create a region that can be easily collapsed/expanded
#region Constructors
    public MainMenu() //TIP: use the constructor to set initial values
    {
        _running = true;
        _currentOption = MenuOption.None;
    }

#endregion


#region Fields
    
    private bool _running;
    private MenuOption _currentOption;

#endregion

#region Methods
    public void Show()
    {
        while (_running)
        {
            ShowMenu();
            GetInput();
            ExecuteInput();

            
        }
    }

    private void ExecuteInput()
    {
        switch (_currentOption) //use a switch to define different paths based on a single value
        {
            case MenuOption.Weather:
                GetWeather();
                break;
            case MenuOption.Calculate:
                Calculate();
                break;
            case MenuOption.Greet:
                Greet();
                break;
            case MenuOption.Exit:
                Exit();
                break;
            case MenuOption.Insult:
                NotImplemented(MenuOption.Insult);
                break;
            case MenuOption.Joke:
                NotImplemented(MenuOption.Joke);
                break;
            default:
                break;
        }
    }

    private void GetInput()
    {
        while (true)
        {
            string input = Console.ReadKey(true).KeyChar.ToString();//fancier input!
            if (int.TryParse(input, out int numberPressed) && IsValidMenuOption(numberPressed))
            {
                _currentOption = (MenuOption)numberPressed; //cast - to change the Type of an object from one (int) to another (MenuOption)
            }

        }
    }



    /// <summary>
    /// determines if the supplied number is within the count of the menu options
    /// </summary>
    /// <param name="inputAsInt"></param>
    /// <returns>true if the value is within bounds, false if out of bounds</returns>
    /// <exception cref="NotImplementedException"></exception>
    private bool IsValidMenuOption(int inputAsInt)
    {
        throw new NotImplementedException();
    }

    private void ShowMenu()
    {
        Console.Clear();
        string menuText = GetMenuAsText();
        Console.Write(menuText);
    }

    private void NotImplemented(MenuOption insult)
    {
        Console.WriteLine($"The {Enum.GetName(insult)} feature is not yet implemented, sorry!");
        Console.Write("Press enter to go back...");
        Console.ReadLine();
    }

    //ADVANCED TIP: use three slashes like below and provide a summary that will appear when you hover over that method/class/property

    /// <summary>
    /// Creates a numbered menu based off the enum MenuOptions
    /// </summary>
    /// <returns>a string representation of the menu and prompt</returns>
    private string GetMenuAsText() //hover your mouse cursor over GetMenuAsText() to the left of this comment, notice the description that appears with the text from above??
    {
        StringBuilder bldr = new StringBuilder();

        List<string> menuOptions = Enum.GetNames<MenuOption>().ToList();

        for (int i = 1; i < menuOptions.Count; i++) //start at 1, don't print the 0 option
        {
            bldr.AppendLine($"{i}. {menuOptions[i]}");
        }

        bldr.AppendLine();
        bldr.Append("Please select a menu option: ");

        return bldr.ToString();
    }

    private void GetWeather()
    {
        Console.WriteLine("Here's the weather!");
        Console.Write("Press enter to go back...");
        Console.ReadLine();
    }

    private void Greet()
    {
        Console.WriteLine("Greetings!");
        Console.Write("Press enter to go back...");
        Console.ReadLine();
    }

    private void Calculate()
    {
        Console.WriteLine("Calculating!");
        Console.Write("Press enter to go back...");
        Console.ReadLine();
    }

    private void Exit()
    {
        _running = false;
        Console.WriteLine("Exiting...");
        Console.ReadLine();

    }
#endregion
}