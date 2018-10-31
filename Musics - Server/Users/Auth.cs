using System.IO;
using System.Xml;
using Utility.Network.Users;
using System.Linq;
namespace Musics___Server.Authentification
{
    class AuthentificationService
    {

        private readonly XmlDocument doc = new XmlDocument();

        public void SetupAuth()
        {
            if (!File.Exists(@"users.xml"))
            {
                using (XmlWriter writer = XmlWriter.Create(@"users.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Users");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }



        public void SignupUser(CryptedCredentials cryptedCredentials)
        {
            var user = new User(cryptedCredentials);
            if (!SigninUser(user))
            {
                doc.Load(@"users.xml");
                XmlNode nodeUser = doc.CreateElement("User");

                XmlNode nodeName = doc.CreateElement("Name");
                nodeName.InnerText = user.Name;
                nodeUser.AppendChild(nodeName);

                XmlNode nodeUID = doc.CreateElement("UID");
                nodeUID.InnerText = user.UID;
                nodeUser.AppendChild(nodeUID);

                XmlNode nodeRank = doc.CreateElement("Rank");
                nodeRank.InnerText = user.Rank.ToString();
                nodeUser.AppendChild(nodeRank);

                XmlNode nodeRatedMusics = doc.CreateElement("RatedMusics");
                nodeUser.AppendChild(nodeRatedMusics);

                XmlNode nodePlaylist = doc.CreateElement("UserPlaylists");
                nodeUser.AppendChild(nodePlaylist);

                doc.DocumentElement.AppendChild(nodeUser);
                doc.Save(@"users.xml");
            }
        }

        public bool SigninUser(User user)
        {
            doc.Load(@"users.xml");
            return UserIDExist(user.UID).exist;
        }

        public (bool exist, XmlNode userNode) UserIDExist(string UID)
        {
            doc.Load(@"users.xml");
            var nodesList = doc.DocumentElement.SelectNodes("User");
            var userNode = nodesList.Cast<XmlNode>().SingleOrDefault(n => n["UID"].InnerText == UID);
            return (userNode != null, userNode);
        }


        public bool EditUser(CryptedCredentials oldCredentials, CryptedCredentials newCredentials)
        {
            (var userExist, var userNode) = UserIDExist(newCredentials.UID);
            if (!userExist) return false; //TODO username already exist.
            userNode["Name"].InnerText = newCredentials.Login;
            userNode["UID"].InnerText = newCredentials.UID;
            doc.Save(@"users.xml");

            return true;
        }

    }
}
