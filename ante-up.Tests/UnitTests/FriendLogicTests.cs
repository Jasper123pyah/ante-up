using System;
using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
using ante_up.Logic;
using ante_up.Tests.FakeData;
using NUnit.Framework;

namespace ante_up.Tests
{
    public class FriendLogicTests
    {
        private readonly FriendLogic _friendLogic = new (new FakeAccountData(), new FakeFriendData());
        private readonly AccountLogic _accountLogic = new (new FakeAccountData());
        
        public FriendLogicTests()
        {
           
        }
    }
}