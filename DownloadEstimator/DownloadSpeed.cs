using System;

namespace DownloadEstimator
{
    public class DownloadSpeed
    {
        public enum Type
        {
            BitPerSecond,
            BytePerSecond,
            Kbps,
            KBps,
            Mbps,
            MBps
        }

        private Type _type;
        private double _speed;

        public DownloadSpeed(Type type, double speed)
        {
            _type = type;
            _speed = speed;
        }
        
        public double BytesPerSecond => BitsPerSecond / 8;
        public double Kbps => BitsPerSecond * Math.Pow(10, -3);
        public double KBps => Kbps / 8;
        public double Mbps => BitsPerSecond * Math.Pow(10, -6);
        public double MBps => Mbps / 8;

        public double BitsPerSecond
        {
            get {
                var ret = _speed;

                switch (_type)
                {
                    case Type.BitPerSecond:
                        break;
                    case Type.BytePerSecond:
                        ret = _speed * 8;
                        break;
                    case Type.Kbps:
                        ret = _speed * Math.Pow(10, 3);
                        break;
                    case Type.KBps:
                        ret = _speed * 8 * Math.Pow(10, 3);
                        break;
                    case Type.Mbps:
                        ret = _speed * Math.Pow(10, 6);
                        break;
                    case Type.MBps:
                        ret = _speed * 8 * Math.Pow(10, 6);
                        break;
                }

                return ret;
            }
        }
    }
}