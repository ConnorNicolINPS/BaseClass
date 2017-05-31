namespace WebSocketHandler.Wpf
{
    using MvvmCross.Platform;
    using MvvmCross.Platform.Plugins;

    class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Mvx.RegisterSingleton<IWebSocketHandler>(() => new WebSocketHandler());
        }
    }
}
