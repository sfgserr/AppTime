
namespace AppTime.Helpers
{
    public static class ConvertIntToTimeFormatHelper
    {
        public static string ConvertIntToTimeFormat(this int seconds)
        {
            int hours = seconds / 3600;
            seconds %= 3600;

            int minutes = seconds / 60;
            seconds %= 60;

            return $"{hours}hr {minutes}min {seconds}sec";
        }
    }
}
