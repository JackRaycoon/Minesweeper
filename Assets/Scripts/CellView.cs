using UnityEngine;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
   private Cell cell;
   private GameBoard board;

   public void Init(Cell c, GameBoard b)
   {
      cell = c;
      board = b;
   }

   void OnMouseDown()
   {
      if (Input.GetMouseButton(1)) // права€ кнопка Ч флаг
      {
         if (!cell.isOpen)
            cell.isFlag = !cell.isFlag;
      }
      else
      {
         board.OpenCell(cell);
      }
   }

   void Update()
   {
      var rend = GetComponent<Image>();
      if (cell.isOpen)
      {
         if (cell.isMine)
            rend.color = Color.red;
         else
            rend.color = Color.white;
      }
      else if (cell.isFlag)
         rend.color = Color.yellow;
      else
         rend.color = Color.gray;
   }
}
