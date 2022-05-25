using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hprose.RPC;

namespace ClassModel
{
    public class MyHexagon
    {
        Client client;
        struct Point
        {
            public float x;
            public float y;
        }
        public MyHexagon(List<float> hexagonPoint)
        {
            client=new Client("http://127.0.0.1:8082");
            //TODO  从用户的六部图中把六边形的顶点算出来
        }
        Point[] point = new Point[6];
        public float GetArea()
        {
            float area = client.Invoke<float>("getArea",new object[] {point});
            return area;
        }
        public float GetOverloapArea(MyHexagon anotherHexagon)
        {
            bool isOverloap= client.Invoke<bool>("isOverloap", new object[] { this.point,anotherHexagon.point });
            if (!isOverloap)
            {
                return 0.0f;
            }
            else
            {
                float overloapArea = client.Invoke<float>("getOverloapArea", new object[] { this.point, anotherHexagon.point });
                return overloapArea;
            }
        }
    }
}
