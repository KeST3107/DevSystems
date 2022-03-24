namespace ds.test.impl.ImplementedPlugins
{
    /// <summary>
    ///     Представляет плагин деления чисел с остатком.
    /// </summary>
    internal class ModuloPlugin : BasePlugin
    {
        /// <summary>
        ///     Инициализирует новый экземпляр <see cref="ModuloPlugin" />
        /// </summary>
        public ModuloPlugin()
        {
            PluginName = "Деление с остатком.";
            Version = "1.0";
            Description = "Выполняет операцию деления с остатком.";
        }

        /// <inheritdoc />
        public override string PluginName { get; }

        /// <inheritdoc />
        public override string Version { get; }

        /// <inheritdoc />
        public override string Description { get; }

        /// <summary>
        ///     Выполняет деление с остатком двух чисел.
        /// </summary>
        /// <param name="input1">1 аргумент.</param>
        /// <param name="input2">2 аргумент.</param>
        /// <returns>Остаток.</returns>
        public override int Run(int input1, int input2)
        {
            return InnerRun(input1, input2, "%");
        }
    }
}