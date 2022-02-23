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

        public byte[] Test(string body, string header)
        {
            try
            {
                
                var options = new OptionsWkhtmltopdf()
                {
                    HeaderHtml = header,
                    PageOrientation = Wkhtmltopdf.NetCore.Options.Orientation.Landscape
                };
                _pdf.SetConvertOptions(options);
                
                string html = "<!DOCTYPE html>" +
                              "<html>" +
                              "<head>" +
                              "</head>" +
                              "<body>";

                html += body;

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
