using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_HT1.Models
{
    public static class MessageConstants
    {
        public const string RegisteredBody = "Hi {{FullName}}";
        public const string RegisteredSubject = "Welcome to our system!";

        public const string DeletedBody = "Dear {{FullName}}";
        public const string DeletedSubject = "We are sorry to inform you that your account has been deleted from our system. This action was taken because [reason for account deletion].";

        public const string SenderEmailAddress = "sultonbek.rakhimov.recovery@gmail.com";
    }
}
