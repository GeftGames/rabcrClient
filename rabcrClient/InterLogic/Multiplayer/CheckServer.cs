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
                } else Console.WriteLine("1515");//Nelze rozpoznat ip
            } else {
                if (IPAddress.TryParse(args[1], out ip) ){
                    Console.WriteLine("1516");//Nelze rozpoznat port
                } else Console.WriteLine("1517");//Nelze rozpoznat adresu serveru
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
               SetServerError(0,"1518",ex.ErrorCode,ex.Message,"Start");//Nelze se připojit
            }catch (Exception ex){
                SetServerError(0,"1518",0,ex.Message,"Start");//Nelze se připojit
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
                    case 10061: SetServerError(0,"1519", ex.ErrorCode, ex.Message, "OnConnect");//Server nenalezen
                    break;

                    case 10060: SetServerError(2,"1520", ex.ErrorCode, ex.Message, "OnConnect");//Server se nenašel v časovém intervalu
                    break;

                    case 10049: SetServerError(0,"1521", ex.ErrorCode, ex.Message, "OnConnect");//Neplatná adresa serveru
                    break;

                    case 10065: SetServerError(0,"1522", ex.ErrorCode, ex.Message, "OnConnect");//Server není dostupný
                    break;

                    default: SetServerError(0,"1518", ex.ErrorCode, ex.Message, "OnConnect");//Nelze se připojit
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
               SetServerError(1,"1523",ex.ErrorCode,ex.Message,"OnSend");//Nelze odeslat k serveru požadavek o odeslání informací.
            }catch (Exception ex){
                SetServerError(1,"1523",0,ex.Message,"OnSend");//Nelze odeslat k serveru požadavek o odeslání informací.
            }
        }

        void OnReceive(IAsyncResult ar) {
            Data msgReceived=null;

            try {
                clientSocket.EndReceive(ar);
                msgReceived = new Data(byteData);
            } catch (SocketException ex) {
                if (ex.ErrorCode==10054) SetServerError(1,"1524",ex.ErrorCode,ex.Message,"OnReceive");//Server byl neočekávaně vypnut.
                else SetServerError(2,ex.Message,ex.ErrorCode,ex.Message,"OnReceive");
            } catch (Exception ex) {
                SetServerError(2,"1525",0,ex.Message,"OnReceive");//Nelze získat data
            } finally {
                if (msgReceived.Cmd==Command.Check) {
                    string[]get=msgReceived.Message.Split('|');
                    if (get.Length>0) {
                        Console.WriteLine("G|"+msgReceived.Message);
                        Exit();
                    } else {
                        SetServerError(3,"1526",0,"","OnReceive");//Připojení existuje, ale získané data nemají správný typ.
                    }
                } else {
                    string str="";
                    foreach (byte b in byteData)str+=b+" ";
                    SetServerError(3,"1527",0,""+str,"OnReceive");//Obdrženy vadné data
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
                SetServerError(1,"1528",ex.ErrorCode,ex.Message,"SendBegin");
            } catch (Exception ex) {
                SetServerError(1,"1528",0,ex.Message,"SendBegin");
            }
        }

        public void Dispose() {
            clientSocket.Dispose();
        }
    }
}