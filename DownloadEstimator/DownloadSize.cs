using System;
using System.Collections.Generic;

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
                var byteTypes = new List<Type> {Type.Byte, Type.KiloByte, Type.MegaByte, Type.GigaByte};
                var kiloTypes = new List<Type> {Type.KiloBit, Type.KiloByte};
                var megaTypes = new List<Type> {Type.MegaBit, Type.MegaByte};
                var gigaTypes = new List<Type> {Type.GigaBit, Type.GigaByte};

                var ret = byteTypes.Contains(_type) ? _size * 8 : _size;
                ret = kiloTypes.Contains(_type) ? ret * Math.Pow(10, 3) : ret;
                ret = megaTypes.Contains(_type) ? ret * Math.Pow(10, 6) : ret;
                ret = gigaTypes.Contains(_type) ? ret * Math.Pow(10, 9) : ret;

                return ret;
            }
        }

        public double ConvertTo(Type type)
        {
            var conversions = new Dictionary<Type, double>
            {
                {Type.Bit, Bits},
                {Type.Byte, Bytes},
                {Type.KiloBit, KiloBits},
                {Type.KiloByte, KiloBytes},
                {Type.MegaBit, MegaBits},
                {Type.MegaByte, MegaBytes},
                {Type.GigaBit, GigaBits},
                {Type.GigaByte, GigaBytes}
            };

            return conversions[type];
        }
    }
}