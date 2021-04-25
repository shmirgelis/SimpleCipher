using System;
using System.Collections.Generic;
using System.Text;

public class SimpleCipher
{
    public SimpleCipher()
    {
        Key = RandomString();
    }

    public SimpleCipher(string key)
    {
        Key = key;
    }

    public string Key
    {
        get
        {
            return Key;
        }
    }

    Dictionary<char, int> alphabetElements = new Dictionary<char, int>() { { 'a', 0 }, { 'b', 1 }, { 'c', 2 }, { 'd', 3 }, { 'e', 4 }, { 'f', 5 }, { 'g', 6 }, { 'h', 7 }, { 'i', 8 }, { 'j', 9 }, { 'k', 10 }, { 'l', 11 }, { 'm', 12 }, { 'n', 13 }, { 'o', 14 }, { 'p', 15 }, { 'q', 16 }, { 'r', 17 }, { 's', 18 }, { 't', 19 }, { 'u', 20 }, { 'v', 21 }, { 'w', 22 }, { 'x', 23 }, { 'y', 24 }, { 'z', 25 } };
    string alphabet = "abcdefghijklmnopqrstuvwxyz";

    private string RandomString()
    {
        var randomString = new StringBuilder();
        var random = new Random();
        for (int i = 0; i < 100; i++)
        {
            char randomChar = alphabet[random.Next(25)];
            randomString.Append(randomChar);
        }
        return randomString.ToString();
    }

    public string Encode(string plaintext)
    {
        string cipherKey = Key;
        while (plaintext.Length > Key.Length)
        {
            cipherKey += cipherKey;
        }

        var encodedString = new StringBuilder();
        for (int i = 0; i < plaintext.Length; i++)
        {
            int element = alphabetElements[plaintext[i]] + alphabetElements[cipherKey[i]];
            while (element > 25)
            {
                element -= 26;
            }
            encodedString.Append(alphabet[element]);
        }
        return encodedString.ToString();
    }

    public string Decode(string ciphertext)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}