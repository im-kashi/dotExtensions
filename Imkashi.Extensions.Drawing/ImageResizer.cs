using System;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Imaging;

namespace Imkashi.Extensions {

    /// <summary>
    /// 画像を指定した矩形にリサイズするクラス。
    /// </summary>
    public class ImageResizer {

        public ImageResizer(Image image, GraphicsOptions options = null) {
            if (image == null) throw new ArgumentNullException(nameof(image));
            Contract.EndContractBlock();

            Image = image;
            Options = options;
        }

        public Image Image { get; }

        public GraphicsOptions Options { get; set; }

        /// <summary>
        /// 画像をリサイズします。
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public virtual Image Resize(int width, int height) {
            if (width < 0) throw new ArgumentOutOfRangeException(nameof(width), width, null);
            if (height < 0) throw new ArgumentOutOfRangeException(nameof(height), height, null);
            Contract.Ensures(Contract.Result<Image>() != null);

            using (var bmp = new Bitmap(width, height)) {
                Contract.Assume((bmp.PixelFormat & PixelFormat.Indexed) == 0);

                using (var g = Graphics.FromImage(bmp)) {
                    Options?.Apply(g);

                    g.DrawImage(Image, 0, 0, bmp.Width, bmp.Height);
                }
                return bmp;
            }
        }
    }

    /// <summary>
    /// 指定した矩形に対して、画像の内接リサイズを行うクラス。
    /// </summary>
    public class ImageContainResizer : ImageResizer {

        public ImageContainResizer(Image image, GraphicsOptions options = null) : base(image, options) {
            Contract.Requires(image != null);
        }

        public override Image Resize(int width, int height) {
            if (width < 0) throw new ArgumentOutOfRangeException(nameof(width), width, null);
            if (height < 0) throw new ArgumentOutOfRangeException(nameof(height), height, null);
            Contract.Ensures(Contract.Result<Image>() != null);

            int imgWidth = Image.Width;
            int imgHeight = Image.Height;

            // 長い方の辺が基準となるよう、リサイズスケールを算出。
            double scale;
            if (imgWidth > imgHeight) {
                scale = (double)width / imgWidth;
            }
            else {
                scale = (double)height / imgHeight;
            }
            //// 拡大リサイズは行わない
            //if (scale >= 1) return Image;

            // リサイズ処理
            int newWidth = (int)(imgWidth * scale);
            int newHeight = (int)(imgHeight * scale);
            return base.Resize(newWidth, newHeight);
        }
    }

    /// <summary>
    /// 指定した矩形に対して、画像の外接リサイズを行うクラス。
    /// </summary>
    public class ImageCoverResizer : ImageResizer {

        public ImageCoverResizer(Image image, GraphicsOptions options = null) : base(image, options) {
            Contract.Requires(image != null);
        }

        public override Image Resize(int width, int height) {
            if (width < 0) throw new ArgumentOutOfRangeException(nameof(width), width, null);
            if (height < 0) throw new ArgumentOutOfRangeException(nameof(height), height, null);
            Contract.Ensures(Contract.Result<Image>() != null);

            int imgWidth = Image.Width;
            int imgHeight = Image.Height;

            // 短い方の辺が基準となるよう、リサイズスケールを算出。
            double scale;
            if (imgWidth < imgHeight) {
                scale = (double)width / imgWidth;
            }
            else {
                scale = (double)height / imgHeight;
            }

            // リサイズ処理
            int newWidth = (int)(imgWidth * scale);
            int newHeight = (int)(imgHeight * scale);
            return base.Resize(newWidth, newHeight);
        }
    }
}