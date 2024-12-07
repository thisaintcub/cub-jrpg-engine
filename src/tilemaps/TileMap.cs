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
using shy_jrpg_engine.src.engine.api;
using DotTiled;
using DotTiled.Serialization;
#endregion

namespace shy_jrpg_engine.src.tilemaps {
    public class TileMap {
        Map tilemap;
        Loader loader = Loader.Default();
           
        public TileMap(String map) {
            tilemap = loader.LoadMap(Paths.tilemap(map));
        }
    }
}