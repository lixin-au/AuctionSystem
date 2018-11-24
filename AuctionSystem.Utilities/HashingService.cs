using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace AuctionSystem.Utilities
{
    public class HashingService : IHashingService
    {
        protected virtual string Separator { get; set; } = ":";

        public string CreateHash(string plainTextPassword)
        {
            var salt = new byte[128 / 8];
            using (var randomNumber = RandomNumberGenerator.Create())
            {
                randomNumber.GetBytes(salt);
            }

            return CreateHash(plainTextPassword, salt);
        }

        protected virtual string CreateHash(string plainTextPassword, byte[] salt)
        {
            var saltString = Convert.ToBase64String(salt);

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: plainTextPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return $"{saltString}{Separator}{hash}";
        }

        public bool Verify(string plainTextPassword, string hashedPassword)
        {
            if (string.IsNullOrWhiteSpace(hashedPassword))
                return false;

            var hashedPasswordElements = hashedPassword.Split(new[] {Separator},
                StringSplitOptions.RemoveEmptyEntries);
            var salt = Convert.FromBase64String(hashedPasswordElements[0]);
            var expectedHash = CreateHash(plainTextPassword, salt);
            return expectedHash.Equals(hashedPassword);
        }
    }
}
