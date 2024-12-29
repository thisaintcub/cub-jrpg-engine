#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using input;
using System.Data;
using shy_jrpg_engine.src.sprites;
using shy_jrpg_engine.src.engine;
using shy_jrpg_engine.src.objects;
using shy_jrpg_engine.src.scenes;
using System.Diagnostics;
using shy_jrpg_engine.src.engine.scene;
using shy_jrpg_engine.src.engine.api;
#endregion

namespace shy_jrpg_engine.src.scenes {
    public class TitleScene : IScene {
        bool intransition = false;
        SoundEffect confirm;

        public TitleScene() { }

        public void Load() {
            confirm = Globals.contentManager.Load<SoundEffect>(Paths.sfx("matt"));

            DiscordRPC.changePresence("Title Screen", null, null, null);
        }

        public void Unload() { }

        public void Update(GameTime gameTime) {
            if ((Globals.keyboard.GetPress("Z") || Globals.keyboard.GetPress("Space") || Globals.keyboard.GetPress("Enter")) && !intransition) {
                Debug.WriteLine("switching the scene...");
                intransition = true;
                confirm.Play();
                Thread.Sleep(1000);
                Globals.sceneManager.AddScene(new TestScene());
            }

            if (Globals.keyboard.GetPress("F")) {
                Globals.graphicsManager.IsFullScreen = !Globals.graphicsManager.IsFullScreen;
                Globals.graphicsManager.ApplyChanges();
            }
        }

        public void Draw() { }
    }
}
