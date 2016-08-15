using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;

namespace Imkashi.Extensions {

    public static class DirectoryInfoExtensions {

        /// <summary>
        /// ディレクトリ内のファイルサイズの総和を返します。
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="searchPattern"></param>
        /// <param name="searchOption"></param>
        /// <returns></returns>
        public static long ComputeLength(this DirectoryInfo directory, string searchPattern = "*", SearchOption searchOption = SearchOption.AllDirectories) {
            if (directory == null) throw new ArgumentNullException(nameof(directory));
            Contract.Ensures(Contract.Result<long>() >= 0);

            var files = directory.EnumerateFiles(searchPattern, searchOption) ?? Enumerable.Empty<FileInfo>();

            long length = 0;
            foreach (var file in files) {
                if (file == null) continue;
                length += file.Length;
            }
            return length;
        }
    }
}