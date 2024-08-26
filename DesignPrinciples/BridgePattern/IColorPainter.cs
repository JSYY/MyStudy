using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public interface IColorPainter
    {
        string Paint();
    }

    public class BluePainter : IColorPainter
    {
        public string Paint()
        {
            return "Blue";
        }
    }

    public class RedPainter : IColorPainter
    {
        public string Paint()
        {
            return "Red";
        }
    }
}
