﻿using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace WhmcsPopulator
{
	public static class ApiCredentials
	{
        public static string Url = ConfigurationManager.AppSettings["ApiUrl"];
		public static string UserName = ConfigurationManager.AppSettings["WhmcsUser"];
		public static string Password = CreateMD5Hash(ConfigurationManager.AppSettings["WhmcsPassword"]);

		private static string CreateMD5Hash(string sourceString)
		{
			using (MD5 md5Hash = MD5.Create())
			{
				string hash = GetMd5Hash(md5Hash, sourceString);

				return hash;
			}
		}

		private static string GetMd5Hash(MD5 md5Hash, string input)
		{

			// Convert the input string to a byte array and compute the hash. 
			byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

			// Create a new Stringbuilder to collect the bytes 
			// and create a string.
			StringBuilder sBuilder = new StringBuilder();

			// Loop through each byte of the hashed data  
			// and format each one as a hexadecimal string. 
			for (int i = 0; i < data.Length; i++)
			{
				sBuilder.Append(data[i].ToString("x2"));
			}

			// Return the hexadecimal string. 
			return sBuilder.ToString();
		}
	}
}