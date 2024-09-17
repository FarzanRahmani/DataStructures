using System;
using System.Collections.Generic;
using TestCommon;
using System.Linq;

namespace E1
{
    public class Q2Cars : Processor
    {
        public Q2Cars(string testDataName) : base(testDataName)
        {
            this.ExcludeTestCaseRangeInclusive(75,76);
        }

        public override string Process(string inStr) => E1Processors.ProcessQ2Cars(inStr, Solve);

        public double Solve(long aX, long aY, long bX, long bY, long cX, long cY, long dX, long dY)
        {
            return Q2((double)aX,(double)aY,(double)bX,(double)bY,(double)cX,(double)cY,(double)dX,(double)dY);
            // double start = Math.Sqrt((aX-cX)*(aX-cX) + (aY-cY)*(aY-cY));
            // // double start = Solve();
            // double end = Math.Sqrt((bX-dX)*(bX-dX) + (bY-dY)*(bY-dY));
            // // double end = Math.Sqrt((bX-dX)*(bX-dX) + (bY-dY)*(bY-dY));
            // if (Math.Abs(end - start) < 0.000001)
            // {
            //     return start;
            // }
            // long mid1X = (aX + bX)/2;
            // long mid1y = (aY + bY)/2;
            // long mid2X = (cX + dX)/2;
            // long mid2y = (cY + dY)/2;
            // double mid = Math.Sqrt( (mid1X-mid2X)*(mid1X-mid2X) + (mid1y-mid2y)*(mid1y-mid2y));
            // if (mid <= start && mid <= end)
            //     return mid;
            // else
            // {
            //     if (start < end)
            //         return Solve(aX,aY,mid1X,mid1y,cX,cY,mid2X,mid2y);
            //     if (end < start)
            //     {
            //         return Solve(mid1X,mid1y,bX,bY,mid2X,mid2y,dX,dY);
            //     }
            // }
            // return mid;
            // -----------------
            // double v1 = 1;
            // double theta1 = Math.PI / 2;
            // // if ( bY < aY)
            // //     theta1 = 3*Math.PI / 2;
            // if ((bX - aX) != 0)
            //     theta1 = Math.Atan((bY - aY) / (bX - aX));
            // // if (bY < aY && bX < aX)
            // //     theta1 *= -1;
            // // if (bY == aY && bX < aX)
            // //     theta1 = Math.PI;

            // double AB = Math.Sqrt((aX-bX)*(aX-bX) + (aY-bY)*(aY-bY));
            // double CD = Math.Sqrt((cX-dX)*(cX-dX) + (cY-dY)*(cY-dY));
            // double v2 = AB / CD;
            // double theta2 = Math.PI / 2;
            // // if ( dY < cY)
            // //     theta2 = 3*Math.PI / 2;
            // if ( (dX - cX) != 0)
            //     theta2 = Math.Atan((dY - cY) / (dX - cX));
            // // if (dY < cY && dX < cX)
            // //     theta2 *= -1;
            // // if (dY == cY && dX < cX)
            // //     theta2 = Math.PI;



            // double time = AB;

            // double vx1 = v1*Math.Cos(theta1);
            // double vy1 = v1*Math.Sin(theta1);
            // double vx2 = v2*Math.Cos(theta2);
            // double vy2 = v2*Math.Sin(theta2);

            // if(bX < aX)
            //     vx1 *= -1;
            // if(bY < aY)
            //     vy1 *= -1;
            // if(dX < cX)
            //     vx2 *= -1;
            // if(dY < cY)
            //     vy2 *= -1;

            // List<double> distances = new List<double>(101);
            // for (double i = 0; i < 101; i++)
            // {
            //     double passedTime = (time*(i/100));
            //     double x1 = aX + vx1*passedTime;
            //     double y1 = aY + vy1*passedTime;
            //     double x2 = cX + vx2*passedTime;
            //     double y2 = cY + vy2*passedTime;
            //     distances.Add(Math.Sqrt((x1-x2)*(x1-x2) + (y1-y2)*(y1-y2)));
            // }
            // return distances.Min();
        }

        public double Q2(double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY)
        {
            double start = Math.Sqrt((aX-cX)*(aX-cX) + (aY-cY)*(aY-cY));
            double end = Math.Sqrt((bX-dX)*(bX-dX) + (bY-dY)*(bY-dY));
            
            double mid1X = (aX + bX)/2;
            double mid1y = (aY + bY)/2;
            double mid2X = (cX + dX)/2;
            double mid2y = (cY + dY)/2;
            double mid = Math.Sqrt( (mid1X-mid2X)*(mid1X-mid2X) + (mid1y-mid2y)*(mid1y-mid2y));

            if (Math.Abs(end - start) < 0.00000000001 && Math.Abs(end - mid) < 0.00000000001)
                return (start + end)/2;
            
            if (start < end)
                return Q2(aX,aY,mid1X,mid1y,cX,cY,mid2X,mid2y);
            else
                return Q2(mid1X,mid1y,bX,bY,mid2X,mid2y,dX,dY);
            
            // return Math.Min(Q2(aX,aY,mid1X,mid1y,cX,cY,mid2X,mid2y),Q2(mid1X,mid1y,bX,bY,mid2X,mid2y,dX,dY));


            // ---------------------------
            // double mid10X = (bX - aX)/3 + aX;
            // double mid10y = (bY - aY)/3 + aY;
            // double mid20X = (dX - cX)/3 + cX;
            // double mid20y = (dY - cY)/3 + cY;
            // double mid10 = Math.Sqrt( (mid10X-mid20X)*(mid10X-mid20X) + (mid10y-mid20y)*(mid10y-mid20y));
            
            // double mid11X = 2*(bX - aX)/3 + aX;
            // double mid11y = 2*(bY - aY)/3 + aY;
            // double mid21X = 2*(dX - cX)/3 + cX;
            // double mid21y = 2*(dY - cY)/3 + cY;
            // double mid11 = Math.Sqrt( (mid11X-mid21X)*(mid11X-mid21X) + (mid11y-mid21y)*(mid11y-mid21y));

            // // if (Math.Abs(mid10 - mid11) < 0.0000000001)
            // //     return mid10 ;  
            // //     // return (mid10 + mid11)/2;  
            // if (Math.Abs(bX - aX)+Math.Abs(dX - cX)+Math.Abs(aY - bY)+Math.Abs(dY - cY) < 0.000000001)
            // {
            //     return (mid10 + mid11)/2;
            // }

            // if (mid10 < mid11)
            //     return Q2(aX,aY,mid11X,mid11y,cX,cY,mid21X,mid21y);
            // else
            //     return Q2(mid10X,mid10y,bX,bY,mid20X,mid20y,dX,dY);
        }

    }
}
