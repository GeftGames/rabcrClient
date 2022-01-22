using System;
using System.Collections.Generic;

namespace rabcrClient {
    //public enum Command : byte{
    //    Null,
    //    Check,   //Status of server
    //    Blank,
    //    Login,      // Login into the server
    //    EnterPassword,  // Check password enter
    //    Logout,     // Logout of the server
    //    Exit,       // End
    //    Message,    // Send a text message to all the chat clients
    //    PlayersList,       //Get a list of users in the chat room from the server

    //    SendingWorldData, //Get chunk of blocks
    //    GetWorldData,
    //   // GetSpawn,
    //    PlayersTeleportMessageToTarget,
    //    PlayersTeleportMessageToSource,
    //    MyPlayerData,        //get pos of player
    //    Request,    //Check if player exists
    //    EditTerrain,

    //    SomeoneLogout,
    //    //SomeoneLogin,
    //    ConnectDuringGame,

    //    EatFood,
    //    SetInventory,
    //    SetInventoryMachine,
    //    SpawnChanged,
    //    SetPlayerPosition,

    //}

    public class DataToSend {
        public DataToSend(){
            Created=DateTime.Now;
        }

        //public Data data;
        public byte[] Bytes;
        public DateTime Created;
        public Importance Importance;

        public int GetWaitingMiliseconds{
            get{return (int)(DateTime.Now-Created).TotalMilliseconds;}
        }
    }

    public enum Importance {
        Trash,
        Low,
        Middle,
        High,
        VeryImportant,
    }

    class Player {
        public int x=50;
        public int y=50;
        public string name;

        public Player(string Name){
            name=Name;
        }
    }

    enum Current {
        Checking,
        EndChecking,
        Loging,
        EndLoging,
        SendingBasic,
        GettingSpawn,
        GettingPlayers,
        LoadingAssets,
        Playing,
        ErrorDuringGame,
    }

    enum LoginType{
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

    //class Data {
    //    // <tot bytes> <type>
    //    //    1        Command
    //    //    1        len to
    //    //    1       len from
    //    //    2      message len
    //    //  lenTo      name to
    //    // lenFrom    name from
    //    //messageLen   message
    //    // <fill>       zeros

    //    public string From;
    //    public string To;
    //    public string Message;
    //    public Command Cmd;

    //    public byte[] terrain;
    //    public int pos;

    //    public Data(){ From=Setting.Name; }

    //    public Data(byte[] data) {
    //        // Command
    //        Cmd=(Command)data[0];

    //        //len to
    //        byte lenTo = data[1];

    //        //len from
    //        byte lenFrom = data[2];

    //        // message length
    //        short msgLen = BitConverter.ToInt16(data, 3);

    //        // name to
    //        if (lenTo>0) To=System.Text.Encoding.UTF8.GetString(data, 5, lenTo);
    //        else To="";

    //        // name from
    //        if (lenFrom>0) From=System.Text.Encoding.UTF8.GetString(data, 5+lenTo, lenFrom);
    //        else From="";

    //        //message
    //        if (msgLen==0) {
    //            Message="";
    //            return;
    //        }

    //        if (Cmd==Command.SendingWorldData) {
    //            if (msgLen<1024-lenTo-lenFrom-5) {
    //                terrain=new byte[msgLen];
    //                pos = BitConverter.ToInt16(data, 5+lenFrom+lenTo);
    //                Array.Copy(data, 5+lenFrom+lenTo+2, terrain, 0, msgLen-2);
    //            } //else Console.WriteLine("Velká zpráva");
    //        } else {
    //            Message=System.Text.Encoding.UTF8.GetString(data, 5+lenFrom+lenTo, msgLen);
    //        }
    //    }

    //    public byte[] ToByte() {
    //        if (Message==null) Message="";

    //        byte[] bytesTo =System.Text.Encoding.UTF8.GetBytes(To);
    //        byte[] bytesFrom = System.Text.Encoding.UTF8.GetBytes(From);
    //        byte[] bytesMessage = System.Text.Encoding.UTF8.GetBytes(Message);

    //        List<byte> bytes=new List<byte>(){
    //            // Command
    //            (byte)Cmd,

    //            // len to
    //            (byte)bytesTo.Length,

    //            // len from
    //            (byte)bytesFrom.Length,
    //        };

    //        //len message
    //        bytes.AddRange(BitConverter.GetBytes((short)bytesMessage.Length));

    //        // to
    //        bytes.AddRange(bytesTo);

    //        // from
    //        bytes.AddRange(bytesFrom);

    //        // message
    //        bytes.AddRange(bytesMessage);

    //        return bytes.ToArray();
    //    }

    //    public byte[] ToByte(byte[] terrain, short myPos) {
    //        byte[] bytesTo =System.Text.Encoding.UTF8.GetBytes(To);
    //        byte[] bytesFrom = System.Text.Encoding.UTF8.GetBytes(From);

    //        List<byte> bytes=new List<byte>(){
    //            // Command
    //            (byte)Cmd,

    //            // len to
    //            (byte)bytesTo.Length,

    //            // len from
    //            (byte)bytesFrom.Length,
    //        };

    //        //len message
    //        bytes.AddRange(BitConverter.GetBytes((short)(terrain.Length+2)));

    //        // to
    //        bytes.AddRange(bytesTo);

    //        // from
    //        bytes.AddRange(bytesFrom);

    //        // message
    //        bytes.AddRange(BitConverter.GetBytes(myPos));
    //        bytes.AddRange(terrain);

    //        return bytes.ToArray();
    //    }

    //    public string Talk() {
    //        if (Cmd==Command.SendingWorldData) {

