namespace cub_jrpg_engine.src.engine;

class Paths {
    public static string image (string path) {
        return "art/" + path;
    }

    public static string sfx (string path) {
        return "audio/sfx/" + path;
    }

    public static string music (string path) {
        return "audio/music/" + path;
    }

    public static string tilemap(string path) {
        return "gamecontent/maps/" + path + ".tmx";
    }
}