using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrinciple
{
    public abstract class User
    {
        public readonly IVideoPlayer _videoPlayer;
        private string userName;
        private string userID;

        public User(IVideoPlayer videoPlayer)
        {
            _videoPlayer = videoPlayer;
        }

        public string UserName
        {
            set { userName = value; }
            get { return userName; }
        }

        public string UserID
        {
            set { userID = value; }
            get { return userID; }
        }

        public void Login()
        {
            Console.WriteLine("user {0} login",new object[] { userName });
        }

        public abstract void WatchMovie();
    }
}
