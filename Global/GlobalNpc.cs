//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;

//namespace MyModNamespace
//{
    //public class MyMod : Mod
    //{
        //public override void Load()
        //{
         //   AddGlobalEvent(new CorruptionRevengeEvent());
        //}

        //private void AddGlobalEvent(GlobalEvent globalEvent)
        //{
            //ModSystem modSystem = ModContent.GetInstance<ModSystem>();
            //modSystem.AddEvent(globalEvent);
       // }
    //}

    //internal class CorruptionRevengeEvent : ModEvent
    //{
        //public override void PostUpdateWorld()
        //{
            //if (Main.hardMode && !Main.dayTime && Main.rand.Next(20) == 0)
           // {
             //   bool corruptionInWorld = false;
              //  bool hallowInWorld = false;
              //  foreach (Biome biome in Main.BiomeMap)
              //  {
              //      if (biome == Biome.CORRUPTION)
              //      {
              //          corruptionInWorld = true;
              //      }
              //      else if (biome == Biome.HALLOW)
              //      {
              //          hallowInWorld = true;
              //      }
              //  }
              //  if (corruptionInWorld && !hallowInWorld)
              //  {
//                    StartCorruptionRevengeEvent();
             //   }
           // }
      //  }

       // private void StartCorruptionRevengeEvent()
       // {
        //    if (Main.netMode == NetmodeID.Server)
       //     {
//                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The Corruption is seeking revenge!"), new Color(175, 75, 255));
       //     }
       //     else
       //     {
       //         Main.NewText("The Corruption is seeking revenge!", 175, 75, 255);
       //     }

        //    Main.invasionSize = 100;
        //    Main.invasionType = mod.GetInvasionSlot("CorruptionRevenge");
        //    Main.invasionDelay = 0;
        //    Main.StartInvasion();
      //  }
   // }

   // internal class GlobalEvent
   // {
//        public virtual void PostUpdateWorld()
   //     {
            // Do something here
            // For example, you could add a message to the chat when the world is updated
     //       if (Main.netMode == NetmodeID.Server)
     //       {
          //      NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The world has been updated!"), new Color(255, 255, 0));
     //       }
      //      else
      //      {
      //          Main.NewText("The world has been updated!", 255, 255, 0);
    //        }
   //     }
   // }
//}