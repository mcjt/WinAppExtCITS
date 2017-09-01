using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocketSharp;

namespace WinAppExtCITS.SHR
{
    public static class CitsConnect
    {
        private static WebSocket webSocket;

        private static Boolean isrunning = false;


        public static Func<Boolean, int> onConnection;

        private enum SslProtocolsHack
        {
            Tls = 192,
            Tls11 = 768,
            Tls12 = 3072
        }

        #region WebSocket
        internal static void connectTo(String address)
        {
            try
            {
                Logger.Log("Check if Server is running");
                if (!isRunning())
                {
                    Logger.Log("Trying to connect with server");
                    Logger.Log("Server " + address);
                    webSocket = new WebSocket(address);
                    webSocket.OnMessage += new EventHandler<MessageEventArgs>(websocketMessage);
                    webSocket.OnClose += new EventHandler<CloseEventArgs>(webSocketClose);
                    webSocket.OnOpen += new EventHandler(webSocketOpen);
                    webSocket.OnError += (sender, e) =>
                    {
                        Logger.Log("OnError");
                        Logger.Log(e.Message.ToString());
                    };
                    Logger.Log("Connecting");
                    webSocket.Connect();
                    Logger.Log("Connected");
                }

            }
            catch (Exception ex)
            {
                Logger.Log("Error Connecting Server");
                Logger.Log(ex.ToString());
            }
        }

        private static void websocketMessage(object sender, MessageEventArgs e)
        {
            try
            {
                HealObject data = HealObject.ToObject(e.Data);
                Logger.Log("Message from Server - " + data.action);
                switch (data.action)
                {
                    case "find":
                        checkForObjectInContext(data);
                        break;
                    case "serverStop":
                        stopAll();
                        break;
                    case "startSpy":
                        //Spy.startSpy();
                        break;
                    case "startHeal":
                        //cognizantitsToolbar.startHeal();
                        break;
                    case "startRecord":
                        //cognizantitsToolbar.startRecord();
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
            }
        }

        private static void checkForObjectInContext(HealObject data)
        {
            //if (Heal.permissionGranted)
            Heal.Search(data);
        }

        private static void webSocketClose(object sender, CloseEventArgs e)
        {
            var sslProtocolHack = (System.Security.Authentication.SslProtocols)(SslProtocolsHack.Tls12 | SslProtocolsHack.Tls11 | SslProtocolsHack.Tls);

            if (e.Code == 1015 && webSocket.SslConfiguration.EnabledSslProtocols != sslProtocolHack)
            {
                Logger.Log("TlsHandshakeFailure Trying again");
                webSocket.SslConfiguration.EnabledSslProtocols = sslProtocolHack;
                webSocket.Connect();
            }
            else
            {
                isrunning = false;
                onConnection(false);
                //cognizantitsToolbar.stopAll();
                //Util.showConnectionError();
            }
        }

        private static void webSocketOpen(object sender, EventArgs e)
        {
            isrunning = true;
            onConnection(true);
        }

        private static void sendMessage(string msg)
        {
            try
            {
                if (isRunning())
                    webSocket.Send(msg);
                else
                {
                    // cognizantitsToolbar.stopAll();
                }


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        internal static void send(string message)
        {
            sendMessage(message);
        }

        internal static bool isRunning()
        {
            return isrunning;
        }

        internal static void stopAll()
        {
            onConnection(false);
            Spy.stopSpy();
        }

        #endregion        
    }
}
