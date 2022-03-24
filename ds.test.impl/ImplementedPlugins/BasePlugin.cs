using System;
using System.Data;
using System.Drawing;

namespace ds.test.impl.ImplementedPlugins
{
    /// <summary>
    ///     Представляет базовую реализацию для плагинов.
    /// </summary>
    internal abstract class BasePlugin : IPlugin
    {
        /// <summary>
        ///     Возвращает имя плагина.
        /// </summary>
        public abstract string PluginName { get; }

        /// <summary>
        ///     Возвращает версию плагина.
        /// </summary>
        public abstract string Version { get; }

        /// <summary>
        ///     Базовая реализация Image.
        /// </summary>
        public virtual Image Image => new Bitmap(100, 100);

        /// <summary>
        ///     Возвращает описание плагина.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        ///     Базовая реализация метода.
        /// </summary>
        /// <param name="input1">1 аргумент.</param>
        /// <param name="input2">2 аргумент.</param>
        /// <returns>Результат вычисления.</returns>
        public virtual int Run(int input1, int input2)
        {
            return input1 + input2 * input1;
        }

        protected virtual int InnerRun(int input1, int input2, string @char)
        {
            var dt = new DataTable();
            int result;
            try
            {
                result = Convert.ToInt32(dt.Compute(input1 + @char + input2, " "));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка: {e}\n" +
                                  $"Плагин: {PluginName}\n" +
                                  $"Версия: {Version}\n" +
                                  $"Описание: {Description}\n" +
                                  $"Входные аргументы 1: {input1}, 2: {input2}");
                throw;
            }

            return result;
        }
    }
}