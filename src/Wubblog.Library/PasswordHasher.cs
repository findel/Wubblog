
using System;
using System.Security.Cryptography;
using System.Text;

namespace Wubblog.Library
{
	/// <summary>
	/// Description of PasswordHasher.
	/// </summary>
	internal static class PasswordHasher
	{
		internal static string CreateHash(string password)
		{
			var salt = CreateSalt();
			var hash = CreateSha256Hex(password, salt);
			// Plant the salt in the middle of the hash.
			return hash.Substring(0, 32) + salt + hash.Substring(32, 32);
		}
		
		internal static bool ValidateHash(string password, string fullHash)
		{
			var salt = fullHash.Substring(32, 64); // Get salt from the middle of the hash.
			var actual = fullHash.Remove(32, 64); // Get hash without the salt.
			var testHash = CreateSha256Hex(password, salt);
			var isValid = string.Equals(actual, testHash);
			return isValid;
		}
		
		private static string CreateSalt()
		{
			RNGCryptoServiceProvider randomProvider = new RNGCryptoServiceProvider();
			byte[] bytes = new byte[32]; // 256 bits, or 64 chars to match the SHA256 output
			randomProvider.GetBytes(bytes);
			return GetHex(bytes);
		}
		
		private static string CreateSha256Hex(string password, string salt)
		{
			SHA256Managed sha256 = new SHA256Managed();
			byte[] passwordBytes = UTF8Encoding.UTF8.GetBytes(password + salt);
			byte[] sha256Bytes = sha256.ComputeHash(passwordBytes);
			return GetHex(sha256Bytes);
		}
		
		private static string GetHex(byte[] bytes)
		{
			StringBuilder builder = new StringBuilder(bytes.Length * 2);
			foreach(var b in bytes)
			{
				builder.Append(b.ToString("x2"));
			}
			return builder.ToString();
		}
	}
}
