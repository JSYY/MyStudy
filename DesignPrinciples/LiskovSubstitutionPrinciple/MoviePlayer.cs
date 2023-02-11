using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrinciple
{
    public class MoviePlayer : IVideoPlayer
    {
        public void Play()
        {
            Console.WriteLine("MoviePlayer start play");
        }
    }
}
