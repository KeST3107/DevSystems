namespace ds.test.impl.ImplementedPlugins
{
    /// <summary>
    ///     Представляет плагин сложения чисел.
    /// </summary>
    internal class MultiplicationPlugin : BasePlugin
    {
        /// <summary>
        ///     Инициализирует новый экземпляр <see cref="MultiplicationPlugin" />
        /// </summary>
        public MultiplicationPlugin()
        {
            PluginName = "Умножение.";
            Version = "1.0";
            Description = "Выполняет операцию умножения.";
        }

        /// <inheritdoc />
        public override string PluginName { get; }

        /// <inheritdoc />
        public override string Version { get; }

        /// <inheritdoc />
        public override string Description { get; }

        /// <summary>
        ///     Выполняет умножение двух чисел.
        /// </summary>
        /// <param name="input1">1 аргумент.</param>
        /// <param name="input2">2 аргумент.</param>
        /// <returns>Результат умножения.</returns>
        public override int Run(int input1, int input2)
        {
            return InnerRun(input1, input2, "*");
        }
    }
}
