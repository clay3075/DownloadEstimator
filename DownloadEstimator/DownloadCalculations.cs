using System.Diagnostics;

namespace DownloadEstimator
{
    public static class DownloadCalculations
    {
        public static double GetTimeRemaining(DownloadSpeed downloadSpeed, DownloadSize downloadSize)
        {
            return downloadSize.Bytes / downloadSpeed.BytesPerSecond;
        }

        public static DownloadSpeed GetProcessDownloadSpeed(PerformanceCounter readByteSec)
        {
            return new DownloadSpeed(DownloadSpeed.Type.BytePerSecond, readByteSec.NextValue());
        }
    }
}