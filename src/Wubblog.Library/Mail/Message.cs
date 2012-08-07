using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Wubblog.Library.Mail
{
	/// <summary>
	/// Use this class to send emails.
	/// </summary>
	public class Message : IDisposable
	{
		#region Constructors
		
		public Message(string subject, string recipientAddress,
		               string htmlBody, string plainTextBody,
		               string senderAddress = "", string senderName = "",
		               MailPriority priority = MailPriority.Normal,
		               string copyAddress = "", string blindCopyAddress = "")
		{
			
			if(string.IsNullOrEmpty(subject))
				throw new ArgumentOutOfRangeException("subject", "The 'subject' parameter can not be null or empty");

			if(string.IsNullOrEmpty(recipientAddress))
				throw new ArgumentOutOfRangeException("recipientAddress", "The 'recipientAddress' parameter can not be null or empty");

			if(string.IsNullOrEmpty(htmlBody))
				throw new ArgumentOutOfRangeException("htmlBody", "The 'htmlBody' parameter can not be null or empty");

			if(string.IsNullOrEmpty(plainTextBody))
				throw new ArgumentOutOfRangeException("plainTextBody", "The 'plainTextBody' parameter can not be null or empty");

			this._Subject = subject;
			this._RecipientAddress = recipientAddress;
			if(senderAddress != "") this._Sender = new MailAddress(senderAddress, senderName);
			this._HtmlBody = htmlBody;
			this._PlainTextBody = plainTextBody;
			this._Priority = priority;
			this._CopyAddress = copyAddress;
			this._BlindCopyAddress = blindCopyAddress;
		}
		
		#endregion
		
		#region Fields

		private string _Subject = "";
		private MailAddress _Sender = new MailAddress(MessageSettings.SystemEmailAddress, MessageSettings.SystemEmailName);
		private string _RecipientAddress = "";
		private string _HtmlBody = "";
		private string _PlainTextBody = "";
		private MailPriority _Priority = MailPriority.Normal;
		private string _CopyAddress = "";
		private string _BlindCopyAddress = "";
		private List<Attachment> _Attachments = new List<Attachment>();
		
		private static SmtpClient _SmtpClient = null;

		#endregion
		
		#region Properties

		public string Subject
		{
			get { return _Subject; }
			set { _Subject = value; }
		}

		public MailAddress Sender
		{
			get { return _Sender; }
			set { _Sender = value; }
		}

		public string RecipientAddress
		{
			get { return _RecipientAddress; }
			set { _RecipientAddress = value; }
		}
		
		public string HtmlBody
		{
			get { return _HtmlBody; }
			set { _HtmlBody = value; }
		}

		public string PlainTextBody
		{
			get { return _PlainTextBody; }
			set { _PlainTextBody = value; }
		}

		public MailPriority Priority
		{
			get { return _Priority; }
			set { _Priority = value; }
		}

		public string CopyAddress
		{
			get { return _CopyAddress; }
			set { _CopyAddress = value; }
		}

		public string BlindCopyAddress
		{
			get { return _BlindCopyAddress; }
			set { _BlindCopyAddress = value; }
		}

		private static SmtpClient SmtpClient
		{
			get
			{
				if (_SmtpClient == null)
				{
					_SmtpClient = new SmtpClient(MessageSettings.SmtpServer);
				}
				return _SmtpClient;
			}
		}
		
		#endregion
		
		#region Methods

		public void AddAttachment(System.IO.Stream stream, string name, string mediaType)
		{
			stream.Position = 0;
			using (Attachment attachment = new Attachment(stream, name, mediaType))
			{
				attachment.ContentDisposition.FileName = name;
				this._Attachments.Add(attachment);
			}
		}

		public void Replace(string keyword, string replacement)
		{
			_HtmlBody = _HtmlBody.Replace(keyword, replacement);
			_PlainTextBody = _PlainTextBody.Replace(keyword, replacement);
			_Subject = _Subject.Replace(keyword, replacement);
		}

		/// <summary>
		/// Send the message.
		/// </summary>
		public void Send()
		{
			this.Replace("[Domain]", MessageSettings.SystemDomain);
			this.Replace("[Subject]", this.Subject);
			
			using (MailMessage message = new MailMessage())
			{
				// Various settings, such as subject, addresses, priority
				message.Subject = this.Subject;
				message.From = this.Sender;
				message.To.Add(this.RecipientAddress);
				if (this.CopyAddress.Length > 0)
					message.CC.Add(this.CopyAddress);
				if (this.BlindCopyAddress.Length > 0)
					message.Bcc.Add(this.BlindCopyAddress);
				message.Priority = this.Priority;


				// Add Plain Text View
				AlternateView textView = AlternateView.CreateAlternateViewFromString(this.PlainTextBody, Encoding.UTF8, "text/plain");
				message.AlternateViews.Add(textView);

				// Add HTML View
				AlternateView htmlView = AlternateView.CreateAlternateViewFromString(this.HtmlBody, Encoding.UTF8, "text/html");
				message.AlternateViews.Add(htmlView);

				// Add attachments.
				foreach (Attachment attachment in this._Attachments)
					message.Attachments.Add(attachment);

				Message.SmtpClient.Send(message);
			}
		}

		#endregion
		
		#region Finalise and Disposing

		private bool isDisposed;

		private void Dispose(bool isDisposing)
		{
			if (!this.isDisposed && isDisposing)
			{
				_Subject = null;
				_Sender = null;
				_RecipientAddress = null;
				_HtmlBody = null;
				_PlainTextBody = null;
				_CopyAddress = null;
				_BlindCopyAddress = null;
			}
			this.isDisposed = true;
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		~Message()
		{
			this.Dispose(false);
		}

		#endregion
		
	}
}
