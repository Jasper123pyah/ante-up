using System;
using System.Linq;
using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
using ante_up.Common.HubModels;
using ante_up.Logic;
using ante_up.Tests.FakeData;
using NUnit.Framework;

namespace ante_up.Tests
{
    public class ChatLogicTests
    {
        private readonly ChatLogic _chatLogic = new(new FakeWagerData(), new FakeAccountData(), new FakeChatData(), new FakeFriendData());
        
    }
}