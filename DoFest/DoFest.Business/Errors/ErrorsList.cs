namespace DoFest.Business.Errors
{
    public static class ErrorsList
    {
        public static Error UserNotFound => new Error("user.not.found","User doesn't exist!");
        public static Error InvalidPassword => new Error("password.invalid","Password is incorrect!");
        public static Error EmailExists => new Error("email.exists","An user with this email already exists!");
        public static Error UsernameExists => new Error("username.exists", "An user with this username already exists!");
        public static Error InvalidUserType => new Error("user.type.invalid", "Undefined user type!");
        public static Error InvalidCity => new Error("city.invalid", "Selected city doesn't exist!");
        public static Error SamePassword => new Error("same.password","New password must be different from the old one.");
        public static Error ExistingCity => new Error("existing.city", "City already exists!");
        public static Error UnavailableActivity => new Error("activity.not.exists","Activity doesn't exist!");
        public static Error InvalidRating => new Error("rating.not.exists", "Rating doesn't exist!");
        public static Error InvalidPhoto => new Error("photo.not.exists", "Photo doesn't exist!");
        public static Error DeleteNotAuthorized => new Error("user.not.authorized", "An user can only delete his own content!");
        public static Error UpdateNotAuthorized => new Error("user.not.authorized", "An user can only update his own content!");

    }
}