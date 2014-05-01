using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyProgrammer002
{
    class Hero
    {
        public int Score
        {
            public get;
            public set;
        }

        public Boolean Weapon
        {
            public get;
            public set;
        }

        public int Row
        {
            public get;
            public set;
        }

        public int Column
        {
            public get;
            public set;
        }

        public Hero(int row, int column, int score = 0, Boolean weapon = false)
        {
            this.Row = row;
            this.Column = column;
            this.Score = score;
            this.Weapon = weapon;
        }

        public void LootGold()
        {
            Score += 5;
        }

        public void LootWeapon()
        {
            Weapon = true;
            Score += 5;
        }

        public Boolean KillWumpus()
        {
            if(Weapon)
            {
                Score += 10;
                return true;
            } else
            {
                return false;
            }
        }

        public void ExploreEmptyUnvisitedRoom()
        {
            Score += 1;
        }

        public char ToChar()
        {
            return '@';
        }
    }
}
