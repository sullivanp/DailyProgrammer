﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace GraphMapper.Models
{
    public class Grid
    {
        // 2d array to store Tile objects
        //public virtual Tile[,] GridMap { get; set; }
        [Key]
        public int ID { get; set; }

        public int Rows { get; set; }
        public int Cols { get; set; }

        public List<Tile> GridMap { get; set; }
       
      
        // default constructor
        public Grid()
        {
            //GridMap = new Tile[12, 12]; // default grid 12x12
            GridMap = new List<Tile>(12);
            //this.Rows = GridMap.GetLength(0);
            //this.Cols = GridMap.GetLength(1);
            this.Rows = 12;
            this.Cols = 12;
        }

        // overloaded constructor
        public Grid(int Rows, int Cols)
        {
            //GridMap = new Tile[Rows, Cols];
            GridMap = new List<Tile>(Cols);
            this.Rows = Rows;
            this.Cols = Cols;
        }


    }


    public class GridDBContext : DbContext
    {
        public DbSet<Grid> Grid { get; set; }
    }

}