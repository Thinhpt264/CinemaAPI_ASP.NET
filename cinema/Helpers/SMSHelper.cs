using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
namespace cinema.Helpers
{
    public  class SMSHelper
    {
        public  Boolean sendSMS(string body)
        {
            var accountSid = "ACdecc7b6a6b0c337e14739da10ac6c947";
            var authToken = "e89047358f7a7d4f5080ce76418a67ff";
            TwilioClient.Init(accountSid, authToken);
            var messageOptions = new CreateMessageOptions(
              new PhoneNumber("+18777804236"));
            messageOptions.From = new PhoneNumber("+19129376559");
            messageOptions.Body = body;
            var message = MessageResource.Create(messageOptions);
            Console.WriteLine(message.Body);
            return true;
        }
    }
}
