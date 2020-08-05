using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace dimensions_mcl.forceliquidmerge
{
    [ApiVersion(2, 1)]
    public class ForceLiquidMerge : TerrariaPlugin
    {
        public override Version Version => new Version(1, 0, 0, 1);
        public override string Name => "Dimensions-MCL_ForceLiquidMerging";
        public override string Author => "Vednix";
        public ForceLiquidMerge(Main game) : base(game)
        {
            Order = 1;
        }
        public override void Initialize()
        {
            //ServerApi.Hooks.NetGetData.Register(this, OnGetData);
            ServerApi.Hooks.NetSendData.Register(this, OnSendData);
        }
        public static void OnGetData(GetDataEventArgs e)
        {
            if (e == null)
                return;

            switch (e.MsgID)
            {
                default:
                    Console.WriteLine($"packetget {e.MsgID}");
                    break;
            }
        }
        public static void OnSendData(SendDataEventArgs e)
        {
            if (e == null)
                return;

            if (e.MsgId == PacketTypes.TileSendSquare && e.number5 != 0 && e.number5 <= 3)
            {
                //Console.WriteLine($"e.Handled => {e.Handled}");
                //Console.WriteLine($"e.ignoreClient => {e.ignoreClient}");
                //Console.WriteLine($"e.number => {e.number}");
                //Console.WriteLine($"e.number2 => {e.number2}");
                //Console.WriteLine($"e.number3 => {e.number3}");
                //Console.WriteLine($"e.number4 => {e.number4}");
                //Console.WriteLine($"e.number5 /TileChangeType => {e.number5}");
                //Console.WriteLine($"e.number6 => {e.number6}");
                //Console.WriteLine($"e.number7 => {e.number7}");
                //Console.WriteLine($"e.MsgId => {e.MsgId}");
                //Console.WriteLine($"e.remoteClient => {e.remoteClient}");
                //Console.WriteLine($"e.text => {e.text}");
                //Console.WriteLine($"----------------------------------");

                TSPlayer.All.SendTileSquare((int)e.number2, (int)e.number3, 4);
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //ServerApi.Hooks.NetGetData.Deregister(this, OnGetData);
                ServerApi.Hooks.NetSendData.Deregister(this, OnSendData);
            }
            base.Dispose(disposing);
        }
    }
}
