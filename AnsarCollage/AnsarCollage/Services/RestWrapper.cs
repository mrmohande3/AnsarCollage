using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Refit;

namespace AnsarCollage.Services
{
    public class RestWrapper
    {
        private static RestWrapper _instance;
        public static RestWrapper Instance
        {
            get
            {
                if(_instance== null )
                    _instance = new RestWrapper();
                return _instance;
            }
        }

        private static RefitSettings setting = new RefitSettings(new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
        {
            Formatting = Newtonsoft.Json.Formatting.Indented,
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
        }));

        public IAuthorizeRestApi AuthorizeRestApi = RestService.For<IAuthorizeRestApi>(Address.BaseAddress,setting);
        public IDataRestApi DataRestApi = RestService.For<IDataRestApi>(Address.BaseAddress, setting);
    }
}
