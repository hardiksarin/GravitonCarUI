 using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;

namespace GravitonCar
{
    public interface IAdminPasswordRequester
    {
        void GetAdminPassword(string enteredPassword, PackIcon icon);
    }
}
