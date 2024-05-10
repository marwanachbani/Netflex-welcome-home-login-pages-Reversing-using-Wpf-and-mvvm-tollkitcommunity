using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskUI.Styles
{
    public  class Theme
    {
        public Theme(string backgroundColor1, string backgroundColor2, string forecolor1, string forecolor2, string themeName)
        {
            BackgroundColor1 = backgroundColor1;
            BackgroundColor2 = backgroundColor2;
            Forecolor1 = forecolor1;
            Forecolor2 = forecolor2;
            ThemeName = themeName;
        }
        public string ThemeName { get; set; }
        public string BackgroundColor1 { get; set; }
        public string BackgroundColor2 { get; set; }
        
        public string Forecolor1 { get; set; }
        public string Forecolor2 { get; set; }
        
        
    }
}
