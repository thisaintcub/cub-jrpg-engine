#region Includes
using System;
using System.Runtime.InteropServices;
using shy_jrpg_engine.src.engine;
#endregion

namespace shy_jrpg_engine.src.engine.api {
    public class DiscordRPC {
        [DllImport("discord-rpc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Initialize")]
        public static extern void Initialize(string applicationId, ref EventHandlers handlers, bool autoRegister, string optionalSteamId);
        [DllImport("discord-rpc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_RunCallbacks")]
        public static extern void RunCallbacks();
        [DllImport("discord-rpc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Shutdown")]
        public static extern void Shutdown();
        [DllImport("discord-rpc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UpdatePresence")]
        public static extern void UpdatePresence(ref RichPresence presence);

        internal static void Initialize(string v1, ref object handlers, bool v2, object p) {
            throw new NotImplementedException();
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void DisconnectedCallback(int errorCode, string message);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ErrorCallback(int errorCode, string message);
        public struct EventHandlers {
            public ReadyCallback readyCallback;
            public DisconnectedCallback disconnectedCallback;
            public ErrorCallback errorCallback;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ReadyCallback();
        [Serializable]

        public struct RichPresence {
            public string state;
            public string details;
            public long startTimestamp;
            public long endTimestamp;
            public string largeImageKey;
            public string largeImageText;
            public string smallImageKey;
            public string smallImageText;
            public string partyId;
            public int partySize;
            public int partyMax;
            public string matchSecret;
            public string joinSecret;
            public string spectateSecret;
            public bool instance;
        }

        internal static void changePresence(string details, string smallImageKey, bool? hasStartTimestamp, float? endTimestamp) {
            //laterrrr
            //var startTimestamp:Float = if (hasStartTimestamp) Date.now().getTime() else 0;
            //if (endTimestamp > 0)
            //	endTimestamp = startTimestamp + endTimestamp;

            Globals.presence.details = details;
            Globals.presence.largeImageKey = "icon";
            Globals.presence.largeImageText = "Matt's World";
            Globals.presence.smallImageKey = smallImageKey;

            // laterrrr
            //Globals.presence.startTimestamp = Std.int(startTimestamp / 1000);
            //Globals.presence.endTimestamp = Std.int(endTimestamp / 1000);

            DiscordRPC.UpdatePresence(ref Globals.presence);
        }
    }
}