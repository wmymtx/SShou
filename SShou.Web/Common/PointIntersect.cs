using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SShou.Web.Common
{
    public class PointIntersect
    {
        /// <summary>
        /// 是否有 横断<br/> 参数为四个点的坐标 
        /// </summary>
        /// <param name="px1"></param>
        /// <param name="py1"></param>
        /// <param name="px2"></param>
        /// <param name="py2"></param>
        /// <param name="px3"></param>
        /// <param name="py3"></param>
        /// <param name="px4"></param>
        /// <param name="py4"></param>
        /// <returns></returns>
        public bool IsIntersect(double px1, double py1, double px2, double py2, double px3, double py3, double px4, double py4)
        {
            bool flag = false;
            double d = (px2 - px1) * (py4 - py3) - (py2 - py1) * (px4 - px3);
            if (d != 0)
            {
                double r = ((py1 - py3) * (px4 - px3) - (px1 - px3) * (py4 - py3))
                        / d;
                double s = ((py1 - py3) * (px2 - px1) - (px1 - px3) * (py2 - py1))
                        / d;
                if ((r >= 0) && (r <= 1) && (s >= 0) && (s <= 1))
                {
                    flag = true;
                }
            }
            return flag;
        }

        /// <summary>
        /// 是否有 横断<br/> 参数为四个点的坐标 
        /// </summary>
        /// <param name="px0"></param>
        /// <param name="py0"></param>
        /// <param name="px1"></param>
        /// <param name="py1"></param>
        /// <param name="px2"></param>
        /// <param name="py2"></param>
        /// <returns></returns>
        public bool IsPointOnLine(double px0, double py0, double px1,
            double py1, double px2, double py2)
        {
            bool flag = false;
            double ESP = 1e-9;// 无限小的正数  
            if ((Math.Abs(Multiply(px0, py0, px1, py1, px2, py2)) < ESP)
                    && ((px0 - px1) * (px0 - px2) <= 0)
                    && ((py0 - py1) * (py0 - py2) <= 0))
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 目标点是否在目标边上边上
        /// </summary>
        /// <param name="px0"> 目标点的经度坐标 </param>
        /// <param name="py0"> 目标点的纬度坐标</param>
        /// <param name="px1"> 目标线的起点(终点)经度坐标 </param>
        /// <param name="py1">   目标线的起点(终点)纬度坐标 </param>
        /// <param name="px2"> 目标线的终点(起点)经度坐标</param>
        /// <param name="py2">目标线的终点(起点)纬度坐标 </param>
        /// <returns></returns>
        public double Multiply(double px0, double py0, double px1, double py1,
           double px2, double py2)
        {
            return ((px1 - px0) * (py2 - py0) - (px2 - px0) * (py1 - py0));
        }

        /// <summary>
        /// 判断目标点是否在多边形内(由多个点组成)
        /// </summary>
        /// <param name="px">  目标点的经度坐标 </param>
        /// <param name="py">目标点的纬度坐标 </param>
        /// <param name="polygonXA">多边形的经度坐标集合 </param>
        /// <param name="polygonYA">多边形的纬度坐标集合</param>
        /// <returns></returns>
        public bool IsPointInPolygon(double px, double py,
         List<Double> polygonXA, List<Double> polygonYA)
        {
            bool isInside = false;
            double ESP = 1e-9;
            int count = 0;
            double linePoint1x;
            double linePoint1y;
            double linePoint2x = 180;
            double linePoint2y;

            linePoint1x = px;
            linePoint1y = py;
            linePoint2y = py;

            for (int i = 0; i < polygonXA.Count - 1; i++)
            {
                double cx1 = polygonXA[i];
                double cy1 = polygonYA[i];
                double cx2 = polygonXA[i + 1];
                double cy2 = polygonYA[i + 1];
                // 如果目标点在任何一条线上  
                if (IsPointOnLine(px, py, cx1, cy1, cx2, cy2))
                {
                    return true;
                }
                // 如果线段的长度无限小(趋于零)那么这两点实际是重合的，不足以构成一条线段  
                if (Math.Abs(cy2 - cy1) < ESP)
                {
                    continue;
                }
                // 第一个点是否在以目标点为基础衍生的平行纬度线  
                if (IsPointOnLine(cx1, cy1, linePoint1x, linePoint1y, linePoint2x,
                        linePoint2y))
                {
                    // 第二个点在第一个的下方,靠近赤道纬度为零(最小纬度)  
                    if (cy1 > cy2)
                        count++;
                }
                // 第二个点是否在以目标点为基础衍生的平行纬度线  
                else if (IsPointOnLine(cx2, cy2, linePoint1x, linePoint1y,
                        linePoint2x, linePoint2y))
                {
                    // 第二个点在第一个的上方,靠近极点(南极或北极)纬度为90(最大纬度)  
                    if (cy2 > cy1)
                        count++;
                }
                // 由两点组成的线段是否和以目标点为基础衍生的平行纬度线相交  
                else if (IsIntersect(cx1, cy1, cx2, cy2, linePoint1x, linePoint1y,
                        linePoint2x, linePoint2y))
                {
                    count++;
                }
            }
            if (count % 2 == 1)
            {
                isInside = true;
            }

            return isInside;
        }
    }
}