﻿using System;
using System.Threading;
using Endorblast.Lib.Enums;
using Endorblast.MasterServer.DataCmd;
using Lidgren.Network;


namespace Endorblast.MasterServer
{
    public class MasterServerScript
    {
        
        private static MasterServerScript instance = new MasterServerScript();
        public static MasterServerScript Instance
        {
            get
            {
                return instance;
            }
            private set
            {
                return;
            }
        }
        
        private bool isRunning = false;

        private NetPeer server;
        public NetPeer Server => server;
        
        SynchronizationContext context;
        

        public void Start()
        {
            Console.WriteLine("### Starting Master Server.");

            isRunning = true;
            
            
            // Make cfg for server then set it to server config.... Done.
            var c = new NetPeerConfiguration("endorblast-master");
            c.Port = MasterServerSettings.masterServerPort;
            c.MaximumConnections = MasterServerSettings.maxConnections;
            server = new NetServer(c);
            
            // Make server packet loop :)
            context = new SynchronizationContext();
            server.RegisterReceivedCallback(NetworkLoop, context);
            server.Start();

            // So it doesn't close
            while (true)
            {
                
            }
            
        }

        public NetOutgoingMessage MASTERMSG() => masterMessage();

        private NetOutgoingMessage masterMessage()
        {
            var msg = Server.CreateMessage();
            msg.Write((byte)ServerPacket.Master);
            
            return msg;
        }

        private void NetworkLoop(object o)
        {
            NetIncomingMessage message;
            while ((message = server.ReadMessage()) != null)
            {
                switch (message.MessageType)
                {
                    case NetIncomingMessageType.Data:
                        // handle custom messages
                        
                        break;

                    case NetIncomingMessageType.StatusChanged:

                        switch (message.SenderConnection.Status)
                        {
                            case NetConnectionStatus.Connected:
                                new SendToLoginCmd().Send(message.SenderConnection);
                                break;
                            case NetConnectionStatus.Disconnecting:
                                break;
                            case NetConnectionStatus.Disconnected:
                                break;
                        }
                        break;

                    case NetIncomingMessageType.DebugMessage:
                        // handle debug messages
                        // (only received when compiled in DEBUG mode)
                        Console.WriteLine(message.ReadString());
                        break;
                    /* .. */
                    default:
                        Console.WriteLine("### ERROR : unhandled message with type: " + message.MessageType);
                        break;
                }
            }
        }

    }
}