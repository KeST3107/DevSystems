namespace ds.test.impl
{
    /// <summary>
    ///     Представляет интерфейс фабрики плагинов.
    /// </summary>
    internal interface PluginFactory
    {
        int PluginsCount { get; }
        string[] GetPluginNames { get; }
        IPlugin GetPlugin(string pluginName);
    }
}