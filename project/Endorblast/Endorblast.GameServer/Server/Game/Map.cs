﻿using System;
using System.Collections.Generic;
using Endorblast.GameServer.Entities;
using Endorblast.GameServer.Server.Game;
using Endorblast.Lib;
using Endorblast.Lib.Enums;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.Tiled;

namespace Endorblast.GameServer.Server
{
    public class Map
    {
        public int worldId;
        public MapType mapType;
        public CharacterManager characterManager;
        public NPCManager npcManager;

        public SceneHeadless sceneHeadless;
        private TmxMap map;
        private TmxLayer ground;
        
        
        public int Players()
        {
            return characterManager.Characters.Count;
        }
        
        
        public Map(int worldID, MapType type)
        {
            sceneHeadless = new SceneHeadless();
            characterManager = new CharacterManager();
            npcManager = new NPCManager();


            switch (type)
            {
                case MapType.Town:
                    map = new TmxMap().LoadTmxMap("Content/Sprites/Tilesets/GameArea/GameStart.tmx", true);
                    ground = map.GetLayer<TmxLayer>("Ground");
                    break;
            }
            
            AddPlayer(ground);
            
            worldId = worldID;
            mapType = type;
            
            // Generate map here :)
            // With "Generate" I mean for example rare mobs to spawn
            // or something in that way :P
            
        }
        
        public void Update()
        {
            // Update anything on the world(map) that needs to be updated here!
            sceneHeadless.Update();
            //characterManager.Update();
            //npcManager.Update();
        }

        public void AddPlayer(TmxLayer layer)
        {

            var lol = sceneHeadless.CreateEntity("lol");
            var player = lol.AddComponent(new Player());
            player.AddComponent(new SpriteRenderer());
            
            player.SetMap(ground);

        }

        public void RemovePlayer()
        {
            
        }

    }
}