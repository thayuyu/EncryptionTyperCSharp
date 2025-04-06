while (true)
{
    Console.WriteLine("Schlüsselwort ");

    Console.WriteLine("Enter 'e' to encrypt or 'd' to decrypt: ");
    string choice = Console.ReadLine();

    Console.Clear();

    Console.WriteLine("Enter the key: ");
    string key = Console.ReadLine();

    if (choice == "e")
    {
        Console.WriteLine("Enter the plaintext: ");
        string plaintext = Console.ReadLine();
        Console.WriteLine("\nCipher:\n" + Encrypt(plaintext, key));
    }
    else if (choice == "d")
    {
        Console.WriteLine("Enter the ciphertext: ");
        string ciphertext = Console.ReadLine();
        Console.WriteLine("\nPlaintext:\n" + Decrypt(ciphertext, key));
    }
    else
    {
        Console.WriteLine("Invalid choice.");
    }


    Console.ReadKey();
    Console.Clear();
}

static string MorphAlphabetAndKey(string alphabet, string key)
{
    bool letterfound = false;

    key = key.ToUpper();

    string remainingLetter = new string(alphabet.Except(key.ToCharArray()).ToArray());
    string altalphabet = new string(key
        .Where((c, i) => key.IndexOf(c) == i)
        .ToArray())
        .ToUpper();

    foreach (char c in alphabet)
    {
        if (letterfound)
        {
            string[] split = remainingLetter.Split(c);
            for (int i = 1; i >= 0; i--)
            {
                if (i == 1)
                {
                    altalphabet += c + split[i];
                }
                else
                {
                    altalphabet += split[i];
                }
            }
            return altalphabet;
        }
        if (key.EndsWith(c))
        {
            letterfound = true;
        }
    }
    return "error";
}

static string Encrypt(string plaintext, string key) 
{
    string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    string result = "";


    foreach (char c in plaintext.ToUpper())
    {
        if (c == ' ')
        {
            result += c;
        }
        else
        {
            result += MorphAlphabetAndKey(alphabet, key)[alphabet.IndexOf(c)];
        }
    }

    return result;
}
static string Decrypt(string ciphertext, string key) 
{
    string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    string result = "";

    foreach (char c in ciphertext.ToUpper())
    {
        if (c == ' ')
        {
            result += c;
        }
        else
        {
            result += alphabet[MorphAlphabetAndKey(alphabet, key).IndexOf(c)];
        }
    }
    return result;
}