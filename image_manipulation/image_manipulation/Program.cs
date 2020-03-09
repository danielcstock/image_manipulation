using System.IO;

namespace ImageManipulation

{
    class Program
    {
        static void Main(string[] args)
        {
            Compressor comp = new Compressor();
            byte[] imgBytes = File.ReadAllBytes("D://foto.jpg");
            byte[] img = comp.CompressToSize(imgBytes, System.Drawing.Imaging.ImageFormat.Jpeg, 200000, 1);
            File.WriteAllBytes("D://nova_foto.jpg", img);
        }
    }
}
