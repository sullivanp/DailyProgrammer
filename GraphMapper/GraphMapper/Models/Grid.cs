using System.Collections.Generic;
using System.Data.Entity;

namespace GraphMapper.Models
{
    public class Grid
    {
        // 2d array to store Tile objects
        Tile[,] Grid;
      
        // default constructor
        public Grid()
        {
            Grid = new Tile[12, 12]; // default grid 12x12
        }

        // overloaded constructor
        public Grid(int Rows, int Cols)
        {
            Grid = new Tile[Rows, Cols];
        }


    }


    public class GridDBContext : DbContext
    {
        public DbSet<Grid> Grid { get; set; }
    }

}