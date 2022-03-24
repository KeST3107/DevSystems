using System;
using ds.test.impl;
using NUnit.Framework;

namespace UnitTests.PluginsTestFixture
{
    [TestFixture]
    public class AdditionPluginTestFixture
    {
        private readonly IPlugin _plugin = Plugins.GetPlugin("Сложение.");

        [Test]
        [Description("Проверяет работоспособность плагина сложения при переполнении int.")]
        public void Run_CalculateError_ExpressionNotCalculated()
        {
            Assert.Catch<OverflowException>(() => { _plugin.Run(1000000000, 2000000000); });
        }

        [Test]
        [Description("Проверяет работоспособность плагина сложения.")]
        public void Run_CalculateDone_ExpressionCalculated()
        {
            Assert.AreEqual(7, _plugin.Run(5, 2));
            Assert.AreEqual(-3, _plugin.Run(-5, 2));

            Assert.AreEqual(3, _plugin.Run(5, -2));
            Assert.AreEqual(-7, _plugin.Run(-5, -2));

            Assert.AreEqual(-5, _plugin.Run(-5, 0));
            Assert.AreEqual(5, _plugin.Run(5, 0));

            Assert.AreEqual(2, _plugin.Run(0, 2));
            Assert.AreEqual(-2, _plugin.Run(0, -2));
        }
    }
}