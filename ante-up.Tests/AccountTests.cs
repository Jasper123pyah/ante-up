using ante_up.Common.Models;
using ante_up.Logic;
using NUnit.Framework;

namespace ante_up.Tests
{
    public class Tests
    {
        [Test]
        public void TestIfLoginPasses()
        {
            Account account = new Account()
            {
                Id = "123abc",
                Username = "User",
                Email = "email@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("verysecretpassword")
            };
            string response = new AccountLogic().LoginCheck(account, "verysecretpassword").Response;

            bool result = response == "123abc";
            
            Assert.IsTrue(result);
        }
    }
}