using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private readonly char[] chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz!@#$%^&*()-+_1234567890".ToCharArray();
    private readonly Random random = new Random();

    static void Main()
    {
        Program program = new Program();
        program.RunApp();
    }

    string PassGen(int length)
    {
        StringBuilder finalPassword = new StringBuilder(length);

        for (int i = 0; i < length; i++)
        {
            finalPassword.Append(chars[random.Next(chars.Length)]);
        }

        Console.WriteLine(finalPassword);
        return finalPassword.ToString();
    }

    void SavePassword()
    {
        Console.WriteLine("Input password length:");
        int.TryParse(Console.ReadLine(), out int length);
        string path = Path.Combine(Directory.GetCurrentDirectory(), "Password.txt");
        using (StreamWriter w = new StreamWriter(path))
        {
            w.WriteLine(PassGen(length)); // You can adjust the password length here
        }
    }

    void Menu()
    {
        Console.WriteLine("1. Generate Password");
        Console.WriteLine("0. Close App");
    }

    void RunApp()
    {
        Menu();
        string request = Console.ReadLine();
        while (request != "0")
        {
            switch (request)
            {
                case "1":
                    // Run SavePassword asynchronously and wait for it to complete
                    Task.WaitAll(Task.Run(() => SavePassword()));
                    break;
                default:
                    Console.WriteLine("Invalid request!");
                    break;
            }
            Menu();
            request = Console.ReadLine();
        }
    }
}
