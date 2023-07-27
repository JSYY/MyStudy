using Abp.Application.Services;
namespace MyServer
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class MyServerAppServiceBase : ApplicationService
    {


        protected MyServerAppServiceBase()
        {
            LocalizationSourceName = MyServerConsts.LocalizationSourceName;
        }

    }
}
