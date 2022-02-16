using Microsoft.AspNetCore.Mvc;
using Wkhtmltopdf.NetCore;

namespace TesteJSON.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteController: ControllerBase
    {
        protected internal readonly IGeneratePdf _pdf;

        public TesteController(IGeneratePdf pdf)
        {
            _pdf = pdf;
        }

        [HttpGet("teste")]
        public IActionResult Teste()
        {
            byte[] bytes = new TesteJson(_pdf).Test();
            Stream stream = new MemoryStream(bytes);
            return new FileStreamResult(stream, "application/pdf")
            {
                FileDownloadName = "FileasStream.pdf"
            };
        }
    }
}
