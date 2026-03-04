namespace VitalLink.Constants;

public static class EventConstants
{
    public static class EventBus
    {
        public const string BloodRequestCreate = nameof(BloodRequestCreate);
        public const string MailConfirmation = nameof(MailConfirmation);
        public const string UserDelete = nameof(UserDelete);
        public const string UserRegister = nameof(UserRegister);
        public const string CreateUserProfile = nameof(CreateUserProfile);
        
    }

    public static class ServerSentEvents
    {
        public static class BloodRequestCreate
        {
            public const string BloodRequestCreateChannel = "blood-request-create";
            public const string Type = nameof(BloodRequestCreate);
        }
    }
}