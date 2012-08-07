using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;

namespace Wubblog.Library.Mail
{
	/// <summary>
	/// Use this to send pre-defined message templates using the Message class. No need a create one.
	/// </summary>
	public sealed class MessageTemplates
	{
		private MessageTemplates() {}
		
		
		public static void ErrorReport(Exception ex)
		{

			var subject = "Error Report";
			var htmlBody = GetHtmlTemplate("ErrorReport");
			var plainBody = GetPlainTemplate("ErrorReport");

			// Get variables for web application information.
			HttpRequest request = HttpContext.Current.Request;

			string serverName = request.ServerVariables["SERVER_NAME"];

			string httpReferer = "None";
			if (request.ServerVariables["HTTP_REFERER"] != null)
				httpReferer = request.ServerVariables["HTTP_REFERER"];

			string userAgent = "No Data";
			if (request.ServerVariables["HTTP_USER_AGENT"] != null)
				userAgent = request.ServerVariables["HTTP_USER_AGENT"];

			string ipAddress = "No Data";
			if (request.ServerVariables["REMOTE_HOST"] != null)
				ipAddress = request.ServerVariables["REMOTE_HOST"];

			string formData = Regex.Replace(request.Form.ToString(), "__VIEWSTATE=([^&]*)&", "");
			formData = formData.Replace("&", "\r");

			string queryStringData = request.QueryString.ToString();
			queryStringData = queryStringData.Replace("&", "\r");

			using (var message = new Message(subject, MessageSettings.ErrorEmailAddress, htmlBody, plainBody))
			{
				message.Replace("[ErrorMessage]", ex.Message);
				message.Replace("[ErrorSource]", ex.Source);
				message.Replace("[ExceptionType]", ex.GetType().ToString());
				message.Replace("[StackTrace]", ex.StackTrace);
				message.Replace("[TargetSite]", ex.TargetSite.ToString());
				message.Replace("[ServerTime]", DateTime.Now.ToString("dd MMMM yyyy hh:mm:ss tt"));
				message.Replace("[ServerName]", serverName);
				message.Replace("[HttpReferer]", httpReferer);
				message.Replace("[UserAgent]", userAgent);
				message.Replace("[IpAddress]", ipAddress);
				message.Replace("[Url]", request.RawUrl);
				message.Replace("[RequestForm]", formData);
				message.Replace("[Querystring]", queryStringData);
				message.Send();
			}
		}

		public static string GetHtmlTemplate(string templateName)
		{
			var htmlStructure = GetFromTemplates("HtmlStructure.html");
			var htmlMessage = GetFromTemplates(templateName + ".html");
			htmlMessage = htmlStructure.Replace("[HtmlMessage]", htmlMessage);
			return htmlMessage;
		}

		public static string GetPlainTemplate(string templateName)
		{
			return GetFromTemplates(templateName + ".txt");
		}

		private static string GetFromTemplates(string templateName)
		{
			string template = "";
			Assembly assem = Assembly.GetExecutingAssembly();
			string resourceName = string.Format("Wubblog.Library.Mail.Templates.{0}", templateName);
			using (Stream stream = assem.GetManifestResourceStream(resourceName))
			{
				if (stream != null)
				{
					using (StreamReader reader = new StreamReader(stream))
					{
						template = reader.ReadToEnd();
					}
				}
			}
			assem = null;
			return template;
		}
		
	}
}
