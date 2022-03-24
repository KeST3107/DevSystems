namespace ds.test.impl.ImplementedPlugins
{
    /// <summary>
    ///     Представляет плагин сложения чисел.
    /// </summary>
    internal class SubtractionPlugin : BasePlugin
    {
        /// <summary>
        ///     Инициализирует новый экземпляр <see cref="SubtractionPlugin" />
        /// </summary>
        public SubtractionPlugin()
        {
            PluginName = "Вычитание.";
            Version = "1.0";
            Description = "Выполняет операцию вычитания.";
        }


        /// <inheritdoc />
        public override string PluginName { get; }


        /// <inheritdoc />
        public override string Version { get; }

        /// <inheritdoc />
        public override string Description { get; }

        /// <summary>
        ///     Выполняет вычитание двух чисел.
        /// </summary>
        /// <param name="input1">1 аргумент.</param>
        /// <param name="input2">2 аргумент.</param>
        /// <returns>Результат вычитания.</returns>
        public override int Run(int input1, int input2)
        {
            return InnerRun(input1, input2, "-");
        }
    }
}