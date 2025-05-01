public class Cell
{
   public int x, y;
   public int MineCountAround;
   public bool isMine;
   public bool isFlag;
   public bool isOpen;

   public Cell(int x, int y)
   {
      this.x = x;
      this.y = y;
      MineCountAround = 0;
      isMine = false;
      isFlag = false;
      isOpen = false;
   }
}
