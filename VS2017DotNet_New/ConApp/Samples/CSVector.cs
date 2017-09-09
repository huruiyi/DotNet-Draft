using System;
using System.Text;

namespace ConApp
{
    public class CSVector : IFormattable
    {
        public double x, y, z;

        public CSVector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
                return ToString();
            string formatUpper = format.ToUpper();
            switch (formatUpper)
            {
                case "N":
                    return "|| " + Norm() + " ||";

                case "VE":
                    return String.Format("( {0:E}, {1:E}, {2:E} )", x, y, z);

                case "IJK":
                    StringBuilder sb = new StringBuilder(x.ToString(), 30);
                    sb.Append(" i + ");
                    sb.Append(y.ToString());
                    sb.Append(" j + ");
                    sb.Append(z.ToString());
                    sb.Append(" k");
                    return sb.ToString();

                default:
                    return ToString();
            }
        }

        public CSVector(CSVector rhs)
        {
            x = rhs.x;
            y = rhs.y;
            z = rhs.z;
        }

        public override string ToString()
        {
            return "( " + x + " , " + y + " , " + z + " )";
        }

        public double this[uint i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return x;

                    case 1:
                        return y;

                    case 2:
                        return z;

                    default:
                        throw new IndexOutOfRangeException(
                           "Attempt to retrieve Vector element" + i);
                }
            }
            set
            {
                switch (i)
                {
                    case 0:
                        x = value;
                        break;

                    case 1:
                        y = value;
                        break;

                    case 2:
                        z = value;
                        break;

                    default:
                        throw new IndexOutOfRangeException("Attempt to set Vector element" + i);
                }
            }
        }

        //public static bool operator == (CSVector lhs, CSVector rhs)
        //{
        //    if (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z)
        //     return true;
        //    return false;
        //}

        private const double Epsilon = 0.0000001;

        public static bool operator ==(CSVector lhs, CSVector rhs)
        {
            if (Math.Abs(lhs.x - rhs.x) < Epsilon &&
              Math.Abs(lhs.y - rhs.y) < Epsilon &&
              Math.Abs(lhs.z - rhs.z) < Epsilon)
                return true;
            return false;
        }

        public static bool operator !=(CSVector lhs, CSVector rhs)
        {
            return !(lhs == rhs);
        }

        public static CSVector operator +(CSVector lhs, CSVector rhs)
        {
            CSVector result = new CSVector(lhs);
            result.x += rhs.x;
            result.y += rhs.y;
            result.z += rhs.z;
            return result;
        }

        public static CSVector operator *(double lhs, CSVector rhs)
        {
            return new CSVector(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
        }

        public static CSVector operator *(CSVector lhs, double rhs)
        {
            return rhs * lhs;
        }

        public static double operator *(CSVector lhs, CSVector rhs)
        {
            return lhs.x * rhs.x + lhs.y + rhs.y + lhs.z * rhs.z;
        }

        public double Norm()
        {
            return x * x + y * y + z * z;
        }
    }
}