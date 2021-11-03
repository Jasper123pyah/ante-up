using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
using ante_up.Data;
using ante_up.Logic;
using NUnit.Framework;
using Moq;

namespace ante_up.Tests
{
    public class AccountTests
    {
        [Test]
        public void TestIfLoginPasses()
        {
            Account account = new()
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

        [Test]
        public void TestIfAccountGetsDeleted()
        {
            
        }
        
        [Test]
        public void TestIfRegisterPasses()
        {
            ApiAccount apiAccount = new()
            {
                Username = "User",
                Email = "email@gmail.com",
                Password = "verysecretpassword"
            };
            string response = new AccountLogic().Register(apiAccount);

            bool result = response == "";
            
            
            Assert.IsTrue(result);
        }
    }
}