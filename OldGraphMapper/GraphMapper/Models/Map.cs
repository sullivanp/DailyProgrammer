using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace GraphMapper.Models
{
    public class Map
    {
        [Key]
        public int MapID { get; set; }

        public int Rows { get; set; }
        public int Columns { get; set; }

        public virtual HashSet<Coordinate> MapData { get; set; }

        public virtual GraphMapperUser Creator { get; set; }

        // default constructor
        public Map() : this(12, 12) {}

        // overloaded constructor
        public Map(int Rows, int Columns)
        {
            MapData = new HashSet<Coordinate>();
            for (int row = 0; row != Rows; row++)
            {
                for (int column = 0; column != Columns; column++)
                {
                    Coordinate coordinate = new Coordinate(row, column);
                    MapData.Add(new Coordinate(row, column) { MapElement = new MapElement(row, column, this.MapID) } );
                }
            }
            this.Rows = Rows;
            this.Columns = Columns;
        }

        // copy constructor
        public Map(Map copy) : this(copy.Rows, copy.Columns)
        {
            foreach(Coordinate coordinate in copy.MapData)
            {
                this.MapData.Add(coordinate);
            }
        }
    }
}