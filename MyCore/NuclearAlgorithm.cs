using MyCore.enums;
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
        /// <param name="alt_m">高度：米</param>
        /// <returns>半径：米</returns>
        public static double GetFireBallRadius(double equivalent_t, double alt_m)
        {
            MyAnalyse myAnalyse = new MyAnalyse();
            return myAnalyse.CalcfireBallRadius(equivalent_t / 1000.0, alt_m * Const.FT2MI > 0);
        }

        /// <summary>
        /// 获取核火球几何对象。
        /// </summary>
        /// <param name="lon">经度。</param>
        /// <param name="lat">纬度。</param>
        /// <param name="equivalent_kt">当量：吨</param>
        /// <param name="alt_m">高度：米</param>
        /// <returns>几何对象</returns>
        public static Geometry GetFireBallGeometry(double lon, double lat, double equivalent_t, double alt_m)
        {
            MyCore.MyAnalyse myAnalyse = new MyCore.MyAnalyse();
            double r = myAnalyse.CalcfireBallRadius(equivalent_t / 1000.0, alt_m * Const.FT2MI > 0);

            // BuildCircle的r要传入km
            Geometry geom = MyCore.Utils.Translate.BuildCircle(lon, lat, r / 1000.0, 50);

            return geom;
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
        ///  获取早期核辐射几何对象。
        /// </summary>
        /// <param name="lon">经度。</param>
        /// <param name="lat">纬度。</param>
        /// <param name="equivalent_t">当量：吨</param>
        /// <param name="alt_m">高度：米</param>
        /// <param name="rem"></param>
        /// <returns>几何对象。</returns>
        public static Geometry GetNuclearRadiationGeometry(double lon, double lat, double equivalent_t, double alt_m, double rem)
        {
            MyCore.MyAnalyse myAnalyse = new MyCore.MyAnalyse();

            double r = myAnalyse.CalcNuclearRadiationRadius(equivalent_t, alt_m, rem);

            //根据(lng,lat,R)生成Geometry
            Geometry geom = MyCore.Utils.Translate.BuildCircle(lon, lat, r / 1000.0, 50);

            return geom;
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
        /// 获取冲击波几何对象。
        /// </summary>
        /// <param name="lon">经度。</param>
        /// <param name="lat">纬度。</param>
        /// <param name="equivalent_t">当量：吨</param>
        /// <param name="alt_m">高度：米</param>
        /// <param name="psi"></param>
        /// <returns>几何对象。</returns>
        public static Geometry GetShockWaveGeometry(double lon, double lat, double equivalent_t, double alt_m, double psi)
        {
            MyCore.MyAnalyse myAnalyse = new MyCore.MyAnalyse();

            double r = myAnalyse.CalcShockWaveRadius(equivalent_t / 1000, alt_m * Const.M2FT, psi);

            //根据(lng,lat,R)生成Geometry
            Geometry geom = MyCore.Utils.Translate.BuildCircle(lon, lat, r / 1000.0, 50);
            return geom;
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
        /// 获取光辐射几何对象。
        /// </summary>
        /// <param name="lon">经度。</param>
        /// <param name="lat">纬度。</param>
        /// <param name="equivalent_t">当量：吨</param>
        /// <param name="alt_m">高度：米</param>
        /// <param name="calcm2"></param>
        /// <returns>几何对象。</returns>
        public static Geometry GetThermalRadiationGeometry(double lon, double lat, double equivalent_t, double alt_m, double calcm2)
        {
            MyCore.MyAnalyse myAnalyse = new MyCore.MyAnalyse();
            double r = myAnalyse.GetThermalRadiationR(equivalent_t / 1000, alt_m * Const.M2FT, calcm2);
            //根据(lng,lat,R)生成Geometry
            Geometry geom = MyCore.Utils.Translate.BuildCircle(lon, lat, r / 1000.0, 50);
            return geom;
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


        /// <summary>
        /// 获取核电磁脉冲几何对象。
        /// </summary>
        /// <param name="lon">经度。</param>
        /// <param name="lat">纬度。</param>
        /// <param name="equivalent_t">当量：吨</param>
        /// <param name="alt_m">高度：米</param>
        /// <param name="vm"></param>
        /// <returns></returns>
        public static Geometry GetNuclearPulseGeometry(double lon, double lat, double equivalent_t, double alt_m, double vm)
        {
            MyCore.MyAnalyse myAnalyse = new MyCore.MyAnalyse();

            double r = myAnalyse.CalcNuclearPulseRadius(equivalent_t, alt_m / 1000, vm);

            //根据(lng,lat,R)生成Geometry。
            // 注意，因为r返回的就是千米，而BuildCircle，需要传入的也是千米，所以就不用除以1000了
            Geometry geom = MyCore.Utils.Translate.BuildCircle(lon, lat, r, 50);
            return geom;
        }


        public static Geometry GetFalloutGeometry(double lon, double lat, double equivalent_t, double alt_m, double wind_speed, double wind_dir)
        {
            MyCore.MyAnalyse myAnalyse = new MyCore.MyAnalyse();
            double maximumDownwindDistance = 0;
            double maximumWidth = 0;
            List<MyCore.Coor> coors = myAnalyse.CalcRadioactiveFalloutRegion(
                lon, lat, alt_m * Const.M2FT, equivalent_t / 1000, wind_speed, wind_dir, MyCore.enums.DamageEnumeration.Light,
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

            return polygon;
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

        public static DamageEnumeration Airblast(double dis, double equivalent_t, double alt_m, double psi01, double psi02, double psi03)
        {
            // 冲击波。

            double r1 = GetShockWaveRadius(equivalent_t, alt_m, psi01);
            double r2 = GetShockWaveRadius(equivalent_t, alt_m, psi02);
            double r3 = GetShockWaveRadius(equivalent_t, alt_m, psi03);

            if (dis <= r3) return MyCore.enums.DamageEnumeration.Destroy;
            if (dis <= r2) return MyCore.enums.DamageEnumeration.Heavy;
            if (dis <= r1) return MyCore.enums.DamageEnumeration.Light;

            return MyCore.enums.DamageEnumeration.Safe;
        }
        public static DamageEnumeration NuclearRadiation(double dis, double equivalent_t, double alt_m, double rem01, double rem02, double rem03)
        {
            // 核辐射
            double r1 = GetNuclearRadiationRadius(equivalent_t, alt_m, rem01);
            double r2 = GetNuclearRadiationRadius(equivalent_t, alt_m, rem02);
            double r3 = GetNuclearRadiationRadius(equivalent_t, alt_m, rem03);

            if (dis <= r3) return DamageEnumeration.Destroy;
            if (dis <= r2) return DamageEnumeration.Heavy;
            if (dis <= r1) return DamageEnumeration.Light;

            return DamageEnumeration.Safe;
        }

        public static DamageEnumeration ThermalRadiation(double dis, double equivalent_t, double alt_m, double cal01, double cal02, double cal03)
        {
            // 光辐射

            double r1 = GetThermalRadiationRadius(equivalent_t, alt_m, cal01);
            double r2 = GetThermalRadiationRadius(equivalent_t, alt_m, cal02);
            double r3 = GetThermalRadiationRadius(equivalent_t, alt_m, cal03);

            if (dis <= r3) return MyCore.enums.DamageEnumeration.Destroy;
            if (dis <= r2) return MyCore.enums.DamageEnumeration.Heavy;
            if (dis <= r1) return MyCore.enums.DamageEnumeration.Light;

            return DamageEnumeration.Safe;
        }

        public static DamageEnumeration NuclearPulse(double dis, double equivalent_t, double alt_m, double vm01, double vm02, double vm03)
        {
            // 核电磁脉冲

            double r1 = GetNuclearPulseRadius(equivalent_t, alt_m, vm01);
            double r2 = GetNuclearPulseRadius(equivalent_t, alt_m, vm02);
            double r3 = GetNuclearPulseRadius(equivalent_t, alt_m, vm03);

            if (dis <= r3) return DamageEnumeration.Destroy;
            if (dis <= r2) return DamageEnumeration.Heavy;
            if (dis <= r1) return DamageEnumeration.Light;

            return enums.DamageEnumeration.Safe;
        }
    }
}
