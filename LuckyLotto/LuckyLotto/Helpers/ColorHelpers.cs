using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace LuckyLotto.Helpers
{
    public static class ColorHelpers
    {    
        public static Color NextColor(this Random random)
        {
            return Color.FromArgb(255, (byte) random.Next(0, 255), (byte) random.Next(0, 255),
                (byte) random.Next(0, 255));
        }
    }
}
