﻿using System;
using Endorblast.GameServer.Server;
using Endorblast.Lib;
using Endorblast.Lib.Entities;
using Endorblast.Lib.Enums;
using Lidgren.Network;

namespace Endorblast.GameServer.NetworkCmd
{
    public class WorldEnterCommand
    {
        public void Receive(NetIncomingMessage inc)
        {
            
            // StaticCharacter player = new StaticCharacter();
            // inc.ReadAllFields(player);
            // var sc = player.ToServerPlayer();
            //
            //
            // MapManager.Instance.AddPlayer(sc, sc.WorldID);
            //
            // Send(sc.WorldID, sc.playerID);
        }


        public void Send(int worldID, int playerID)
        {
            var list = MapManager.Instance.GetConnections(worldID);
            var outmsg = GameServerScript.Instance.CreateWorldMessage();
            outmsg.Write((byte)WorldPacket.WorldEnter);
            
            outmsg.Write(playerID);

            GameServerScript.Instance.Server.SendMessage(outmsg, list, NetDeliveryMethod.ReliableOrdered, 0);


        }
    }
}