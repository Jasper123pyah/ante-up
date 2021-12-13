using ante_up.Common.DataModels;
using ante_up.Logic.Services;
using NUnit.Framework;

namespace ante_up.Tests.UnitTests
{
    public class BalanceTests
    {
        [Test]
        public void GetFeelessAmount_Success()
        {
            int number = new BalanceLogic().GetFeelessAmount(10300.30);

            bool result = number == 10000;
            Assert.IsTrue(result);
        }
    }
}