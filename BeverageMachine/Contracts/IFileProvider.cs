using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BeverageMachine.Contracts
{
  public interface IFileProvider
  {
    Task<string> UploadImage(IFormFile file);
    void RemoveFile(string path);
  }
}
