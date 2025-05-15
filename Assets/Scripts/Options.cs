using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
   public TextMeshProUGUI textSizeBoard, textMinesCount;
   public Slider sliderBoardSize, sliderMinesCount;
   public TMP_InputField textSeed;

   private void Start()
   {
      sliderBoardSize.value = GameSettings.BoardSize;
      MinesCountMinMax();
      textSeed.text = GameSettings.UserSeed;
   }

   void Update()
   {
      textSizeBoard.text = $"Board Size: {sliderBoardSize.value}x{sliderBoardSize.value}";
      textMinesCount.text = $"Mines Count: {GameSettings.MineCount}";
   }

   void MinesCountMinMax()
   {
      sliderMinesCount.minValue = 1;
      sliderMinesCount.maxValue = GameSettings.BoardSize * GameSettings.BoardSize - 1;
      sliderMinesCount.value = (GameSettings.BoardSize * GameSettings.BoardSize - 1) / 8;
   }

   public void ChangeSizeBoard()
   {
      GameSettings.BoardSize = (int)sliderBoardSize.value;
      MinesCountMinMax();
   }
   public void ChangeMinesCount()
   {
      GameSettings.MineCount = (int)sliderMinesCount.value;
   }

   public void ChangeSeed()
   {
      GameSettings.UserSeed = textSeed.text;
   }
}
