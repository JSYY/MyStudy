namespace MyUnity.Modules
{
    public interface IUnityModule
    {
        void PreInitialize();
        void Initialize();
        void PostInitialize();
        void Shutdown();
    }
}