    //            string h="";
    //            foreach (byte c in terrain){
    //                string k=c.ToString();

    //                if (k.Length==1) h+="   "+k+Environment.NewLine;
    //                else if (k.Length==2) h+="  "+k+Environment.NewLine;
    //                else h+=" "+k+Environment.NewLine;
    //            }

    //            return "Cmd: "+Command.SendingWorldData+", From: "+From+", To: "+To+" Pos: "+pos+", Terrain: "+Environment.NewLine+h;

    //        } else if (Cmd!=Command.Blank){
    //            return "Cmd: "+Cmd+", From: "+From+", To: "+To+", Message: "+Message;
    //        }
    //        return "";
    //    }
    //}

    //static class BasicDataOut {
    //    public static void GetBasicData(byte[] data, out Command cmd, out ushort toPlayerId, out ushort fromPlayerId, out byte[] byteData) {
    //        // Command
    //        cmd = (Command)data[0];

    //        // len to player
    //        toPlayerId = (ushort)(data[2] << 8 | data[1]);

    //        // len from player (server)
    //        fromPlayerId = (ushort)(data[4] << 8 | data[3]);

    //        // lenght data
    //        int len = data[6] << 8 | data[5];

    //        // message length
    //        byteData = data.SubBytes(7, len - 7);
    //    }
    //}


    class TerrainData {
        // <tot bytes> <type>
        //    1        Command
        //    1        len to
        //    1       len from
        //    2      message len
        //  lenTo      name to
        // lenFrom    name from
        //messageLen   message
        // <fill>       zeros

        public string From;
        public string To;
        public string Message;
        public Command Cmd;

        public byte[] terrain;
        public int pos;


        public TerrainData(){ From=Setting.Name; }

        public TerrainData(byte[] data) {
            // Command
            Cmd=(Command)data[0];

            //len to
            byte lenTo = data[1];

            //len from
            byte lenFrom = data[2];

            // message length
            short msgLen = BitConverter.ToInt16(data, 3);

            // name to
            if (lenTo>0) To=System.Text.Encoding.UTF8.GetString(data, 5, lenTo);
            else To="";

            // name from
            if (lenFrom>0) From=System.Text.Encoding.UTF8.GetString(data, 5+lenTo, lenFrom);
            else From="";

            //message
            if (msgLen==0) {
                Message="";
                return;
            }

            if (Cmd==Command.SendingWorldData) {
                if (msgLen<1024-lenTo-lenFrom-5) {
                    terrain=new byte[msgLen];
                    pos = BitConverter.ToInt16(data, 5+lenFrom+lenTo);
                    Array.Copy(data, 5+lenFrom+lenTo+2, terrain, 0, msgLen-2);
                } //else Console.WriteLine("Velká zpráva");
            } else {
                Message=System.Text.Encoding.UTF8.GetString(data, 5+lenFrom+lenTo, msgLen);
            }
        }

        public byte[] ToByte() {
            if (Message==null) Message="";

            byte[] bytesTo =System.Text.Encoding.UTF8.GetBytes(To);
            byte[] bytesFrom = System.Text.Encoding.UTF8.GetBytes(From);
            byte[] bytesMessage = System.Text.Encoding.UTF8.GetBytes(Message);

            List<byte> bytes=new List<byte>(){
                // Command
                (byte)Cmd,

                // len to
                (byte)bytesTo.Length,

                // len from
                (byte)bytesFrom.Length,
            };

            //len message
            bytes.AddRange(BitConverter.GetBytes((short)bytesMessage.Length));

            // to
            bytes.AddRange(bytesTo);

            // from
            bytes.AddRange(bytesFrom);

            // message
            bytes.AddRange(bytesMessage);

            return bytes.ToArray();
        }

        public byte[] ToByte(byte[] terrain, short myPos) {
            byte[] bytesTo =System.Text.Encoding.UTF8.GetBytes(To);
            byte[] bytesFrom = System.Text.Encoding.UTF8.GetBytes(From);

            List<byte> bytes=new List<byte>(){
                // Command
                (byte)Cmd,

                // len to
                (byte)bytesTo.Length,

                // len from
                (byte)bytesFrom.Length,
            };

            //len message
            bytes.AddRange(BitConverter.GetBytes((short)(terrain.Length+2)));

            // to
            bytes.AddRange(bytesTo);

            // from
            bytes.AddRange(bytesFrom);

            // message
            bytes.AddRange(BitConverter.GetBytes(myPos));
            bytes.AddRange(terrain);

            return bytes.ToArray();
        }

        public string Talk() {
            if (Cmd==Command.SendingWorldData) {

                string h="";
                foreach (byte c in terrain){
                    string k=c.ToString();

                    if (k.Length==1) h+="   "+k+Environment.NewLine;
                    else if (k.Length==2) h+="  "+k+Environment.NewLine;
                    else h+=" "+k+Environment.NewLine;
                }

                return "Cmd: "+Command.SendingWorldData+", From: "+From+", To: "+To+" Pos: "+pos+", Terrain: "+Environment.NewLine+h;

            } else if (Cmd!=Command.Blank){
                return "Cmd: "+Cmd+", From: "+From+", To: "+To+", Message: "+Message;
            }
            return "";
        }
    }

    static class Bytes {
        public static byte[] SubBytes(this byte[] bytes, int startPos, int lenght) {
            byte[] ret = new byte[lenght];
            Array.Copy(bytes, startPos, ret, 0, lenght);
            return ret;
        }

        public static byte[] SubBytes(this byte[] bytes, int startPos) {
            byte[] ret = new byte[bytes.Length-startPos];
            Array.Copy(bytes, startPos, ret, 0, bytes.Length-startPos);
            return ret;
        }
    }
}