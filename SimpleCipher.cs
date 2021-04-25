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

    private string RandomString()
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
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
       
    }

    public string Decode(string ciphertext)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}