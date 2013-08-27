using System;
using System.IO;
using General.IniParser.Model;
using General.IniParser.Parser;

namespace General.IniParser
{

    /// <summary>
    ///     Represents an INI data parser for streams.
    /// </summary>
    public class StreamIniDataParser
    {
        /// <summary>
        ///     This instance will handle ini data parsing and writing
        /// </summary>
        public IniDataParser Parser { get; protected set; }

        /// <summary>
        ///     Ctor
        /// </summary>
        public StreamIniDataParser() : this (new IniDataParser()) {}

        /// <summary>
        ///     Ctor
        /// </summary>
        /// <param Name="parser"></param>
        public StreamIniDataParser(IniDataParser parser)
        {
            Parser = parser;
        }
        #region Public Methods

        /// <summary>
        /// Reads data in INI format from a stream.
        /// </summary>
        /// <param Name="reader">Reader stream.</param>
        /// <returns>
        ///     And <see cref="IniData"/> instance with the readed ini data parsed.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref Name="reader"/> is <c>null</c>.
        /// </exception>
        public IniData ReadData(StreamReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException("reader");
            
            return Parser.Parse(reader.ReadToEnd());
        }

        /// <summary>
        ///     Writes the ini data to a stream.
        /// </summary>
        /// <param Name="writer">A write stream where the ini data will be stored</param>
        /// <param Name="iniData">An <see cref="IniData"/> instance.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref Name="writer"/> is <c>null</c>.
        /// </exception>
        public void WriteData(StreamWriter writer, IniData iniData)
        {
            if (writer == null)
                throw new ArgumentNullException("reader");

            writer.Write(iniData.ToString());
        }

        #endregion
    }
}
