namespace DoFest.Business.Errors
{
    public static class ErrorsList
    {
        public static Error UserNotFound => new Error("user.not.found","User doesn't exists!");
        public static Error InvalidPassword => new Error("password.invalid","Password is incorrect!");
        public static Error EmailExists => new Error("email.exists","An user with this email already exits!");
        public static Error UsernameExists => new Error("username.exists", "An user with this username already exits!");
        public static Error InvalidUserType => new Error("user.type.invalid", "Undefined user type!");
        public static Error InvalidCity => new Error("city.invalid", "Selected city doesn't exists!");
        public static Error SamePassword => new Error("same.password","New password must be different from the old one.");
        public static Error ExistingCity => new Error("existing.city", "City already exits!");
        public static Error UnavailableActivity => new Error("activity.not.exists","Activity doesn't exists!");
        public static Error ActivityExists => new Error("activity.exists", "Activity already exists!");
    }
}