namespace ds.test.impl.ImplementedPlugins
{
    /// <summary>
    ///     Представляет плагин сложения чисел.
    /// </summary>
    internal class AdditionPlugin : BasePlugin
    {
        /// <summary>
        ///     Инициализирует новый экземпляр <see cref="AdditionPlugin" />
        /// </summary>
        public AdditionPlugin()
        {
            PluginName = "Сложение.";
            Version = "1.0";
            Description = "Выполняет операцию сложения.";
        }

        /// <inheritdoc />
        public override string PluginName { get; }

        /// <inheritdoc />
        public override string Version { get; }

        /// <inheritdoc />
        public override string Description { get; }

        /// <summary>
        ///     Выполняет сложение двух чисел.
        /// </summary>
        /// <param name="input1">1 аргумент.</param>
        /// <param name="input2">2 аргумент.</param>
        /// <returns>Результат сложения.</returns>
        public override int Run(int input1, int input2)
        {
            return InnerRun(input1, input2, "+");
        }
    }
}