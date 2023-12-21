using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Management;

namespace mi_lightstrip_controller.src.Com
{
    public class ComUtility
    {
        public static Dictionary<string, ComObj> GetComs()
        {
            var coms = new Dictionary<string, ComObj>();
            try
            {
                //string[] portNames = SerialPort.GetPortNames();
                //foreach (var name in portNames)
                //{
                //    string description = "";
                //    using (var searcher = new ManagementObjectSearcher($"SELECT * FROM Win32_PnPEntity WHERE DeviceID LIKE '%{name}%'"))
                //    {
                //        foreach (var port in searcher.Get())
                //        {
                //            if (port["DeviceID"] != null && port["Description"] != null && port["DeviceID"].ToString() == name)
                //            {
                //                description = port["Description"].ToString();
                //                break;
                //            }
                //        }
                //    }
                //    var com = new ComObj
                //    {
                //        name = name,
                //        description = description,
                //    };
                //    coms.Add(com.GetShowText(), com);
                //}

                //using (var searcher = new ManagementObjectSearcher("select * from Win32_PnPEntity"))
                //{
                //    foreach (var port in searcher.Get())
                //    {
                //        if (port["DeviceID"] != null && port["Description"] != null)
                //        {
                //            // 获取串口详细信息
                //            string name = port["DeviceID"].ToString();
                //            if (name.ToLower().Contains("com"))
                //            {
                //                string description = port["Description"].ToString();
                //                var com = new ComObj
                //                {
                //                    name = name,
                //                    description = description,
                //                };
                //                coms.Add(com.GetShowText(), com);
                //            }
                //        }
                //    }
                //}

                using (var searcher = new ManagementObjectSearcher("select * from Win32_PnPEntity"))
                {
                    var hardInfos = searcher.Get();
                    foreach (var hardInfo in hardInfos)
                    {
                        if (hardInfo.Properties["Name"].Value != null && hardInfo.Properties["Name"].Value.ToString().Contains("(COM"))
                        {
                            foreach (var item in hardInfo.Properties)
                            {
                                Console.WriteLine(item.Name + " " + item.Value);
                            }
                            var strComName = hardInfo.Properties["Name"].Value.ToString();
                            var description = hardInfo.Properties["Description"].Value != null? hardInfo.Properties["Description"].Value.ToString() : "";

                            int leftIndex = strComName.ToUpper().LastIndexOf('(');
                            int rightIndex = strComName.ToUpper().LastIndexOf(')');
                            if (leftIndex >= 0 && rightIndex >= 0)
                            {
                                string name = strComName.Substring(leftIndex + 1, rightIndex - leftIndex - 1);
                                var com = new ComObj
                                {
                                    name = name,
                                    description = description,
                                };
                                coms.Add(com.GetShowText(), com);
                            }
                        }
                    }
                }
            }
            catch { }
            return coms;
        }
        public static ComObj FindCom(string comName)
        {
            var coms = GetComs();
            if (coms != null)
            {
                foreach (var com in coms)
                {
                    if (com.Value.name == comName)
                    {
                        return com.Value;
                    }
                }
            }
            return null;
        }
    }
}
