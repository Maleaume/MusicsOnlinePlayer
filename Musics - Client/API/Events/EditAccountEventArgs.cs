using System;
using Utility.Network.Users;

namespace Musics___Client.API.Events
{
    public class EditAccountEventArgs : EventArgs
    { 
        public CryptedCredentials NewCredentials { get; }

        public EditAccountEventArgs(CryptedCredentials newCredentials)
        {
            NewCredentials = newCredentials; 
        }
    }
}
