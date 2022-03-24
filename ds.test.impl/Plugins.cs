using System;

namespace ds.test.impl
{
    /// <summary>
    ///     Представляет реализацию получения плагинов.
    /// </summary>
    public static class Plugins
    {
        private static readonly Factory Factory;

        /// <summary>
        ///     Инициализирует фабрику плагинов.
        /// </summary>
        static Plugins()
        {
            Factory = new Factory();
        }

        /// <summary>
        ///     Возвращает количество доступных плагинов.
        /// </summary>
        public static int PluginsCount => Factory.PluginsCount;

        /// <summary>
        ///     Возвращает массив имен плагинов.
        /// </summary>
        public static string[] GetPluginNames => Factory.GetPluginNames;

        /// <summary>
        ///     Возвращает плагин по его названию.
        /// </summary>
        /// <param name="pluginName">Имя плагина.</param>
        /// <returns>Реализация плагина.</returns>
        public static IPlugin GetPlugin(string pluginName)
        {
            try
            {
                return Factory.GetPlugin(pluginName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}