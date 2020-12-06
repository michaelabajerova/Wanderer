using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using GreenFox;
using SharpDX.Direct3D11;

namespace Wanderer.GameMap
{
    class Map
    {
        public int[,] Tiles { get; set; }

        public Map()
        {
           Tiles = new int[10,10];
        }
        public void FillMap(FoxDraw foxDraw)
        {
            string layoutFilePath = @"C:\Users\bajer\Documents\wanderer-cs\Wanderer\bin\Debug\netcoreapp3.1\mapa.txt";
            string[] layout = File.ReadAllLines(layoutFilePath);

            for (int row = 0; row < layout.Length; row++)
            {
                for (int column = 0; column < layout[row].Length; column++)
                {
                  AddBrick(foxDraw, layout[row][column].ToString(), column * 72, row * 72);
                    int.TryParse(layout[row][column].ToString(), out int tile);
                    Tiles[row, column] = tile;
                }
                
            }

        }

        private void AddBrick(FoxDraw foxDraw, string brick, double x, double y)
        {
           string wallBrickPath = @"C:\Users\bajer\Documents\wanderer-cs\img\wall.png";
           string floorBrickPath = @"C:\Users\bajer\Documents\wanderer-cs\img\floor.png";

           bool isFloor = (brick == "1") ? true : false;

            if (isFloor)
            {
                    var image = new Avalonia.Controls.Image();
                    image.Source = new Avalonia.Media.Imaging.Bitmap(floorBrickPath);
                    foxDraw.AddImage(image, x, y);
            }
            else
            {
                    var image = new Avalonia.Controls.Image();
                    image.Source = new Avalonia.Media.Imaging.Bitmap(wallBrickPath);
                    foxDraw.AddImage(image, x, y);
            }

        } 
        public void SaveText()
        {
            string[] toWrite = new string[10];
            string numbers = "";

            for(int i = 0; i < Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < Tiles.GetLength(1); j++)
                {
                    numbers += Tiles[i, j].ToString();
                }
                toWrite[i] = numbers;
                numbers = "";
            }
            File.WriteAllLines("mapa.txt", toWrite);
        }
        public int[,] ReadText()
        {
            int[,] gameBoard = new int[10, 10];
            string[] map = File.ReadAllLines("mapa.txt");

            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                string line = map[i];
                {
                    for (int j = 0; j < gameBoard.GetLength(0); i++)
                    {
                        gameBoard[i, j] = Int32.Parse(line[j].ToString());
                    }
                }
            }
            return gameBoard;
        }
    }
}
