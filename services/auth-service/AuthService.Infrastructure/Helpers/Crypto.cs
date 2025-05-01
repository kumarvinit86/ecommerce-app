using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace AuthService.Infrastructure.Helpers;

public class Crypto
{
    public static string HashPassword(string password)
    {
        // Generate a 128-bit salt using a secure PRNG
        byte[] salt = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        // Derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 32));

        // Combine salt and hash for storage
        return $"{Convert.ToBase64String(salt)}.{hashed}";
    }

    /// <summary>
    /// Verifies if the provided password matches the stored hash.
    /// </summary>
    /// <param name="password">The plain text password to verify.</param>
    /// <param name="storedHash">The stored hash containing the salt and hashed password, separated by a period.</param>
    /// <returns>True if the password matches the stored hash; otherwise, false.</returns>
    public static bool VerifyPassword(string password, string storedHash)
    {
        var parts = storedHash.Split('.');
        if (parts.Length != 2) return false;

        byte[] salt = Convert.FromBase64String(parts[0]);
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 32));

        return hashed == parts[1];
    }
    public static string UnHashPassword(string storedHash)
    {
        // Split the stored hash into salt and hashed password
        var parts = storedHash.Split('.');
        if (parts.Length != 2) throw new ArgumentException("Invalid stored hash format.");

        // Extract the salt
        byte[] salt = Convert.FromBase64String(parts[0]);

        // Return the salt as a string (passwords hashed with PBKDF2 cannot be decrypted)
        return Convert.ToBase64String(salt);
    }

}
