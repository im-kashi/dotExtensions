using System;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Imkashi.Extensions {

    public class GraphicsOptions {
        public InterpolationMode? InterpolationMode { get; set; }

        public void Apply(Graphics graphics) {
            if (graphics == null) throw new ArgumentNullException(nameof(graphics));
            Contract.EndContractBlock();

            if (InterpolationMode.HasValue) {
                graphics.InterpolationMode = InterpolationMode.Value;
            }
        }
    }
}