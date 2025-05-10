using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class CellView : MonoBehaviour, IPointerClickHandler
{
   public GameObject upCube;
   public GameObject flagObject;
   public Image icon_GUI;
   public SpriteRenderer icon;
   public Sprite spriteMine;
   public Sprite spriteFlag;
   public List<Sprite> spritesNumber;

   private Cell cell;
   private GameBoard board;
   private bool is2D;

   private Image rend;

   public void Init(Cell c, GameBoard b, bool isD)
   {
      cell = c;
      board = b;
      is2D = isD;
      if(isD)
         rend = GetComponent<Image>();
   }

   public void OnPointerClick(PointerEventData eventData)
   {
      Click((int)eventData.button);
   }

   public void Click(int id)
   {
      if (board.isEnd) return;
      switch (id)
      {
         case 0:
            board.OpenCell(cell);
            break;
         case 1:
            if (!cell.isOpen)
               cell.isFlag = !cell.isFlag;
            break;
         case 2:
            Debug.Log("Middle click on cell!");
            break;
      }
   }

   void Update()
   {
      if (cell.isOpen)
      {
         if(upCube != null)
            upCube.GetComponent<MeshRenderer>().enabled = false;
         if (cell.isMine)
         {
            //rend.color = Color.red; //?
            if (is2D)
            {
               icon_GUI.sprite = spriteMine;
            }
            else
            {
               icon.sprite = spriteMine;
            }
         }
         else
         {
            //rend.color = Color.white;
            if (is2D)
            {
               icon_GUI.sprite = spritesNumber[cell.MineCountAround];
            }
            else
            {
               icon.sprite = spritesNumber[cell.MineCountAround];
            }
            //смена цвета
         }
      }
      else if (cell.isFlag)
      {
         //rend.color = Color.yellow;
         if (is2D)
         {
            icon_GUI.sprite = spriteFlag;
         }
         else
         {
            flagObject.SetActive(true);
         }
      }
      else
      {
         //rend.color = Color.gray;
         if (is2D)
         {
            icon_GUI.sprite = spritesNumber[0];
         }
         else
         {
            icon.sprite = spritesNumber[0];
            flagObject.SetActive(false);
         }
      }
   }
}
