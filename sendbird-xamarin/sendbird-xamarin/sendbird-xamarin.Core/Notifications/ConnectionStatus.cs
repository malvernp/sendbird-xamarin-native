﻿// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: ConnectionStatus.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/06/27
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
namespace sendbirdxamarin.Core.Notifications
{
    public enum ConnectionStatus
    {

        OnReconnectFailed,
        OnReconnectStarted,
        OnReconnectSucceeded,
        OnConnectionSuccess,
        OnConnectionFailed

    }
}
