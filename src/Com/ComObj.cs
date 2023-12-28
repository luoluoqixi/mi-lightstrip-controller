using System.IO.Ports;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace mi_lightstrip_controller.src.Com
{
    public class ComObj
    {
        public class SendReponse
        {
            public string res;
            public string error;
            public int errCount;

            public bool IsError
            {
                get { return errCount > 0; }
            }
        }
        public int BaudRate { get; set; } = 230400;
        public int DataBits { get; set; } = 8;
        public StopBits StopBits { get; set; } = StopBits.One;
        public Parity Parity { get; set; } = Parity.None;
        public int RetryMilliseconds { get; set; } = 1000;

        public string name;
        public string description;

        private CancellationTokenSource cts;
        private readonly static object lockObj = new object();

        public string GetShowText()
        {
            return $"{description} ({name})";
        }
        async public Task<SendReponse> SendCom(string command, bool hasResponse, Action<string, int> errorAction)
        {
            if (cts != null)
            {
                cts.Cancel();
                cts = null;
            }
            cts = new CancellationTokenSource();
            var response = new SendReponse();
            Action<string> success = (res) =>
            {
                response.res = res;
            };
            Action<string, int> error = (err, errCount) =>
            {
                response.error = err;
                response.errCount = errCount;
                errorAction?.Invoke(err, errCount);
            };
            await Task.Run(() => SendComTask(command, cts, hasResponse, success, error), cts.Token);
            return response;
        }
        private void SendComTask(string command, CancellationTokenSource cts, bool hasResponse, Action<string> successAction, Action<string, int> errorAction)
        {
            int errorCount = 0;
            while (true)
            {
                if (cts.IsCancellationRequested)
                    break;
                try
                {
                    using (var serialPort = new SerialPort())
                    {
                        serialPort.PortName = name;        // 串口名称
                        serialPort.BaudRate = BaudRate;   // 波特率
                        serialPort.DataBits = DataBits;   // 数据位
                        serialPort.StopBits = StopBits;   // 停止位
                        serialPort.Parity = Parity;       // 校验位
                        serialPort.NewLine = "\r\n";
                        try
                        {
                            serialPort.Open();
                        }
                        catch (UnauthorizedAccessException)
                        {
                            throw new UnauthorizedAccessException("串口被占用: " + name);
                        }
                        serialPort.WriteLine(command);
                        Thread.Sleep(300);
                        string response = serialPort.ReadExisting();
                        if (hasResponse && string.IsNullOrEmpty(response))
                        {
                            throw new Exception("串口未响应");
                        }
                        successAction?.Invoke(response);
                        break;
                    }
                }
                catch (Exception e)
                {
                    errorCount++;
                    lock (lockObj)
                    {
                        errorAction?.Invoke(e.Message, errorCount);
                    }
                }
                Thread.Sleep(RetryMilliseconds);
            }
        }
        public void Dispose()
        {
            if (cts != null)
            {
                cts.Cancel();
                cts = null;
            }
        }
    }
}
