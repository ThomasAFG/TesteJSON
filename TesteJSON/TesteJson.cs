using System.Text.Json;
using Wkhtmltopdf.NetCore;

namespace TesteJSON
{
    public class TesteJson
    {
        protected internal readonly IGeneratePdf _pdf;

        public TesteJson(IGeneratePdf pdf)
        {
            _pdf = pdf;
        }

        public byte[] Test()
        {
            try
            {
                string html = "<!DOCTYPE html>" +
                              "<html>" +
                              "<head><meta charset='UTF-8'><title>TESTE</title></head>" +
                              "<body> 123";

                html += "</body>" +
                        "</html>";

                var pdf = _pdf.GetPDF(html);
                return pdf;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
