using System;
using ds.test.impl;
using NUnit.Framework;

namespace UnitTests.PluginsTestFixture
{
    public class MultiplicationPluginTestFixture
    {
        private readonly IPlugin _plugin = Plugins.GetPlugin("Умножение.");

        [Test]
        [Description("Проверяет работоспособность плагина умножения при переполнении int.")]
        public void Run_CalculateError_ExpressionNotCalculated()
        {
            Assert.Catch<OverflowException>(() => { _plugin.Run(1000000000, 2000000000); });
        }

        [Test]
        [Description("Проверяет работоспособность плагина умножения.")]
        public void Run_CalculateDone_ExpressionCalculated()
        {
            Assert.AreEqual(10, _plugin.Run(5, 2));
            Assert.AreEqual(-10, _plugin.Run(-5, 2));

            Assert.AreEqual(-10, _plugin.Run(5, -2));
            Assert.AreEqual(10, _plugin.Run(-5, -2));

            Assert.AreEqual(0, _plugin.Run(-5, 0));
            Assert.AreEqual(0, _plugin.Run(5, 0));

            Assert.AreEqual(0, _plugin.Run(0, 2));
            Assert.AreEqual(0, _plugin.Run(0, -2));
        }
    }
}