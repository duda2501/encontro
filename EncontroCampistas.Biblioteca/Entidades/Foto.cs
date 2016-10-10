using System.Drawing;
using System.IO;

namespace Cadastro_de_Campistas.Biblioteca
{
    public class Foto
	{
		#region Conversoes
		public static Image byteToImage(byte[] byteA)
		{
			MemoryStream ms = new MemoryStream(byteA);
			Image Imagem = Image.FromStream(ms);
			return Imagem;
		}

		public static byte[] imageToByte(Image image)
		{
			MemoryStream ms = new MemoryStream();
			image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
			return ms.ToArray();
		}
		#endregion
	}
}
