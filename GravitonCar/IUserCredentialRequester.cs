using GravitonCarLibrary.Models;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;

namespace GravitonCar
{
    public interface IUserCredentialRequester
    {
        void UserCredentials(bool isChanged, UserModel user, PackIcon icon);
    }
}
