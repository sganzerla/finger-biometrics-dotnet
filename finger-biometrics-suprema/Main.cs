using Suprema;
using System;
using System.IO;
using System.Windows.Forms;

namespace finger_biometrics_suprema
{
    public partial class Main : Form
    {

        private UFScannerManager _mScannerManager;
        private UFScanner _scanner;
        private string _mStrError;
        private const int TimeoutLedScannerSuprema = 60000;
        private const int MaxTemplateSize = 1024;
        private string _base64;

        public Main()
        {
            InitializeComponent();
            LoadScannerSuprema();
        }

        private void LoadScannerSuprema()
        {
            _mScannerManager = new UFScannerManager(this);
            _scanner = new UFScanner();
            var ufsRes = _mScannerManager.Init();
            if (ufsRes == UFS_STATUS.OK)
            {
                SetLog("UFScanner Init: OK\r\n");
            }
            else
            {
                UFScanner.GetErrorString(ufsRes, out _mStrError);
                SetLog($"UFScanner Init: {_mStrError}\r\n");
                return;
            }

            _mScannerManager.ScannerEvent += ScannerEvent;
            var nScannerNumber = _mScannerManager.Scanners.Count;
            SetLog($"UFScanner GetScannerNumber: {nScannerNumber}\r\n");
            UpdateScannerListSuprema();
        }

        private void ScannerEvent(object sender, UFScannerManagerScannerEventArgs e)
        {
            UpdateScannerListSuprema();
        }


        private void SetLog(string message)
        {
            textBoxLogs.AppendText("     " + DateTime.Now + " - " + message + " \n");
        }


        private void UpdateScannerListSuprema()
        {
            var nScannerNumber = _mScannerManager.Scanners.Count;

            if (nScannerNumber == 0)
            {
                _scanner = null;
                SetLog("UFScanner not found GetScannerNumber \r\n");
            }
            else
            {
                _scanner = _mScannerManager.Scanners[0];
                SetLog($"Biometria serial: {_scanner.Serial}\r\n");
                SetLog($"UFScanner GetScannerNumber: {nScannerNumber}\r\n");
            }
        }

        private void ClearLogTextMessage()
        {
            textBoxLogs.Text = "";
        }

        private void DrawCapturedImageFingerSuprema()
        {
            var ufsRes = _scanner.GetCaptureImageBuffer(out var bitmap, out _);
            pictureBoxFinger.Image = ufsRes == UFS_STATUS.OK ? bitmap : null;
        }

        private void ExtractWsqBufferToFileSuprema()
        {
            var template = new byte[MaxTemplateSize];

            var ufsRes = _scanner.ExtractEx(MaxTemplateSize, template, out var templateSize, out var enrollQuality);

            if (ufsRes == UFS_STATUS.OK)
            {
                SetLog($"Template Size({templateSize}), Quality({enrollQuality})\r\n");
            }
            else
            {
                UFScanner.GetErrorString(ufsRes, out var mStrError);
                SetLog("UFScanner ExtractEx: " + mStrError + "\r\n");
            }

            var filename = $"{Guid.NewGuid()}.wsq";
            ufsRes = _scanner.SaveCaptureImageBufferToWSQ(filename, 1);
            if (ufsRes == UFS_STATUS.OK)
                SetLog($"UFScanner image buffer is read");

            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                using var reader = new BinaryReader(fs);
                _base64 = Convert.ToBase64String(reader.ReadBytes((int)fs.Length));
            }


            if (File.Exists(filename))
                File.Delete(filename);
        }



        private void buttonCapture_Click(object sender, EventArgs e)
        {
            if (_scanner == null) return;

            _scanner.ClearCaptureImageBuffer();
            ClearLogTextMessage();
            _scanner.Timeout = TimeoutLedScannerSuprema;

            var ufsRes = _scanner.CaptureSingleImage();

            if (ufsRes == UFS_STATUS.OK)
            {
                SetLog("UFScanner CaptureSingleImage: OK\r\n");
                DrawCapturedImageFingerSuprema();
                ExtractWsqBufferToFileSuprema();
            }
            else
            {
                UFScanner.GetErrorString(ufsRes, out _mStrError);
                SetLog($"UFScanner CaptureSingleImage: {_mStrError}\r\n");
            }
        }
    }
}
