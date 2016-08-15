using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Imkashi.Extensions {

    public static class ImageExtensions {

        /// <summary>
        /// 画像をリサイズします。
        /// </summary>
        /// <param name="image"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="resizeType"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static Image Resize(this Image image, int width, int height, ImageResizeType resizeType, GraphicsOptions options = null) {
            if (image == null) throw new ArgumentNullException(nameof(image));
            if (width < 0) throw new ArgumentOutOfRangeException(nameof(width), width, null);
            if (height < 0) throw new ArgumentOutOfRangeException(nameof(height), height, null);
            Contract.Ensures(Contract.Result<Image>() != null);

            switch (resizeType) {
                case ImageResizeType.Absolute:
                    return new ImageResizer(image, options).Resize(width, height);

                case ImageResizeType.Contain:
                    return new ImageContainResizer(image, options).Resize(width, height);

                case ImageResizeType.Cover:
                    return new ImageCoverResizer(image, options).Resize(width, height);

                default:
                    throw new ArgumentOutOfRangeException(nameof(resizeType), resizeType, null);
            }
        }

        #region SaveJpeg

        /// <summary>
        /// 圧縮レベルを指定して 画像を JPEG 形式で保存します。
        /// </summary>
        /// <param name="image"></param>
        /// <param name="fileName"></param>
        /// <param name="quality"></param>
        public static void SaveJpeg(this Image image, string fileName, int quality) {
            if (image == null) throw new ArgumentNullException(nameof(image));
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));
            if (quality < 0 || quality > 100) throw new ArgumentOutOfRangeException(nameof(quality), quality, null);
            Contract.EndContractBlock();

            // JPEG 形式で保存
            image.SaveJpeg((img, encoder, encodeParams) => {
                img.Save(fileName, encoder, encodeParams);
            }, quality);
        }

        /// <summary>
        /// 圧縮レベルを指定して 画像を JPEG 形式で保存します。
        /// </summary>
        /// <param name="image"></param>
        /// <param name="stream"></param>
        /// <param name="quality"></param>
        public static void SaveJpeg(this Image image, Stream stream, int quality) {
            if (image == null) throw new ArgumentNullException(nameof(image));
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (quality < 0 || quality > 100) throw new ArgumentOutOfRangeException(nameof(quality), quality, null);
            Contract.EndContractBlock();

            // JPEG 形式で保存
            image.SaveJpeg((img, encoder, encodeParams) => {
                img.Save(stream, encoder, encodeParams);
            }, quality);
        }

        private static void SaveJpeg(this Image image, Action<Image, ImageCodecInfo, EncoderParameters> saver, long quality) {
            Contract.Requires(image != null);
            Contract.Requires(saver != null);
            Contract.Requires(quality >= 0 && quality <= 100);

            // JPEG のコーデック情報を走査
            ImageCodecInfo encoder = ImageFormat.Jpeg.FindEncoder();
            if (encoder == null) throw new InvalidOperationException("JPEG encoder is not found.");

            using (var encodeParams = new EncoderParameters()) {
                encodeParams.Param = new[] {
                    // 品質のパラメータを設定する
                    new EncoderParameter(Encoder.Quality, quality),
                };

                // エンコード
                saver(image, encoder, encodeParams);
            }
        }

        #endregion SaveJpeg

        #region FindEncoder / Decoder

        /// <summary>
        /// 指定した画像フォーマットのエンコーダーを返します。
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static ImageCodecInfo FindEncoder(this ImageFormat format) {
            if (format == null) throw new ArgumentNullException(nameof(format));
            Contract.EndContractBlock();

            var encoders = ImageCodecInfo.GetImageEncoders();
            Contract.Assume(encoders != null);

            return encoders.FindCodecByFormat(format);
        }

        /// <summary>
        /// 指定した画像フォーマットのデコーダーを返します。
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static ImageCodecInfo FindDecoder(this ImageFormat format) {
            if (format == null) throw new ArgumentNullException(nameof(format));
            Contract.EndContractBlock();

            var decoders = ImageCodecInfo.GetImageDecoders();
            Contract.Assume(decoders != null);

            return decoders.FindCodecByFormat(format);
        }

        private static ImageCodecInfo FindCodecByFormat(this IEnumerable<ImageCodecInfo> codecs, ImageFormat format) {
            Contract.Requires(codecs != null);
            Contract.Requires(format != null);

            var formatGuid = format.Guid;

            foreach (var codec in codecs) {
                Contract.Assume(codec != null);

                if (codec.FormatID == formatGuid) {
                    return codec;
                }
            }
            return null;
        }

        #endregion FindEncoder / Decoder

        #region FindMimeType

        /// <summary>
        /// 画像の MimeType を取得します。
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static string FindMimeType(this Image image) {
            if (image == null) throw new ArgumentNullException(nameof(image));
            Contract.EndContractBlock();

            return image.RawFormat.FindMimeType();
        }

        /// <summary>
        /// 画像フォーマットの MimeType を取得します。
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string FindMimeType(this ImageFormat format) {
            if (format == null) throw new ArgumentNullException(nameof(format));
            Contract.EndContractBlock();

            ImageCodecInfo codec = format.FindDecoder();
            return codec?.MimeType;
        }

        #endregion FindMimeType
    }
}