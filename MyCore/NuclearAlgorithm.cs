using MyCore.Utils;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCore
{
    public static class NuclearAlgorithm
    {
        /// <summary>
        /// 获取核火球半径。
        /// </summary>
        /// <param name="equivalent_kt">当量：吨</param>
        /// <param name="alt_ft">高度：米</param>
        /// <returns>半径：米</returns>
        public static double GetFireBallRadius(double equivalent_t, double alt_m)
        {
            MyAnalyse myAnalyse = new MyAnalyse();
            return myAnalyse.CalcfireBallRadius(equivalent_t / 1000.0, alt_m * Const.FT2MI > 0);
        }

        /// <summary>
        /// 获取输入值rem对应的早期核辐射半径。
        /// </summary>
        /// <param name="equivalent_t">当量：吨</param>
        /// <param name="alt_m">高度：米</param>
        /// <param name="rem"></param>
        /// <returns>半径：米</returns>
        public static double GetNuclearRadiationRadius(double equivalent_t, double alt_m, double rem)
        {
            MyAnalyse myAnalyse = new MyAnalyse();
            return myAnalyse.CalcNuclearRadiationRadius(equivalent_t / 1000.0, alt_m * Const.M2FT, rem);
        }


        /// <summary>
        /// 获取输入值psi对应的冲击波半径。
        /// </summary>
        /// <param name="equivalent_t">当量：吨</param>
        /// <param name="alt_m">高度：米</param>
        /// <param name="psi"></param>
        /// <returns>半径：米</returns>
        public static double GetShockWaveRadius(double equivalent_t, double alt_m, double psi)
        {
            MyAnalyse myAnalyse = new MyAnalyse();
            return myAnalyse.CalcShockWaveRadius(equivalent_t / 1000, alt_m * Const.M2FT, psi);
        }

        /// <summary>
        /// 获取输入值calcm2对应的光辐射半径。
        /// </summary>
        /// <param name="equivalent_t">当量：吨</param>
        /// <param name="alt_m">高度：米</param>
        /// <param name="calcm2"></param>
        /// <returns>半径：米</returns>
        public static double GetThermalRadiationRadius(double equivalent_t, double alt_m, double calcm2)
        {
            MyAnalyse myAnalyse = new MyAnalyse();
            return myAnalyse.GetThermalRadiationR(equivalent_t / 1000, alt_m * Const.M2FT, calcm2);
        }
        /// <summary>
        /// 获取输入值vm对应的核电磁脉冲半径。
        /// </summary>
        /// <param name="equivalent_t">当量：吨</param>
        /// <param name="alt_m">高度：米</param>
        /// <param name="vm"></param>
        /// <returns>半径：米</returns>
        public static double GetNuclearPulseRadius(double equivalent_t, double alt_m, double vm)
        {
            MyAnalyse myAnalyse = new MyAnalyse();
            return  1000* myAnalyse.CalcNuclearPulseRadius(equivalent_t, alt_m / 1000, vm);
        }
        public static string GetFalloutGeometryJson(double equivalent_t, double lng,double lat,
            double alt_m,  double wind_speed, double wind_dir,int radshour)
        {

            MyAnalyse myAnalyse = new MyAnalyse();
            double maximumDownwindDistance = 0;
            double maximumWidth = 0;
            List<Coor> coors = myAnalyse.CalcRadioactiveFalloutRegion(
                lng, lat, alt_m * Const.M2FT, equivalent_t / 1000, wind_speed, wind_dir, (MyCore.enums.DamageEnumeration)radshour,
                ref maximumDownwindDistance, ref maximumWidth);

            List<Coordinate> coordinates = new List<Coordinate>();
            for (int i = 0; i < coors.Count; i++)
            {
                coordinates.Add(new Coordinate(coors[i].lng, coors[i].lat));
            }

            // 把coordinators 转换成geometry
            Coordinate[] coords = coordinates.ToArray();
            Polygon polygon = new NetTopologySuite.Geometries.Polygon(
                new LinearRing(coords));

            string geometry = MyCore.Utils.Translate.Geometry2GeoJson(polygon);

            return geometry;

        }


    }
}
