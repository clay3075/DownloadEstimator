using System;
using System.Collections.Generic;
using System.Windows.Documents;

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
            MBps,
            Gbps,
            GBps
        }

        private readonly Type _type;
        private readonly double _speed;

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
        public double Gbps => BitsPerSecond * Math.Pow(10, -9);
        public double GBps => Gbps / 8;

        public double BitsPerSecond
        {
            get {
                var bytePerSecondTypes = new List<Type> {Type.BytePerSecond, Type.KBps, Type.MBps, Type.GBps};
                var kiloPerSecondTypes = new List<Type> {Type.Kbps, Type.KBps};
                var megaPerSecondTypes = new List<Type> {Type.Mbps, Type.MBps};
                var gigaPerSecondTypes = new List<Type> {Type.Gbps, Type.GBps};

                var ret = bytePerSecondTypes.Contains(_type) ? _speed * 8 : _speed;
                ret = kiloPerSecondTypes.Contains(_type) ? ret * Math.Pow(10, 3) : ret;
                ret = megaPerSecondTypes.Contains(_type) ? ret * Math.Pow(10, 6) : ret;
                ret = gigaPerSecondTypes.Contains(_type) ? ret * Math.Pow(10, 9) : ret;

                return ret;
            }
        }
    }
}