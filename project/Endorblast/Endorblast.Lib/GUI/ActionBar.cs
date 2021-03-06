﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Game;
using Endorblast.Lib.Skills;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.UI;


namespace Endorblast.Lib.GUI
{
    class ActionBar : Component, IUpdatable
    {

        public static CharacterCreationUI Instance { get; } = new CharacterCreationUI();

        UICanvas canvas;
        Stage stage;
        Table table;

        int slotsAmount = 9;

        public void Init(Scene scene)
        {

            Entity UI = scene.CreateEntity("CharacterCreation");
            canvas = UI.AddComponent(new UICanvas());
            canvas.SetRenderLayer(RenderLayers.UILayer1);

            table = canvas.Stage.AddElement(new Table());
            table.SetFillParent(true);


            for (int i = 0; i < slotsAmount; i++)
            {
                
            }

        }


        public void Update()
        {
            
        }


    }
}
