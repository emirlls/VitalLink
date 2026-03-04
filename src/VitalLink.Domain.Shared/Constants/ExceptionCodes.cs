namespace VitalLink.Constants;

public static class ExceptionCodes
{
    private const string ExceptionCodePrefix = "VitalLink:ExceptionCodes:";
    public const string UnexpectedException = $"{ExceptionCodePrefix}UnexpectedException:001";
    public const string Success = $"{ExceptionCodePrefix}Success:001";
    
    public static class BloodRequests
    {
        private const string Prefix = $"{ExceptionCodePrefix}{nameof(BloodRequests)}:";
        public const string NotFound = $"{Prefix}:001";
        public const string AlreadyExists = $"{Prefix}:001";
    }

    public static class BloodTypes
    {
        private const string Prefix = $"{ExceptionCodePrefix}{nameof(BloodTypes)}:";
        public const string NotFound = $"{Prefix}:001";
        public const string AlreadyExists = $"{Prefix}:001";
    }
    
    public static class IdentityUser
    {
        private const string Prefix = $"{ExceptionCodePrefix}IdentityUser:";
        public const string NotFound = $"{Prefix}001";
        public const string AlreadyExists = $"{Prefix}002";
        public const string CannotLoginIfMailNotConfirmed = $"{Prefix}003";
        public const string MailInUsed = $"{Prefix}004";
        public const string MailIsInvalid = $"{Prefix}005";
        public const string UsernameInUsed = $"{Prefix}006";
    }
    public static class NotificationTemplate
    {
        private const string Prefix = $"{ExceptionCodePrefix}NotificationTemplate:";
        public const string NotFound = $"{Prefix}001";
        public const string AlreadyExists = $"{Prefix}002";
    }
    
    public static class NotificationEventType
    {
        private const string Prefix = $"{ExceptionCodePrefix}NotificationEventType:";
        public const string NotFound = $"{Prefix}001";
        public const string AlreadyExists = $"{Prefix}002";
    }
    public static class Mail
    {
        private const string Prefix = $"{ExceptionCodePrefix}Mail:";
        public const string SettingNotFound = $"{Prefix}001";
    }
    
    public static class ChatMessage
    {
        private const string Prefix = $"{ExceptionCodePrefix}ChatMessage:";
        public const string NotFound = $"{Prefix}001";
        public const string AlreadyExists = $"{Prefix}002";
    }
    public static class UserProfile
    {
        private const string Prefix = $"{ExceptionCodePrefix}UserProfile:";
        public const string NotFound = $"{Prefix}001";
        public const string AlreadyExists = $"{Prefix}002";
    }
    public static class BloodRequestDonors
    {
        private const string Prefix = $"{ExceptionCodePrefix}BloodRequestDonors:";
        public const string NotFound = $"{Prefix}001";
        public const string AlreadyExists = $"{Prefix}002";
    }
}