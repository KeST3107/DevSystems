using System;

namespace ds.test.impl.ImplementedPlugins
{
    /// <summary>
    ///     Представляет плагин возведения в степень.
    /// </summary>
    internal class PowPlugin : BasePlugin
    {
        /// <summary>
        ///     Инициализирует новый экземпляр <see cref="PowPlugin" />
        /// </summary>
        public PowPlugin()
        {
            PluginName = "Возведение в степень.";
            Version = "1.0";
            Description = "Выполняет операцию возведения в степень.";
        }

        /// <inheritdoc />
        public override string PluginName { get; }

        /// <inheritdoc />
        public override string Version { get; }

        /// <inheritdoc />
        public override string Description { get; }

        /// <summary>
        ///     Выполняет возведение первого числа в степень второго.
        /// </summary>
        /// <param name="input1">1 аргумент.</param>
        /// <param name="input2">2 аргумент.</param>
        /// <returns>Результат возведения.</returns>
        public override int Run(int input1, int input2)
        {
            int result;
            try
            {
                if (input1 == 0 && input2 < 0) throw new DivideByZeroException();
                result = Convert.ToInt32(Math.Pow(input1, input2));
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
