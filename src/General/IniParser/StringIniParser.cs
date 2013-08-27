using System;
using General.IniParser.Model;
using General.IniParser.Parser;

namespace General.IniParser
{
    /// <summary>
    ///     Represents an INI data parser for strings.
    ///     
    /// </summary>
    /// <remarks>
    ///     This class is deprecated and kept for backwards compatibility.
    ///     It's just a wrapper around <see cref="IniDataParser"/> class.
    ///     Please, replace your code.
    /// </remarks>
    [Obsolete("Use class IniDataParser instead. See remarks comments in this class.")]
    public class StringIniParser
    {
        /// <summary>
        ///     This instance will handle ini data parsing and writing
        /// </summary>
        public IniDataParser Parser { get; protected set; }

        /// <summary>
        ///     Ctor
        /// </summary>
        public StringIniParser() : this (new IniDataParser()) {}

        /// <summary>
        ///     Ctor
        /// </summary>
        /// <param Name="parser"></param>
        public StringIniParser(IniDataParser parser)
        {
            Parser = parser;
        }

        /// <summary>
        /// Parses a string containing data formatted as an INI file.
        /// </summary>
        /// <param Name="dataStr">The string containing the data.</param>
        /// <returns>
        /// A new <see cref="IniData"/> instance with the data parsed from the string.
        /// </returns>
        public IniData ParseString(string dataStr)
        {
            return Parser.Parse(dataStr);
        }

        /// <summary>
        /// Creates a string from the INI data.
        /// </summary>
        /// <param Name="iniData">An <see cref="IniData"/> instance.</param>
        /// <returns>
        /// A formatted string with the contents of the
        /// <see cref="IniData"/> instance object.
        /// </returns>
        public string WriteString(IniData iniData)
        {
            return iniData.ToString();
        }
    }
}
