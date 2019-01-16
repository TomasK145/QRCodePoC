using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QRCoder.PayloadGenerator;

namespace TestQrCode
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Test();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ex: " + ex);
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }

        private static void Test()
        {
            Url generator = new Url("https://github.com/codebude/QRCoder/");
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(20);

            qrCodeAsBitmap.Save("test.jpeg", ImageFormat.Jpeg);
        }
    }
}
