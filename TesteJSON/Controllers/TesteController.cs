using Microsoft.AspNetCore.Mvc;
using Wkhtmltopdf.NetCore;

namespace TesteJSON.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteController: Controller
    {
        protected internal readonly IGeneratePdf _pdf;
       
        public TesteController(IGeneratePdf pdf)
        {
            _pdf = pdf;
        }

        [HttpGet("index")]
        public ActionResult Index(string nome)
        {
            ViewBag.Nome = nome;
            return View("Header");
        }

        [HttpGet("teste")]
        public async Task<IActionResult> Teste()
        {
            string header = @"http://localhost:5021/Teste/index?nome=" + "ChuckNorris";

            string body = "";
            for (int i=0; i < 1000; i++)
            {
                body += "<span>" + i.ToString() + "</span><br>";
            }

            byte[] bytes = new TesteJson(_pdf).Test(body,header);
            Stream stream = new MemoryStream(bytes);
            return new FileStreamResult(stream, "application/pdf")
            {
                FileDownloadName = DateTime.Now.ToString("dd_MM_yy_hh_mm")+".pdf"
            };
        }
    }
}
