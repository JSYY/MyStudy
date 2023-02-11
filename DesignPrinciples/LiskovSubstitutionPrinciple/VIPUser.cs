using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrinciple
{
    public class VIPUser : User
    {
        public VIPUser(IVideoPlayer videoPlayer):base(videoPlayer)
        {
            
        }

        public override void WatchMovie()
        {
            Console.WriteLine(this.UserName+" start watch movie");
            _videoPlayer.Play();
        }
    }
}
