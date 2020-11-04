﻿using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndorblastCore.Lib.Enums;
using EndorblastCore.Lib;

namespace EndorblastCore.Lib.Network
{
    class WorldCharacterEnterCommand : NetCommand
    {


        public void Read(NetIncomingMessage msg)
        {
            string username = msg.ReadString();

            float x = msg.ReadFloat();
            float y = msg.ReadFloat();

            if (NetworkManager.Instance.State == NetworkState.InGame)
            {
                if (username.ToUpper() == NetworkManager.AccountName.ToUpper())
                    CharacterManager.Instance.AddPlayer(GameManager.instance.CreateEntity(2, username, true), username, x , y);
                else
                    CharacterManager.Instance.AddPlayer(GameManager.instance.CreateEntity(2, username, false), username, x, y);

                Console.WriteLine("Added player!");
            }
        }

        public void Send()
        {
            NetOutgoingMessage outmsg = NetworkManager.Instance.CreateWorldMessage();
            outmsg.Write((byte)WorldPacket.CharacterEnter);


            outmsg.Write(NetworkManager.AccountName);
            outmsg.Write(NetworkManager.Instance.isLoggingIn);



            NetworkManager.Instance.client.SendMessage(outmsg, NetDeliveryMethod.ReliableOrdered);

        }




    }
}