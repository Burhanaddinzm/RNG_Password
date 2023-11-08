RunApp();

string PassGen()
{
    char[] chars = new char[] {
    'A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'E', 'e',
    'F', 'f', 'G', 'g', 'H', 'h', 'I', 'i', 'J', 'j',
    'K', 'k', 'L', 'l', 'M', 'm', 'N', 'n', 'O', 'o',
    'P', 'p', 'Q', 'q', 'R', 'r', 'S', 's', 'T', 't',
    'U', 'u', 'V', 'v', 'W', 'w', 'X', 'x', 'Y', 'y',
    'Z', 'z','!','@','#','$','%','^','&','*','(',')',
    '-','+','_','=','1','2','3','4','5','6','7','8',
    '9','0'
};
    Console.WriteLine("Input password length:");
    int.TryParse(Console.ReadLine(), out int Length);
    char[] password = new char[Length];
    string finalPassword = default;
    Random random = new Random();

    for (int i = 0; i < Length; i++)
    {
        password[i] = chars[random.Next(0, chars.Length-1)];
        finalPassword += password[i];
    }
    Console.WriteLine(finalPassword);
    return finalPassword;
}
void SavePassword()
{
    string path = Directory.GetCurrentDirectory() + @"\Password.txt";
    StreamWriter w = new StreamWriter(path);
    w.WriteLine(PassGen());
    w.Close();
}
void Menu()
{
    Console.WriteLine("1.Generate Password");
    Console.WriteLine("0.Close App");
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
                SavePassword();
                break;
            default:
                Console.WriteLine("Invalid request!");
                break;
        }
        Menu();
        request = Console.ReadLine();
    }

}