﻿using Endorblast.Server.NetCommands;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.Server
{
    public class PlayerStats : Component, IUpdatable
    {


        public void Update()
        {
            //new CharacterDataCommand().Send(Endorblast.Lib.Enums.CharacterDataType.Position, this.GetComponent<Endorblast.Lib.BasePlayer>());
        }

    }
}