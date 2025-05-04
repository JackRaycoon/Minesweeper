using System;
using UnityEngine;

public static class GameSettings
{
   public const int BoardSize = 9;
   public const int MineCount = 10;
   private const string UserSeed = "";

   // �������� ���, ������������ � ��������� (���� UserSeed ������, ����� �������������� ������� ����� �������)
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
