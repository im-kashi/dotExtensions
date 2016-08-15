using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;

namespace Imkashi.Extensions {

    public static class TextReaderExtensions {

        /// <summary>
        /// ストリームの各行を読み取ります。
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static IEnumerable<string> ReadLines(this TextReader reader) {
            if (reader == null) throw new ArgumentNullException(nameof(reader));
            Contract.Ensures(Contract.Result<IEnumerable<string>>() != null);

            string line;
            while ((line = reader.ReadLine()) != null) {
                yield return line;
            }
        }
    }
}