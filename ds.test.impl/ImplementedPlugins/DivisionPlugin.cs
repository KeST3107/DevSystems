using System;
using System.Data;

namespace ds.test.impl.ImplementedPlugins
{
    /// <summary>
    ///     Представляет плагин деления чисел без остатка.
    /// </summary>
    internal class DivisionPlugin : BasePlugin
    {
        /// <summary>
        ///     Инициализирует новый экземпляр <see cref="DivisionPlugin" />
        /// </summary>
        public DivisionPlugin()
        {
            PluginName = "Деление без остатка.";
            Version = "1.0";
            Description = "Выполняет операцию деления без остатка.";
        }

        /// <inheritdoc />
        public override string PluginName { get; }

        /// <inheritdoc />
        public override string Version { get; }

        /// <inheritdoc />
        public override string Description { get; }

        /// <summary>
        ///     Выполняет деление без остатка двух чисел.
        /// </summary>
        /// <param name="input1">1 аргумент.</param>
        /// <param name="input2">2 аргумент.</param>
        /// <returns>Результат деления.</returns>
        public override int Run(int input1, int input2)
        {
            var dt = new DataTable();
            int result;
            try
            {
                if (input2 == 0) throw new DivideByZeroException();
                result = Convert.ToInt32(dt.Compute(input1 + "/" + input2, " "));
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