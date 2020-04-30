﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Application.Dto.Email;
using Application.Services.Interfaces;
using Hangfire;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using MimeKit;

namespace Application.Services.Implementation
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly EmailConfiguration _emailConfig;
        private readonly IHostingEnvironment _env;

        public EmailSenderService(EmailConfiguration emailConfig, IHostingEnvironment env)
        {
            _emailConfig = emailConfig;
            _env = env;
        }

        public void Hello()
        {
            Console.WriteLine("Hello world!");
        }
        /// <inheritdoc />
        public async Task SendReceiveConfirmationAsync(string userName, string bookName, int bookId, int requestId, string userAddress)
        {
            string body = string.Empty;
            using (StreamReader reader =
                new StreamReader(Path.Combine(_env.ContentRootPath, "Templates", "RequestReceiveConfirmation.html")))
            {
                body = await reader.ReadToEndAsync();
            }

            body = body.Replace("{USER.NAME}", userName);
            body = body.Replace("{BOOK.NAME}", bookName);
            body = body.Replace("{BOOK.ID}", bookId.ToString());

            var message = new Message(new List<string>() { userAddress },
                "Book crossing book receive confirmation!", body);

            await SendAsync(CreateEmailMessage(message));
        }
        /// <inheritdoc />
        public async Task SendThatBookWasReceivedAsync(RequestMessage requestMessage)
        {
            string body = string.Empty;
            using (StreamReader reader =
                new StreamReader(Path.Combine(_env.ContentRootPath, "Templates", "RequestReceived.html")))
            {
                body = await reader.ReadToEndAsync();
            }

            body = body.Replace("{OWNER.NAME}", requestMessage.OwnerName);
            body = body.Replace("{REQUEST.ID}", Convert.ToString(requestMessage.RequestId));
            body = body.Replace("{BOOK.NAME}", requestMessage.BookName);

            var message = new Message(new List<string>() { requestMessage.OwnerAddress.ToString() },
                $"Your book {requestMessage.BookName} was received!", body);

            await SendAsync(CreateEmailMessage(message));
        }
        /// <inheritdoc />
        public async Task SendForCanceledRequestAsync(RequestMessage requestMessage)
        {
            string body = string.Empty;
            using (StreamReader reader =
                new StreamReader(Path.Combine(_env.ContentRootPath, "Templates", "RequestCanceled.html")))
            {
                body = await reader.ReadToEndAsync();
            }

            body = body.Replace("{OWNER.NAME}", requestMessage.OwnerName);
            body = body.Replace("{REQUEST.ID}", Convert.ToString(requestMessage.RequestId));
            body = body.Replace("{BOOK.NAME}", requestMessage.BookName);

            var message = new Message(new List<string>() { requestMessage.OwnerAddress.ToString() },
                $"Request for {requestMessage.BookName} was canceled!", body);

            await SendAsync(CreateEmailMessage(message));
        }

        /// <inheritdoc />
        public async Task SendForRequestAsync(RequestMessage requestMessage)
        {
            string body = string.Empty;
            using (StreamReader reader =
                new StreamReader(Path.Combine(_env.ContentRootPath, "Templates", "RequestEmail.html")))
            {
                body = await reader.ReadToEndAsync();
            }

            body = body.Replace("{OWNER.NAME}", requestMessage.OwnerName);
            body = body.Replace("{USER.NAME}", requestMessage.UserName);
            body = body.Replace("{REQUEST.ID}", Convert.ToString(requestMessage.RequestId));
            body = body.Replace("{REQUEST.DATE}", requestMessage.RequestDate.ToString("MMMM dd, yyyy"));
            body = body.Replace("{BOOK.NAME}", requestMessage.BookName);

            var message = new Message(new List<string>() { requestMessage.OwnerAddress.ToString() },
                $"Request for {requestMessage.BookName}!", body);

            await SendAsync(CreateEmailMessage(message));
        }

        /// <inheritdoc />
        public async Task SendForPasswordResetAsync(string userName, string confirmNumber, string email)
        {
            string body = string.Empty;
            using (StreamReader reader =
                new StreamReader(Path.Combine(_env.ContentRootPath, "Templates", "ResetPassword.html")))
            {
                body = await reader.ReadToEndAsync();
            }

            body = body.Replace("{USER.NAME}", userName);
            body = body.Replace("{CONFIRM.NUMBER}", confirmNumber);
            body = body.Replace("{EMAIL}", email);

            var message = new Message(new List<string>() { email },
                "Book crossing password reset!", body);

            await SendAsync(CreateEmailMessage(message));
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Book Crossing",_emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content };

            return emailMessage;
        }

        private async Task SendAsync(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

                    await client.SendAsync(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception or both.
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}
