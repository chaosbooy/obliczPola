namespace obliczPola.Resources.Scripts
{
    public class Drawing : IDrawable
    {
        private int _whichFigure;
        private List<PointF> _nodeList;
        private float _radius;


        public int WhichFigure
        {
            get {   return _whichFigure; }
            set {   _whichFigure = value;   }
        }
        public float Radius
        {
            get {   return _radius; }
            set {   _radius = value;}
        }
        public List<PointF> NodeList
        {
            get {   return _nodeList;   }
            set {   _nodeList = value;  }
        }


        public Drawing()
        {
            _nodeList = new();
            _radius = 10;
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.FillColor = Colors.White;

            foreach(var node in _nodeList)
            {
                canvas.FillCircle(node, _radius);
            }

        }
    }
}
