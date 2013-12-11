using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Stufkan.IO
{
    /// <summary>
    /// Contains methods to measure graphics elements
    /// </summary>
    public static class Measure
    {
        /// <summary>
        /// Measures a string by measuring each character independently
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static RectangleF MeasureString(this Graphics graphics, Font font, string text)
        {
            StringFormat format = new StringFormat();
            format.SetMeasurableCharacterRanges(new CharacterRange[]{
        new CharacterRange(0,text.Length)});

            return graphics.MeasureCharacterRanges(text, font, new RectangleF(0, 0, 1000, 1000), format)[0].GetBounds(graphics);
        }
    }
}
