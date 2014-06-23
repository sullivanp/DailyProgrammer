using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraphMapper.Models
{
    public class Coordinate : IEquatable<Coordinate>
    {
        [Key]
        public int CoordinateID { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public MapElement MapElement { get; set; }

        public Coordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }
            Coordinate coordinate = obj as Coordinate;
            if(((System.Object)coordinate) == null)
            {
                return false;
            }
            return ((Row == coordinate.Row) && (Column == coordinate.Column) && (MapElement == coordinate.MapElement));
        }

        public bool Equals(Coordinate coordinate)
        {
            return((Row == coordinate.Row) && (Column == coordinate.Column) && (MapElement == coordinate.MapElement));
        }

        public override int GetHashCode()
        { 
            return ShiftAndWrap(Row.GetHashCode(), 2) ^ Column.GetHashCode();
        } 

        private int ShiftAndWrap(int value, int positions)
        {
            positions = positions & 0x1F;

            // Save the existing bit pattern, but interpret it as an unsigned integer. 
            uint number = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
            // Preserve the bits to be discarded. 
            uint wrapped = number >> (32 - positions);
            // Shift and wrap the discarded bits. 
            return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) | wrapped), 0);
        }
    }
}