using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerHp = 100;
            int playerDef = 20;
            int monsterHp = 100;
            int monsterDef = 20;
            Console.CursorVisible = false;
            int sceneType = 1;
            bool game = true;
            while (game)
            {
                switch (sceneType)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("1. 开始游戏\n2. 退出游戏");
                        ConsoleKeyInfo info = Console.ReadKey();
                        if (info.Key == ConsoleKey.NumPad1)
                        {
                            sceneType = 2;
                        }
                        else if (info.Key == ConsoleKey.NumPad2)
                        {
                            sceneType = 4;
                        }
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        game = true;
                        int playerX = 4;
                        int playerY = 5;
                        int monsterX = 8;
                        int monsterY = 10;
                        int MapHight = 20;
                        int MapWidth = 40;
                        int i, j;
                        for (i = 0; i <= MapHight; i++)
                        {
                            for (j = 0; j <= MapWidth; j++)
                            {
                                if (i == 0 || i == MapHight || j == 0 || j == MapWidth)
                                    Console.Write("#");
                                else if (i == playerY && j == playerX)
                                    Console.Write("♜");
                                else Console.Write(" ");
                            }
                            Console.WriteLine();
                        }
                        while (true)
                        {
                            Console.SetCursorPosition(playerX, playerY);
                            Console.Write("■");
                            if (monsterHp > 0)
                            {
                                Console.SetCursorPosition(monsterX, monsterY);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("■");
                            }
                            ConsoleKeyInfo input = Console.ReadKey();
                            Console.ForegroundColor = ConsoleColor.White;
                            if (input.Key == ConsoleKey.LeftArrow && playerX > 2)
                            {
                                Console.SetCursorPosition(playerX, playerY);
                                Console.Write(" ");
                                playerX -= 2;
                                if (playerX == monsterX && playerY == monsterY && monsterHp > 0)
                                {
                                    sceneType = 3;
                                    break;
                                }
                                Console.SetCursorPosition(playerX, playerY);
                                Console.Write("■");
                            }
                            else if (input.Key == ConsoleKey.RightArrow && playerX < MapWidth - 2)
                            {
                                Console.SetCursorPosition(playerX, playerY);
                                Console.Write(" ");
                                playerX += 2;
                                if (playerX == monsterX && playerY == monsterY && monsterHp > 0)
                                {
                                    sceneType = 3;
                                    break;
                                }
                                Console.SetCursorPosition(playerX, playerY);
                                Console.Write("■");
                            }
                            else if (input.Key == ConsoleKey.UpArrow && playerY > 1)
                            {
                                Console.SetCursorPosition(playerX, playerY);
                                Console.Write(" ");
                                playerY--;
                                if (playerX == monsterX && playerY == monsterY && monsterHp > 0)
                                {
                                    sceneType = 3;
                                    break;
                                }
                                Console.SetCursorPosition(playerX, playerY);
                                Console.Write("■");
                            }
                            else if (input.Key == ConsoleKey.DownArrow && playerY < MapHight - 1)
                            {
                                Console.SetCursorPosition(playerX, playerY);
                                Console.Write(" ");
                                playerY++;
                                if (playerX == monsterX && playerY == monsterY && monsterHp > 0)
                                {
                                    sceneType = 3;
                                    break;
                                }
                                Console.SetCursorPosition(playerX, playerY);
                                Console.Write("■");
                            }
                        }
                        break;
                    case 3:
                        Random r = new Random();
                        int count = 1;
                        while (monsterHp > 0)
                        {
                            Console.Clear();
                            int playerAtk = r.Next(16, 40);
                            int monsterAtk = r.Next(16, 40);
                            if (playerAtk < monsterDef)
                            {
                                monsterHp -= 0;
                            }
                            else
                            {
                                monsterHp -= (playerAtk - monsterDef);
                            }
                            if (monsterAtk < playerDef)
                            {
                                playerHp -= 0;
                            }
                            else
                            {
                                playerHp -= (monsterAtk - playerDef);
                            }
                            if (monsterHp < 0)
                            {
                                monsterHp = 0;
                            }
                            if (playerHp < 0)
                            {
                                playerHp = 0;
                            }
                            Console.WriteLine("第{0}回合：", count);
                            Console.WriteLine("敌人的血量：" + monsterHp);
                            Console.WriteLine("你的血量：" + playerHp);
                            Console.WriteLine();
                            if (monsterHp == 0)
                            {
                                Console.Clear();
                                Console.WriteLine("第{0}回合：", count);
                                Console.WriteLine("敌人的血量：" + monsterHp);
                                Console.WriteLine("你的血量：" + playerHp);
                                Console.WriteLine();
                                Console.WriteLine("你赢了\n");
                                Console.WriteLine("按任意键退出游戏");
                                Console.ReadKey();
                                sceneType = 4;
                                break;
                            }
                            else if (playerHp == 0)
                            {
                                Console.Clear();
                                Console.WriteLine("第{0}回合：", count);
                                Console.WriteLine("敌人的血量：" + monsterHp);
                                Console.WriteLine("你的血量：" + playerHp);
                                Console.WriteLine();
                                Console.WriteLine("你输了\n");
                                Console.WriteLine("按任意键重新开始游戏");
                                playerHp = 100;
                                monsterHp = 100;
                                Console.ReadKey();
                                sceneType = 2;
                                break;
                            }
                            count++;
                            Console.WriteLine("请按任意键进行下一回合");
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        game = false;
                        break;
                }
            }
        }
    }
}