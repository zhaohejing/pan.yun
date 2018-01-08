using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Yun.Features;
using Yun.Storage;

namespace Yun.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FileController : YunControllerBase
    {
        private readonly IOptions<ApplicationConfiguration> _options;
        private readonly IBinaryObjectManager _storager;
        public FileController(IOptions<ApplicationConfiguration> options, IBinaryObjectManager storager)
        {
            _options = options;
            _storager = storager;
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> UploadFile()
        {
            string error = "", fileName = "";
            string path = "";
            Guid name = Guid.Empty;
            var host = _options.Value.ClientRootAddress;
            try
            {
                var oFile = Request.Form.Files["txt_file"];
                Stream sm = oFile.OpenReadStream();
                fileName = oFile.FileName;
                var user = AbpSession.UserId?.ToString() ?? "zero";
                var folder = $"{AppContext.BaseDirectory}/{user}/{DateTime.Now:yyyyMMdd}/";

                var ext = oFile.FileName.Split('.').Last();
                name = Guid.NewGuid();
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                string filename = $"{folder}{name.ToString()}.{ext}";
                ;
                FileStream fs = new FileStream(filename, FileMode.Create);
                var length = sm.Length;
                byte[] buffer = new byte[length];
                sm.Read(buffer, 0, buffer.Length);
                fs.Write(buffer, 0, buffer.Length);
                fs.Dispose();
                path = $"/{user}/{DateTime.Now:yyyyMMdd}/{name.ToString()}.{ext}";
                //保存数据库
                await _storager.SaveAsync(new BinaryObject()
                {
                    Id = name,
                    Name = filename,
                    Size = length,
                    Suffix = ext,
                    Url = path
                });
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return Json(new
            {
                result = !string.IsNullOrWhiteSpace(error),
                fileName = fileName,
                url = path,
                viewUrl = host + path,
                guid = name
            });
        }
    }
}
