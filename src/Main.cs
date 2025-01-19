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
using cub_jrpg_engine.src.engine.api;
#endregion

namespace cub_jrpg_engine {
    public class Main : Game {
        private DiscordRPC.EventHandlers handlers = default(DiscordRPC.EventHandlers);

        public Main() {
            Globals.graphicsManager = new GraphicsDeviceManager(this);
            Globals.sceneManager = new();
            Content.RootDirectory = "gamecontent";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            Globals.screenWidth = 960;
            Globals.screenHeight = 720;

            Globals.graphicsManager.PreferredBackBufferWidth = Globals.screenWidth;
            Globals.graphicsManager.PreferredBackBufferHeight = Globals.screenHeight;

            Globals.graphicsManager.ApplyChanges();

            DiscordRPC.Initialize("1313455559986380821", ref this.handlers, true, null);

            base.Initialize();
        }

        protected override void LoadContent() {
            Globals.contentManager = this.Content;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.keyboard = new Input();
            Globals.sceneManager.AddScene(new TitleScene());
        }

        protected override void UnloadContent() {
            Globals.sceneManager.CurrentScene().Unload();
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime) {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            Globals.gameTime = gameTime;
            Globals.keyboard.Update();

            base.Update(gameTime);

            Globals.keyboard.UpdateOld();
            Globals.sceneManager.CurrentScene().Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            Globals.spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            Globals.sceneManager.CurrentScene().Draw();
            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
