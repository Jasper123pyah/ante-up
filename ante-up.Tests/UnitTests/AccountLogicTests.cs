using System.Linq;
using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
using ante_up.Logic;
using ante_up.Tests.FakeData;
using NUnit.Framework;

namespace ante_up.Tests
{
    public class AccountLogicTests
    {
        private readonly AccountLogic _accountLogic = new(new FakeAccountData());
        private Account account;

        public AccountLogicTests()
        {
            ApiAccount apiAccount = new()
                {Email = "email@gmail.com", Username = "User", Password = "verysecretpassword"};
            _accountLogic.Register(apiAccount);
            account = _accountLogic.GetAccountByUserName("User");
        }

        [Test]
        public void GetAccountInfo_AccountInfoMatchesAccount()
        {
            ApiAccountInfo accountInfo = _accountLogic.GetAccountInfo(account.Id.ToString());
            bool result = accountInfo.Username == account.Username &&
                          accountInfo.Email == account.Email;

            Assert.IsTrue(result);
        }
        [Test]
        public void GetAccountInfo_AccountInfoIsNull()
        {
            Assert.Throws<ApiException>(() => _accountLogic.GetAccountInfo("randomid"));
        }
        [Test]
        public void GetAccountByUsername_AccountIsNotNull()
        {
            bool result = account.Username == "User";

            Assert.IsTrue(result);
        }

        [Test]
        public void GetAccountByUsername_AccountIsNull()
        {
            bool result = _accountLogic.GetAccountByUserName("NonExistentUser") == null;

            Assert.IsTrue(result);
        }

        [Test]
        public void SaveConnectionId_ConnectionIdIsNotNull()
        {
            _accountLogic.SaveConnectionId(account.Id.ToString(), "connectionId");

            bool result = account.ConnectionIds.FirstOrDefault(x => x.Connection == "connectionId") != null;

            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveConnectionId_ConnectionIdIsNull()
        {
            _accountLogic.SaveConnectionId(account.Id.ToString(), "newconnectionId");
            _accountLogic.RemoveConnectionId(account.Id.ToString(), "newconnectionId");

            bool result = account.ConnectionIds.FirstOrDefault(x => x.Connection == "connectionId") == null;

            Assert.IsTrue(result);
        }

        [Test]
        public void LoginCheck_Accepted()
        {
            bool result = _accountLogic.LoginCheck("email@gmail.com", "verysecretpassword").Username == "User";

            Assert.IsTrue(result);
        }

        [Test]
        public void LoginCheck_WrongPassword()
        {
            Assert.Throws<ApiException>(() => _accountLogic.LoginCheck("email@gmail.com", "verywrongpassword"));
        }

        [Test]
        public void LoginCheck_WrongEmail()
        {
            Assert.Throws<ApiException>(() => _accountLogic.LoginCheck("wrongemail@gmail.com", "verysecretpassword"));
        }

        [Test]
        public void Register_Accepted()
        {
            ApiAccount apiAccount = new()
                {Email = "registeredemail@gmail.com", Username = "RegisteredUser", Password = "verysecretpassword"};
            _accountLogic.Register(apiAccount);

            bool result = _accountLogic.GetAccountByUserName("RegisteredUser") != null;


            Assert.IsTrue(result);
        }

        [Test]
        public void Register_EmailTaken()
        {
            ApiAccount apiAccount2 = new()
                {Email = "email@gmail.com", Username = "NewUserName", Password = "verysecretpassword"};

            Assert.Throws<ApiException>(() => _accountLogic.Register(apiAccount2));
        }

        [Test]
        public void Register_UsernameTaken()
        {
            ApiAccount apiAccount2 = new()
                {Email = "newEmail@gmail.com", Username = "User", Password = "verysecretpassword"};

            Assert.Throws<ApiException>(() => _accountLogic.Register(apiAccount2));
        }
    }
}