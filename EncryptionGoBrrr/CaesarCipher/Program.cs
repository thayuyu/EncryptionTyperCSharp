using System.Text;

while (true)
{
    Console.WriteLine("Caesar Cipher");

    Console.WriteLine("Enter 'e' to encrypt or 'd' to decrypt: ");
    string choice = Console.ReadLine();

    Console.Clear();

    Console.WriteLine("Enter the shift: ");
    int shift = Convert.ToInt32(Console.ReadLine());

    if (choice == "e")
    {
        Console.WriteLine("Enter the plaintext: ");
        string plaintext = Console.ReadLine();
        Console.WriteLine("\nCipher:\n" + Encrypt(plaintext, shift));
    }
    else if (choice == "d")
    {
        Console.WriteLine("Enter the ciphertext: ");
        string ciphertext = Console.ReadLine();
        Console.WriteLine("\nPlaintext:\n" + Decrypt(ciphertext, shift));
    }
    else
    {
        Console.WriteLine("Invalid choice.");
    }


    Console.ReadKey();
    Console.Clear();
}

static string Encrypt(string plaintext, int shift)
{

    char[] alphabet = [
    'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
    ];


    StringBuilder cipherText = new();
    foreach (char c in plaintext)
    {
        if (char.IsLetter(c))
        {   
            char letter = char.ToUpper(c);
            int index = Array.IndexOf(alphabet, letter);
            int shiftedIndex = (index + shift) % 26;
            char shiftedLetter = alphabet[shiftedIndex];
            cipherText.Append(char.IsLower(c) ? char.ToLower(shiftedLetter) : shiftedLetter);
        }
        else
        {
            cipherText.Append(c);
        }
    }
    return cipherText.ToString();
}

static string Decrypt(string ciphertext, int shift)
{
    return Encrypt(ciphertext, 26 - shift);
}