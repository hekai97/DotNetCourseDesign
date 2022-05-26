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
        //六边形内部最长半边的长度
        float hexagonMaxLength = 10;
        struct Point
        {
            public float x;
            public float y;
        }
        public MyHexagon(List<float> hexagonPoint)
        {
            float cos60 = (float)Math.Cos(Math.PI / 3);
            float sin60 = (float)Math.Sin(Math.PI / 3);
            float sqrt3=(float)Math.Sqrt(3);
            client =new Client("http://127.0.0.1:8082");
            //TODO  从用户的六部图中把六边形的顶点算出来
            Point[] points=new Point[6];
            points[0].x = hexagonMaxLength - hexagonPoint[0];
            points[0].y = (5 *sqrt3);

            points[1].x = hexagonMaxLength - hexagonPoint[1]*cos60;
            points[1].y = 5 * sqrt3 + hexagonPoint[1] * sin60;

            points[2].x = 10 + hexagonPoint[2] * cos60;
            points[2].y = 5 * sqrt3 + hexagonPoint[2] * sin60;

            points[3].x = 10 + hexagonPoint[3];
            points[3].y = 5 * sqrt3 - hexagonPoint[3] * cos60;

            points[4].x=10+hexagonPoint[4]*cos60;
            points[4].y=5*sqrt3-hexagonPoint[4] * sin60;

            points[5].x=10-hexagonPoint[5]*cos60;
            points[5].y=5*sqrt3-hexagonPoint[5] * sin60;
            //用定点值初始化类中的数据列表
            hexagonPoints = new List<Point>(points);

        }
        List<Point> hexagonPoints { get; }
        public float GetArea()
        {
            float area = client.Invoke<float>("getArea",new object[] {hexagonPoints});
            return area;
        }
        public float GetOverloapArea(MyHexagon anotherHexagon)
        {
            bool isOverloap= client.Invoke<bool>("isOverloap", new object[] { this.hexagonPoints,anotherHexagon.hexagonPoints });
            if (!isOverloap)
            {
                return 0.0f;
            }
            else
            {
                float overloapArea = client.Invoke<float>("getOverloapArea", new object[] { this.hexagonPoints, anotherHexagon.hexagonPoints });
                return overloapArea;
            }
        }
    }
}
