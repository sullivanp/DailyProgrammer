using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace GraphMapper.Models
{
    public class Grid
    {
        [Key]
        public int GridID { get; set; }

        public int Rows { get; set; }
        public int Cols { get; set; }

        public virtual List<Tile> GridMap { get; set; }
             
        // default constructor
        public Grid() : this(12, 12) {}

        // overloaded constructor
        public Grid(int Rows, int Cols)
        {
            //GridMap = new Tile[Rows, Cols];
            GridMap = new List<Tile>(Rows * Cols);
            for (int row = 0; row != Rows; row++)
            {
                for (int col = 0; col != Cols; col++)
                {
                    GridMap.Add(new Tile());
                }
            }
            this.Rows = Rows;
            this.Cols = Cols;
        }
    }

    public class GridDBContext : DbContext
    {
        public DbSet<Grid> Grids { get; set; }
        public DbSet<Tile> Tiles { get; set; }
    }
}