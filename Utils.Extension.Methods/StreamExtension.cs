using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Utils.Extension.Methods
{
	public static partial class UtilsExtension
	{
		public static string AsString(this Stream stream)
		{
			using (var reader = new StreamReader(stream))
			{
				return reader.ReadToEnd();
			}
		}

		public static async Task<string> AsStringAsync(this Stream stream)
		{
			using (var reader = new StreamReader(stream))
			{
				return await reader.ReadToEndAsync();
			}
		}

		public static byte[] AsBytes(this Stream stream)
		{
			var bytes = new byte[stream.Length];
			stream.Read(bytes, 0, bytes.Length);
			return bytes;
		}

		public static async Task<byte[]> AsBytesAsync(this Stream stream)
		{
			var bytes = new byte[stream.Length];
			await stream.ReadAsync(bytes, 0, bytes.Length);
			return bytes;
		}

		public static async Task<byte[]> AsBytesAsync(this Stream stream, CancellationToken cancellationToken)
		{
			var bytes = new byte[stream.Length];
			await stream.ReadAsync(bytes, 0, bytes.Length, cancellationToken);
			return bytes;
		}
	}
}
