using System.Diagnostics.Contracts;
using System.IO;

namespace Imkashi.Extensions {

    public static class FileSystemInfoExtensions {

        /// <summary>
        /// ファイルサイズ、又はディレクトリ内のファイルサイズの総和を返します。
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="searchPattern"></param>
        /// <param name="searchOption"></param>
        /// <returns></returns>
        public static long ComputeLength(this FileSystemInfo fs, string searchPattern = "*", SearchOption searchOption = SearchOption.AllDirectories) {
            Contract.Requires(fs != null);
            Contract.Requires(fs is FileInfo || fs is DirectoryInfo);
            Contract.Ensures(Contract.Result<long>() >= 0);

            var file = fs as FileInfo;
            if (file != null) {
                return file.Length;
            }
            else {
                return ComputeLength((DirectoryInfo)fs, searchPattern, searchOption);
            }
        }
    }
}