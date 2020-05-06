namespace ES.WineShop.Common.Extenions
{
    public static class StringExtensions
    {
        public static TEnum ToEnum<TEnum>(this string value, bool ignoreCase)
            where TEnum : struct
        {
            System.Enum.TryParse(value, true, out TEnum result);

            return result;
        }
    }
}
