using ControlLibrary.Network;
using Musics___Client.API.Events;
using System;
using Utility.Network.Dialog.Edits;
using Utility.Network.Users;

namespace Musics___Client.API
{
    public class EditAccountServices
    {
        static private readonly Lazy<EditAccountServices> instance = new Lazy<EditAccountServices>(() => new EditAccountServices());
        static public EditAccountServices Instance { get => instance.Value; }

        private EditAccountServices()
        {
            NetworkClient.Packetreceived += NetworkClient_Packetreceived;
        }

        public event EventHandler<EditAccountReportEventArgs> EditAccountReport;
        protected virtual void OnEditAccountReport(EditAccountReportEventArgs e) => EditAccountReport?.Invoke(this, e);

        private void NetworkClient_Packetreceived(object sender, PacketEventArgs a)
        {
            if(a.Packet is EditUserReport)
            {
                var editUserReport = a.Packet as EditUserReport;
                OnEditAccountReport(new EditAccountReportEventArgs(editUserReport.NewUser, editUserReport.IsApproved));            
            }
        }

        public void EditUser(CryptedCredentials oldCredentials, CryptedCredentials newCredentials) 
            => NetworkClient.SendObject(new EditUser(oldCredentials, newCredentials));
    }
}
