﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CalculationsLibrary
{
    public class TextDataAccess
    {
        public void SaveText(string filePath, List<string> lines, IWriteToText textWriter)
        {
            if (filePath.Length > 260)
            {
                throw new PathTooLongException("The path needs to be less than 261 characters long.");
            }

            string fileName = Path.GetFileName(filePath);

            textWriter.WriteToFile(fileName, lines);
        }
    }

    internal class WriteToText : IWriteToText
    {
        public void WriteToFile(string fileName, List<string> lines)
        {
            File.WriteAllLines(fileName, lines);
        }
        
    }

    public interface IWriteToText
    {
        void WriteToFile(string fileName, List<string> lines);
    }
}
