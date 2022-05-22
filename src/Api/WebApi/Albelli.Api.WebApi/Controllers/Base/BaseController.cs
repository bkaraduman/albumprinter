using Albelli.Common;
using Microsoft.AspNetCore.Mvc;

namespace Albelli.Api.WebApi.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private Guid? _userId;
        
        public Guid UserId
        {
            get
            {
                try
                {
                    if (!_userId.HasValue)
                        _userId = new Guid(AlbelliConstants.DefaultUserId);

                    return _userId.Value;
                }
                catch
                {
                    return Guid.Empty;
                }
            }
        }
    }


    

}
