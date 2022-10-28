using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _2048
{
    class GameCore
    {
       
        public bool IsFull;
        private bool IsChange;
        private int index;
        private int[,] map;
        private int[,] maporigin;
        private int[] MoveArray;
        int[] item;
        private List<Location> EmptyList;
        private Random random;
        public GameCore()
        {
            
            random = new Random();
            map = new int[4, 4];
            MoveArray = new int[4];
            item = new int[4];
            EmptyList = new List<Location>(16);
            maporigin = new int[4, 4];
        }
        public int[,] Map
        {
            get
            { return map; }
        }
        public bool ISChange { get { return IsChange; } }
        public void Move(MoveDirection direction)
        {
            Array.Copy(map, maporigin, map.Length);
            IsChange = false;
            IsFull = false;
            switch (direction)
            {
                case MoveDirection.up:
                    UpMove();
                    break;
                case MoveDirection.down:
                    DownMove();
                    break;
                case MoveDirection.left:
                    LeftMove();
                    break;
                case MoveDirection.right:
                    RightMove();
                    break;

            }
            for (int r = 0; r < map.GetLength(0); r++)
            {

                for (int c = 0; c < map.GetLength(1); c++)
                {
                    if (map[r, c] != maporigin[r, c])
                    {

                        IsChange = true;
                    }

                }

            }
             int Number=0;
            for (int r = 0; r < map.GetLength(0); r++)
            {

                for (int c = 0; c < map.GetLength(1); c++)
                {
                    if (map[r, c] !=0)
                    {
                        Number++;
                        
                    }

                }

            }
            if (Number == 0) { IsFull = true; }
        }


        /// <summary>
        /// 获得空位置
        /// </summary>
        private void Empty()
        {
            EmptyList.Clear();
            for (int c = 0; c < map.GetLength(0); c++)
            {
                for (int r = 0; r < map.GetLength(1); r++)
                {
                    if (map[c, r] == 0)
                    {

                        EmptyList.Add(new Location(c, r));

                    }

                }

            }

        }
        /// <summary>
        /// 插入数值2或者4
        /// </summary>
        public void GetNumber()
        {
            Empty();
            int randomindex = random.Next(0, EmptyList.Count);
            Location loc = EmptyList[randomindex];
            map[loc.Cindex, loc.Rindex] = random.Next(0, 10) == 1 ? 4 : 2;



        }






        /// <summary>
        /// 消零操作
        /// </summary>
        /// <param name="MoveArray"></param>
        private void ClearZero()
        {
            index = 0;
            Array.Clear(item, 0, 4);
            for (int i = 0; i < MoveArray.Length; i++)
            {
                if (MoveArray[i] != 0)
                {
                    item[index] = MoveArray[i];
                    index++;
                }
            }
            item.CopyTo(MoveArray, 0);
        }
        /// <summary>
        /// 合并操作
        /// </summary>
        /// <param name="MoveArray"></param>
        private void Merge()
        {
            ClearZero();
            for (int i = 0; i < MoveArray.Length - 1; i++)
            {
                if (MoveArray[i] != 0 && MoveArray[i] == MoveArray[i + 1])
                {
                    MoveArray[i] = MoveArray[i + 1] + MoveArray[i];
                    MoveArray[i + 1] = 0;
                }
            }
            ClearZero();
        }

        /// <summary>
        /// 向左移动
        /// </summary>
        /// <param name="map"></param>
        private void LeftMove()
        {

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    MoveArray[j] = map[i, j];


                }

                Merge();


                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = MoveArray[j];

                }


            }

        }

        /// <summary>
        /// 向右移动
        /// </summary>
        /// <param name="map"></param>
        private void RightMove()
        {

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = map.GetLength(1) - 1; j >= 0; j--)
                {
                    MoveArray[map.GetLength(1) - 1 - j] = map[i, j];
                }
                Merge();
                for (int j = map.GetLength(1) - 1; j >= 0; j--)
                {
                    map[i, j] = MoveArray[map.GetLength(1) - 1 - j];
                }
            }
        }

        /// <summary>
        /// 向下移动
        /// </summary>
        /// <param name="map"></param>
        private void DownMove()
        {

            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int j = map.GetLength(0) - 1; j >= 0; j--)
                {
                    MoveArray[map.GetLength(0) - 1 - j] = map[j, i];
                }
                Merge();
                for (int j = map.GetLength(0) - 1; j >= 0; j--)
                {
                    map[j, i] = MoveArray[map.GetLength(0) - 1 - j];
                }
            }
        }



        /// <summary>
        /// 向上移动
        /// </summary>
        /// <param name="map"></param>
        private void UpMove()
        {

            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    MoveArray[j] = map[j, i];
                }
                Merge();
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    map[j, i] = MoveArray[j];
                }
            }
        }


    }
}
