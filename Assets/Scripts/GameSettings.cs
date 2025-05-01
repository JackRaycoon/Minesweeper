using System;
using UnityEngine;

public static class GameSettings
{
   public const int BoardSize = 9;
   public const int MineCount = 10;
   private const string UserSeed = "";

   // Итоговый сид, используемый в генерации (если UserSeed пустой, будет использоваться текущая метка времени)
   public static readonly string Seed;

   static GameSettings()
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
