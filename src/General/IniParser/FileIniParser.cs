using System;
using System.IO;
using System.Text;
using General.IniParser.Exceptions;
using General.IniParser.Model;

namespace General.IniParser
{
    /// <summary>
    /// Represents an INI data parser for files.
    /// </summary>
    public class FileIniDataParser : StreamIniDataParser
    {
        #region Deprecated methods

        [Obsolete("Please, use ReadFile method instead of this one as is more semantically accurate")]
        public IniData LoadFile(string fileName)
        {
            return ReadFile(fileName);
        }

        [Obsolete("Please, use ReadFile method instead of this one as is more semantically accurate")]
        public IniData LoadFile(string fileName, System.Text.Encoding fileEncoding)
        {
            return ReadFile(fileName, fileEncoding);
        }
        #endregion

        /// <summary>
        ///     Implements reading ini data from a file.
        /// </summary>
        /// <remarks>
        ///     Uses <see cref="Encoding.Default"/> codification for the file.
        /// </remarks>
        /// <param Name="fileName">
        ///     Name of the file.
        /// </param>
        public IniData ReadFile(string fileName)
        {
            return ReadFile(fileName, System.Text.Encoding.Default);
        }

        /// <summary>
        ///     Implements reading ini data from a file.
        /// </summary>
        /// <param Name="fileName">
        ///     Name of the file.
        /// </param>
        /// <param Name="fileEncoding">
        ///     File's encoding.
        /// </param>
        public IniData ReadFile(string fileName, System.Text.Encoding fileEncoding)
        {
            if (fileName == string.Empty)
                throw new ArgumentException("Bad filename.");

            try
            {
                using (FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs, fileEncoding))
                    {
                        return ReadData(sr);
                    }
                }
            }
            catch (IOException ex)
            {
                throw new ParsingException(String.Format("Could not parse file {0}", fileName), ex);
            }

        }

        /// <summary>
        ///     Saves INI data to a file.
        /// </summary>
        /// <remarks>
        ///     Creats an ASCII encoded file by default.
        /// </remarks>
        /// <param Name="fileName">
        ///     Name of the file.
        /// </param>
        /// <param Name="parsedData">
        ///     IniData to be saved as an INI file.
        /// </param>
        public void SaveFile(string fileName, IniData parsedData)
        {
            SaveFile(fileName, parsedData, System.Text.Encoding.ASCII);
        }
                             
        /// <summary>
        ///     Saves INI data to a file.
        /// </summary>
        /// <param Name="fileName">
        ///     Name of the file.
        /// </param>
        /// <param Name="parsedData">
        ///     IniData to be saved as an INI file.
        /// </param>
        /// <param Name="fileEncoding">
        ///     Specifies the encoding used to create the file.
        /// </param>
        public void SaveFile(string fileName, IniData parsedData, System.Text.Encoding fileEncoding)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("Bad filename.");

            if (parsedData == null)
                throw new ArgumentNullException("parsedData");

            using (FileStream fs = File.Open(fileName, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sr = new StreamWriter(fs, fileEncoding))
                {
                    WriteData(sr, parsedData);
                }
            }
        }
    }
}
