using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;

namespace Imkashi.Extensions {

    public static class FileInfoExtensions {

        /// <summary>
        /// ファイルの各行を読み取ります。全ての行を読み取った後、ファイルを閉じます。
        /// </summary>
        /// <param name="file"></param>
        /// <param name="encoding">ファイルの読み取りエンコーディング。null の場合は UTF-8 が使用される。</param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static IEnumerable<string> ReadLines(this FileInfo file, Encoding encoding = null) {
            if (file == null) throw new ArgumentNullException(nameof(file));
            Contract.Requires(string.IsNullOrEmpty(file.FullName) == false);
            Contract.Ensures(Contract.Result<IEnumerable<string>>() != null);

            var lines = File.ReadLines(file.FullName, encoding ?? Encoding.UTF8);
            Contract.Assume(lines != null);
            return lines;
        }

        /// <summary>
        ///ファイルを開き、全ての内容を読み取った後、ファイルを閉じます。
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static byte[] ReadAllBytes(this FileInfo file) {
            if (file == null) throw new ArgumentNullException(nameof(file));
            Contract.Requires(string.IsNullOrEmpty(file.FullName) == false);
            Contract.Ensures(Contract.Result<byte[]>() != null);

            return File.ReadAllBytes(file.FullName);
        }

        /// <summary>
        /// テキストファイルを開き、ファイルの全ての行を読み取った後、ファイルを閉じます。
        /// </summary>
        /// <param name="file"></param>
        /// <param name="encoding">ファイルの読み取りエンコーディング。null の場合は UTF-8 が使用される。</param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static string[] ReadAllLines(this FileInfo file, Encoding encoding = null) {
            if (file == null) throw new ArgumentNullException(nameof(file));
            Contract.Requires(string.IsNullOrEmpty(file.FullName) == false);
            Contract.Ensures(Contract.Result<string[]>() != null);

            return File.ReadAllLines(file.FullName, encoding ?? Encoding.UTF8);
        }

        /// <summary>
        /// テキストファイルを開き、全ての内容を読み取った後、ファイルを閉じます。
        /// </summary>
        /// <param name="file"></param>
        /// <param name="encoding">ファイルの読み取りエンコーディング。null の場合は UTF-8 が使用される。</param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static string ReadAllText(this FileInfo file, Encoding encoding = null) {
            if (file == null) throw new ArgumentNullException(nameof(file));
            Contract.Requires(string.IsNullOrEmpty(file.FullName) == false);
            Contract.Ensures(Contract.Result<string>() != null);

            return File.ReadAllText(file.FullName, encoding ?? Encoding.UTF8);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="file"></param>
        /// <param name="binary"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static void WriteAllBytes(this FileInfo file, byte[] binary) {
            if (file == null) throw new ArgumentNullException(nameof(file));
            Contract.EndContractBlock();

            File.WriteAllBytes(file.FullName, binary);
        }

        /// <summary>
        /// 新しいファイルを作成し、文字列のコレクションをそのファイルに書き込んだ後、そのファイルを閉じます。
        /// </summary>
        /// <param name="file"></param>
        /// <param name="contents"></param>
        /// <param name="encoding">使用する文字エンコーディング。null の場合は UTF-8 が使用される。</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static void WriteAllLines(this FileInfo file, IEnumerable<string> contents, Encoding encoding = null) {
            if (file == null) throw new ArgumentNullException(nameof(file));
            Contract.EndContractBlock();

            File.WriteAllLines(file.FullName, contents, encoding ?? Encoding.UTF8);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="file"></param>
        /// <param name="contents"></param>
        /// <param name="encoding">使用する文字エンコーディング。null の場合は UTF-8 が使用される。</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static void WriteAllText(this FileInfo file, string contents, Encoding encoding = null) {
            if (file == null) throw new ArgumentNullException(nameof(file));
            Contract.EndContractBlock();

            File.WriteAllText(file.FullName, contents, encoding);
        }

        /// <summary>
        /// ファイルサイズを 0 に切り詰めます。
        /// </summary>
        /// <param name="file"></param>
        public static void Truncate(this FileInfo file) {
            if (file == null) throw new ArgumentNullException(nameof(file));
            Contract.EndContractBlock();

            using (var stream = file.OpenWrite()) {
                stream.SetLength(0);
            }
        }
    }
}