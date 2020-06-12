namespace LSSD.Registration.Extensions 
{
    public static class BoolExtensions
    {
        public static string ToYesOrNo(this bool input) {
            return input ? "Yes" : "No";
        }

        public static string ToYesOrNothing(this bool input) {
            return input ? "Yes" : string.Empty;
        }

        public static string ToYesOrDash(this bool input) {
            return input ? "Yes" : "-";
        }
    }
}