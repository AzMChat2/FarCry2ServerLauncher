using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace FC2.SL.Remote
{
	internal static class Encryptor
	{
		private static TripleDESCryptoServiceProvider _crypto;
		private static byte[] Key;
		private static byte[] IV;

		public static void Initialize()
		{
			if (_crypto == null)
			{
				_crypto = new TripleDESCryptoServiceProvider();
				Key = new byte[1]; // TODO: load from key file
				IV = new byte[1]; // TODO: hardcode
			}
		}

		public static byte[] Encrypt(string input)
		{
			Initialize();
			ICryptoTransform encryptor = _crypto.CreateEncryptor(Key, IV);
			byte[] data = ASCIIEncoding.ASCII.GetBytes(input);
			return encryptor.TransformFinalBlock(data, 0, data.Length);
		}

		public static string Decrypt(byte[] input)
		{
			Initialize();
			ICryptoTransform decryptor = _crypto.CreateDecryptor(Key, IV);
			byte[] data = decryptor.TransformFinalBlock(input, 0, input.Length);
			return ASCIIEncoding.ASCII.GetString(data);
		}

		private static void GenerateKey()
		{
			Initialize();
			_crypto.GenerateKey();
			Key = _crypto.Key;
			// TODO: Save Key File...
		}
	}
}
