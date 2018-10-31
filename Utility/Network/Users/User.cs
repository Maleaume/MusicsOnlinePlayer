using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Utility.Musics;

namespace Utility.Network.Users
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "", TypeName = "")]
    [XmlRoot(ElementName = "Users")]
    public class Users : List<User>
    { }

    public class User : CryptedCredentials
    {

        public Rank Rank { get; set; }
        [XmlIgnore]
        public string Name => Login;

        public User(ICredentials credential)
            : base(credential)
        {

        }
        public User()
            : this(new UserCredentials("", "")) { }

        public User(string name)
            : this(new UserCredentials(name, ""))
        {
        }
        public User(CryptedCredentials cryptedCredential)
            : base(cryptedCredential)
        {
        }



    }


    public interface ICredentials : ICredentialValidator
    {
        string Login { get; }
        string Password { get; }
    }

    public interface ICredentialValidator
    {
        bool IsValidCredential { get; }
    }

    public class UserCredentials : ICredentials
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public UserCredentials(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public bool IsValidCredential => IsValidLogin && IsValidPassword;


        private bool IsValidLogin => Login.Trim().Length != 0;
        private bool IsValidPassword => Password.Trim().Length != 0;


    }
    [Serializable]
    public class CryptedCredentials
    {
        public string Login { get; }
        public string UID { get; set; }

        public CryptedCredentials(string login, string uid)
        {
            Login = login;
            UID = uid;
        }

        protected CryptedCredentials(CryptedCredentials copy)
        {
            Login = copy.Login;
            UID = copy.UID;
        }

        protected CryptedCredentials(ICredentials credentials)
        {
            Login = credentials.Login;
            UID = GenerateUID(credentials);
        }
        protected virtual string GenerateUID(ICredentials credentials)
            => Hash.SHA256Hash(credentials.Login + credentials.Password);

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is CryptedCredentials cryptedCredential))
                return false;
            return cryptedCredential.UID == UID;
        }

        public override int GetHashCode() => UID.GetHashCode();
    }



    public abstract class UserUidCredentials : CryptedCredentials
    {

        protected UserUidCredentials(ICredentials credentials)
            : base(credentials)
        {
        }


    }
}
