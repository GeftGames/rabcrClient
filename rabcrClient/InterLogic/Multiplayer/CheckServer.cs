using System;
using System.Net;
using System.Net.Sockets;

namespace rabcrClient {
    class CheckServer :IDisposable{

        Socket clientSocket;
        byte[] byteData = new byte[1024];
        readonly IPAddress ip;
        readonly int port;

        volatile bool running=true;

        public CheckServer(string[] args) {
            Console.WriteLine("I|Started "+Release.VersionString);
            if (int.TryParse(args[2], out port)) {
                if (IPAddress.TryParse(args[1], out ip) ) {
                    Start();
                } else Console.WriteLine("Nelze rozpoznat ip");
            } else {
                if (IPAddress.TryParse(args[1], out ip) ){
                    Console.WriteLine("Nelze rozpoznat port");
                } else Console.WriteLine("Nelze rozpoznat adresu serveru");
            }
            while (running) {}
            Console.WriteLine("I|Exited");
        }

        void Start() {
            try {
                clientSocket=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp) {
                    SendTimeout=1500,
                    ReceiveTimeout=1500
                };

                IPEndPoint ipEndPoint = new IPEndPoint(ip,port);

                clientSocket.BeginConnect(ipEndPoint, new AsyncCallback(OnConnect), null);
            } catch (SocketException ex) {
               SetServerError(0,"Nelze se připojit",ex.ErrorCode,ex.Message,"Start");
            }catch (Exception ex){
                SetServerError(0,"Nelze se připojit",0,ex.Message,"Start");
            }
        }

        void Exit() {
            running=false;
        }

        void SetServerError(int deep, string gedo, int code, string msg, string where) {
            //}>   ---   deep   ---   <{//
            // 0 = "silná" chyba = DarkRed
            // 1 = chyba         = Red
            // 2 = "lehká" chyba = Orange
            // 3 = OK+problémy   = Yellow
            // 4 = OK            = None
            Console.WriteLine("E|"+deep+"|"+gedo+"|"+code+"|"+msg+"|"+where);
            try {
                clientSocket.Disconnect(false);
                clientSocket.Dispose();
                clientSocket=null;
            } catch {}
            Exit();
        }

        void OnConnect(IAsyncResult ar) {
            try {
                clientSocket.EndConnect(ar);

                Data msgToSend = new Data {
                    Cmd=Command.Check,
                    From=Setting.Name,
                    To="{Server}",
                    Message="check"
                };

                byte[] bytes = msgToSend.ToByte();

                clientSocket.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
           } catch (SocketException ex) {
                switch (ex.ErrorCode) {
                    case 10061: SetServerError(0,"Server nenalezen", ex.ErrorCode, ex.Message, "OnConnect");
                    break;

                    case 10060: SetServerError(2,"Server se nenašel v časovém intervalu", ex.ErrorCode, ex.Message, "OnConnect");
                    break;

                    case 10049: SetServerError(0,"Neplatná adresa serveru", ex.ErrorCode, ex.Message, "OnConnect");
                    break;

                    case 10065: SetServerError(0,"Server není dostupný", ex.ErrorCode, ex.Message, "OnConnect");
                    break;

                    default: SetServerError(0,"Nelze se připojit", ex.ErrorCode, ex.Message, "OnConnect");
                    break;
                }
            } catch (Exception ex) {
                SetServerError(0,ex.Message, 0, ex.Message,"OnConnect");
            }
        }

        void OnSend(IAsyncResult ar) {

            SendBegin();

            try {
                clientSocket.EndSend(ar);
            } catch (SocketException ex) {
               SetServerError(1,"Nelze odeslat k serveru požadavek o odeslání informací.",ex.ErrorCode,ex.Message,"OnSend");
            }catch (Exception ex){
                SetServerError(1,"Nelze odeslat k serveru požadavek o odeslání informací.",0,ex.Message,"OnSend");
            }
        }

        void OnReceive(IAsyncResult ar) {
            Data msgReceived=null;

            try {
                clientSocket.EndReceive(ar);
                msgReceived = new Data(byteData);
            } catch (SocketException ex) {
                if (ex.ErrorCode==10054) SetServerError(1,"Server byl neočekávaně vypnut.",ex.ErrorCode,ex.Message,"OnReceive");
                else SetServerError(2,ex.Message,ex.ErrorCode,ex.Message,"OnReceive");
            } catch (Exception ex) {
                SetServerError(2,"Nelze získat data",0,ex.Message,"OnReceive");
            } finally {
                if (msgReceived.Cmd==Command.Check) {
                    string[]get=msgReceived.Message.Split('|');
                    if (get.Length>0) {
                        Console.WriteLine("G|"+msgReceived.Message);
                        Exit();
                    } else {
                        SetServerError(3,"Připojení existuje, ale získané data nemají správný typ.",0,"","OnReceive");
                    }
                } else {
                    string str="";
                    foreach (byte b in byteData)str+=b+" ";
                    SetServerError(3,"Obdrženy vadné data",0,""+str,"OnReceive");
                }
            }
        }

        private void SendBegin() {
            try {
                byteData = new byte[1024];

                clientSocket.BeginReceive(byteData,
                    0,
                    byteData.Length,
                    SocketFlags.None,
                    new AsyncCallback(OnReceive),
                    null);

            } catch (SocketException ex) {
                SetServerError(1,"Nelze odeslat serveru požadavek o poskytnutí informací",ex.ErrorCode,ex.Message,"SendBegin");
            } catch (Exception ex) {
                SetServerError(1,"Nelze odeslat serveru požadavek o poskytnutí informací",0,ex.Message,"SendBegin");
            }
        }

        public void Dispose() {
            clientSocket.Dispose();
        }
    }
}