using System;
using ds.test.impl;
using NUnit.Framework;

namespace UnitTests.PluginsTestFixture
{
    public class PowPluginTestFixture
    {
        private readonly IPlugin _plugin = Plugins.GetPlugin("Возведение в степень.");

        [Test]
        [Description(
            "Проверяет работоспособность плагина возведения при переполнении int, а также при возведении в минусовую степень происходит деление на ноль.")]
        public void Run_CalculateError_ExpressionNotCalculated()
        {
            Assert.Catch<OverflowException>(() => { _plugin.Run(10000, 5); });
            Assert.Catch<DivideByZeroException>(() => { _plugin.Run(0, -2); });
        }

        [Test]
        [Description("Проверяет работоспособность плагина возведения в степень.")]
        public void Run_CalculateDone_ExpressionCalculated()
        {
            Assert.AreEqual(25, _plugin.Run(5, 2));
            Assert.AreEqual(25, _plugin.Run(-5, 2));

            Assert.AreEqual(0, _plugin.Run(5, -2));
            Assert.AreEqual(0, _plugin.Run(-5, -2));

            Assert.AreEqual(1, _plugin.Run(-5, 0));
            Assert.AreEqual(1, _plugin.Run(5, 0));

            Assert.AreEqual(0, _plugin.Run(0, 2));
            Assert.AreEqual(1, _plugin.Run(0, 0));
        }
    }
}