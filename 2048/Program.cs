using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    internal class Program
    {
       
      
        static void Main(string[] args)
        {
          
           GameCore game = new GameCore();

            game.GetNumber();
            game.GetNumber();

            while (true) 
            {
                
                KeyDown(game);
                if (game.ISChange&&game.IsFull!=true)
                {
                    game.GetNumber();
                    WriteArray(game.Map);
                }
                else 
                {
                    Console.WriteLine("Game Over");
                    
                        
                 }
              
            }
           
           
 
            
        }



        public static void KeyDown(GameCore game)
        { 
        switch(Console.ReadLine())
            {
                case "W":
                    game.Move(MoveDirection.up);
                    break;
                case "A":
                    game.Move(MoveDirection.left);
                    break;
                case "S":
                    game.Move(MoveDirection.down);
                    break;
                case "D":
                    game.Move(MoveDirection.right);
                    break;



            }


        }
       
      


        

     


        
        static void WriteArray(int[,]map)
        {
            Console.Clear();
            for (int c = 0; c <= 3; c++)
            {

                for (int b = 0; b <= 3; b++)
                {
                    string s = map[c, b].ToString();
                    Console.Write(s.PadLeft(3,' '));
                   
                }
                Console.WriteLine();


            }
            Console.WriteLine();



        }





    }
}
