using AccountsWebAuthentication.Helper;
using AccountsWebAuthentication.Controllers;

namespace AndersonCRMWeb.Controllers
{
    [CustomAuthorize(AllowedRoles = new string[] { "AndersonCRM" })]
    public class BaseController : BaseAccountsController
    {
    }
}