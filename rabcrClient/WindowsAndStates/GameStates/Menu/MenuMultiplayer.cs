using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace rabcrClient {
    #if MULTIPLAYER
    class MenuMultiplayer : MenuScreen {

        #region Varibles
        Texture2D scrollbarTopTexture, scrollbarCenterTexture, scrollbarBottomTexture,
            buttonLeftTexture, buttonRightTexture, buttonSettingTexture,
            packChecking, packUsed, packError, serverTexture;
        int runEditServer = -1;
        RenderTarget2D worldsTarget;
        Effect effectBlur;
        Scrollbar scrollbar;
        // KeyboardState newKeyboardState/*, oldKeyboardState*/;
        // MouseState newMouseState, oldMouseState;
        Button buttonMenu;
        ButtonCenter buttonAddServer, buttonRefreshList/*,buttonProblems,buttonServer*/;
        //    SpriteFont Fonts.Small, Fonts.SmallItalic, Fonts.Medium, Fonts.Big,Fonts.Biggest;
        float angleChecking;
        bool findingservers;
        int foreachedServer;
        List<Server> servers;
        ConnectionChecker connectionChecker;
        Thread serverInfo;
        Text header;
        //  bool mouse;
        #endregion
        //   string header=Lang.Texts[7];
        public override void Init() {
            worldsTarget=new RenderTarget2D(GraphicsManager.GraphicsDevice, Global.WindowWidth, Global.WindowHeight-75-65-2);
            serverTexture=GetDataTexture("Menu/Worlds types/server");

            buttonSettingTexture=GetDataTexture("Buttons/Other/Setting");
            buttonLeftTexture=Textures.ButtonLeft;
            buttonRightTexture=Textures.ButtonRight;
            //buttonProblems=new Button(Textures.ButtonCenter, Fonts.Medium, Fonts.Big);
            buttonAddServer=new ButtonCenter(buttonLeftTexture/*, Fonts.Medium, Fonts.Big,true*/) { /*center=true*/ };
            buttonRefreshList=new ButtonCenter(buttonRightTexture/*, Fonts.Medium, Fonts.Big,true*/) { /*center=true*/ };
            buttonMenu=new Button(Textures.ButtonLongLeft, Lang.Texts[1]/*, Fonts.Medium, Fonts.Big,true*/);
            buttonMenu.Click+=ClickMenu;
            //buttonServer=new Button(Textures.ButtonCenter, Fonts.Medium, Fonts.Big);
            scrollbarTopTexture=GetDataTexture("Buttons/Scrollbar/Top");
            scrollbarCenterTexture=GetDataTexture("Buttons/Scrollbar/Center");
            scrollbarBottomTexture=GetDataTexture("Buttons/Scrollbar/Bottom");

            packUsed=GetDataTexture("Menu/Styles/Used");
            packChecking=GetDataTexture("Menu/Styles/Checking");
            packError=GetDataTexture("Menu/Styles/Error");

            header=new Text(Lang.Texts[7], 10, 10, BitmapFont.bitmapFont34);

            scrollbar=new Scrollbar(scrollbarTopTexture, scrollbarCenterTexture, scrollbarBottomTexture) {
                height=Global.WindowHeight-75-65-2
            };

            effectBlur=Effects.BluredTopDownBounds;

            //effectBlur.Parameters["v"].SetValue(1f/(Global.WindowHeight-65-75));
            //effectBlur.Parameters["pos"].SetValue((1f/(Global.WindowHeight-65-75))*5);
            scrollbar.PositionY=76;

            SetTexts();
            Start();
            Resize();
        }

        public override void Update(GameTime gameTime) {
              MousePos.mouseRealPosX=Menu.mousePosX;
            MousePos.mouseRealPosY=Menu.mousePosYCorrection;
            MousePos.mouseLeftDown=Menu.mouseDown;
            MousePos.mouseLeftRelease=Menu.oldMouseState.LeftButton==ButtonState.Pressed && !Menu.mouseDown;

            //newMouseState=Mouse.GetState();
            //newKeyboardState=Keyboard.GetState();

            if (Menu.newKeyboardState.IsKeyDown(Keys.Up)) scrollbar.Scroll(-2);
            if (Menu.newKeyboardState.IsKeyDown(Keys.Down)) scrollbar.Scroll(2);

            if (Menu.newKeyboardState.IsKeyDown(Keys.PageUp)) scrollbar.Scroll(-5);
            if (Menu.newKeyboardState.IsKeyDown(Keys.PageDown)) scrollbar.Scroll(5);

            if (Menu.newMouseState.ScrollWheelValue!=Menu.oldMouseState.ScrollWheelValue) {
                scrollbar.Scroll((Menu.oldMouseState.ScrollWheelValue-Menu.newMouseState.ScrollWheelValue)/2f);
            }
            buttonMenu.Update();
            //if (buttonProblems.Click) {
            //    new FormProblems().ShowDialog();

            //}

            //if (buttonServer.Click){
            //    Process p=new Process();
            //    p.StartInfo.Arguments="/Server";
            //    p.StartInfo.FileName=System.Reflection.Assembly.GetExecutingAssembly().Location;
            //    p.Start();
            //}
            int yy = (int)(-(servers.Count-(Global.WindowHeight-75-65)/100f)*100*scrollbar.scale)-65/*-55*/;
          //
            for (int i = 0; i<servers.Count; i++) {
                //if (i>=Worlds.Count)break;
                if (yy>-70-70&&yy<Global.WindowHeight-75-65-70) {


               //    MousePos.mouseRealPosY+=130;
                    if (servers[i].setting.Update()/*.Click*/) {
                        //   EditSingleWorld(servers[i].directoryName);
                        EditServer(servers[i]);
                      //  MousePos.mouseRealPosY-=130;
                        if (servers.Count==i) break;
                    }
                    if (servers[i].play.Click) {
                        RunMultiplayer(servers[i]);
                        // RunGame(servers[i].directoryName);
                    }// (spriteBatch,newMouseState.LeftButton==ButtonState.Pressed,1,new Vector2(newMouseState.X,newMouseState.Y-75),new Vector2(105+38,yy+100));
                    //                    #region Button join

                }
            }
           //
            //if (buttonMenu.Click) {
            //    ((Menu)Rabcr.screen).GoToMenu(new MainMenu());
            //}

            if (runEditServer!=-1) {

                string dir = servers[runEditServer].filePath;
                runEditServer=-1;
                string message, ip, name;
                if (Directory.Exists(dir)) {
                    try {
                        using (StreamReader sr = new StreamReader(dir+"\\Info.txt")) {
                            name=sr.ReadLine();
                            message=sr.ReadLine();
                            ip=sr.ReadLine()+":"+sr.ReadLine();
                        }
                    } catch {
                        name=Lang.Texts[14]/*"Nový server"*/;
                        ip="localhost:1000";
                        message="";
                    }

                    using (EditServer f = new EditServer(name, ip)) {
                        f.ShowDialog();

                        if (f.ReturnSmt) {
                            if (f.Remove) {
                                Directory.Delete(dir, true);
                            } else {
                                File.WriteAllText(dir+"\\Info.txt", f.Output1+Environment.NewLine+message+Environment.NewLine+f.OutputIp+Environment.NewLine+f.OutputPort);
                                RefreshListMultiplayer();
                            }
                        }
                    }
                }

                RefreshListMultiplayer();
            }

            if (buttonRefreshList.Click) {
                // if (serverInfo!=null) {
                //    if (serverInfo.IsAlive) {
                //        //clientSocket.Disconnect(false);
                //        serverInfo.Abort();

                //    }
                //    serverInfo=null;
                //}  Start();
                RefreshListMultiplayer();
            }

            //if (OwnServer.Click) {

            //}

            if (buttonAddServer.Click) {
                string dir = Setting.Path+"\\Servers\\"+FastRandom.Int(100000000);
                if (!Directory.Exists(dir)) {
                    Directory.CreateDirectory(dir);

                    using (AddServer f = new AddServer()) {
                        f.ShowDialog();

                        if (f.ReturnSmt) {
                            File.WriteAllText(dir+"\\Info.txt", f.Output1+Environment.NewLine+""+Environment.NewLine+f.OutputIp+Environment.NewLine+f.OutputPort);
                            RefreshListMultiplayer();
                        }
                    }
                }
            }

            angleChecking+=0.02f;

            if (findingservers) {
             //   connectionChecker=new ConnectionChecker(servers[foreachedServer].ip.ToString(), servers[foreachedServer].port);
                connectionChecker.Check();

                if (connectionChecker.Error) {
                    if (servers.Count>0) {
                        servers[foreachedServer].currentConnection=Server.Connection.Error;
                        //   servers[foreachedServer].geDoMessage=new GeDo(Fonts.Small/*,Fonts.SmallItalic,Pixel*//*,false*/);

                        if (!int.TryParse(connectionChecker.ErrorText, out int langErrorCode)) langErrorCode =1531;

                        if (connectionChecker.ErrorDeep==0) {
                            servers[foreachedServer].geDoMessage=new GeDo(/*Fonts.Small,*/"<Red>"+Lang.Texts[241]+"</Red> "+Lang.Texts[langErrorCode], 100, yy+103/*, BitmapFont.bitmapFont18*/);
                            //servers[foreachedServer].geDoMessage.BuildString("<Red>Chyba</Red> "+connectionChecker.ErrorText);
                        } else if (connectionChecker.ErrorDeep==1) {
                            servers[foreachedServer].geDoMessage=new GeDo(/*Fonts.Small,*/"<Red>"+Lang.Texts[241]+"</Red> "+Lang.Texts[langErrorCode], 100, yy+103/*, BitmapFont.bitmapFont18*/);
                        } else if (connectionChecker.ErrorDeep==2) {
                            servers[foreachedServer].geDoMessage=new GeDo(/*Fonts.Small,*/"<Orange>"+Lang.Texts[241]+"</Orange> "+Lang.Texts[langErrorCode], 100, yy+103/*, BitmapFont.bitmapFont18*/);
                        } else if (connectionChecker.ErrorDeep==3) {
                            servers[foreachedServer].geDoMessage=new GeDo(/*Fonts.Small,*/"<Yellow>"+Lang.Texts[241]+"</Yellow> "+Lang.Texts[langErrorCode], 100, yy+103/*, BitmapFont.bitmapFont18*/);
                        }
                        connectionChecker.Dispose();
                        findingservers=false;

                        if (servers.Count>foreachedServer+1) {
                            foreachedServer++;
                            //  Console.WriteLine("Připojování: "+servers[foreachedServer].ip.ToString()+" : "+servers[foreachedServer].port);

                            servers[foreachedServer].currentConnection=Server.Connection.Checking;
                            connectionChecker=new ConnectionChecker(servers[foreachedServer].ip.ToString(), servers[foreachedServer].port);
                            findingservers=true;
                            connectionChecker.Start();
                        }
                    }
                } else if (connectionChecker.Received!=""&&connectionChecker.Received!=null) {
                    string[] data = connectionChecker.Received.Split('|');
                    servers[foreachedServer].geDoMessage=new GeDo(data[2], 100, yy+103);
                    servers[foreachedServer].joinedPlayers=int.Parse(data[3]);
                    servers[foreachedServer].maxplayers=int.Parse(data[4]);
                    servers[foreachedServer].version=data[1];

                    if (servers[foreachedServer].version!=Release.VersionString) {
                        servers[foreachedServer].currentConnection=Server.Connection.Error;
                        servers[foreachedServer].error=true;
                        servers[foreachedServer].geDoMessage=new GeDo("<Yellow>"+Lang.Texts[241]+"</Yellow> "+Lang.Texts[1529].Replace("%name%",servers[foreachedServer].version)/* Hra je pro jinou verzi - "+*/, 100, yy+103);
                    } else if (servers[foreachedServer].joinedPlayers==servers[foreachedServer].maxplayers) {
                        servers[foreachedServer].error=true;
                        servers[foreachedServer].currentConnection=Server.Connection.Error;
                        servers[foreachedServer].geDoMessage.BuildString("<Yellow>"+Lang.Texts[241]+"</Yellow> "+Lang.Texts[1530]);//Server je plný
                    } else {
                        servers[foreachedServer].currentConnection=Server.Connection.Ok;
                    }

                    findingservers=false;

                    if (servers.Count>foreachedServer+1) {
                        foreachedServer++;
                        //   Console.WriteLine("Připojování: "+servers[foreachedServer].ip.ToString()+" : "+servers[foreachedServer].port);
                        if (servers[foreachedServer].ip!=null) {
                            connectionChecker=new ConnectionChecker(servers[foreachedServer].ip.ToString(), servers[foreachedServer].port);
                            findingservers=true;
                            connectionChecker.Start();
                        }
                    }
                }
            }

            base.Update(gameTime);
        }

        public override void PreDraw() {
            //mouse= newMouseState.LeftButton==ButtonState.Pressed;

            Graphics.SetRenderTarget(worldsTarget);
            Graphics.Clear(Color.Transparent);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            int yy = (int)(-(servers.Count-(Global.WindowHeight-75-65)/100f)*100*scrollbar.scale)-65/*-55*/;

            for (int h = 0; h<servers.Count; h++) {
                Server server = servers[h];

                if (yy>-70-70&&yy<Global.WindowHeight-75-65-70) {
                    // DrawTextShadowMinSmall(100,yy+80,server.name);
                    server.serverNameText=new Text(server.name, 100, yy+80, BitmapFont.bitmapFont18);
                    server.serverNameText.Draw(spriteBatch);

                    if (server.maxplayers!=-1) DrawTextShadowMinSmall(55-(int)Fonts.Small.MeasureString(server.joinedPlayers+"/"+server.maxplayers).Y/2, yy+145, server.joinedPlayers+"/"+server.maxplayers);

                    if (server.error) {
                        server.geDoMessage.DrawGedo(1f,spriteBatch/*,*//*100,yy+103,*//*255*/);
                    } else {
                        if (server.currentConnection==Server.Connection.Checking) {
                            DrawTextShadowMinSmall(100, yy+103, Lang.Texts[242]+"...", Color.Blue);
                        } else if (server.currentConnection==Server.Connection.NotStarted) {
                            DrawTextShadowMinSmall(100, yy+103, Lang.Texts[243]/*"V pořadí"*/, Color.Blue);
                        } else if (server.geDoMessage!=null) server.geDoMessage.DrawGedo(1f,spriteBatch/*,*//*100,yy+103,*//*255*/);

                        // DrawTextShadowMinSmall(0,yy+103,server.currentConnection.ToString(),Color.Blue);
                    }
                    server.setting.Position.Y=yy+130;
                    server.setting.ButtonDraw(/*spriteBatch*//*,newMouseState.X,newMouseState.Y-75,100,yy+130*//*,newMouseState.LeftButton==ButtonState.Pressed*/);
                    server.play.Position=new Vector2(100+38, yy+130);


                    server.play.ButtonDrawCorectionY(spriteBatch,/*mouse,*/1/*,new Vector2(newMouseState.X,newMouseState.Y-75*//*)*/);



                    //    server.geDoError.DrawGedo(spriteBatch, Rabcr.Game.IsActive, 100+34, yy+100+30, 255);
                    //            else server.geDoMessage.DrawGedo(spriteBatch,Rabcr.Game.IsActive,100+34,70+80+h*70-height+pressed+30,255);
                    //            DrawTextShadowMin(Fonts.Small,Global.WindowWidth-100,70+80+h*70-height+pressed+3,(server.joinedPlayers==-1?"?":server.joinedPlayers.ToString())+"/"+(server.maxplayers==-1?"?":server.maxplayers.ToString()));
                    spriteBatch.Draw(serverTexture, new Vector2(30, yy+85-5), Color.White);

                    if (server.currentConnection==Server.Connection.Ok) {
                        spriteBatch.Draw(packUsed, new Vector2(28+16, yy+100), Color.White);
                    } else if (server.currentConnection==Server.Connection.Error) {
                        spriteBatch.Draw(packError, new Vector2(28+16, yy+100), Color.White);
                    } else {
                        spriteBatch.Draw(packChecking, new Rectangle(28+32, yy+100, 32, 32), null, Color.White, angleChecking, new Vector2(16f, 16f), SpriteEffects.None, 1);
                        //}
                        angleChecking+=0.01f;
                    }



                    //                if (newMouseState.Y>70+80+h*70-height+pressed && newMouseState.Y<70+80+h*70-height+pressed+70) {

                    //                    if (mouse) {
                    //                        spriteBatch.Draw(Rabcr.Pixel,new Rectangle(28-3,70+80+h*70-height+pressed-3,Global.WindowWidth-70,70),new Color(200,200,200,200));
                    //                    } else {
                    //                        spriteBatch.Draw(Rabcr.Pixel,new Rectangle(28-3,70+80+h*70-height+pressed-3,Global.WindowWidth-70,70),new Color(100,100,100,100));

                    //                        if (oldMouseState.LeftButton==ButtonState.Pressed) {
                    //                            if (newMouseState.X>28+64+5 && newMouseState.Y>70+80+h*70-height+pressed+20+5
                    //                            && newMouseState.X<28+64+5+32 && newMouseState.Y<70+80+h*70-height+pressed+20+5+32) {

                    //                                if (Rabcr.Game.IsActive) {
                    //                                    if (mouse) {
                    //                                        if (oldMouseState.LeftButton==ButtonState.Released) {
                    //                                            spriteBatch.Draw(buttonSettingTexture, new Vector2(28+64+5, 70+80+h*70-height+pressed+20+5), Color.Gray);
                    //                                    //   Process.Start(System.Reflection.Assembly.GetEntryAssembly().Location,"/EditServer \""+server.filePath+"\"");
                    //                                            runEditServer=h;
                    //                                            //string dir = servers[h].filePath;
                    //                                            //string message, ip, name;
                    //                                            //if (Directory.Exists(dir)) {
                    //                                            //    try {
                    //                                            //        using (StreamReader sr = new StreamReader(dir+"\\Info.txt")) {
                    //                                            //            name=sr.ReadLine();
                    //                                            //            message=sr.ReadLine();
                    //                                            //            ip=sr.ReadLine()+":"+sr.ReadLine();
                    //                                            //        }
                    //                                            //    } catch {
                    //                                            //        name="Nový server";
                    //                                            //        ip="localhost:6666";
                    //                                            //        message="";
                    //                                            //    }

                    //                                            //    using (EditServer f = new EditServer(name, ip)) {
                    //                                            //        f.ShowDialog();

                    //                                            //        if (f.ReturnSmt) {
                    //                                            //            File.WriteAllText(dir+"\\Info.txt", f.Output1+Environment.NewLine+message+Environment.NewLine+f.OutputIp+Environment.NewLine+f.OutputPort);
                    //                                            //            RefreshListMultiplayer();
                    //                                            //        }
                    //                                            //    }
                    //                                            //}
                    //                                        }
                    //                                    }
                    //                                }
                    //                            } else {
                    //                                if (Rabcr.Game.IsActive) {
                    //                                //MultiPlayer m = new MultiPlayer {
                    //                                //    port=server.port,
                    //                                //    ip=server.ip,
                    //                                //    playedWorld=server.filePath
                    //                                //};
                    //                            //Console.WriteLine(m.playedWorld);
                    //                            //ScreenManager.GoTo(m);
                    //                        }
                    //                            }
                    //                        }
                    //                    }

                    //                    if (newMouseState.X>28+64+5 && newMouseState.Y>70+80+h*70-height+pressed+20+5
                    //                    && newMouseState.X<28+64+5+32 && newMouseState.Y<70+80+h*70-height+pressed+20+5+32) {
                    //                        spriteBatch.Draw(buttonSettingTexture, new Vector2(28+64+5, 70+80+h*70-height+pressed+20+5), Color.WhiteSmoke);

                    //                        if (Rabcr.Game.IsActive) {
                    //                            if (mouse) {
                    //                                if (oldMouseState.LeftButton==ButtonState.Released) {
                    //                                    spriteBatch.Draw(buttonSettingTexture, new Vector2(28+64+5, 70+80+h*70-height+pressed+20+5), Color.LightGray);
                    //                                    // Process.Start(System.Reflection.Assembly.GetEntryAssembly().Location,"/EditServer \""+server.filePath+"\"");
                    //                                   runEditServer=h;
                    //                                }
                    //                            }
                    //                        }
                    //                    } else  spriteBatch.Draw(buttonSettingTexture, new Vector2(28+64+5, 70+80+h*70-height+pressed+20+5), Color.White);
                    //                }else  spriteBatch.Draw(buttonSettingTexture, new Vector2(28+64+5, 70+80+h*70-height+pressed+20+5), Color.White);
                    //            }else  spriteBatch.Draw(buttonSettingTexture, new Vector2(28+64+5, 70+80+h*70-height+pressed+20+5), Color.White);


                    //            DrawTextShadowMin(Fonts.Small,100,70+80+h*70-height+pressed+3,server.name);
                    //            if (server.geDoError!=null)server.geDoError.DrawGedo(spriteBatch,Rabcr.Game.IsActive,100+34,70+80+h*70-height+pressed+30,255);
                    //            else server.geDoMessage.DrawGedo(spriteBatch,Rabcr.Game.IsActive,100+34,70+80+h*70-height+pressed+30,255);
                    //            DrawTextShadowMin(Fonts.Small,Global.WindowWidth-100,70+80+h*70-height+pressed+3,(server.joinedPlayers==-1?"?":server.joinedPlayers.ToString())+"/"+(server.maxplayers==-1?"?":server.maxplayers.ToString()));


                    //            if (server.currentConnection==Server.Connection.Ok) {
                    //                spriteBatch.Draw(packUsed,new Vector2(28+16,70+80+h*70-height+pressed+16),Color.White);
                    //            } else if (server.currentConnection==Server.Connection.Error) {
                    //                spriteBatch.Draw(packError,new Vector2(28+16,70+80+h*70-height+pressed+16),Color.White);
                    //            } else //if (server.currentConnection==Server.Connection.Checking) {
                    //                spriteBatch.Draw(packChecking,new Rectangle(28+32,70+80+h*70-height+pressed+32,32,32),null,Color.White,angleChecking,new Vector2(16f,16f),SpriteEffects.None,1);
                    //            //}
                    //        angleChecking+=0.01f;
                    ////    }
                }
                yy+=100;
            }

            spriteBatch.End();
            Graphics.SetRenderTarget(null);
        }

        public override void Draw(GameTime gameTime, float a) {
            spriteBatch.Begin();
            DrawTextShadowMinSmall(Global.WindowWidth-(int)Fonts.Small.MeasureString("Hra pro více hráčů ještě není plně propracovaná!").X-5, 5, "Hra pro více hráčů ještě není plně propracovaná!", Color.Red);
            //DrawTextHeader(10, 10, Lang.Texts[7] /*Setting.czechLanguage ? "Hra pro více hráčů":"Multiplayer"*/, a);
            header.Draw(spriteBatch);
            //else DrawTextShadowMax(Fonts.Big, 10, 10,  , Color.White*a);
            buttonAddServer.ButtonDraw(spriteBatch, /*mouse,*/ a/*, new Vector2(newMouseState.X,newMouseState.Y)*/);
            buttonRefreshList.ButtonDraw(spriteBatch, /*mouse,*/ a/*, new Vector2(newMouseState.X,newMouseState.Y)*/);

            //buttonServer.ButtonDraw(spriteBatch, mouse, a, new Vector2(newMouseState.X,newMouseState.Y),new Vector2(Global.WindowWidth-200,40));

            // buttonProblems.ButtonDraw(spriteBatch, mouse, a, new Vector2(newMouseState.X,newMouseState.Y),new Vector2(Global.WindowWidth-200,40));
            buttonMenu.ButtonDraw(spriteBatch, /*mouse,*/ a/*, new Vector2(newMouseState.X,newMouseState.Y)*/);

            spriteBatch.End();
            effectBlur.Parameters["alpha"].SetValue(a);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, effectBlur);
            effectBlur.Techniques[0].Passes[0].Apply();
            spriteBatch.Draw(worldsTarget, new Vector2(0, 76), new Rectangle(0, 0, Global.WindowWidth, Global.WindowHeight-75-65-2), Color.White*a);
            spriteBatch.End();

            spriteBatch.Begin();
            scrollbar.ButtonDraw(spriteBatch,/*mouse,*/a/*,new Vector2(newMouseState.X,newMouseState.Y),new Vector2(Global.WindowWidth-35,76)*/);
            spriteBatch.End();


            //oldMouseState = newMouseState;
            //oldKeyboardState = newKeyboardState;

            base.Draw(gameTime);
        }

        //public override void Shutdown() {
        //    worldsTarget.Dispose();
        //    base.Shutdown();
        //}

        void ClickMenu(object sender, EventArgs e){
           //  if (buttonMenu.Click) {
                ((Menu)Rabcr.screen).GoToMenu(new MainMenu());
           // }
        }

        void MakeServerList() {
            if (!Directory.Exists(Setting.Path+@"\Servers")) Directory.CreateDirectory(Setting.Path+@"\Servers");
            foreach (string f in Directory.GetDirectories(Setting.Path+@"\Servers")) {
                if (File.Exists(f+"\\Info.txt")) {
                    if (servers.Count>12)
                        break;
                    using (StreamReader sr = new StreamReader(f+"\\Info.txt")) {
                        Server s = new Server {
                            //name
                            //message
                            //ip
                            //port
                            maxplayers=-1,
                            joinedPlayers=-1,
                            name=sr.ReadLine()
                        };
                        string g = sr.ReadLine();
                        s.geDoMessage=new GeDo(g , 100, 103/*, BitmapFont.bitmapFont18*/);


                        //  s.geDoMessage.BuildString();

                        s.ip=IPAddress.Any;
                        string ip = sr.ReadLine();

                        if (ip=="*"||ip=="localhost") {
                            s.ip=IPAddress.Any;
                        } else if (ip=="loopback"||ip=="Loopback") {
                            s.ip=IPAddress.Loopback;
                        } else if (ip=="Broadcast"||ip=="broadcast") {
                            s.ip=IPAddress.Broadcast;
                        } else s.ip=IPAddress.Parse(ip);



                        s.setting=new ImgButton(buttonSettingTexture);
                        s.setting.Position.X=100;
                     //   s.setting.
                        // s.setting.mouseYCorrection=75;
                        s.play=new ButtonCenter(buttonRightTexture/*,Fonts.Medium,Fonts.Big,true*/) {
                            Text=Lang.Texts[247] /*Setting.czechLanguage ? "Připojit":"Connect"*/,
                          //  center=true
                        };



                        try {
                            s.port=int.Parse(sr.ReadLine());
                        } catch {
                            s.port=1000;
                        }
                        s.filePath=f;
                        servers.Add(s);
                    }
                }
            }

            scrollbar.maxheight=servers.Count*100;
        }

        void SetTexts() {
        //    buttonAddServer.center=true;

         //   buttonMenu.Text=Lang.Texts[1];
            buttonRefreshList.Text=Lang.Texts[15];
            buttonAddServer.Text=Lang.Texts[16];
            //buttonRefreshList.center=true;
            //      if (Setting.czechLanguage) {
            //      //    buttonRefreshList.Text="Aktualizovat";
            //// buttonMenu.Text="Zpět";
            //          buttonAddServer.Text="Přidat";
            //          //buttonProblems.Text="Problémy?";
            //          //buttonServer.Text="Můj server";
            //          ////OwnServer.Text="Vlastní";
            //      } else {
            //        //  buttonRefreshList.Text="Refresh";
            //        //  buttonMenu.Text="Back";
            //        //  buttonProblems.Text="Problems?";
            //          buttonAddServer.Text="Add";
            //          //buttonServer.Text="My server";
            //          //OwnServer.Text="Own";
            //      }
        }

        void RunMultiPlayer(IPAddress ip, int port) {
            //if (serverInfo!=null) {
            //    if (serverInfo.IsAlive) {
            //    serverInfo.Abort();
            //    }
            //}
            //if (packCheckingProcess!=null) {
            //    if (packCheckingProcess.IsAlive) {
            //    packCheckingProcess.Abort();
            //    }
            //}
            //if (checking!=null) {
            //    if (checking.IsAlive) {
            //    checking.Abort();
            //    }
            //}
            if (Rabcr.ActiveWindow) {
                Process p = new Process();
                p.StartInfo.FileName=Environment.GetCommandLineArgs()[0];
                p.StartInfo.Arguments="/Server \""+Environment.GetCommandLineArgs()[2]+"\" "+Setting.Name+" "+ip.ToString()+" "+port;
                p.Start();
            }
            // clientSocket.Close();
            //   clientSocket.Dispose();
            //    clientSocket=null;
            // Global.ReadyToClose=false;
            // Global.RunServer=true;
            // Global.ServerIP=ip;
            // Global.ServerPort=port;

            // //Global.PlayedWorld=playedWorld+"\\";

            //// if (IsActive) {
            //      System.Windows.Forms.SendKeys.Send("%{F4}");
            //      Console.WriteLine("1");
            //       //System.Windows.Forms.SendKeys.Send("%{F4}");
            //  //  }
            //RunGame();
            //Global.ReadyToClose=false;
            //  Global.PlayedWorld=playedWorld+"\\";
            //Global.RunServer=true;
            //if (IsActive)System.Windows.Forms.SendKeys.Send("%{F4}");
            //System.Windows.Forms.Form myForm =(System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(Window.Handle);
            //myForm.();
        }

        public override void Resize() {
            //if (Global.WindowWidth)
            worldsTarget=new RenderTarget2D(GraphicsManager.GraphicsDevice, Global.WindowWidth, Global.WindowHeight-75-65);
            scrollbar.scale=0;

            effectBlur.Parameters["v"].SetValue(1f/(Global.WindowHeight-65-75));
            effectBlur.Parameters["pos"].SetValue((1f/(Global.WindowHeight-65-75))*5);
            //    effectPlate.Parameters["pos"].SetValue(1f/(Global.WindowHeight-65-75));
            scrollbar.height=Global.WindowHeight-75-65-2;

            buttonAddServer.Position=new Vector2(10, Global.WindowHeight-50);
            buttonRefreshList.Position=new Vector2(15+128+30, Global.WindowHeight-50);

            buttonMenu.Position=new Vector2(Global.WindowWidth-400+70, Global.WindowHeight-50-4);

            scrollbar.PositionX=Global.WindowWidth-35;// .ButtonDraw(spriteBatch,mouse,a,new Vector2(newMouseState.X,newMouseState.Y),new Vector2(,76));
        }

        //  void DrawTextHighSmall(string text,int x, int y) => spriteBatch.DrawString(Fonts.Big,text,new Vector2(x,y),Color.Black,0,Vector2.Zero,0.33333333333333f,SpriteEffects.None,0);

        void Start() {
            servers=new List<Server>();
            // serverSelect=0;
            MakeServerList();
            // CurrentGameState=GameState.MenuMultiPlayer;

            if (servers.Count!=0) {
                foreachedServer=0;
                servers[foreachedServer].currentConnection=Server.Connection.Checking;
                connectionChecker=new ConnectionChecker(servers[foreachedServer].ip.ToString(), servers[foreachedServer].port);
                findingservers=true;
                connectionChecker.Start();

            }
        }

        void RefreshListMultiplayer() {
            if (serverInfo!=null) {
                if (serverInfo.IsAlive) {
                    //clientSocket.Disconnect(false);
                    serverInfo.Abort();
                }
                serverInfo=null;
            }
            Start();
        }

        void SetList() {
            string dir = servers[runEditServer].filePath;

            runEditServer=-1;
            string message, ip, name;
            if (Directory.Exists(dir)) {
                try {
                    using (StreamReader sr = new StreamReader(dir+"\\Info.txt")) {
                        name=sr.ReadLine();
                        message=sr.ReadLine();
                        ip=sr.ReadLine()+":"+sr.ReadLine();
                    }
                } catch {
                    name=Lang.Texts[14]/*"Nový server"*/;
                    ip="localhost:1000";
                    message="";
                }

                using (EditServer f = new EditServer(name, ip)) {
                    f.ShowDialog();

                    if (f.ReturnSmt) {
                        if (f.Remove) {
                            Directory.Delete(dir, true);
                        } else {
                            File.WriteAllText(dir+"\\Info.txt", f.Output1+Environment.NewLine+message+Environment.NewLine+f.OutputIp+Environment.NewLine+f.OutputPort);
                            RefreshListMultiplayer();
                        }
                    }
                }
            }

            RefreshListMultiplayer();

        }

        void EditServer(Server s) {
            string dir = s.filePath;
            string message, ip, name;
            if (Directory.Exists(dir)) {
                try {
                    using (StreamReader sr = new StreamReader(dir+"\\Info.txt")) {
                        name=sr.ReadLine();
                        message=sr.ReadLine();
                        ip=sr.ReadLine()+":"+sr.ReadLine();
                    }
                } catch {
                    name=Lang.Texts[14]/*"Nový server"*/;
                    ip="localhost:1000";
                    message="";
                }

                using (EditServer f = new EditServer(name, ip)) {
                    f.ShowDialog();

                    if (f.ReturnSmt) {
                        if (f.Remove) Directory.Delete(dir, true);
                        else File.WriteAllText(dir+"\\Info.txt", f.Output1+Environment.NewLine+message+Environment.NewLine+f.OutputIp+Environment.NewLine+f.OutputPort);
                        RefreshListMultiplayer();

                    }
                }
            }
        }

        void RunMultiplayer(Server s) {
            Multiplayer m = new Multiplayer {
                port = s.port,
                ip = s.ip,
                pathToWorld = s.filePath
            };
            Rabcr.GoTo(m);
        }
    }

    class Server {
        public Text serverNameText;
        public IPAddress ip;
        public int port;

        public int joinedPlayers;
        public int maxplayers;

        public string version;

        public bool error = false;

        public GeDo geDoMessage;
        //  public GeDo geDoError;

        public string name;

        public string filePath;
        //public int deep;
        public ButtonCenter play;
        public ImgButton setting;
        public enum Connection {
            NotStarted,
            Checking,
            Ok,
            Error
        }
        public Connection currentConnection = Connection.NotStarted;
    }
    #endif
}
