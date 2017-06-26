using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace SGPET.ViewModel
{
    public class ToolBarViewModel
    {
        public ToolBarViewModel()
        {
            HomeCmd = new RelayCommand<object>(ExecuteHomeCmd, null);
        }

        public ICommand HomeCmd { get; internal set; }
    

            

        public void ExecuteHomeCmd(object parameter)
        {

        }
    }
}

