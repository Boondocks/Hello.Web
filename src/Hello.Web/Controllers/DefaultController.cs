using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Hello.Web.Controllers
{
    using System.Collections;
    using Models;

    [Route("/")]
    public class DefaultController : Controller
    {
        //Use this to keep track of which instance we are. Handy for debugging clustered containers.
        private static readonly Guid _instanceId = Guid.NewGuid();

        public IActionResult Index()
        {
            var model = new DefaultModel()
            {
                InstanceId = _instanceId,
                EnvironmentVariables = Environment.GetEnvironmentVariables()
                    .Cast<DictionaryEntry>()
                    .Select(e => new EnvironmentVariable()
                    {
                        Name = e.Key as string,
                        Value = e.Value as string
                    })
                    .OrderBy(v => v.Name)
                    .ToArray()
            };

            return View(model);
        }
    }
}