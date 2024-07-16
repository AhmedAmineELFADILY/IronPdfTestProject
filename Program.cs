using Microsoft.Extensions.Configuration;

namespace IronPdfTestProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Build configuration
                var configDirectory = @"C:\Users\hp\source\repos\IronPdfTestProject";
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(configDirectory)
                    .AddJsonFile("appsetting.json", optional: false, reloadOnChange: true)
                    .Build();
                string licenseKey = configuration["IronPdf:LicenseKey"];
                IronPdf.License.LicenseKey = licenseKey;
                var Renderer = new HtmlToPdf();


                //HTML Content
                string htmlContent = @"
                    <html>
                        <head>
                            <title>Advanced Test PDF</title>
                            <style>
                                body { font-family: Arial, sans-serif; margin: 20px; }
                                h1 { color: #2E86C1; }
                                p { font-size: 14px; line-height: 1.5; }
                                .container { width: 100%; max-width: 800px; margin: 0 auto; }
                                .image { text-align: center; }
                                .table { width: 100%; border-collapse: collapse; margin-top: 20px; }
                                .table th, .table td { border: 1px solid #ddd; padding: 8px; text-align: left; }
                                .table th { background-color: #f2f2f2; }
                                .footer { text-align: center; margin-top: 20px; font-size: 12px; color: #888; }
                            </style>
                        </head>
                        <body>
                            <div class='container'>
                                <h1>Welcome to IronPDF</h1>
                                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec eu felis eros. Suspendisse at pulvinar nibh. Cras vitae consectetur est. Proin ut diam non mauris vulputate laoreet a in purus. Duis porttitor blandit rhoncus. Fusce ut nulla malesuada, blandit leo vitae, aliquet massa. Sed pulvinar, nisi ac tincidunt mattis, nisl arcu pharetra augue, nec auctor nulla nisl nec elit. Integer dapibus massa id lorem auctor imperdiet. Nam vulputate malesuada diam, sed faucibus lorem tristique sed. Suspendisse a elit et dolor condimentum congue. Donec consectetur eros nunc, at egestas erat semper ac. Fusce elementum odio vitae purus varius scelerisque.</p>
                                <div class='image'>
                                    <img src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSLtZy-ivuMV16sGOJxgZwLtYWVOB1wJETIjg&s' alt='Sample Image' />
                                </div>
                                <table class='table'>
                                    <tr>
                                        <th>Header 1</th>
                                        <th>Header 2</th>
                                        <th>Header 3</th>
                                    </tr>
                                    <tr>
                                        <td>Data 1</td>
                                        <td>Data 2</td>
                                        <td>Data 3</td>
                                    </tr>
                                    <tr>
                                        <td>Data 4</td>
                                        <td>Data 5</td>
                                        <td>Data 6</td>
                                    </tr>
                                </table>
                                <p>For more information, visit <a href='https://google.com'> Our Website</a>.</p>
                                <div class='footer'>
                                    <p>&copy; AmineFadily</p>
                                </div>
                            </div>
                        </body>
                    </html>";

                PdfDocument pdf = Renderer.RenderHtmlAsPdf(htmlContent);

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // Setting the output path to the desktop
                string outputPath = Path.Combine(desktopPath, "test_document.pdf");
                pdf.SaveAs(outputPath);
                Console.WriteLine($"PDF document created and saved to {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
