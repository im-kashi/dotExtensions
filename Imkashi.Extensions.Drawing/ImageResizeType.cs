namespace Imkashi.Extensions {

    /// <summary>
    /// 画像のリサイズタイプを示す列挙型。
    /// </summary>
    public enum ImageResizeType {

        /// <summary>
        /// 指定した矩形にリサイズする事を示します。
        /// </summary>
        Absolute,

        /// <summary>
        /// 指定した矩形に対して、内接リサイズを行う事を示します。
        /// </summary>
        Contain,

        /// <summary>
        /// 指定した矩形に対して、外接リサイズを行う事を示します。
        /// </summary>
        Cover,
    }
}