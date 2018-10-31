using System.Windows.Forms;
using Utility.Network.Users;

namespace Musics___Client.UI
{

    public partial class SignInControl : UserControl
    {
        public delegate void SignInHandler();
        public event SignInHandler SignInMatchedPassword;
        public event SignInHandler SignInUnmatchedPassword;

        public SignInControl()
        {
            InitializeComponent();
        }

        private void UIConfirmPassword_TextChanged(object sender, System.EventArgs e)
        {
            CryptedCredentials firstCredential = credentialControl.User;
            ICredentials confirmCredential = new UserCredentials(firstCredential.Login, UIConfirmPassword.Text);
            CryptedCredentials secondCredential = new User(confirmCredential);

            if (firstCredential.Equals(secondCredential))
                SignInMatchedPassword?.Invoke();
            else
                SignInUnmatchedPassword?.Invoke();
        }

        public CryptedCredentials NewCredentials => credentialControl.User;
    }
}
