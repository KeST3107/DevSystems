using System;
using ds.test.impl;
using NUnit.Framework;

namespace UnitTests.PluginsTestFixture
{
    public class SubstractionPluginTestFixture
    {
        private readonly IPlugin _plugin = Plugins.GetPlugin("Вычитание.");

        [Test]
        [Description("Проверяет работоспособность плагина вычитания при переполнении int.")]
        public void Run_CalculateError_ExpressionNotCalculated()
        {
            Assert.Catch<OverflowException>(() => { _plugin.Run(1000000000, -2000000000); });
        }

        [Test]
        [Description("Проверяет работоспособность плагина вычитания.")]
        public void Run_CalculateDone_ExpressionCalculated()
        {
            Assert.AreEqual(3, _plugin.Run(5, 2));
            Assert.AreEqual(-7, _plugin.Run(-5, 2));

            Assert.AreEqual(7, _plugin.Run(5, -2));
            Assert.AreEqual(-3, _plugin.Run(-5, -2));

            Assert.AreEqual(7, _plugin.Run(2, -5));
            Assert.AreEqual(-3, _plugin.Run(2, 5));

            Assert.AreEqual(-2, _plugin.Run(0, 2));
            Assert.AreEqual(2, _plugin.Run(0, -2));

            Assert.AreEqual(2, _plugin.Run(2, 0));
            Assert.AreEqual(-2, _plugin.Run(-2, 0));
        }
    }
}