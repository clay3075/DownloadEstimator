using System;

namespace DownloadEstimator
{
    public class DownloadSize
    {
        public enum Type
        {
            Bit,
            Byte,
            KiloBit,
            KiloByte,
            MegaBit,
            MegaByte,
            GigaBit,
            GigaByte
        }

        private Type _type;
        private double _size;

        public DownloadSize(Type type, double size)
        {
            _type = type;
            _size = size;
        }

        public double Bytes => Bits / 8;
        public double KiloBits => Bits * Math.Pow(10, -3);
        public double KiloBytes => KiloBits / 8;
        public double MegaBits => Bits * Math.Pow(10, -6);
        public double MegaBytes => MegaBits / 8;
        public double GigaBits => Bits * Math.Pow(10, -9);
        public double GigaBytes => GigaBits / 8;

        public double Bits
        {
            get
            {
                var ret = _size;

                switch (_type)
                {
                    case Type.Bit:
                        break;
                    case Type.Byte:
                        ret = _size * 8;
                        break;
                    case Type.KiloBit:
                        ret = _size * Math.Pow(10, 3);
                        break;
                    case Type.KiloByte:
                        ret = _size * 8 * Math.Pow(10, 3);
                        break;
                    case Type.MegaBit:
                        ret = _size * Math.Pow(10, 6);
                        break;
                    case Type.MegaByte:
                        ret = _size * 8 * Math.Pow(10, 6);
                        break;
                    case Type.GigaBit:
                        ret = _size * Math.Pow(10, 9);
                        break;
                    case Type.GigaByte:
                        ret = _size * 8 * Math.Pow(10, 9);
                        break;
                }

                return ret;
            }
        }
    }
}