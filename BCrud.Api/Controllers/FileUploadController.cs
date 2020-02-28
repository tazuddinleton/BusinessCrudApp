using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BCrud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {   
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly string fileLocation = "/files/";
        public FileUploadController(IHostingEnvironment hostingEnvironment)
        {            
            _hostingEnvironment = hostingEnvironment;
        }


        [HttpPost]
        public ActionResult<Dictionary<string, string>> Post()
        {
            try
            {
                var form = Request.Form;
                var f = form.Files;


                var url = Request.Host.ToUriComponent() + fileLocation;

                var files = Request.Form.Files.Count > 0 ? Request.Form.Files : null;



                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                if (files != null)
                {
                    foreach (var file in files)
                    {
                        string path = Path.Combine(_hostingEnvironment.WebRootPath, "files");

                        string ext = Path.GetExtension(file.FileName);
                        var newFilename = Guid.NewGuid() + ext;

                        keyValuePairs.Add(file.FileName, url + newFilename);

                        using (var fileStream = new FileStream(Path.Combine(path, newFilename), FileMode.Create))
                        {
                            file.CopyToAsync(fileStream);
                        }
                    }
                }
                return Ok(keyValuePairs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}