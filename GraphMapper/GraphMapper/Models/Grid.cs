using System.Collections.Generic;
using System.Data.Entity;

namespace GraphMapper.Models
{
    public class Grid
    {
        // 2d array to store Tile objects
        public Tile[,] GridMap { get; set; }
        public int ID { get; set; }

        public int Rows { get; set; }
        public int Cols { get; set; }


      
        // default constructor
        public Grid()
        {
            GridMap = new Tile[12, 12]; // default grid 12x12
            this.Rows = GridMap.GetLength(0);
            this.Cols = GridMap.GetLength(1);
        }

        // overloaded constructor
        public Grid(int Rows, int Cols)
        {
            GridMap = new Tile[Rows, Cols];
            this.Rows = Rows;
            this.Cols = Cols;
        }


    }


    public class GridDBContext : DbContext
    {
        public DbSet<Grid> Grid { get; set; }
    }

}