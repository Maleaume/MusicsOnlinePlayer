using System;
using Utility.Network.Users;

namespace Utility.Network.Dialog.Edits
{
    [Serializable]
    public class EditUser : Packet
    {
        [Obsolete]
        public string UIDOld { get; set; }
        public CryptedCredentials OldCredentials { get; }
        public CryptedCredentials NewCredentials { get; }

        [Obsolete]
        public User NewUser { get; set; }

        [Obsolete]
        public EditUser(string UserIdOld, User Newuser)
        {
            UIDOld = UserIdOld;
            NewUser = Newuser;
        }

        public EditUser(CryptedCredentials oldCredentials, CryptedCredentials newCredentials)
        {
            OldCredentials = oldCredentials;
            NewCredentials = newCredentials;
        }
    }
}
