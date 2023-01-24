using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumsPractice;

/*
 *   1. Greet
 *   2. Calculate
 *   3. Exit
 * 
 *   Menu Option: 
 */
public class MainMenu
{
    private enum MenuOption
    {
        Calculate,
        Greet,
        None,
        Other,
        Weather,
        Exit,
    }
    private bool _running;

    public void Show()
    {
        _running = true;
        while (_running)
        {
            MenuOption currentOption = MenuOption.None;

            Console.Clear();
            string menuText = GetMenuAsText();
            Console.Write(menuText);

            string input = Console.ReadLine();
            MenuOption chosenOption = (MenuOption)int.Parse(input); //cast - to change the Type of an object (MenuOption)

            switch (chosenOption)
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
                default:
                    break;
            }
        }
    }

    private string GetMenuAsText()
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
}
