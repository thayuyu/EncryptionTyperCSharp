using System.Text;

while (true)
{
    Console.WriteLine("ZAUNMETHODE WOOOOO");

    Console.WriteLine("Enter 'e' to encrypt or 'd' to decrypt: ");
    string choice = Console.ReadLine();
    Console.Clear();
    Console.WriteLine("Enter the depth: ");
    int depth = Convert.ToInt32(Console.ReadLine());

    if (choice == "e")
    {
        Console.WriteLine("Enter the plaintext: ");
        string plaintext = Console.ReadLine();
        Console.WriteLine("\nCipher:\n" + Encrypt(plaintext, depth));
    }
    else if (choice == "d")
    {
        Console.WriteLine("Enter the ciphertext: ");
        string ciphertext = Console.ReadLine();
        Console.WriteLine("\nPlaintext:\n" + Decrypt(ciphertext, depth));
    }
    else
    {
        Console.WriteLine("Invalid choice.");
    }
    Console.ReadKey();
    Console.Clear();
}

static string Encrypt(string plaintext, int depth)
{
    char[,] rail = new char[depth, plaintext.Length];
    bool down = false;
    int row = 0, col = 0;
    StringBuilder result = new StringBuilder();

    for (int i = 0; i < plaintext.Length; i++)
    {
        if (row == 0 || row == depth - 1)
            down = !down;

        rail[row, col++] = plaintext[i];
        row += down ? 1 : -1;
    }

    for (int i = 0; i < depth; i++)
    {
        for (int j = 0; j < plaintext.Length; j++)
        {
            if (rail[i, j] != '\0')
                result.Append(rail[i, j]);
        }
    }

    return result.ToString();
}

static string Decrypt(string ciphertext, int depth)
{
    if (depth <= 1)
    {
        return ciphertext;
    }

    char[,] rail = new char[depth, ciphertext.Length];
    bool down = false;
    int row = 0, col = 0;

    for (int i = 0; i < ciphertext.Length; i++)
    {
        if (row == 0 || row == depth - 1)
            down = !down;

        rail[row, col++] = '*'; 
        row += down ? 1 : -1;
    }

    int index = 0;
    for (int i = 0; i < depth; i++)
    {
        for (int j = 0; j < ciphertext.Length; j++)
        {
            if (rail[i, j] == '*' && index < ciphertext.Length)
                rail[i, j] = ciphertext[index++];
        }
    }

    StringBuilder result = new StringBuilder();
    row = 0; col = 0;
    down = false;

    for (int i = 0; i < ciphertext.Length; i++)
    {
        if (row == 0 || row == depth - 1)
            down = !down;

        result.Append(rail[row, col++]);
        row += down ? 1 : -1;
    }

    return result.ToString();
}
