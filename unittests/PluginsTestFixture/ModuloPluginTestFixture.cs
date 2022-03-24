using System;
using ds.test.impl;
using NUnit.Framework;

namespace UnitTests.PluginsTestFixture
{
    public class ModuloPluginTestFixture
    {
        private readonly IPlugin _plugin = Plugins.GetPlugin("Деление с остатком.");

        [Test]
        [Description("Проверяет работоспособность плагина при делении на ноль.")]
        public void Run_CalculateError_ExpressionNotCalculated()
        {
            Assert.Catch<DivideByZeroException>(() => { _plugin.Run(5, 0); });
        }

        [Test]
        [Description("Проверяет работоспособность плагина деления с остатком.")]
        public void Run_CalculateDone_ExpressionCalculated()
        {
            Assert.AreEqual(1, _plugin.Run(5, 2));
            Assert.AreEqual(-1, _plugin.Run(-5, 2));

            Assert.AreEqual(1, _plugin.Run(5, -2));
            Assert.AreEqual(-1, _plugin.Run(-5, -2));

            Assert.AreEqual(2, _plugin.Run(2, -5));
            Assert.AreEqual(-2, _plugin.Run(-2, 5));

            Assert.AreEqual(0, _plugin.Run(0, 2));
            Assert.AreEqual(0, _plugin.Run(0, -2));
        }
    }
}