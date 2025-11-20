namespace PMS.Entity.Validation
{
    public static class ValidationMessage
    {
        public const string required = "{0} is required.";
        public const string maxLength = "{0} must be {1} characters or fewer.";
        public const string minLength = "{0} must be at least {1} characters.";
        public const string range = "{0} must be between {1} and {2}.";
        public const string unique = "{0} must be unique.";
    }
}
