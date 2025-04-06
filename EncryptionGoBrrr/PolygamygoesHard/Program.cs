while (true)
{
    Console.WriteLine("Polyalphabetische Sigma ");

    Console.WriteLine("Enter 'e' to encrypt or 'd' to decrypt: ");
    string choice = Console.ReadLine();

    Console.Clear();

    Console.WriteLine("Enter how many keys there is: ");
    int keyCount = Convert.ToInt32(Console.ReadLine());

    string[] keys = new string[keyCount];
    for (int i = 1; i <= keyCount; i++)
    {
        Console.WriteLine($"Enter the {i} key: ");
        keys[i - 1] = Console.ReadLine();
    }

    if (choice == "e")
    {
        Console.WriteLine("Enter the plaintext: ");
        string plaintext = Console.ReadLine();
        Console.WriteLine("\nCipher:\n" + Encrypt(plaintext, keys));
    }
    else if (choice == "d")
    {
        Console.WriteLine("Enter the ciphertext: ");
        string ciphertext = Console.ReadLine();
        Console.WriteLine("\nPlaintext:\n" + Decrypt(ciphertext, keys));
    }
    else
    {
        Console.WriteLine("Invalid choice.");
    }


    Console.ReadKey();
    Console.Clear();
}

static string Encrypt(string plaintext, string[] keys)
{
    string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    plaintext = plaintext.ToUpper();
    string result = "";

    string[] altalphabets = new string[keys.Length];
    int i = 0;
    foreach (string key in keys)
    {
        altalphabets[i] = MorphAlphabetAndKey(alphabet, key);
        i++;
    }
    
    i = 0;
    foreach (char c in plaintext)
    {
        if (c == ' ')
        {
            result += c;
        }
        else
        {
            if (i >= altalphabets.Length)
            {
                i = 0;
            }

            string currentaltalphabet = altalphabets[i];
            result += currentaltalphabet[alphabet.IndexOf(c)];
            i++;
        }
    }

    return result;
}

static string Decrypt(string plaintext, string[] keys)
{
    string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    plaintext = plaintext.ToUpper();
    string result = "";

    string[] altalphabets = new string[keys.Length];
    int i = 0;
    foreach (string key in keys)
    {
        altalphabets[i] = MorphAlphabetAndKey(alphabet, key);
        i++;
    }

    i = 0;
    foreach (char c in plaintext)
    {
        if (c == ' ')
        {
            result += c;
        }
        else
        {
            if (i >= altalphabets.Length)
            {
                i = 0;
            }

            string currentaltalphabet = altalphabets[i];
            result += alphabet[currentaltalphabet.IndexOf(c)];
            i++;
        }
    }

    return result;
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
        if (letterfound && remainingLetter.Contains(c))
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