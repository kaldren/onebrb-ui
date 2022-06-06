using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.UI.Core.Auth
{
    internal class B2CConstants
    {
        public static string Tenant = "onebrb.onmicrosoft.com";
        public static string AzureADB2CHostname = "onebrb.b2clogin.com";
        public static string ClientID = "5807f21a-4429-4e21-84f2-0f7711d0c649";
        public static string PolicySignUpSignIn = "B2C_1_Client";
        public static string PolicyEditProfile = "b2c_1_edit_profile";
        public static string PolicyResetPassword = "b2c_1_reset";

        public static string[] Scopes = { "" };

        public static string AuthorityBase = $"https://{AzureADB2CHostname}/tfp/{Tenant}/";
        public static string AuthoritySignInSignUp = $"{AuthorityBase}{PolicySignUpSignIn}";
        public static string AuthorityEditProfile = $"{AuthorityBase}{PolicyEditProfile}";
        public static string AuthorityPasswordReset = $"{AuthorityBase}{PolicyResetPassword}";
        public static string IOSKeyChainGroup = "com.microsoft.adalcache";
    }
}
