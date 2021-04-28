using System;
using System.Collections.Generic;
using System.Text;



public class SimpleCipher
{
    private readonly Dictionary<char, int> _alphabetElements = new Dictionary<char, int>() { { 'a', 0 }, { 'b', 1 }, { 'c', 2 }, { 'd', 3 }, { 'e', 4 }, { 'f', 5 }, { 'g', 6 }, { 'h', 7 }, { 'i', 8 }, { 'j', 9 }, { 'k', 10 }, { 'l', 11 }, { 'm', 12 }, { 'n', 13 }, { 'o', 14 }, { 'p', 15 }, { 'q', 16 }, { 'r', 17 }, { 's', 18 }, { 't', 19 }, { 'u', 20 }, { 'v', 21 }, { 'w', 22 }, { 'x', 23 }, { 'y', 24 }, { 'z', 25 } };
    private readonly string _alphabet = "abcdefghijklmnopqrstuvwxyz";
    private readonly string _key;

    public SimpleCipher()
    {
        _key = RandomString();
    }

    public SimpleCipher(string key)
    {
        _key = key;
    }

    public string Key
    {
        get
        {
            return _key;
        }
    }

   
    private string RandomString()
    {
        var randomString = new StringBuilder();
        var random = new Random();
        for (int i = 0; i < 100; i++)
        {
            char randomChar = _alphabet[random.Next(25)];
            randomString.Append(randomChar);
        }
        return randomString.ToString();
    }

    public string Encode(string plaintext)
    {
        string cipherKey = Key;
        while (plaintext.Length > cipherKey.Length)
        {
            cipherKey += cipherKey;
        }

        var encodedString = new StringBuilder();
        for (int i = 0; i < plaintext.Length; i++)
        {
            int element = _alphabetElements[plaintext[i]] + _alphabetElements[cipherKey[i]];
            if (element > 25)
            {
                element -= 26;
            }
            encodedString.Append(_alphabet[element]);
        }
        return encodedString.ToString();
    }

    public string Decode(string ciphertext)
    {
        string cipherKey = Key;
        while (ciphertext.Length > cipherKey.Length)
        {
            cipherKey += cipherKey;
        }
       
        var decodeString = new StringBuilder();
        for (int i = 0; i < ciphertext.Length; i++)
        {
            int element = _alphabetElements[ciphertext[i]] - _alphabetElements[cipherKey[i]];
            if (element < 0)
            {
                element += 26;
            }
            decodeString.Append(_alphabet[element]);
        }
        return decodeString.ToString();
    }
}