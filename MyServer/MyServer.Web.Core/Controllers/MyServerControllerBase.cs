using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MyServer.Controllers
{
    public abstract class MyServerControllerBase: AbpController
    {
        protected MyServerControllerBase()
        {
            LocalizationSourceName = MyServerConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
