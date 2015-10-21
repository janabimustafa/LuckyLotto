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
        private bool _isBusy;

        public MainViewModel()
        {
            _random = new Random();
            DrawLuckyNumbers();
        }

        private bool CanDraw()
        {
            return Numbers > 0;
        }

        private async Task<ObservableCollection<LuckyBall>> GenerateListAsync()
        {
            var list = await Task<List<LuckyBall>>.Factory.StartNew(() =>
            {
                var luckyList = new List<LuckyBall>();
                for (var i = 0; i < Numbers; i++)
                {
                    luckyList.Add(new LuckyBall() { Number = _random.Next(0, 99), Color = _random.NextColor() });
                }
                return luckyList;
            });
            return new ObservableCollection<LuckyBall>(list);
        }

        private async void DrawLuckyNumbers()
        {
            IsBusy = true;
            LuckyBalls = await GenerateListAsync();
            IsBusy = false;
        }

        public int Numbers
        {
            get
            {
                if (_numbers == 0)
                    Numbers = 6;
                return _numbers;
            }

            set
            {
                Set(ref _numbers, value);
                GenerateCommand.RaiseCanExecuteChanged();
            }
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
                    _generateCommand = new DelegateCommand(DrawLuckyNumbers, CanDraw);
                return _generateCommand;
            }

            set { Set(ref _generateCommand, value); }
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                Set(ref _isBusy, value);
            }
        }
    }
}
