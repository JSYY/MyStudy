namespace MyUnity.Modules
{
    public abstract class UnityModule : IUnityModule
    {
        public virtual void PreInitialize()
        {
        }

        public virtual void Initialize()
        {
        }

        public virtual void PostInitialize()
        {
        }

        public virtual void Shutdown()
        {
        }
    }
}
