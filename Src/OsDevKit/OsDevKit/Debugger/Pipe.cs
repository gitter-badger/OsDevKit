using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsDevKit.Debugger
{
    public  class Pipe
    {
        bool Run = true;
        public async void StartPipe()
        {
            
                var message = "";
                var server = "127.0.0.1";
                Int32 port = 8080;
                TcpClient client = new TcpClient(server, port);

                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

   

                NetworkStream stream = client.GetStream();

           


                Debug.WriteLine("Sent: {0}", message);

                data = new Byte[256];

               
                String responseData = String.Empty;

                while (Run)
                {


                try
                {


                    Int32 bytes = stream.Read(data, 0, data.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    Global.DebugOutPut = responseData + Global.DebugOutPut;
                    Application.DoEvents();
                }
                catch(Exception ee)
                {
                    break;
                }  

                }
                // Close everything.
                stream.Close();
                client.Close();
            Global.SerialPipe.StopPipe();
            Global.DebugOutPut = "\n\n-------------------------------------------------------\n\n Gebugging pipe closed\n" + Global.DebugOutPut;


        }


        public void StopPipe()
        {
            Run = false;
        }
    }
}
