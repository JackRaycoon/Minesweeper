using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBoard : MonoBehaviour
{
   public GameObject cellPrefab;
   public GameObject cubeUpPrefab;
   public Transform gridParent;
   public Transform cubeParent;

   public Transform cameraTrans = null;

   public GameObject winPanel, losePanel;

   private Cell[,] board;
   private int remainingCells;
   private bool isFirstOpen = true;
   public bool isEnd = false;

   void Start()
   {
      InitializeBoard();
   }

   void InitializeBoard()
   {
      int size = GameSettings.BoardSize;
      board = new Cell[size, size];
      remainingCells = size * size;

      if (GameSettings.is2Dmode)
      {
         var grid = gridParent.GetComponent<GridLayoutGroup>();
         grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
         grid.constraintCount = size;

         // Вычисляем высоту панели, на которой находится GridLayoutGroup
         float panelHeight = ((RectTransform)gridParent).rect.height;
         float cellSize = panelHeight / size - 10;

         // Задаём квадратный размер ячейки
         grid.cellSize = new Vector2(cellSize, cellSize);
      }
      else
      {
         cameraTrans.position = new((size - 1) / 2f, size + 3, (size + size / 2.5f) / 2f);
      }

      for (int x = 0; x < size; x++)
      {
         for (int y = 0; y < size; y++)
         {
            var cell = new Cell(x, y);
            board[x, y] = cell;

            if (GameSettings.is2Dmode)
            {
               GameObject go = Instantiate(cellPrefab, gridParent);
               go.GetComponent<CellView>().Init(cell, this, true);
            }
            else
            {
               GameObject go = Instantiate(cubeUpPrefab, new Vector3(x, 1, y), Quaternion.Euler(0, 180, 0), cubeParent);
               go.GetComponent<CellView>().Init(cell, this, false);
            }
         }
      }
   }

   public void OpenCell(Cell cell)
   {
      if (cell.isFlag || cell.isOpen || isEnd)
         return;

      if (isFirstOpen)
      {
         isFirstOpen = false;
         PlaceMines(cell);
      }

      cell.isOpen = true;
      remainingCells--;

      if (cell.isMine)
      {
         isEnd = true;
         losePanel.SetActive(true);
         OpenAllMines();
         return;
      }

      if (cell.MineCountAround == 0)
      {
         for (int dx = -1; dx <= 1; dx++)
            for (int dy = -1; dy <= 1; dy++)
            {
               int nx = cell.x + dx;
               int ny = cell.y + dy;
               if (IsInBounds(nx, ny) && !board[nx, ny].isOpen)
                  OpenCell(board[nx, ny]);
            }
      }

      if (remainingCells == GameSettings.MineCount)
      {
         isEnd = true;
         winPanel.SetActive(true);
         FlagAllMines();
      }
   }

   void PlaceMines(Cell exclude)
   {
      System.Random rng = string.IsNullOrEmpty(GameSettings.Seed) ?
          new System.Random() :
          new System.Random(GameSettings.Seed.GetHashCode());

      int placed = 0;
      while (placed < GameSettings.MineCount)
      {
         int x = rng.Next(GameSettings.BoardSize);
         int y = rng.Next(GameSettings.BoardSize);

         Cell c = board[x, y];
         if (!c.isMine && !c.Equals(exclude))
         {
            c.isMine = true;
            IncrementNeighbours(c);
            placed++;
         }
      }
   }

   void IncrementNeighbours(Cell cell)
   {
      for (int dx = -1; dx <= 1; dx++)
         for (int dy = -1; dy <= 1; dy++)
         {
            int nx = cell.x + dx;
            int ny = cell.y + dy;
            if (IsInBounds(nx, ny))
               board[nx, ny].MineCountAround++;
         }

      cell.MineCountAround--; // исключаем саму клетку
   }

   bool IsInBounds(int x, int y)
   {
      return x >= 0 && y >= 0 && x < GameSettings.BoardSize && y < GameSettings.BoardSize;
   }

   void OpenAllMines()
   {
      foreach (var cell in board)
         if (cell.isMine)
            cell.isOpen = true;
   }

   void FlagAllMines()
   {
      foreach (var cell in board)
         if (cell.isMine)
            cell.isFlag = true;
   }

   public void BackToMainMenu()
   {
      SceneManager.LoadScene(0);
   }
}
