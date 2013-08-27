namespace General.IniParser.Helpers
{
    internal static class Assert
    {
        /// <summary>
        /// Asserts that a strings has no blank spaces.
        /// </summary>
        /// <param Name="s">The string to be checked.</param>
        /// <returns></returns>
        internal static bool StringHasNoBlankSpaces(string s)
        {
            return !s.Contains(" ");
        }
    }

}
