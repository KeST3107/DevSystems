using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ds.test.impl.ImplementedPlugins;

namespace ds.test.impl
{
    /// <summary>
    ///     Представляет фабрику плагинов.
    /// </summary>
    internal class Factory : PluginFactory
    {
        private readonly IEnumerable<BasePlugin> _collectionPlugins;

        /// <summary>
        ///     Конструктор фабрики.
        /// </summary>
        public Factory()
        {
            _collectionPlugins = GetCollectionPlugins();
            GetPluginNames = GetNames();
            PluginsCount = GetPluginNames.Length;
        }

        public int PluginsCount { get; }
        public string[] GetPluginNames { get; }

        /// <summary>
        ///     Возвращает реализацию плагина.
        /// </summary>
        /// <param name="pluginName">Имя плагина.</param>
        /// <returns>Реализация плагина.</returns>
        /// <exception cref="ArgumentNullException">Если плагин не найден.</exception>
        public IPlugin GetPlugin(string pluginName)
        {
            if (!GetPluginNames.Contains(pluginName)) throw new ArgumentNullException(pluginName);

            var type = _collectionPlugins.Where(x => x.PluginName == pluginName).First();
            return type;
        }

        private IEnumerable<BasePlugin> GetCollectionPlugins()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.IsClass && x.BaseType == typeof(BasePlugin) && !x.IsAbstract);
            var plugins = new List<BasePlugin>();
            foreach (var type in types) plugins.Add(Activator.CreateInstance(type) as BasePlugin);

            return plugins;
        }

        private string[] GetNames()
        {
            var names = _collectionPlugins.Select(x =>
            {
                if (x != null) return x.PluginName;
                return string.Empty;
            }).ToArray();
            return names;
        }
    }
}