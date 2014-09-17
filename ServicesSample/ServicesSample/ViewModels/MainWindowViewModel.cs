using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServicesSample.Services;

namespace ServicesSample.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }

            set
            {
                if (_message != value)
                {
                    _message = value;
                    RaisePropertyChanged(() => Message);
                }
            }
        }

        #region Constructor
        public MainWindowViewModel()
        {
            InitializeServices();

            _timer.RunServiceAsync();//todo on command
        }

        #endregion

        #region InitializeServices
        private void InitializeServices()
        {
            _timer = new TimerService();
            _timer.SleepTime = 1000;//1s
            _timer.Tick += _timer_Tick;
        }

        void _timer_Tick(object sender, int tick)
        {
            Message = string.Format("Tick #{0}", tick);
        }
        #endregion

        #region Members
        private TimerService _timer;
        #endregion
    }
}
