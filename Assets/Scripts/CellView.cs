using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellView : MonoBehaviour, IPointerClickHandler
{
   public TextMeshProUGUI text;
   public Image icon;
   public Sprite spriteMine;
   public Sprite spriteFlag;
   public Sprite spriteNone;

   private Cell cell;
   private GameBoard board;

   public void Init(Cell c, GameBoard b)
   {
      cell = c;
      board = b;
   }

   public void OnPointerClick(PointerEventData eventData)
   {
      if (board.isEnd) return;
      switch (eventData.button)
      {
         case PointerEventData.InputButton.Right:
            if (!cell.isOpen)
               cell.isFlag = !cell.isFlag;
            break;
         case PointerEventData.InputButton.Left:
            board.OpenCell(cell);
            break;
         case PointerEventData.InputButton.Middle:
            Debug.Log("Middle click on cell!");
            break;
      }
   }

   void Update()
   {
      var rend = GetComponent<Image>();
      if (cell.isOpen)
      {
         if (cell.isMine)
         {
            rend.color = Color.red;
            icon.sprite = spriteMine;
         }
         else
         {
            rend.color = Color.white;
            icon.sprite = spriteNone;
            text.text = cell.MineCountAround.ToString();
            if (cell.MineCountAround == 0)
               text.text = "";
            //смена цвета
         }
      }
      else if (cell.isFlag)
      {
         rend.color = Color.yellow;
         icon.sprite = spriteFlag;
      }
      else
      {
         rend.color = Color.gray;
         icon.sprite = spriteNone;
         text.text = "";
      }
   }
}
