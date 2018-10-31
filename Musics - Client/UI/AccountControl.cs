using Musics___Client.API.Events;
using System;
using System.Windows.Forms;
using Utility.Network.Users;

namespace Musics___Client.UI
{
    public partial class AccountControl : UserControl
    {
        public AccountControl()
        {
            InitializeComponent();
            signInControl.SignInMatchedPassword += SignInControl_SignInMatchedPassword;
            signInControl.SignInUnmatchedPassword += SignInControl_SignInUnmatchedPassword;
        }

        private void SignInControl_SignInUnmatchedPassword()  { UIAccountEditButton.Enabled = false; }
          private void SignInControl_SignInMatchedPassword()   { UIAccountEditButton.Enabled = true; }

        public event EventHandler<EditAccountEventArgs> EditAccountDone;
        protected virtual void OnEditAccountDone(EditAccountEventArgs e) => EditAccountDone?.Invoke(this, e);


        private void UIAccountEdit_Click(object sender, EventArgs e)
        {
            OnEditAccountDone(new EditAccountEventArgs(signInControl.NewCredentials));
        }

        private void UIEditName_TextChanged(object sender, EventArgs e)
            => UIAccountEditButton.Enabled = UIEditName.Text == null ? true : true;


        private void UIEditPassword1_TextChanged(object sender, EventArgs e)
            => UIAccountEditButton.Enabled = CheckSyntax();

        private void UIEditPassword2_TextChanged(object sender, EventArgs e)
            => UIAccountEditButton.Enabled = CheckSyntax();

        public bool CheckSyntax()
        {
            return (UIEditPassword1.Text != null && UIEditPassword1.Text == UIEditPassword2.Text);
        }

        public void EditAccountDetails(User Me)
        {
            UIAccountName.Text = Me.Name;
            UIAccountId.Text = Me.UID;
            UIRank.Text = Me.Rank.ToString();
        }
            
        public void TellError(string Error)
            => Invoke((MethodInvoker)delegate {  UIEditError.Text = "Username use by another person !";});

        private void signInControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
