using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace rabcrClient {
    #if MULTIPLAYER
    partial class Multiplayer {
        int playerId=-1;
        #region varibles
        List<ChangeTerrain> terrainChanges = new();
        List<DataToSend> Queue = new();
        const string toServer = "{Server}";
        const string toEveryone = "{Everyone}";
        string SomeoneWantTeleportToYouName;

        Password password;

        enum LoginType {
            Null,

            Banned,
            BannedWithInfo,

            FirstConnectPassword,
            FirstConnect,

            NotOnWhitelistNoInfo,
            NotOnWhitelist,

            LoginWithPassword,
            BasicLogin,
        }
        int state = 0;
          const int downloadingSpawnAreaMax = 53;
        int downloadedSpawnArea = 0;
        //  bool cmdWeb;
        byte[] byteData = new byte[1024];
        Current currentState;
        bool Error = false;
        int joinedPlayers = 0;
        Socket clientSocket;
        string serverName = "";
        int maxplayers = 10;
        DateTime tpPlayerTime;
        string tpPlayerMsgWaiting;
        int safeSpawn = 0;
        List<Player> players = new();
        //   bool UseBackColor;
        //    Color BackColor;
        // bool UseGedo;
        GameButtonMedium menu;
        float Process {
            get { return state/496f; }
        }
        string sn = "";
        #endregion

        void DestroyBlockTopBlock(int x, int y) {
            MTerrain chunk=terrain[x];
            SendRemovedBlock(x, y, chunk.TopBlocks[y].Id,BlockType.Top);
         //   chunk.TopBlocks[y]=null;
          //  chunk.IsTopBlocks[y]=MBlockState.TmpRemoved;
        }

        void DestroyBlockBackBlock(int x, int y) {
            MTerrain chunk=terrain[x];
            SendRemovedBlock(x, y, chunk.TopBlocks[y].Id,BlockType.Back);
            //chunk.BackBlocks[y]=null;
           // chunk.IsTopBlocks[y]=MBlockState.TmpRemoved;
        }

        void DestroyBlockSolidBlock(int x, int y) {
            MTerrain chunk=terrain[x];
            SendRemovedBlock(x, y, chunk.SolidBlocks[y].Id,BlockType.Solid);
          //  chunk.TopBlocks[y]=null;
            //chunk.IsTopBlocks[y]=MBlockState.TmpRemoved;
        }

        void SendRemovedBlock(int x, int y, ushort id, BlockType bt) {
            terrainChanges.Add(new SendedBlockToRemove {
                blockPos=new DInt(x,y),
                blockType=bt,
                World="Earth",
                SelectedInv=boxSelected,
                sended=DateTime.Now,
            });

            //switch (bt) {
            //    case BlockType.Back:
            //        terrain[x].IsBackground[y]=MBlockState.TmpRemoved;
            //        break;

            //    case BlockType.Solid:
            //        terrain[x].IsSolidBlocks[y]=MBlockState.TmpRemoved;
            //        break;

            //    case BlockType.Top:
            //        terrain[x].IsTopBlocks[y]=MBlockState.TmpRemoved;
            //        break;

            //    case BlockType.Plant:
            //        terrain[x].Plants.[y]=MBlockState.TmpRemoved;
            //        break;

            //    case BlockType.Mob:
            //        terrain[x].IsTopBlocks[y]=MBlockState.TmpRemoved;
            //        break;
            //}

            //Queue.Add(new DataToSend {
            //    Importance=Importance.Middle,
            //    Bytes=new Data {
            //        Cmd=Command.EditTerrain,
            //        From=Setting.Name,
            //        To=toServer,
            //        Message="-|"+x+"|"+y+"|"+world+"|"+(int)BlockType.Top+"|"+id+"|",
            //    }.ToByte(),
            //});
        }

        //void SendChangedBlock(int x, int y, ushort oldId, ushort newId, BlockType bt) {
        //    terrainChanges.Add(new SendedBlockToAdd {
        //        blockPos=new DInt(x,y),
        //        blockType=bt,
        //        World="Earth",
        //        sended=DateTime.Now,
        //    });

        //    //switch (bt) {
        //    //    case BlockType.Back:
        //    //     //   terrain[x].IsBackground[y]=false;
        //    //        break;

        //    //    case BlockType.Solid:
        //    //      //  terrain[x].IsSolidBlocks[y]=MBlockState.TmpRemoved;
        //    //        break;

        //    //    case BlockType.Top:
        //    //      //  terrain[x].IsTopBlocks[y]=MBlockState.TmpRemoved;
        //    //        break;

        //    //    case BlockType.Plant:
        //    //       // terrain[x].Plants.[y]=MBlockState.TmpRemoved;
        //    //        break;

        //    //    case BlockType.Mob:
        //    //      //  terrain[x].IsTopBlocks[y]=MBlockState.TmpRemoved;
        //    //        break;
        //    //}

        //    Queue.Add(new DataToSend {
        //        Importance=Importance.Middle,
        //        Bytes=new Data {
        //            Cmd=Command.EditTerrain,
        //            From=Setting.Name,
        //            To=toServer,
        //            Message="*|"+x+"|"+y+"|"+world+"|"+(int)BlockType.Top+"|"+oldId+"|"+newId,
        //        }.ToByte(),
        //    });
        //}

        void SendAddedBlock(int x, int y, int id, BlockType bt) {
            terrainChanges.Add(new SendedBlockToAdd {
                blockPos=new DInt(x,y),
                blockType=bt,
                World="Earth",
                SelectedInv=boxSelected,
                sended=DateTime.Now,
            });

            //switch (bt) {
            //    case BlockType.Back:
            //     //   terrain[x].IsBackground[y]=false;
            //        break;

            //    case BlockType.Solid:
            //      //  terrain[x].IsSolidBlocks[y]=MBlockState.TmpRemoved;
            //        break;

            //    case BlockType.Top:
            //      //  terrain[x].IsTopBlocks[y]=MBlockState.TmpRemoved;
            //        break;

            //    case BlockType.Plant:
            //       // terrain[x].Plants.[y]=MBlockState.TmpRemoved;
            //        break;

            //    case BlockType.Mob:
            //      //  terrain[x].IsTopBlocks[y]=MBlockState.TmpRemoved;
            //        break;
            //}

            //Queue.Add(new DataToSend {
            //    Importance=Importance.Middle,
            //    Bytes=new Data {
            //        Cmd=Command.EditTerrain,
            //        From=Setting.Name,
            //        To=toServer,
            //        Message="+|"+x+"|"+y+"|"+world+"|"+(int)BlockType.Top+"|"+id+"|",
            //    }.ToByte(),
            //});
        }

        void SendEatItem() {
            //Queue.Add(new DataToSend {
            //    Importance=Importance.Middle,
            //    Bytes=new Data {
            //        Cmd=Command.EatFood,
            //        From=Setting.Name,
            //        To=toServer,
            //        Message=InventoryNormal[boxSelected].Id.ToString(),
            //    }.ToByte(),
            //});
        }

        void SendHoeAction(int x, int y) {

        }

        Color StringToColor(string str) {
            string h = str.Replace("[", "").Replace("]", "").Replace(" ", "");
            return new Color(int.Parse(h.Substring(0, h.IndexOf(","))),
                int.Parse(h.Substring(h.IndexOf(",")+1, h.LastIndexOf(",")-h.IndexOf(",")-1)),
                int.Parse(h.Substring(h.LastIndexOf(",")+1)));
        }

        public void Connect() {
            clientSocket=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp) {
                ReceiveTimeout=10
            };
            IPAddress ipAddress = ip;

            if (ipAddress.ToString()==IPAddress.Any.ToString()) { ipAddress=IPAddress.Loopback; ip=IPAddress.Loopback; }

            IPEndPoint ipEndPoint = new(ipAddress, port);

            Debug.WriteLine("Připojování: "+ipAddress.ToString()+":"+port);

            clientSocket.BeginConnect(ipEndPoint, new AsyncCallback(OnCheck), null);
        }

        public void ConnectDuringGameError() {
            clientSocket=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp) {
                ReceiveTimeout=10
            };
            IPAddress ipAddress = ip;

            if (ipAddress.ToString()==IPAddress.Any.ToString()) ipAddress=IPAddress.Loopback;

            IPEndPoint ipEndPoint = new(ipAddress, port);

            Debug.WriteLine("Znovupřipojování: "+ipAddress.ToString()+":"+port);

            clientSocket.BeginConnect(ipEndPoint, new AsyncCallback(OnCheck), null);
        }

        void OnCheck(IAsyncResult ar) {
            try {
                state++;
                clientSocket.EndConnect(ar);

                //Data msgToSend = new Data {
                //    Cmd = Command.Check,
                //    //       From=Setting.Name,
                //    To = toServer,
                //    Message = ""
                //};

                List<byte> bytesToSend = new() {
                    (byte)Command.Check
                };
                AddStringToByteList(bytesToSend, Setting.Name);

                byteData = bytesToSend.ToArray();

                //byteData = msgToSend.ToByte();

                clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);

                byteData = new byte[1024];

                clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);

                //current=Current.EndChecking;
                state++;
            } catch (SocketException ex) {

                //Nemohlo být vytvořeno žádné připojení, protože cílový počítač je aktivně odmítl
                if (10061 == ex.ErrorCode) {
                    ShowError("Nelze se připojit k serveru", "Žádný server není spuštěn na adrese " + ip + ":" + port);
                } else {
                    //Pokus o připojení selhal, protože připojená strana v časovém intervalu řádně neodpověděla, nebo vytvořené připojení selhalo, protože neodpověděl připojený hostitel
                    if (10060 == ex.ErrorCode) {
                        ShowError("Nelze se připojit k serveru", "Připojování trvalo příliš dlouho.");
                    } else if (10013 == ex.ErrorCode) {
                        ShowError("Nelze se připojit k serveru", "Pravděpodobně Váš firewall blokuje připojení (Zkuste ho vypnout)");
                    } else
                        ShowError("Nelze se připojit k serveru", "Neznámá chyba v OnCheck: " + ex.Message + "; Kód: " + ex.ErrorCode);
                }
            }

            //if (!Global.OnlineAccount){
            //    string url="https://geftgames.ga/System/rabcr/ifplayerexists.php?username="+Setting.Name;
            //    MyWebClient wc=new MyWebClient {
            //        Encoding=Encoding.UTF8,
            //    };
            //    try{
            //        string get=wc.DownloadString(new Uri(url));
            //         Console.WriteLine(6);
            //        if (string.IsNullOrEmpty(get)) {
            //            ShowError("Nelze zkontrolovat hráče", "Nelze ověřit zda již takový účet neexistuje");
            //        } else {
            //            string[]g=get.Split('|');

            //            if (g.Length>1){
            //                switch (g[0]) {
            //                    case "E":

            //                        break;

            //                    case "O":
            //                        //ok
            //                        ShowError("Tento účet již existuje", "Někdo si již takovou přezdívku používá");
            //                        break;

            //                    default:
            //                       // ShowError("Tento účet již existuje", "Někdo si již takovou přezdívku používá");
            //                        break;
            //                }
            //            } else {
            //                ShowError("Nelze zkontrolovat hráče", "Nelze ověřit zda již takový účet neexistuje");
            //            }
            //        }
            //    }catch{
            //        ShowError("Nelze zkontrolovat hráče", "Nelze ověřit zda již takový účet neexistuje");
            //    }
            //}

        }

        void SendMyInventory() {
            //Data data = new Data {
            //    Cmd=Command.Message,
            //    To=toServer,
            //    Message="*int-set ",
            //};

            //data.Message+=maxInvCount+" ";

            ////for (int i = 0; i<maxInvCount; i++) {
            ////    DInt p = Inventory[i];
            ////    data.Message+=p.X+" "+p.Y+" ";
            ////}

            //Queue.Add(
            //    new DataToSend {
            //        Bytes=data.ToByte(),
            //        Importance=Importance.Middle,
            //    }
            //);
        }

        void SendMachineInventory(int x, int y) {
            List<DInt> inv = null;
            int id = terrain[x].TopBlocks[y].Id;

            //if (terrain[x].TopBlocks[y] is BoxBlock) {
            //    inv=((BoxBlock)terrain[x].TopBlocks[y]).Inv;
            //} else if (terrain[x].TopBlocks[y] is MashineBlockBasic) {
            //    inv=((MashineBlockBasic)terrain[x].TopBlocks[y]).Inv;
            //} else if (terrain[x].TopBlocks[y] is ShelfBlock) {
            //    inv=((ShelfBlock)terrain[x].TopBlocks[y]).Inv;
            //} else return;

            //Data data = new Data {
            //    Cmd=Command.Message,
            //    To=toServer,
            //    Message="*inv-machine-set "+x+" "+y+" ",
            //};

            //data.Message+=inv.Count+" ";

            //for (int i = 0; i<inv.Count; i++) {
            //    DInt p = inv[i];
            //    data.Message+=p.X+" "+p.Y+" ";
            //}

            //Queue.Add(
            //    new DataToSend {
            //        Bytes=data.ToByte(),
            //        Importance=Importance.Middle,
            //    }
            //);
        }

        void GetMachineInventory(int x, int y) {
            //Queue.Add(
            //    new DataToSend {
            //        Bytes=new Data {
            //            Cmd=Command.Message,
            //            To=toServer,
            //            Message="*inv-machine-get "+x+" "+y,
            //        }.ToByte(),
            //        Importance=Importance.Middle,
            //    }
            //);
        }

        void SendInventory() {
            // List<DInt> inv=null;


            //Data data = new Data {
            //    Cmd=Command.Message,
            //    To=toServer,
            //    Message="*inv-set ",
            //};

            //data.Message+=maxInvCount+" ";

            //List<byte> bytesInv=new();
            //for (int i = 0; i<maxInvCount; i++) {
            //    InventoryNormal[i].SaveBytes(bytesInv);
            // //   data.Message+=p.X+" "+p.Y+" ";
            //}

            //Queue.Add(
            //    new DataToSend {
            //        Bytes=data.ToByte(),
            //        Importance=Importance.Middle,
            //    }
            //);
        }

        void GetInventory() {
            //Queue.Add(
            //    new DataToSend {
            //        Bytes=new Data {
            //            Cmd=Command.Message,
            //            To=toServer,
            //            Message="*inv-get ",
            //        }.ToByte(),
            //        Importance=Importance.Middle,
            //    }
            //);
        }

        public static void GetBasicData(byte[] data, out Command cmd, out ushort toPlayerId, out ushort fromPlayerId, out byte[] commandByteData) {
             // Command
            cmd=(Command)data[0];

            // len to player
            toPlayerId = (ushort)(data[2]<<8 | data[1]);

            // len from player (or server)
            fromPlayerId = (ushort)(data[4]<<8 | data[3]);

            // lenght data
            int len=data[6]<<8 | data[5];

            // message length
            commandByteData=data.SubBytes(7, len-7);
        }

        void SolveErrorDuringGame(int errorCode, string info, string more) {
            if (currentState==Current.ErrorDuringGame) {
                ShowError(info, more);
            } else {
                // current==Current.ErrorDuringGame
                // Stávající připojení bylo ukončeno vzdáleným hostitelem
                if (errorCode==10054) {
                    try {
                        clientSocket.Close();
                        clientSocket.Dispose();
                    } catch (Exception ex) {
                        Console.WriteLine("SolveErrorDuringGame 1 "+ex.Message);
                    }

                    ConnectDuringGameError();
                } else {
                    ShowError(info, more);
                }
            }
        }

        void DoCommand() {
            if (!text.StartsWith("*")) return;

            string[] word = text.Split(' ');
            word[0]=word[0].ToLower();

            switch (word[0]) {
                case "*spawn":
                    if (tpSpawn) {
                        if (word.Length==1) {
                            PlayerX=spawnX;
                            PlayerY=spawnY;
                            DisplayText("Byl jsi teleportován na spawn");
                        } else DisplayText("Za příkaz *spawn nic nepište");
                    } else DisplayText("Na tento příkaz namáte oprávnění");
                    return;

                case "*ping":
                    if (cmdPing) {
                        if (word.Length==1) {
                            DisplayText("Počkejte chviličku...");
                            diserpeard=250;
                            //Data msg = new Data {
                            //    Cmd=Command.Request,
                            //    //     From=Setting.Name,
                            //    To=toServer,
                            //};
                            //Queue.Add(new DataToSend {
                            //    Bytes=msg.ToByte(),
                            //    Importance=Importance.VeryImportant
                            //});
                        }
                    }
                    DisplayText("Na tento příkaz namáte oprávnění");
                    return;

                case "*players":
                    if (word.Length==1) {
                        string t = "";
                        foreach (Player p in players) t+=p.name+", ";

                        DisplayText(t);
                    }
                    return;

                case "*help":
                    if (word.Length==1) {
                        string t = "players, help, ";
                        if (tpSpawn) t+="spawn, ";
                        if (cmdPing) t+="ping, ";
                        if (tpPlayer) t+="tp, ";
                        DisplayText(t);
                    }
                    return;

                //case "*web":
                //    if (cmdWeb){
                //        if (word.Length==1) {
                //            System.Diagnostics.Process.Start(web);
                //            DisplayText("Otevírá se..."+web);
                //        }
                //    } else DisplayText("Na tento příkaz namáte oprávnění");
                //    return;


                case "*tp":
                    if (tpPlayer) {
                        if (word.Length==2) {
                            bool notExists = true;

                            foreach (Player p in players) {
                                if (word[1]==p.name) {
                                    notExists=false;

                                    if (tpPlayerMessage) {

                                        //Data msg = new Data {
                                        //    Cmd=Command.PlayersTeleportMessageToTarget,
                                        //    //  From=Setting.Name,
                                        //    To=toServer,
                                        //    Message="3|"+p.name,
                                        //};

                                        //Queue.Add(new DataToSend {
                                        //    Bytes=msg.ToByte(),
                                        //    Importance=Importance.High
                                        //});
                                        tpPlayerTime=DateTime.Now;

                                        DisplayText("Odesílám požadavek o teleportaci ...");
                                        tpPlayerMsgWaiting=p.name;
                                        return;
                                    } else {
                                        PlayerX=p.x;
                                        PlayerY=p.y;
                                        DisplayText("Teleportace úspěštná");
                                        return;
                                    }
                                }

                                if (notExists) {
                                    DisplayText("Hráč nenelezen");
                                }
                            }
                        }
                    } else if (tpEverywhere) {
                        if (word.Length==3) {
                            if (int.TryParse(word[1], out int x)) {
                                if (int.TryParse(word[2], out int y)) {
                                    PlayerX=x;
                                    PlayerY=y;
                                } else {
                                    DisplayText("Použití: \"*tp <x> <y>\"; y je číslo");
                                }
                            } else {
                                if (int.TryParse(word[2], out int y)) {
                                    DisplayText("Použití: \"*tp <x> <y>\"; x je číslo");
                                } else {
                                    DisplayText("Použití: \"*tp <x> <y>\"; x a y je číslo");
                                }
                            }
                        }
                    } else {
                        DisplayText("Na tento příkaz namáte oprávnění");
                    }
                    return;

                case "*warp-set":
                    if (word.Length==2) {
                        //Queue.Add(new DataToSend {
                        //    Bytes=new Data {
                        //        Cmd=Command.Message,
                        //        //  From=Setting.Name,
                        //        To=toServer,
                        //        Message="*warp-set "+word[1]+" "+PlayerX+" "+PlayerY,
                        //    }.ToByte(),
                        //    Importance=Importance.Middle
                        //});
                        DisplayText("Nastavuji warp "+word[1]);
                    }
                    break;

                case "*warp":
                    if (word.Length==2) {
                        //Queue.Add(new DataToSend {
                        //    Bytes=new Data {
                        //        Cmd=Command.Message,
                        //        //   From=Setting.Name,
                        //        To=toServer,
                        //        Message="*warp "+word[1],
                        //    }.ToByte(),
                        //    Importance=Importance.Middle
                        //});
                    }
                    break;

                case "*kick":
                    if (word.Length==2) {
                        //Queue.Add(new DataToSend {
                        //    Bytes=new Data {
                        //        Cmd=Command.Message,
                        //        //   From=Setting.Name,
                        //        To=toServer,
                        //        Message="*kick "+word[1],
                        //    }.ToByte(),
                        //    Importance=Importance.Middle
                        //});
                    }
                    break;

                case "*ban":
                    if (word.Length==2) {
                        //Queue.Add(new DataToSend {
                        //    Bytes=new Data {
                        //        Cmd=Command.Message,
                        //        //   From=Setting.Name,
                        //        To=toServer,
                        //        Message="*ban "+word[1],
                        //    }.ToByte(),
                        //    Importance=Importance.Middle
                        //});
                    }
                    break;

                case "*unban":
                    if (word.Length==2) {
                        //Queue.Add(new DataToSend {
                        //    Bytes=new Data {
                        //        Cmd=Command.Message,
                        //        //    From=Setting.Name,
                        //        To=toServer,
                        //        Message="*unban "+word[1],
                        //    }.ToByte(),
                        //    Importance=Importance.Middle
                        //});
                    }
                    break;

                case "*warp-remove":
                    if (word.Length==2) {
                        //Queue.Add(new DataToSend {
                        //    Bytes=new Data {
                        //        Cmd=Command.Message,
                        //        //   From=Setting.Name,
                        //        To=toServer,
                        //        Message="*warp-remove "+word[1],
                        //    }.ToByte(),
                        //    Importance=Importance.Middle
                        //});
                    }
                    break;

                case "*group-set":
                    if (word.Length==3) {
                        //Queue.Add(new DataToSend {
                        //    Bytes=new Data {
                        //        Cmd=Command.Message,
                        //        //   From=Setting.Name,
                        //        To=toServer,
                        //        Message="*group-set "+word[1]+" "+word[2],
                        //    }.ToByte(),
                        //    Importance=Importance.Middle
                        //});
                    }
                    break;

                case "*itemsclear":
                    //Queue.Add(new DataToSend {
                    //    Bytes=new Data {
                    //        Cmd=Command.Message,
                    //        //   From=Setting.Name,
                    //        To=toServer,
                    //        Message="*itemsclear",
                    //    }.ToByte(),
                    //    Importance=Importance.Middle
                    //});
                    break;

                case "*server-backup":
                    //Queue.Add(new DataToSend {
                    //    Bytes=new Data {
                    //        Cmd=Command.Message,
                    //        //   From=Setting.Name,
                    //        To=toServer,
                    //        Message="*server-backup",
                    //    }.ToByte(),
                    //    Importance=Importance.Middle
                    //});
                    break;

                case "*server-reset":
                    //Queue.Add(new DataToSend {
                    //    Bytes=new Data {
                    //        Cmd=Command.Message,
                    //        //  From=Setting.Name,
                    //        To=toServer,
                    //        Message="*server-reset",
                    //    }.ToByte(),
                    //    Importance=Importance.Middle
                    //});
                    break;

                case "*server-end":
                    //Queue.Add(new DataToSend {
                    //    Bytes=new Data {
                    //        Cmd=Command.Message,
                    //        //  From=Setting.Name,
                    //        To=toServer,
                    //        Message="*server-end",
                    //    }.ToByte(),
                    //    Importance=Importance.Middle
                    //});
                    break;

                case "*changepassword":
                    password=new Password();
                    password.Show();
                    break;

                case "*spawn-set":
                    //Queue.Add(new DataToSend {
                    //    Bytes=new Data {
                    //        Cmd=Command.Message,
                    //        //   From=Setting.Name,
                    //        To=toServer,
                    //        Message="*spawn-set "+PlayerX+" "+PlayerY,
                    //    }.ToByte(),
                    //    Importance=Importance.Middle
                    //});
                    break;

                case "*gamemode":
                    if (word.Length==2) {
                        if (word[1]=="Dobrodružná"||word[1]=="Výzkum"||word[1]=="Kreativní"
                            ||word[1]=="0"||word[1]=="1"||word[1]=="2"
                            ||word[1]=="d"||word[1]=="v"||word[1]=="k") {
                            //Queue.Add(new DataToSend {
                            //    Bytes=new Data {
                            //        Cmd=Command.Message,
                            //        //   From=Setting.Name,
                            //        To=toServer,
                            //        Message="*gamemode "+word[1],
                            //    }.ToByte(),
                            //    Importance=Importance.Middle
                            //});
                        } else DisplayText("Neplatný příkaz, zkus \"*help\"");
                    }
                    break;

                default:
                    DisplayText("Neplatný příkaz, zkus \"*help\"");
                    return;
            }
        }

        void OnReceive(IAsyncResult ar) {
            //Console.WriteLine("rec");
            try {
                clientSocket.EndReceive(ar);
            } catch (Exception ex) {
                if (ex.HResult==10054) {
                    //ShowError("Spojení bylo přerušeno", ex.Message);
                    //clientSocket.Shutdown(new SocketShutdown());
                    //clientSocket.Close();
                    //clientSocket.Dispose();
                    if (!exit) SolveErrorDuringGame(ex.HResult, "", "");
                    return;
                } else {
                    Console.WriteLine(ex.Message+" rec1");
                }
            }

           // Data msgReceived = new Data(byteData);
           // msgReceived.Talk();
           Command cmd=(Command)byteData[0];

            Console.WriteLine("Get: "+cmd.ToString("g"));

            switch (cmd) {
                case Command.SendingWorldData:
                    {
                //    if (msgReceived.terrain!=null) {
                //        if (msgReceived.terrain.Length>2) {
                //            Load(bytes: msgReceived.terrain, pos: msgReceived.pos);

                //            if (currentState==Current.GettingSpawn) {
                //                if (downloadedSpawnArea<downloadingSpawnAreaMax) {
                //                    SendMsgTerrain();
                //                } else {
                //                    state++;

                //                    currentState=Current.GettingPlayers;
                //                    SetMultiplayerLoadingText();
                //                    {
                //                        Data msg = new Data {
                //                            Cmd=Command.PlayersList,
                //                            //            From=Setting.Name,
                //                            To=toServer
                //                        };
                //                        Queue.Add(new DataToSend {
                //                            Bytes=msg.ToByte(),
                //                            Importance=Importance.High
                //                        });
                //                        //clientSocket.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
                //                    }
                //                }
                //            }
                //        } else {
                //            Debug.WriteLine("ERROR - Přijetí prázné zprávy. "+msgReceived.Cmd.ToString());
                //        }
                //    } else {
                //        Debug.WriteLine("ERROR - Přijetí prázné zprávy. "+msgReceived.Cmd.ToString());
                //    }
                }
                    break;

                case Command.EditTerrain:
                    {
                //    if (currentState==Current.Playing) {
                //        if (!string.IsNullOrEmpty(msgReceived.Message)) {
                //            string[] strs = msgReceived.Message.Split('|');
                //            Console.WriteLine("Editing: "+msgReceived.Message);
                //            List<byte> bytes = new List<byte>();
                //            if (strs.Length==5) {
                //                if (strs[4]!="") {
                //                    foreach (string s in strs[4].Split(',')) {
                //                        bytes.Add(byte.Parse(s));
                //                    }
                //                }
                //            }
                //            if (strs[0]=="+") {
                //                int x = int.Parse(strs[1]),
                //                    y = int.Parse(strs[2]);
                //                if (terrain[x]==null) break;
                //                byte id = byte.Parse(strs[3]);
                //                bool stay = true;

                //                {
                //                    Block b = SolidBlockFromId(id, new Vector2(x, y));
                //                    if (b!=null) {
                //                     //   if (terrain[x].IsSolidBlocks[y]) GetItemsFromBlock(id, x, y);
                //                        terrain[x].IsSolidBlocks[y]=true;
                //                        terrain[x].SolidBlocks[y]=b;
                //                        stay=false;
                //                    }
                //                }
                //                if (stay) {
                //                    Block b = TopBlockFromId(id, new Vector2(x, y));
                //                    if (b!=null) {
                //                    //    if (terrain[x].IsTopBlocks[y]) GetItemsFromBlock(id, x, y);
                //                        terrain[x].IsTopBlocks[y]=true;
                //                        terrain[x].TopBlocks[y]=b;
                //                        stay=false;
                //                    }
                //                }
                //                if (stay) {
                //                    Block b = BackBlockFromId(id, new Vector2(x, y));
                //                    if (b!=null) {
                //                     //   if (terrain[x].IsBackground[y]) GetItemsFromBlock(id, x, y);
                //                        terrain[x].IsBackground[y]=true;
                //                        terrain[x].Background[y]=null;
                //                        stay=false;
                //                    }
                //                }

                //                if (stay) {
                //                    Plant p = GetPlantFromId(id, (byte)y,/*?*/255, (short)x);
                //                    if (p!=null) {
                //                        foreach (Plant px in terrain[x].Plants) {
                //                            if (px.Height==y) {
                //                                //GetItemsFromPlant(id, new DInt(x, y), px.Grow==255);
                //                                terrain[x].Plants.Remove(px);
                //                                break;
                //                            }
                //                        }
                //                        stay=false;
                //                        terrain[x].Plants.Add(p);
                //                    }
                //                }


                //                //if (stay) {
                //                //    Block b=ani(id,new Vector2(x,y));
                //                //     if (b!=null) {
                //                //    foreach (Mob m in terrain[x].Mobs) {
                //                //        if (m.Height==y) {
                //                //            if (m.Id==id) {GetItemsFromBlock(id,new DInt(x,y));
                //                //                terrain[x].Mobs.Remove(m);
                //                //                stay=false;
                //                //                break;
                //                //            }
                //                //        }
                //                //    }
                //                //}
                //            } else {
                //                int x = int.Parse(strs[1]),
                //                    y = int.Parse(strs[2]);
                //                if (terrain[x]==null) break;
                //                byte id = byte.Parse(strs[3]);
                //                bool stay = true;

                //                if (terrain[x].IsSolidBlocks[y]) {
                //                    if (terrain[x].SolidBlocks[y].Id==id) {
                //                        terrain[x].IsSolidBlocks[y]=false;
                //                        terrain[x].SolidBlocks[y]=null;
                //                        stay=false;
                //                    }
                //                }
                //                if (stay) {
                //                    if (terrain[x].IsTopBlocks[y]) {
                //                        if (terrain[x].TopBlocks[y].Id==id) {
                //                            terrain[x].IsTopBlocks[y]=false;
                //                            terrain[x].TopBlocks[y]=null;
                //                            stay=false;
                //                        }
                //                    }
                //                }
                //                if (stay) {
                //                    if (terrain[x].IsBackground[y]) {
                //                        if (terrain[x].Background[y].Id==id) {
                //                            terrain[x].IsBackground[y]=false;
                //                            terrain[x].Background[y]=null;
                //                            stay=false;
                //                        }
                //                    }
                //                }

                //                if (stay) {
                //                    foreach (Plant p in terrain[x].Plants) {
                //                        if (p.Height==y) {
                //                            if (p.Id==id) {
                //                                terrain[x].Plants.Remove(p);
                //                                stay=false;
                //                                break;
                //                            }
                //                        }
                //                    }
                //                }
                //                if (stay) {
                //                    foreach (MMob m in terrain[x].Mobs) {
                //                        if (m.Height==y) {
                //                            if (m.Id==id) {
                //                                terrain[x].Mobs.Remove(m);
                //                                stay=false;
                //                                break;
                //                            }
                //                        }
                //                    }
                //                }
                //            }
                //        }
                //    }
                }
                    break;

                case Command.Login:
                    {
                        state++;
                        bool success = byteData[1]==1;

                        if (success) {
                            playerId = byteData[3] | (byteData[4]>>8) | (byteData[5]>>16) | (byteData[6]>>24);

                        //PlayerX = (byteData[7] | (byteData[8]>>8));
                        //PlayerY = byteData[9];

                        List<byte> bytesToSend = new() { (byte)Command.PlayerPosition
                        };
                        // bytesToSend.Add((byte)LoginType.BasicLogin);
                        AddStringToByteList(bytesToSend, Setting.Name);

                            Queue.Add(new DataToSend {
                                Bytes = bytesToSend.ToArray(),
                                Importance = Importance.VeryImportant
                            });

                            SendMsgTerrain();
                        } else {
                            ShowError("Nelze se připjit", "Server odmítl hráče připojit");
                        }


                    //if (msgReceived.Message!=null) {

                    //    string[] strs = msgReceived.Message.Split('|');
                    //    if (strs.Length>0) {
                    //        if (strs[0]=="0") {
                    //            //  Console.WriteLine("Wrong password!");
                    //            System.Windows.Forms.MessageBox.Show("Špatné heslo", "Pro připojení k serveru je potřeba zadat správné heslo");
                    //            // System.Windows.Forms.MessageBox.Show("Zadali jste špatné heslo","Špatné heslo");
                    //            clientSocket.Disconnect(false);
                    //            //   Rabcr.GoTo(new MenuMultiplayer());
                    //        } else if (strs[0]=="1") {
                    //            //Console.WriteLine("Setting vars");

                    //            TerrainLenght=int.Parse(strs[1]);
                    //            terrain=new MTerrain[TerrainLenght];
                    //            Console.WriteLine(TerrainLenght+" len");

                    //            for (int c = 0; c<TerrainLenght; c++) terrain[c]=new MTerrain();


                    //            Global.WorldDifficulty=int.Parse(strs[2]);
                    //            //  Global.WorldDifficulty=2;
                    //            //Console.WriteLine(Global.WorldDifficulty);
                    //            PlayerX=int.Parse(strs[3]);
                    //            PlayerY=int.Parse(strs[4]);
                    //            SetPlayerPos(PlayerX, PlayerY);
                    //            int i = 0;
                    //         //   for (; i<int.Parse(strs[5]); i+=2) Inventory.Add(new DInt(int.Parse(strs[6+i]), int.Parse(strs[7+i])));

                    //            //UseBackColor=bool.Parse(strs[6+i]);
                    //            //BackColor=StringToColor(strs[7+i]);

                    //            //UseGedo=bool.Parse(strs[8+i]);

                    //            //tpSpawn=bool.Parse(strs[6+i]);

                    //            //tpEverywhere=bool.Parse(strs[7+i]);
                    //            //tpPlayer=bool.Parse(strs[8+i]);
                    //            //tpPlayerMessage=bool.Parse(strs[9+i]);

                    //            //changeSpawn=bool.Parse(strs[10+i]);
                    //            //changeTerrainSpawn=bool.Parse(strs[11+i]);
                    //            //changeWarps=bool.Parse(strs[12+i]);

                    //            //  cmdRemoveItems=bool.Parse(strs[16+i]);

                    //            //allowFly=bool.Parse(strs[17+i]);
                    //            //allowChangeGametype=bool.Parse(strs[13+i]);

                    //            //cmdPing=bool.Parse(strs[14+i]);
                    //            //cmdMsg=bool.Parse(strs[15+i]);
                    //            //cmdMsgAll=bool.Parse(strs[16+i]);
                    //            //cmdLog=bool.Parse(strs[17+i]);
                    //            //cmdKick=bool.Parse(strs[18+i]);

                    //            //cmdServerEnd=bool.Parse(strs[19+i]);
                    //            //cmdServerReset=bool.Parse(strs[20+i]);
                    //            //cmdServerBackup=bool.Parse(strs[21+i]);

                    //            //    kit=bool.Parse(strs[27+i]);

                    //          //  safeSpawn=int.Parse(strs[22+i]);

                    //            //spawnX=int.Parse(strs[23+i]);
                    //            //spawnY=int.Parse(strs[24+i]);

                    //            //cmdWeb=bool.Parse(strs[31+i]);
                    //            // web=strs[32+i];
                    //            serverName=strs[25+i];
                    //            SendMsgTerrain();

                    //        }
                    //    }
                    //}
                }
                    break;

                case Command.GetStatus:
                    {
                    state++;
                    currentState=Current.EndLoging;
                    SetMultiplayerLoadingText();
                    if (!Directory.Exists(Setting.Path+"\\Servers")) Directory.CreateDirectory(Setting.Path+"\\Servers");
                    if (!Directory.Exists(Setting.Path+"\\Servers\\"+serverName)) Directory.CreateDirectory(Setting.Path+"\\Servers\\"+serverName);
                    if (!Directory.Exists(pathToWorld+"\\Earth")) Directory.CreateDirectory(pathToWorld+"\\Earth");

                    //if (string.IsNullOrEmpty(msgReceived.Message)) {
                    //    ShowError("Chyba sítě", "Hra obdržela nulový sáček při přihlašování");
                    //} else {
                    //    string[] strs = msgReceived.Message.Split('|');

                        switch ((LoginType)byteData[1]) {
                            case LoginType.Null:
                                ShowError("Chyba", "Hra obdržela nulový token přihlašování");
                                clientSocket.Disconnect(false);
                                break;

                            case LoginType.Banned:
                                ShowError("Zakázaný přístup", "Máte zakázaný přístup na tento server");
                                clientSocket.Disconnect(false);
                                break;

                            case LoginType.BannedWithInfo:
                             //   ShowError("Zakázaný přístup", "Máte zakázaný přístup na tento server"+Environment.NewLine+strs[1]);
                                clientSocket.Disconnect(false);
                                break;

                            case LoginType.NotOnWhitelist:
                             //   ShowError("Nejste na whitelistu", "Název vašeho jména není zapsán ve whitelistu"+Environment.NewLine+strs[1]);
                                clientSocket.Disconnect(false);
                                break;

                            case LoginType.NotOnWhitelistNoInfo:
                                ShowError("Nejste na whitelistu", "Název vašeho jména není zapsán ve whitelistu");
                                clientSocket.Disconnect(false);
                                break;

                            case LoginType.FirstConnectPassword:
                                {
                            using Password p = new();
                            p.ShowDialog();
                            if (p.Output != null) {
                                //Data msg = new Data {
                                //    Cmd=Command.SetPassword,
                                //    //    From=Setting.Name,
                                //    To=toServer,
                                //    Message=p.Output
                                //};

                                //Queue.Add(new DataToSend {
                                //    Bytes=msg.ToByte(),
                                //    Importance=Importance.VeryImportant
                                //});
                                //clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
                            }
                            else {
                                clientSocket.Disconnect(false);
                            }
                        }
                                break;

                            case LoginType.LoginWithPassword:
                                {
                                    using CheckPassword p = new();
                                    p.ShowDialog();

                                    if (p.Output != null) {
                                        //Data msg = new Data {
                                        //    Cmd = Command.SetPassword,
                                        //    //      From=Setting.Name,
                                        //    To = toServer,
                                        //    Message = p.Output
                                        //};

                                        ////  byteData=msg.ToByte();
                                        //Queue.Add(new DataToSend {
                                        //    Bytes = msg.ToByte(),
                                        //    Importance = Importance.VeryImportant
                                        //});
                                        //clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
                                    } else {
                                        clientSocket.Disconnect(false);
                                    }
                                }
                                break;

                            case LoginType.BasicLogin:
                                {
                            //Data msg = new Data {
                            //    Cmd=Command.SetPassword,
                            //    //    From=Setting.Name,
                            //    To=toServer,
                            //    Message=""
                            //};
                            List<byte> bytesToSend = new() { (byte)Command.Login,
                                (byte)LoginType.BasicLogin
                            };
                            AddStringToByteList(bytesToSend, Setting.Name);

                                Queue.Add(new DataToSend {
                                    Bytes = bytesToSend.ToArray(),
                                    Importance = Importance.VeryImportant
                                });
                         //   byteData = msg.ToByte();

                            //clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
                            }
                            break;

                            case LoginType.FirstConnect:
                                {
                                    //Data msg = new Data {
                                    //    Cmd = Command.SetPassword,
                                    //    //    From=Setting.Name,
                                    //    To = toServer,
                                    //    Message = ""
                                    //};
                                    List<byte> bytesToSend = new();
                                    bytesToSend.Add((byte)Command.Login);
                                    bytesToSend.Add((byte)LoginType.FirstConnect);
                                    AddStringToByteList(bytesToSend, Setting.Name);

                                    Queue.Add(new DataToSend {
                                        Bytes = bytesToSend.ToArray(),
                                        Importance = Importance.VeryImportant
                                    });
                                 //   byteData = msg.ToByte();

                                   // clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
                                }
                                break;

                        }
                  //  }



                    //if (strs.Length>0) {
                    //    switch (strs[0]) {
                    //        case "0":
                    //            if (strs.Length==3) {
                    //                ShowError("Zakázaný přístup", "Máte zakázaný přístup na server"+Environment.NewLine+strs[1]+Environment.NewLine+"zkuste tento web: "+strs[2]);
                    //            } else ShowError("Chybná konfigurace", "Sáček k přihlašování neodpovídá sestavení");
                    //            break;

                    //        case "1":
                    //            if (strs.Length==2) {
                    //                ShowError("Zakázaný přístup", "Máte zakázaný přístup na server"+Environment.NewLine+strs[1]);
                    //            } else ShowError("Chybná konfigurace", "Sáček k přihlašování neodpovídá sestavení");
                    //            break;

                    //        case "2":
                    //            if (strs.Length==4) {
                    //                int x = int.Parse(strs[0]);
                    //                int y = int.Parse(strs[1]);
                    //                string password = strs[2];
                    //                int type = int.Parse(strs[3]);

                    //                if (password!="") {
                    //                    chp=new CheckPassword();
                    //                    chp.Show();
                    //                    waitingPassword=true;
                    //                    this.password=password;
                    //                }
                    //                ShowError("Zakázaný přístup", "Máte zakázaný přístup na server"+Environment.NewLine+strs[1]);
                    //            } else ShowError("Chybná konfigurace", "Sáček k přihlašování neodpovídá sestavení");
                    //            break;

                    //        case "3":
                    //            if (strs.Length==2) {
                    //                ShowError("Nejste v seznamu", "Kontaktujte majtele serveru a požádejteho o členství"+Environment.NewLine+strs[1]);
                    //            } else ShowError("Chybná konfigurace", "Sáček k přihlašování neodpovídá sestavení");
                    //            break;

                    //        case "4":
                    //            if (strs.Length==1) {
                    //                ShowError("Nejste v seznamu", "Kontaktujte majtele serveru a požádejteho o členství");
                    //            } else ShowError("Chybná konfigurace", "Sáček k přihlašování neodpovídá sestavení");
                    //            break;

                    //        case "5":

                    //            break;
                    //    }
                    //}

                    //int.TryParse(strs[1], out spawnX);
                    //int.TryParse(strs[2], out spawnY);
                    //int.TryParse(strs[3], out safeSpawn);

                    //PlayerX=spawnX;
                    //PlayerY=spawnY;

                    //SendMsgTerrain();
                    state++;
                }
                    break;

                //case Command.Logout:
                //    clientSocket.Disconnect(false);
                //    break;

                case Command.PlayersTeleportMessageToSource:
                    {
                    //if (!string.IsNullOrEmpty(msgReceived.Message)) {
                    //    string[] strs = msgReceived.Message.Split('|');

                    //    if (int.TryParse(strs[0], out int num)) {
                    //        if (num==1) {
                    //            //DisplayText("Vaše žádost byla zamítnuta");
                    //        }
                    //        if (num==2) {
                    //            if ((DateTime.Now-tpPlayerTime.Date).TotalMinutes<=2) {
                    //                foreach (Player p in players) {
                    //                    if (tpPlayerMsgWaiting==p.name) {
                    //                        //    DisplayText("Teleportuji...");
                    //                        text="Teleportuji...";
                    //                        PlayerX=p.x;
                    //                        PlayerY=p.y;
                    //                        break;
                    //                    }
                    //                }
                    //            }
                    //        }
                    //        if (num==3) {
                    //            if (strs[1]==Setting.Name) {
                    //                //SomeoneWantTeleportToYou=true;
                    //                SomeoneWantTeleportToYouName=msgReceived.From;
                    //                gedo.BuildString("Hráč "+SomeoneWantTeleportToYouName+" se chce k vám teleportovat.\r\nPoužij \"*tp-allow\" pro přijení nebo \"*tp-deny\" pro zamítnutí.");
                    //                diserpeard=255;
                    //            }
                    //        }
                    //    }
                    //}
                }
                break;

                case Command.Message:
                    {
                    //if (msgReceived.Message!=null||msgReceived.Message!="") {
                    //    if (msgReceived.Message.StartsWith("*")) {
                    //        string[] word = msgReceived.Message.Split(' ');
                    //        switch (word[0]) {
                    //            case "*setplayerpos":
                    //                if (word.Length==3) {
                    //                    PlayerX=int.Parse(word[1]);
                    //                    PlayerY=int.Parse(word[2]);
                    //                    DisplayText("Teleportuji...");
                    //                    SetPlayerPos(PlayerX, PlayerY);
                    //                }
                    //                break;

                    //            case "*spawnwaschanged":
                    //                spawnX=int.Parse(word[1]);
                    //                spawnY=int.Parse(word[2]);
                    //                break;

                    //            case "*int-set": {
                    //                int count = int.Parse(word[1]);

                    //                List<DInt> tmpInv = new List<DInt>();

                    //                //for (int i = 0; i<count; i++) {
                    //                //    Inventory[i].X=2+i*2;
                    //                //    Inventory[i].Y=3+i*2;
                    //                //}
                    //            }
                    //            break;

                    //            case "*inv-machine-set": {
                    //                int
                    //                    x = int.Parse(word[1]),
                    //                    y = int.Parse(word[2]),
                    //                    count = int.Parse(word[3]);

                    //                //List<DInt> tmpInv = new List<DInt>();

                    //                //for (int i = 0; i<count; i++) {
                    //                //    tmpInv.Add(new DInt(4+i*2, 5+i*2));
                    //                //}

                    //                //if (terrain[x].TopBlocks[y] is BoxBlock) {
                    //                //    ((BoxBlock)terrain[x].TopBlocks[y]).Inv=tmpInv;
                    //                //} else if (terrain[x].TopBlocks[y] is MashineBlockBasic) {
                    //                //    ((MashineBlockBasic)terrain[x].TopBlocks[y]).Inv=tmpInv;
                    //                //} else if (terrain[x].TopBlocks[y] is ShelfBlock) {
                    //                //    ((ShelfBlock)terrain[x].TopBlocks[y]).Inv=tmpInv;
                    //                //}
                    //                getFromServerInv=true;
                    //            }
                    //            break;
                    //        }
                    //    } else {
                    //        gedo.BuildString(msgReceived.Message);
                    //        diserpeard=255;
                    //    }
                    //}
                    ////Loading=false;
                    ////if (msgReceived.strName=="{Server}") {
                    ////    Console.WriteLine(msgReceived.strName+"<>"+msgReceived.cmdCommand.ToString()+"<>"+msgReceived.strMessage);
                    ////} else Console.WriteLine("!jméno "+msgReceived.strName);
                    }
                    break;

                //case Command.Request:
                //    {
                //        Data msg = new Data {
                //            Cmd=Command.Request,
                //            //    From=Setting.Name,
                //            To=toServer,
                //            Message=""
                //        };
                //        //byteData=new byte[1024];
                //        //byteData=msg.ToByte();

                //        //clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
                //        Queue.Add(new DataToSend {
                //            Bytes=msg.ToByte(),
                //            Importance=Importance.VeryImportant
                //        });
                //    }
                //    break;

                case Command.Check:
                    {
                        state++;
                        // Version
                        byte lenVersion = byteData[1];
                        string version=System.Text.Encoding.UTF8.GetString(byteData, 2, lenVersion);

                        if (version==Release.VersionString) {

                            // Message
                            int pos=3+lenVersion;
                            int lenMessage=byteData[pos];
                            string serverMessage=System.Text.Encoding.UTF8.GetString(byteData, pos, lenMessage);

                            pos+=lenMessage+1;
                            joinedPlayers=byteData[pos];
                            maxplayers=byteData[pos+1];

                            Debug.WriteLine("G|"+version+'|'+serverMessage+'|'+joinedPlayers+'|'+maxplayers);

                            // Ask server what I need to join server
                            List<byte> bytesToSend=new();
                            bytesToSend.Add((byte)Command.GetStatus);

                            Queue.Add(new DataToSend {
                                Bytes=bytesToSend.ToArray(),
                                Importance=Importance.VeryImportant
                            });
                            //clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
                        } else ShowError("Jiná verze serveru", "Verze serveru ("+version+") je rozdílná od verze hry.");

            //        string[] get = msgReceived.Message.Split('|');

            //        if (get.Length > 0) {
            //            maxplayers = int.Parse(get[1]);
            //            joinedPlayers = int.Parse(get[2]);
            //            string version = get[3];
            //            //smd=true;
            //            if (version == Release.VersionString) {
            //                Data msg = new Data {
            //                    Cmd = Command.Login,
            //                    //   From=Setting.Name,
            //                    To = toServer,
            //                    //Message=Setting.Name
            //                };
            //                //byteData=msg.ToByte();
            //                currentState = Current.EndChecking;
            //                SetMultiplayerLoadingText();
            //                //clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
            //                Queue.Add(new DataToSend {
            //                    Bytes = msg.ToByte(),
            //                    Importance = Importance.VeryImportant
            //                });
            //            } else {

            //            }
            //        } else {
            //            ShowError("Chyba sáčku", "Hra obdržela od serveru prázdný soubor s informacemi.");
            //        }
            //        Console.WriteLine(msgReceived.strMessage);
            //        string _new = msgReceived.strMessage;
            //        string version = _new.Substring(_new.LastIndexOf("|") + 1);
            //        _new = _new.Substring(0, _new.LastIndexOf("|"));
            //        int.TryParse(_new.Substring(_new.LastIndexOf("|") + 1), out maxplayers);
            //        _new = _new.Substring(0, _new.LastIndexOf("|"));
            //        int.TryParse(_new.Substring(_new.LastIndexOf("|") + 1), out joinedPlayers);
            //        _new = _new.Substring(0, _new.LastIndexOf("|"));
            //        Console.WriteLine("sdfgdfgfdf");
            //        if
            //            if (joinedPlayers < maxplayers) {
            //             //   OK ////////////////////////////////////////



            //          }
            //        Console.WriteLine("Logining...");
            //        state++;

            //    } else {
            //        Error = true;
            //        ErrorCode = "Server je plný.";
            //        Console.WriteLine("Moc hráčů.");
            //        clientSocket.Disconnect(false);
            //        clientSocket.Close();
            //        clientSocket.Dispose();
            //    }
            //} else {
            //    Error = true;
            //    ErrorCode = "Server je pro jinou verzi.";
            //    Console.WriteLine("Jiná verze.");
            //    clientSocket.Disconnect(false);
            //    clientSocket.Close();
            //    clientSocket.Dispose();
            //}
        }
                break;

                case Command.Exit:
                    //Queue.Add(new DataToSend {
                    //    Bytes=new Data {
                    //        //   From=Setting.Name,
                    //        To=toServer,
                    //        Message="*beforeexitdata "+PlayerX+" "+PlayerY,//+inv...
                    //        Cmd=Command.Message
                    //    }.ToByte(),
                    //    Importance=Importance.VeryImportant
                    //});
                    //closingServer=true;
                    break;

                case Command.PlayersList: {
                    //players.Clear();
                    //foreach (string h in msgReceived.Message.Split('~')) {
                    //    if (h!="") {
                    //        string[] splited = h.Split('|');

                    //        Player player = new Player(splited[0]) {
                    //            x=int.Parse(splited[1]),
                    //            y=int.Parse(splited[2])
                    //        };
                    //        players.Add(player);
                    //    }
                    //}

                    //if (currentState==Current.GettingPlayers) {
                    //    currentState=Current.Playing;
                    //    SetMultiplayerLoadingText();
                    //    //Resize();
                    //}
                }
                break;
            }

            if (Queue.Count == 0) {
                // if (cmd==Command.Blank)
                //   System.Threading.Thread.Sleep(10);
                //  else System.Threading.Thread.Sleep(5);
                //Data data = new Data {
                //    //   From=Setting.Name,
                //    To = toServer,
                //    Cmd = Command.Blank
                //};
                List<byte> bytesToSend = new() {
                    (byte)Command.Blank
                };
                try {
                    byte[] bytes = bytesToSend.ToArray();
                    clientSocket.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
                } catch (Exception ex) { Console.WriteLine(ex.Message + "1"); }
            } else {
                try {
                    byte[] bytes = Queue[0].Bytes;
                    Console.WriteLine("SEND: "+((Command)Queue[0].Bytes[0]).ToString());
                    Queue.RemoveAt(0);
                    clientSocket.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
                } catch (Exception ex) { Console.WriteLine(ex.Message + "2"); }
            }



            ////////if (!closingServer){
            ////////    byteData=new byte[1024];

            ////////    try {
            ////////        clientSocket.BeginReceive(byteData,
            ////////            0,
            ////////            byteData.Length,
            ////////            SocketFlags.None,
            ////////            new AsyncCallback(OnReceive),
            ////////            clientSocket);
            ////////    } catch (Exception ex) {
            ////////        if (ex.HResult==10054) {
            ////////            ShowError("Spojení bylo přerušeno", ex.Message);
            ////////            clientSocket.Shutdown(new SocketShutdown());
            ////////            clientSocket.Close();
            ////////            clientSocket.Dispose();
            ////////            return;
            ////////        }else{
            ////////            Console.WriteLine(ex.Message+"12");
            ////////        }
            ////////    }
            ////////} else {
            ////////    clientSocket.Shutdown(new SocketShutdown());
            ////////    current=Current.Checking;
            ////////    clientSocket.Disconnect(false);
            ////////    clientSocket.Close();
            //////// //   clientSocket.Dispose();
            ////////    ShowError("Server byl ukončen","Server se vypnul ze strany serveru");
            ////////       // Rabcr.GoTo(new Menu());
            ////////}
            //if (msgReceived.strMessage != null && msgReceived.cmdCommand != Command.List) {
            //    chat += msgReceived.strMessage + "\r\n";
            //    Console.WriteLine("G " + msgReceived.strMessage);
            //    foreach (Player p in players) {//Console.WriteLine(0);
            //        if (p.name == msgReceived.strName) {//Console.WriteLine(1);
            //            string data = msgReceived.strMessage.Replace(msgReceived.strName + ": ", "");
            //            if (data.StartsWith("X")) {//Console.WriteLine(2);

            //                //for (int i=0; i<players.Count; i++) {
            //                //   Console.WriteLine(3);
            //                //if (players[i].name==msgReceived.strName) {
            //                Console.WriteLine(data);
            //                p.x = int.Parse(data.Substring(1, data.IndexOf(" ")));
            //                p.y = int.Parse(data.Substring(data.IndexOf("Y") + 1));
            //                break;
            //                //}
            //            }
            //        }//}
            //    }
            //}


            //byteData = new byte[1024];

            //clientSocket.BeginReceive(byteData,
            //                          0,
            //                          byteData.Length,
            //                          SocketFlags.None,
            //                          new AsyncCallback(OnReceive),
            //                          null);

            //    }
            //            catch (ObjectDisposedException) { }
            //            catch (Exception ex) {
            //                Console.WriteLine("E"+ex.Message);
            //            }
            //            }catch (SocketException ex) {
            //    if (ex.SocketErrorCode.ToString() == "10054") {
            //        Console.WriteLine("Konec");
            //        return;
            //        throw ex;
            //    }
            //}
            //if (!closingServer) {
            byteData = new byte[1024];

            try {
                clientSocket.BeginReceive(byteData,
                    0,
                    byteData.Length,
                    SocketFlags.None,
                    new AsyncCallback(OnReceive),
                    clientSocket);
            } catch (Exception ex) {
                if (ex.HResult == 10054) {
                    ShowError("Spojení bylo přerušeno", ex.Message);
                    clientSocket.Shutdown(new SocketShutdown());
                    clientSocket.Close();
                    clientSocket.Dispose();
                    return;
                } else {
                    Console.WriteLine(ex.Message + "12");
                }
            }
            //} else {
            //    clientSocket.Shutdown(new SocketShutdown());
            //    current = Current.Checking;
            //    clientSocket.Disconnect(false);
            //    clientSocket.Close();
            //    //   clientSocket.Dispose();
            //    ShowError("Server byl ukončen", "Server se vypnul ze strany serveru");
            //    // Rabcr.GoTo(new Menu());
            //}
        }

        void SendData(byte[] bytes, bool response) {
            try {
                clientSocket.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message+"2");
            }

            if (response) {
                //    if (!closingServer){
                try {
                    clientSocket.BeginReceive(bytes,
                        0,
                        bytes.Length,
                        SocketFlags.None,
                        new AsyncCallback(OnReceive),
                        clientSocket);
                } catch (Exception ex) {
                    if (ex.HResult==10054) {
                        ShowError("Spojení bylo přerušeno", ex.Message);
                        clientSocket.Shutdown(new SocketShutdown());
                        clientSocket.Close();
                        clientSocket.Dispose();
                        return;
                    } else {
                        Console.WriteLine(ex.Message+"x");
                    }
                }
            }
        }

        void SendMsgTerrain() {
            //currentState=Current.GettingSpawn;
            //SetMultiplayerLoadingText();
            ////Data msgToSend = new Data {
            ////    Cmd = Command.GetWorldData,
            ////    //   From=Setting.Name,
            ////    To = toServer,
            ////};

            //if (PlayerX < 424)
            //    PlayerX = 424;
            //int xx = (int)(PlayerX - Global.WindowWidthHalf / (16 * Setting.Zoom)) / 16 + downloadedSpawnArea;
            //if (xx < TerrainLenght) {
            //    terrain[xx].state = MChunkState.SendRequest;
            //    if (xx < 0) {
            //        msgToSend.Message = world + "|" + (TerrainLenght - PlayerX / 16 - xx).ToString();
            //    } else
            //        msgToSend.Message = world + "|" + xx.ToString();

            //    downloadedSpawnArea++;
            //    state++;
            //    Queue.Add(new DataToSend { Bytes = msgToSend.ToByte(), Importance = Importance.VeryImportant });
            //} else {
            //    state++;

            //    currentState = Current.GettingPlayers;
            //    SetMultiplayerLoadingText();
            //    {
            //        Data msg = new Data {
            //            Cmd = Command.PlayersList,
            //            //            From=Setting.Name,
            //            To = toServer
            //        };
            //        Queue.Add(new DataToSend {
            //            Bytes = msg.ToByte(),
            //            Importance = Importance.High
            //        });
            //        //clientSocket.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
            //    }
            //}
            ////   clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);

        }

        void SendRequestChunk(int pos) {
            terrain[pos].state=MChunkState.SendRequest;
            terrain[pos].sended=DateTime.Now;
            //Queue.Add(
            //    new DataToSend {
            //        Bytes=new Data {
            //            Cmd=Command.GetWorldData,
            //            //     From=Setting.Name,
            //            To=toServer,
            //            Message=world+"|"+pos.ToString()
            //        }.ToByte(),
            //        Importance=Importance.VeryImportant
            //    });
        }

        void OnConnectDuringGameError(IAsyncResult ar) {

            try {

                clientSocket.EndConnect(ar);

                //Data msgToSend = new Data {
                //    Cmd=Command.ConnectDuringGame,
                //    //       From=Setting.Name,
                //    To=toServer,
                //    Message=""
                //};
                List<byte> bytesToSend = new() {
                    (byte)Command.ConnectDuringGame
                };
                AddStringToByteList(bytesToSend,Setting.Name);

                byteData=bytesToSend.ToArray();
                clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);

                byteData=new byte[1024];
                clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);

                //current=Current.EndChecking;
                state++;
            } catch (SocketException ex) {

                //Nemohlo být vytvořeno žádné připojení, protože cílový počítač je aktivně odmítl
                if (10061==ex.ErrorCode) {
                    ShowError("Nelze se připojit k serveru", "Pravděpodobně není spuštěn server.");
                } else {
                    //Pokus o připojení selhal, protože připojená strana v časovém intervalu řádně neodpověděla, nebo vytvořené připojení selhalo, protože neodpověděl připojený hostitel
                    if (10060==ex.ErrorCode) {
                        ShowError("Nelze se připojit k serveru", "Připojování trvalo příliš dlouho.");
                    } else {
                        ShowError("Nelze se připojit k serveru", "Neznámá chyba v OnConnectDuringGameError: "+ex.Message);
                    }
                }
            }
        }

        void OnSend(IAsyncResult ar) {
            try {
                // clientSocket.Connected
                //Process=0.55f;
                clientSocket.EndSend(ar);
                //Process=1f;
                //ready=true;
                //Loading=false;
            } catch (SocketException ex) {
                //Console.WriteLine(ex.ErrorCode+" 2 "+ex.Message);
                ////Process=1f;
                //ready=true;
                //Error=true;
                //ErrorCode=ex.Message;
                if (!exit) ShowError("Nelze odeslat sáček", ""+ex.Message);
            }
 //Console.WriteLine(byteData);
            //    Console.WriteLine("send");
        }

        void SendEveryone(string text) {
            try {
                //Fill the info for the message to be send
                //Data msgToSend = new Data {
                //    //Console.WriteLine(text);
                //    //      From=Setting.Name,
                //    To=toEveryone,
                //    Message=text,
                //    Cmd=Command.Message
                //};

                ////byte[] byteData =
                //Queue.Add(new DataToSend {
                //    Bytes=msgToSend.ToByte(),
                //    Importance=Importance.High
                //});
                //Send it to the server
                //clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSendAfter), null);
                // Console.WriteLine("sending: "+System.Text.Encoding.UTF8.GetString(byteData));
                // txtMessage.Text = null;
            } catch (Exception) {
                //Console.WriteLine("Unable to send message to the server.");
            }
        }

        void ShowError(string main, string toShow) {
            Error=true;
            ErrorHeader=main;
            ErrorText=toShow;
            currentState=Current.ErrorDuringGame;
            textHeader=new TextWithMeasure(ErrorHeader,0,0);
            textMore=new TextWithMeasure(ErrorText,0,0);

            textHeader.ChangePosition(Global.WindowWidthHalf-textHeader.MeasureX/2, Global.WindowHeightHalf-30/2);
            textMore.ChangePosition(Global.WindowWidthHalf-textMore.MeasureX/2, Global.WindowHeightHalf+30/2);
        }

           void SetMultiplayerLoadingText(){
            switch (currentState) {
                case Current.Checking:
                    textHeader=new TextWithMeasure("Připojování...",0,0);
                  //  textHeader.Draw(spriteFont_big, (int)((Global.WindowWidth-spriteFont_big.MeasureString().X)/2), Global.WindowHeightHalf-50, "Připojování...", Color.Black);
                    break;

                case Current.EndChecking:
                    textHeader=new TextWithMeasure("Přihlašování...",0,0);
                 //   textHeader.Draw(spriteFont_big, (int)((Global.WindowWidth-spriteFont_big.MeasureString().X)/2), Global.WindowHeightHalf-50, "Připojování...", Color.Black);
                    break;

                case Current.EndLoging:
                    textHeader=new TextWithMeasure("Přihlašování...",0,0);
                 //   textHeader.Draw(spriteFont_big, (int)((Global.WindowWidth-spriteFont_big.MeasureString().X)/2), Global.WindowHeightHalf-50, "Připojování...", Color.Black);
                    break;

                case Current.Loging:
                    textHeader=new TextWithMeasure("Přihlašování...",0,0);
                  //  textHeader.Draw(spriteFont_big, (int)((Global.WindowWidth-spriteFont_big.MeasureString().X)/2), Global.WindowHeightHalf-50, "Připojování...", Color.Black);
                    break;

                case Current.SendingBasic:
                    textHeader=new TextWithMeasure("Přihlašování...",0,0);
                  //  textHeader.Draw(spriteFont_big, (int)((Global.WindowWidth-spriteFont_big.MeasureString().X)/2), Global.WindowHeightHalf-50, "Připojování...", Color.Black);
                    break;

                case Current.GettingSpawn:
                    textHeader=new TextWithMeasure("Získávání terénu",0,0);
                  //  textHeader.Draw(spriteFont_big, (int)((Global.WindowWidth-spriteFont_big.MeasureString().X)/2), Global.WindowHeightHalf-50, "Získávání terénu", Color.Black);
                    break;

                case Current.GettingPlayers:
                    textHeader=new TextWithMeasure("Informace o hráčích",0,0);
                 //   textHeader.Draw(spriteFont_big, (int)((Global.WindowWidth-spriteFont_big.MeasureString().X)/2), Global.WindowHeightHalf-50, "Načítání herních komponent", Color.Black);
                    break;

                case Current.LoadingAssets:
                    textHeader=new TextWithMeasure("Herních komponent",0,0);
                  //  textHeader.Draw(spriteFont_big, (int)((Global.WindowWidth-spriteFont_big.MeasureString().X)/2), Global.WindowHeightHalf-50, "Načítání herních komponent", Color.Black);
                    break;
            }
            textHeader.ChangePosition(Global.WindowWidthHalf-textHeader.MeasureX/2, Global.WindowHeightHalf-30/2);
        //}
          //  textHeader=new TextWithMeasure(,0,0);//.Draw(spriteFont_big, (int)((Global.WindowWidth-spriteFont_big.MeasureString("Připojování...").X)/2), Global.WindowHeightHalf-50, "Připojování...", Color.Black);
        }

    }
    #endif
}
