using System.Threading.Tasks;

using BeverageMachine.Contracts;
using BeverageMachine.Controllers.Params;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeverageMachine.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ImageUploaderController : ControllerBase
  {
    [HttpPost]
    public async Task<IActionResult> Upload(
      [FromServices] IFileProvider provider)
    {
      HttpRequest request = HttpContext.Request;
      IFormFile file = request.Form.Files.GetFile("file");
      return new JsonResult(await provider.UploadImage(file));
    }

    [HttpDelete]
    public async Task<IActionResult> Remove(
      [FromServices] IFileProvider provider,
      [FromBody] FileInfoDto filiInfo)
    {
      provider.RemoveFile(filiInfo.Path);
      return Ok();
    }
  }
}
