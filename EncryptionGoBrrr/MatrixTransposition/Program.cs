using System.Text;

while (true)
{
    Console.WriteLine("Matrix Shiii");

    Console.WriteLine("Enter 'e' to encrypt or 'd' to decrypt (no no work): ");
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

static string Encrypt(string plaintext, string key)
{
    int columns = key.Length;
    int rows = (int)Math.Ceiling((double)plaintext.Length / columns);
    char[,] matrix = new char[rows, columns];

    int index = 0;
    for (int r = 0; r < rows; r++)
    {
        for (int c = 0; c < columns; c++)
        {
            if (index < plaintext.Length)
                matrix[r, c] = plaintext[index++];
            else
                matrix[r, c] = ' ';
        }
    }

    StringBuilder cipherText = new StringBuilder();
    int[] keyOrder = GetKeyOrder(key);

    foreach (int col in keyOrder)
    {
        for (int row = 0; row < rows; row++)
        {
            cipherText.Append(matrix[row, col]);
        }
    }

    return cipherText.ToString();
}

static int[] GetKeyOrder(string key)
{
    var keyChars = key.Select((ch, index) => new { Value = ch, Index = index })
                      .OrderBy(x => x.Value)
                      .Select(x => x.Index)
                      .ToArray();
    foreach (var keyChar in keyChars)
    {
        Console.WriteLine(keyChar);
    }
    return keyChars;
}

static string Decrypt(string ciphertext, string key)
{
    int columns = key.Length;
    int rows = (int)Math.Ceiling((double)ciphertext.Length / columns);
    char[,] matrix = new char[rows, columns];

    int[] keyOrder = GetKeyOrder(key);
    int index = 0;

    for (int i = 0; i < keyOrder.Length; i++)
    {
        int col = keyOrder[i];
        for (int row = 0; row < rows; row++)
        {
            if (index < ciphertext.Length)
                matrix[row, col] = ciphertext[index++];
        }
    }

    StringBuilder plainText = new StringBuilder();
    for (int r = 0; r < rows; r++)
    {
        for (int c = 0; c < columns; c++)
        {
            plainText.Append(matrix[r, c]);
        }
    }

    return plainText.ToString().Trim();
}

static int[] GetKeyOrderForDecryption(string key)
{
    int[] keyOrder = new int[key.Length];


    var keyWithIndices = key.Select((ch, index) => new { Value = ch, Index = index })
                            .OrderBy(x => x.Value) // Sort by character value
                            .ToList();

    for (int i = 0; i < key.Length; i++)
    {
        keyOrder[keyWithIndices[i].Index] = i;
        Console.WriteLine(keyOrder[i]);
    }
    return keyOrder;
}
