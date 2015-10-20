using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI;
using Windows.UI.Xaml.Media;
using LuckyLotto.Model;
using LuckyLotto.MVVM;
using LuckyLotto.Helpers;
namespace LuckyLotto.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private int _numbers;
        private ObservableCollection<LuckyBall> _luckyBalls;
        private DelegateCommand _generateCommand;
        private Random _random;

        public MainViewModel()
        {
            _random = new Random();
            DrawLuckyNumbers();
        }

        private void DrawLuckyNumbers()
        {
            LuckyBalls = new ObservableCollection<LuckyBall>();

            for (int i = 0; i < Numbers; i++)
            {
                LuckyBalls.Add(new LuckyBall() { Number = _random.Next(0, 99), Color = new SolidColorBrush() { Color = _random.NextColor() } });
            }
        }

        public int Numbers
        {
            get
            {
                if (_numbers == 0)
                    Numbers = 6;
                return _numbers;
            }

            set { Set(ref _numbers, value); }
        }

        public ObservableCollection<LuckyBall> LuckyBalls
        {
            get
            {
                return _luckyBalls;
            }

            set { Set(ref _luckyBalls, value); }
        }

        public DelegateCommand GenerateCommand
        {
            get
            {
                if (_generateCommand == null)
                    _generateCommand = new DelegateCommand(DrawLuckyNumbers);
                return _generateCommand;
            }

            set { Set(ref _generateCommand, value); }
        }

    }
}
