using System.Collections.Generic;
using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
using ante_up.Logic;
using NUnit.Framework;

namespace ante_up.Tests
{
    public class ChatTests
    {
        [Test]
        public void AddMessage_NewMessageIsAdded()
        {
            Chat chat = new();
            chat.AddMessage(new Message("sender", "Hey"));

            bool result = chat.Messages.Count == 1;
            
            Assert.IsTrue(result);
        }
        [Test]
        public void SortByTime_MessagePositionIsRight()
        {
            Chat chat = new();
            chat.AddMessage(new Message("sender", "1"));
            chat.AddMessage(new Message("sender", "2"));
            chat.AddMessage(new Message("sender", "3"));
            chat.SortByTime();

            bool result = chat.Messages[0].Text == "1" && chat.Messages[1].Text == "2" && chat.Messages[2].Text == "3";
            
            Assert.IsTrue(result);
        }
    }
}