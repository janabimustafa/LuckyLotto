using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;
using LuckyLotto.MVVM;

namespace LuckyLotto.Model
{
    public class LuckyBall
    {
        public int Number { get; set; }
        public Color Color { get; set; }
        public SolidColorBrush BackgroundBrush => new SolidColorBrush(Color);
    }
}
