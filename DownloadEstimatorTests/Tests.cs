using System;
using DownloadEstimator;
using NUnit.Framework;

namespace DownloadEstimatorTests
{
    [TestFixture]
    public class Tests
    {
        #region Download Speed Tests

        private void CheckAllConversionsAgainstOneBitPerSecond(DownloadSpeed downloadSpeed)
        {
            Assert.AreEqual(1, downloadSpeed.BitsPerSecond);
            Assert.AreEqual(0.125, downloadSpeed.BytesPerSecond);
            Assert.AreEqual(0.001, downloadSpeed.Kbps);
            Assert.AreEqual(0.000125, downloadSpeed.KBps);
            Assert.AreEqual(1e-6, downloadSpeed.Mbps);
            Assert.AreEqual(1.25e-7, downloadSpeed.MBps);
        }
        
        [Test]
        public void VerifyDownloadSpeedConversionsFromBitPerSecond()
        {
            var downloadSpeed = new DownloadSpeed(DownloadSpeed.Type.BitPerSecond, 1);

            CheckAllConversionsAgainstOneBitPerSecond(downloadSpeed);
        }
        
        [Test]
        public void VerifyDownloadSpeedConversionsFromBytePerSecond()
        {
            var downloadSpeed = new DownloadSpeed(DownloadSpeed.Type.BytePerSecond, 0.125);

            CheckAllConversionsAgainstOneBitPerSecond(downloadSpeed);
        }
        
        [Test]
        public void VerifyDownloadSpeedConversionsFromKiloBitPerSecond()
        {
            var downloadSpeed = new DownloadSpeed(DownloadSpeed.Type.Kbps, 0.001);

            CheckAllConversionsAgainstOneBitPerSecond(downloadSpeed);
        }
        
        [Test]
        public void VerifyDownloadSpeedConversionsFromKiloBytePerSecond()
        {
            var downloadSpeed = new DownloadSpeed(DownloadSpeed.Type.KBps, 0.000125);

            CheckAllConversionsAgainstOneBitPerSecond(downloadSpeed);
        }
        
        [Test]
        public void VerifyDownloadSpeedConversionsFromMegaBitPerSecond()
        {
            var downloadSpeed = new DownloadSpeed(DownloadSpeed.Type.Mbps, 1e-6);

            CheckAllConversionsAgainstOneBitPerSecond(downloadSpeed);
        }
        
        [Test]
        public void VerifyDownloadSpeedConversionsFromMegaBytePerSecond()
        {
            var downloadSpeed = new DownloadSpeed(DownloadSpeed.Type.MBps, 1.25e-7);

            CheckAllConversionsAgainstOneBitPerSecond(downloadSpeed);
        }

        #endregion

        #region Download Size Tests

        private void CheckAllConversionsAgainsOneBit(DownloadSize downloadSize)
        {
            Assert.AreEqual(1, downloadSize.Bits);
            Assert.AreEqual(0.125, downloadSize.Bytes);
            Assert.AreEqual(0.001, downloadSize.KiloBits);
            Assert.AreEqual(0.000125, downloadSize.KiloBytes);
            Assert.AreEqual(1e-6, downloadSize.MegaBits);
            Assert.AreEqual(1.25e-7, downloadSize.MegaBytes);
            Assert.AreEqual(1e-9, downloadSize.GigaBits);
            Assert.AreEqual(1.25e-10, downloadSize.GigaBytes);
        }
        
        [Test]
        public void VerifyDownloadSizeConversionsFromBits()
        {
            var downloadSize = new DownloadSize(DownloadSize.Type.Bit, 1);
            
            CheckAllConversionsAgainsOneBit(downloadSize);
        }
        
        [Test]
        public void VerifyDownloadSizeConversionsFromBytes()
        {
            var downloadSize = new DownloadSize(DownloadSize.Type.Byte, 0.125);
            
            CheckAllConversionsAgainsOneBit(downloadSize);
        }
        
        [Test]
        public void VerifyDownloadSizeConversionsFromKiloBits()
        {
            var downloadSize = new DownloadSize(DownloadSize.Type.KiloBit, 0.001);
            
            CheckAllConversionsAgainsOneBit(downloadSize);
        }
        
        [Test]
        public void VerifyDownloadSizeConversionsFromKiloBytes()
        {
            var downloadSize = new DownloadSize(DownloadSize.Type.KiloByte, 0.000125);
            
            CheckAllConversionsAgainsOneBit(downloadSize);
        }
        
        [Test]
        public void VerifyDownloadSizeConversionsFromMegaBits()
        {
            var downloadSize = new DownloadSize(DownloadSize.Type.MegaBit, 1e-6);
            
            CheckAllConversionsAgainsOneBit(downloadSize);
        }
        
        [Test]
        public void VerifyDownloadSizeConversionsFromMegaBytes()
        {
            var downloadSize = new DownloadSize(DownloadSize.Type.MegaByte, 1.25e-7);
            
            CheckAllConversionsAgainsOneBit(downloadSize);
        }
        
        [Test]
        public void VerifyDownloadSizeConversionsFromGigaBits()
        {
            var downloadSize = new DownloadSize(DownloadSize.Type.GigaBit, 1e-9);
            
            CheckAllConversionsAgainsOneBit(downloadSize);
        }
        
        [Test]
        public void VerifyDownloadSizeConversionsFromGigaBytes()
        {
            var downloadSize = new DownloadSize(DownloadSize.Type.GigaByte, 1.25e-10);
            
            CheckAllConversionsAgainsOneBit(downloadSize);
        }

        #endregion
        
    }
}