using System;
using System.Configuration;
using System.Net.Mail;

namespace Wubblog.Library.Mail
{
	/// <summary>
	/// Use this class to access settings from the .config file for use with the Message class.
	/// </summary>
	public sealed class MessageSettings
	{
		private MessageSettings(){}
		
		#region Properties
		
		internal static string SystemEmailAddress
		{
			get { return ConfigurationManager.AppSettings["SystemEmailAddress"]; }
		}

		internal static string SystemEmailName
		{
			get { return ConfigurationManager.AppSettings["SystemEmailName"]; }
		}

		internal static string SystemDomain
		{
			get { return ConfigurationManager.AppSettings["Domain"]; }
		}

		internal static string SmtpServer
		{
			get { return ConfigurationManager.AppSettings["SmtpServer"]; }
		}

		internal static string ErrorEmailAddress
		{
			get { return ConfigurationManager.AppSettings["ErrorEmailAddress"]; }
		}
		
		#endregion
		
	}
}
