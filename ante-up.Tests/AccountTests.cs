using System.Linq;
using ante_up.Common.DataModels;
using NUnit.Framework;

namespace ante_up.Tests
{
    public class AccountTests
    {
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
        public void SetTeam_TeamIsNotNull()
        {
            Account account = new("email", "username", "password");
            account.SetTeam(new Team());

            bool result = account.Team != null;
            
            Assert.IsTrue(result);
        }
        [Test]
        public void RemoveTeam_TeamIsNull()
        {
            Account account = new("email", "username", "password");
            account.SetTeam(new Team());
            account.RemoveTeam();
            
            bool result = account.Team == null;
            
            Assert.IsTrue(result);
        }
    }
}