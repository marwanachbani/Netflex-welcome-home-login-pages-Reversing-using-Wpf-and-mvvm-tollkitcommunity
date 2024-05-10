using CommunityToolkit.Mvvm.ComponentModel;
using DeskUI.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskUI.Core
{
    public abstract class BaseViewModel : ObservableRecipient
    {
        public BaseViewModel(Theme theme)
        {
            Theme = theme;
        }
        public Theme Theme { get; set; }
    }
}
