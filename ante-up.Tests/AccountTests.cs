using System.Linq;
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
        public void LoginCheck_Accepted()
        {
            Account account = new("email@gmail.com", "User", BCrypt.Net.BCrypt.HashPassword("verysecretpassword"));
            
            string response = new AccountLogic().LoginCheck(account, "verysecretpassword").Username ;

            bool result = response == "User";
            
            Assert.IsTrue(result);
        }
        [Test]
        public void AddConnectionId_Added()
        {
            Account account = new("email", "username", "password");
            account.AddConnectionId("connection123");

            bool result =  account.ConnectionIds.Any(x => x.Connection == "connection123");

            Assert.IsTrue(result);
        }

        [Test]
        public void GetConnectionIds_Found()
        {
            Account account = new("email", "username", "password");
            account.AddConnectionId("connection123");

            bool result = account.GetConnectionIds().Count() == 1;
            
            Assert.IsTrue(result);
        }

        [Test]
        public void SetTeam_Teamisnotnull()
        {
            Account account = new("email", "username", "password");
            account.SetTeam(new Team());

            bool result = account.Team != null;
            
            Assert.IsTrue(result);
        }
        [Test]
        public void RemoveTeam_Teamisnull()
        {
            Account account = new("email", "username", "password");
            account.SetTeam(new Team());
            account.RemoveTeam();
            
            bool result = account.Team == null;
            
            Assert.IsTrue(result);
            
        }
        
    }
}