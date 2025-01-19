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
using cub_jrpg_engine.src.sprites;
using cub_jrpg_engine.src.engine;
using cub_jrpg_engine.src.objects;
using cub_jrpg_engine.src.scenes;
using cub_jrpg_engine.src.engine.scene;
using System.Diagnostics;
using cub_jrpg_engine.src.engine.api;
#endregion

namespace cub_jrpg_engine.src.scenes {
    public class TestScene : IScene {
        Character player;
        Hitbox playerHitbox;

        public TestScene() {
            Debug.WriteLine("scene switched to test scene!");
        }

        public void Load() {
            playerHitbox = new Hitbox();
            player = new Character(Globals.contentManager.Load<Texture2D>("art/char/Basic Charakter Spritesheet"));
            DiscordRPC.changePresence("Test", null, null, null);
            playerHitbox.Load(14, 6, 17, 26);
        }

        public void Unload() {
            playerHitbox.Unload();
        }

        public void Update(GameTime gameTime) {
            player.Update(gameTime);
            if (Globals.keyboard.GetPress("H"))
                playerHitbox.Hide();
            else if (Globals.keyboard.GetPress("S"))
                playerHitbox.Show();

            if (MediaPlayer.State != MediaState.Playing)
                MediaPlayer.Play(Globals.contentManager.Load<Song>(Paths.music("m")));
        }
        public void Draw() {
            Globals.graphicsManager.GraphicsDevice.Clear(Color.White);
            playerHitbox.Draw(player.position);
            player.PlayerDraw();
        }
    }
}
