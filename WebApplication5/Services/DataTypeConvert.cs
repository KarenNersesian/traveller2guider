using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace WebApplication5.Services
{
    public class DataTypeConvert
    {
        public static double ConvertToDouble(string userInportString)
        {
            double number = 0;
            try
            {
                if (userInportString.Contains('.'))
                {
                    number = double.Parse(userInportString, CultureInfo.InvariantCulture);
                }
                else if (userInportString.Contains(','))
                {
                    number = double.Parse(userInportString);
                }
            }
            catch (Exception e)
            {
                return 0;
            }

            return number;
        }

        public static double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        public static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}