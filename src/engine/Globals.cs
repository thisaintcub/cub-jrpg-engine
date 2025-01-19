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
using cub_jrpg_engine.src.objects;
using cub_jrpg_engine.src.scenes;
using cub_jrpg_engine.src.engine.scene;
using cub_jrpg_engine.src.engine.api;
#endregion

namespace cub_jrpg_engine.src.engine;

class Globals {
    public static int screenWidth, screenHeight;
    public static String version = "0.0.1";
    public static ContentManager contentManager;
    public static SpriteBatch spriteBatch;
    public static GraphicsDeviceManager graphicsManager;
    public static SceneManager sceneManager;

    public static Input keyboard;

    public static GameTime gameTime;

    public static DiscordRPC.RichPresence presence;
}