using System;

namespace BridgePattern
{
    public abstract class DefaultShape
    {
        public string Color;
        public string Type;
        protected IColorPainter _colorPainter;

        public DefaultShape(IColorPainter colorPainter)
        {
            _colorPainter = colorPainter;
        }

        public virtual void Paint()
        {
            Color = _colorPainter.Paint();
        }

        public abstract void Draw();
    }

    public class Circle : DefaultShape
    {
        public Circle(IColorPainter colorPainter) : base(colorPainter)
        {

        }

        public override void Draw()
        {
            Paint();
            Type = "Circle";
        }
    }

    public class Rectangle : DefaultShape
    {
        public Rectangle(IColorPainter colorPainter) : base(colorPainter)
        {

        }

        public override void Draw()
        {
            Paint();
            Type = "Rectangle";
        }
    }
}
