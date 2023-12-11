using System;
using System.Security.Cryptography;

namespace BuberDinner.Infrastructure.Authentication;
public class KeyGenerator
{
    public static byte[] GenerateRandomKey(int sizeInBytes)
    {
        byte[] key = new byte[sizeInBytes];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(key);
        }
        return key;
    }
}
