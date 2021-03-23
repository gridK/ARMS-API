namespace AURoomAPI.Models
{
    public class Path
    {
        public const string BaseUrl = "https://arms-969f7.firebaseio.com/";
        private const string Assigning = "assigning/";
        private const string Dissolving = "dissolving/";
        
        public static readonly string IsUpdating = $"{Assigning}isUpdating";
        public static readonly string IsError = $"{Assigning}isError";
        public static readonly string IsProcessing = $"{Assigning}isProcessing";
        public static readonly string IsComputing = $"{Assigning}isComputing";
        public static readonly string IsRetrieving = $"{Assigning}isRetrieving";
        public static readonly string ErrorMessage = $"{Assigning}errorMessage";
        public static readonly string IsAutomate = $"{Assigning}isAutomate";

        public static readonly string IsDissolving = $"{Dissolving}isDissolving";
    }
}