using System;
using System.Linq;
using ds.test.impl;
using NUnit.Framework;

namespace UnitTests
{
    public class PluginTestFixture
    {
        [Test]
        [Description("Проверяет количество плагинов в библиотеке.")]
        public void PluginsCount_PluginsNotEmpty_CountReturned()
        {
            var count = Plugins.PluginsCount;
            Assert.AreEqual(2, count);
        }

        [Test]
        [Description("Проверяет получение несуществующего плагина.")]
        public void GetPlugin_PluginNotRegistered_PluginNotReturned()
        {
            Assert.Catch<ArgumentNullException>(() => Plugins.GetPlugin("Несуществующий плагин"));
        }

        [Test]
        [Description("Проверяет получение существующих плагинов.")]
        public void GetPlugin_PluginRegistered_PluginReturned()
        {
            var addition = Plugins.GetPlugin("Сложение.");
            var substraction = Plugins.GetPlugin("Вычитание.");
            var division = Plugins.GetPlugin("Деление без остатка.");
            var modulo = Plugins.GetPlugin("Деление с остатком.");
            var multiplication = Plugins.GetPlugin("Умножение.");
            var pow = Plugins.GetPlugin("Возведение в степень.");

            Assert.AreEqual("Выполняет операцию сложения.", addition.Description);
            Assert.AreEqual("Выполняет операцию вычитания.", substraction.Description);

            Assert.AreEqual("Выполняет операцию деления без остатка.", division.Description);
            Assert.AreEqual("Выполняет операцию деления с остатком.", modulo.Description);

            Assert.AreEqual("Выполняет операцию умножения.", multiplication.Description);
            Assert.AreEqual("Выполняет операцию возведения в степень.", pow.Description);

            Assert.AreEqual(7, addition.Run(6, 1));
            Assert.AreEqual(5, substraction.Run(6, 1));

            Assert.AreEqual(6, division.Run(6, 1));
            Assert.AreEqual(0, modulo.Run(6, 1));

            Assert.AreEqual(12, multiplication.Run(6, 2));
            Assert.AreEqual(36, pow.Run(6, 2));
        }

        [Test]
        [Description("Проверяет какие имена плагинов находятся в библиотеке.")]
        public void GetPluginNames_PluginsNotEmpty_NamesReturned()
        {
            var names = Plugins.GetPluginNames;
            var isAddition = names.Contains("Сложение.");
            var isSubstraction = names.Contains("Вычитание.");
            var isDivision = names.Contains("Деление без остатка.");
            var isModulo = names.Contains("Деление с остатком.");
            var isMultiplication = names.Contains("Умножение.");
            var isPow = names.Contains("Возведение в степень.");

            Assert.AreEqual(true, isAddition);
            Assert.AreEqual(true, isSubstraction);

            Assert.AreEqual(true, isDivision);
            Assert.AreEqual(true, isModulo);

            Assert.AreEqual(true, isMultiplication);
            Assert.AreEqual(true, isPow);
        }
    }
}
