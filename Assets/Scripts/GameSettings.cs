using System;
using UnityEngine;

public static class GameSettings
{
   public static int BoardSize = 9;
   public static int MineCount = 10;
   private static string UserSeed = "";
   public static bool is2Dmode = false;

   // Итоговый сид, используемый в генерации (если UserSeed пустой, будет использоваться текущая метка времени)
   public static string Seed;

   static GameSettings()
   {
      RandomSeed();
   }

   public static void RandomSeed()
   {
      if (string.IsNullOrEmpty(UserSeed))
      {
         Seed = DateTime.Now.Ticks.ToString();
         Debug.Log($"[GameSettings] Using random seed: {Seed}");
      }
      else
      {
         Seed = UserSeed;
         Debug.Log($"[GameSettings] Using user-defined seed: {Seed}");
      }
   }
}
