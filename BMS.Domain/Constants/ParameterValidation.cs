namespace BMS.Domain.Constants
{
    public static class ParameterValidation
    {
        public const string InvalidBookCategoryName = "please enter BookCategory name.";
        public const string InvalidBookCategoryNameLength = "BookCategory name cannot exceed 50 characters.";

        public const string InvalidBookName = "please enter Book name.";
        public const string InvalidCopiesAvailable = "Available copies for the book should be at least 3.";
        public const string InvalidAuthorName = "Author name cannot be empty.";
        public const string InvalidCategoryId = "Category ID cannot be empty.";

    }
}
