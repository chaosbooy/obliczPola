using obliczPola.Resources.Scripts;

namespace obliczPola
{
    public partial class MainPage : ContentPage
    {
        private Drawing _d;
        private int sideCount = 0;

        public Drawing D
        {
            get { return _d; } 
            set 
            {
                _d = value; 
            }
        }


        public MainPage()
        {
            _d = new();

            InitializeComponent();

            mainCanvas.Drawable = _d;
        }

        private async void MainCanvasTapped(object sender, TappedEventArgs e)
        {
            try
            {
#pragma warning disable 
                var position = (PointF)e.GetPosition(mainCanvas);
#pragma warning restore

                bool isHit = false;
                foreach (var node in D.NodeList)
                {
                    var distance = Math.Sqrt(Math.Pow(node.X - position.X, 2) + Math.Pow(node.Y - position.Y, 2));

                    if (distance < D.Radius * 1.5f)
                    {
                        isHit = true;
                        break;
                    }
                }

                if (!isHit)
                {
                    D.NodeList.Add(position);
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An Error has occured: {ex.Message}", "OK");
            }


            mainCanvas.Invalidate();
        }

        private void AreaChanged(object sender, TappedEventArgs e)
        {
            sideNumber.IsVisible = true;
            sideStepper.IsVisible = true;
        }

        private void SideNumberChanged(object sender, ValueChangedEventArgs e)
        {
            sideCount = (int)e.NewValue;
            sideNumber.Text = $"number of sides: {sideCount.ToString("D2")}";
        }

        private void EvaluateArea()
        {
            float area = 0;

            switch (D.NodeList.Count)
            {
                case 1:
                    area = RegularPolygonArea();
                    break;

                case 2:
                    area = LineArea();
                    break;

                case 3:
                    area = TriangleArea();
                    break;

                case 4:
                    area = QuadrangleArea();
                    break;

                default:
                    throw new NotImplementedException();
            }


        }

        private float TriangleArea()
        {
            throw new NotImplementedException();
        }

        private float QuadrangleArea()
        {
            throw new NotImplementedException();
        }

        private float RegularPolygonArea()
        {
            if (sideCount < 2) return CircleArea();
            else if (sideCount == 2) return LineArea();

            throw new NotImplementedException();
        }

        private float CircleArea()
        {
            throw new NotImplementedException();
        }

        private float LineArea()
        {
            throw new NotImplementedException();
        }

        
    }

}
