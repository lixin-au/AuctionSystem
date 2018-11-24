using Common.Utilities;
using NUnit.Framework;
using System;

namespace AuctionSystem.Tests.ServerSide
{
    public class HashingTests
    {
        [Test]
        public void Given_PlainTextPassword_When_Hash_And_Verify_Then_ExpectedResultShouldBeReturned()
        {
            var password = Guid.NewGuid().ToString();
            var service = new HashingService();
            var hashedPassword = service.CreateHash(password);
            var verificationResult = service.Verify(password, hashedPassword);
            Assert.IsTrue(verificationResult);

            verificationResult = service.Verify(Guid.NewGuid().ToString(), hashedPassword);
            Assert.IsFalse(verificationResult);
        }
    }
}