using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace MyApiApp.Controllers {

[Route("api/files")]
[ApiController]
public class FilesController : ControllerBase {
 public readonly FileExtensionContentTypeProvider _fileExtenstionContentProvider;
 
 public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider) {
     _fileExtenstionContentProvider = fileExtensionContentTypeProvider;
 }
    [HttpGet("{fileId}")]
   public ActionResult GetFile(string fileId) {
       var pathToFile ="demo.txt";
       if(!System.IO.File.Exists(pathToFile)) {
           return NotFound();
       }

       if(!_fileExtenstionContentProvider.TryGetContentType(pathToFile, out var contentType)) {
           contentType = "application/octet-stream";
       }

       var bytes = System.IO.File.ReadAllBytes(pathToFile);
   
   return File(bytes, contentType,  Path.GetFileName(pathToFile));
   } 
}
}