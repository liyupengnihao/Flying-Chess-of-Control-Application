using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_飞行棋游戏//0 无效果方块、1幸运轮盘、2地雷、3暂停、4时空隧道、AB相同符号✉
{
    internal class Program
    {

        //  用静态字段模拟全局变量（静态变量属于类本身）
        public static int[] Maps = new int[100];

        //  声明一个数组声明玩家A与B的坐标
        public static int[] PlayerPos = new int[2];//玩家坐标
        public static string[] PlayerName = new string[2];//玩家名字 
        static void Main(string[] args)
        {
            GameHead();//   游戏头

            #region 输入玩家名
            Console.WriteLine("请输入玩家A的姓名");
            PlayerName[0]=Console.ReadLine();
            while (PlayerName[0]=="")
            {
                Console.WriteLine("游戏名不能为空，请重新输入");
                PlayerName[0] = Console.ReadLine();
            }

            Console.WriteLine("请输入玩家B的姓名");
            PlayerName[1]=Console.ReadLine();
            while (PlayerName[1]==""||PlayerName[1]==PlayerName[0])
            {
                if (PlayerName[1]=="")
                {
                    Console.WriteLine("游戏名不能为空，请重新输入");
                    PlayerName[1] = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("B玩家的姓名不能与A玩家相同");
                    PlayerName[1] = Console.ReadLine();
                }
            }
            #endregion


            //  玩家输入名字后应该清屏、初始化地图
            Console.Clear();//类Console里的清屏方法Clear
            GameHead();//清屏后重新打印
            Console.WriteLine("{0}的士兵是A", PlayerName[0]);
            Console.WriteLine("{0}的士兵是B", PlayerName[1]);
            Program.InitailMap();// 初始化地图（方法）方法InitailMap在类Program里，可以省略Program,如下方法DrawMap
            DrawMap();//    画地图（方法）方法DramMap在类Program里，可以省略Program

            //  没到终点一直玩
            while (PlayerPos[0]<99&&PlayerPos[1]<99)
            {
                PlayGame(0);
                if (PlayerPos[0]==99)
                {
                    Console.WriteLine("玩家{0}胜利了,游戏结束", PlayerName[0]);
                    break;
                }
                PlayGame(1);
                if (PlayerPos[1]==99)
                {
                    Console.WriteLine("玩家{0}胜利了,游戏结束", PlayerName[1]);
                    break;
                }
            }
            Console.ReadLine();

        }


        #region 方法：游戏头
        /// <summary>
        /// 游戏头
        /// </summary>
        public static void GameHead()
        {
            //Console.BackgroundColor = ConsoleColor.Green;//背景颜色
            Console.ForegroundColor = ConsoleColor.Red;//前景颜色
            //      BackgroundColor 为Console类中的属性
            //      ForegroundColor
            Console.WriteLine("************************");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("************************");
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("************************");
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("************************");
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("***********飞行棋*******");
            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine("************************");
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("************************");
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("************************");
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("************************");
            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine("************************");
        }
        #endregion



        #region 初始化地图（加载地图所需要的资源）（此为画地图做准备）
        /// <summary>
        /// 初始化地图
        /// </summary>
        public static void InitailMap()
        {
            Console.WriteLine("图例：幸运轮盘☆、地雷♤、暂停▲、时空隧道⊙、普通位置□");
            int[] luckturn = { 6, 23, 40, 55, 69, 83 };//幸运轮盘      1☆
            for (int i = 0; i<luckturn.Length; i++)
            {
                Maps[luckturn[i]] = 1;
            }
            int[] landMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };//地雷  2♤
            for (int i = 0; i<landMine.Length; i++)
            {
                Maps[landMine[i]]=2;
            }
            int[] pause = { 9, 27, 60, 93 };//暂停    3▲
            for (int i = 0; i<pause.Length; i++)
            {
                Maps[pause[i]]=3;
            }
            int[] timeTunnel = { 20, 25, 45, 63, 72, 88, 90 };//时空隧道    4⊙
            for (int i = 0; i<timeTunnel.Length; i++)
            {
                Maps[timeTunnel[i]]=4;
            }
        }

        #endregion


        #region 画地图 方法
        /// <summary>
        /// 画地图
        /// </summary>
        public static void DrawMap()
        {
            //  画第一横行

            #region 画第一横行方法版本（用）
            for (int i = 0; i<30; i++)
            {
                Console.Write(DrawStringMap(i));
            }
            #endregion

            #region 画第一横行switch版本
            //for (int i = 0; i<30; i++)
            //{
            //    //  玩家A与B的坐标相同且都在地图上
            //    if (PlayerPos[0]==PlayerPos[1]&&PlayerPos[1]==i)
            //    {

            //        Console.Write("<>");
            //    }
            //    else if (PlayerPos[0]==i)
            //    {

            //        Console.Write("A");
            //    }
            //    else if (PlayerPos[1]==i)
            //    {

            //        Console.Write("B");
            //    }
            //    else
            //    {
            //        switch (Maps[i])
            //        {
            //            case 0:
            //                Console.ForegroundColor=ConsoleColor.Green;
            //                Console.Write(" □{0}", i);
            //                break;
            //            case 1:
            //                Console.ForegroundColor=ConsoleColor.Red;
            //                Console.Write(" ☆{0}", i);
            //                break;
            //            case 2:
            //                Console.ForegroundColor=ConsoleColor.Yellow;
            //                Console.Write(" ♤{0}", i);
            //                break;
            //            case 3:
            //                Console.ForegroundColor=ConsoleColor.White;
            //                Console.Write(" ▲{0}", i);
            //                break;
            //            case 4:
            //                Console.ForegroundColor=ConsoleColor.Blue;
            //                Console.Write(" ⊙{0}", i);
            //                break;
            //        }
            //    }
            //}
            #endregion

            #region 画第一竖行 if else版
            //for (int i = 0; i<30; i++)
            //{
            //if (Maps[i] == 0)
            //{
            //    Console.Write(" □{0}", i);
            //}
            //else if (Maps[i]==1)
            //{
            //    Console.Write(" ☆{0}", i);
            //}
            //else if (Maps[i]==2)
            //{
            //    Console.Write(" ♤{0}", i);
            //}
            //else if (Maps[i]==3)
            //{
            //    Console.Write(" ▲{0}", i);
            //}
            //else if (Maps[i]==4)
            //{
            //    Console.Write(" ⊙{0}", i);
            //}
            //}
            #endregion

            Console.WriteLine();


            //  画第一竖行

            #region 第一竖行方法版本(用)
            for (int i = 30; i<35; i++)
            {
                for (int j = 0; j<29; j++)
                {
                    Console.Write("  ");
                }
                Console.WriteLine(DrawStringMap(i));
            }
            #endregion

            #region 第一竖行for画空格版本
            //for (int i=30;i<35;i++)
            //{
            //    
            //    for (int j=0;j<28;j++)
            //    {
            //        Console.Write("  ");
            //    }
            //    if (PlayerPos[0]==PlayerPos[1]&&PlayerPos[1]==i)
            //    {
            //        Console.Write("<>");
            //    }
            //    else if (PlayerPos[0]==i)
            //    {
            //        Console.Write("A");
            //    }
            //    else if (PlayerPos[1]==i)
            //    {
            //        Console.Write("B");
            //    }
            //    else
            //    {
            //        switch (Maps[i])
            //        {
            //            case 0:
            //                Console.ForegroundColor=ConsoleColor.Green;
            //                Console.Write(" □{0}", i);
            //                break;
            //            case 1:
            //                Console.ForegroundColor=ConsoleColor.Red;
            //                Console.Write(" ☆{0}", i);
            //                break;
            //            case 2:
            //                Console.ForegroundColor=ConsoleColor.Yellow;
            //                Console.Write(" ♤{0}", i);
            //                break;
            //            case 3:
            //                Console.ForegroundColor=ConsoleColor.White;
            //                Console.Write(" ▲{0}", i);
            //                break;
            //            case 4:
            //                Console.ForegroundColor=ConsoleColor.Blue;
            //                Console.Write(" ⊙{0}", i);
            //                break;
            //        }
            //    }
            //    Console.WriteLine();//  从下一行开始打印
            //}
            #endregion

            #region 第一竖行switch版本
            //for (int i = 30; i<35; i++)
            //{
            //    if (PlayerPos[0]==PlayerPos[1]&&PlayerPos[1]==i)//PlayerPos[1]==i   确保AB在这一段上
            //    {
            //        Console.Write("<>");
            //    }
            //    else if (PlayerPos[0]==i)
            //    {
            //        Console.Write("A");
            //    }
            //    else if (PlayerPos[1]==i)
            //    {
            //        Console.Write("B");
            //    }
            //    else
            //    {
            //        switch (Maps[i])
            //        {
            //            case 0:
            //                Console.ForegroundColor=ConsoleColor.Green;
            //                Console.Write("\n                                                           □{0}", i);
            //                break;
            //            case 1:
            //                Console.ForegroundColor=ConsoleColor.Red;
            //                Console.Write(" \n                                                           ☆{0}", i);
            //                break;
            //            case 2:
            //                Console.ForegroundColor=ConsoleColor.Yellow;
            //                Console.Write(" \n                                                           ♤{0}", i);
            //                break;
            //            case 3:
            //                Console.ForegroundColor=ConsoleColor.White;
            //                Console.Write(" \n                                                           ▲{0}", i);
            //                break;
            //            case 4:
            //                Console.ForegroundColor=ConsoleColor.Blue;
            //                Console.Write(" \n                                                           ⊙{0}", i);
            //                break;
            //        }
            //    }
            //}
            #endregion

            #region 画第一横行if else版
            //for (int i = 30; i<35; i++)
            //{
            //    if (Maps[i] == 0)
            //    {
            //        Console.Write("\n                                                           □{0}", i);
            //    }
            //    else if (Maps[i]==1)
            //    {
            //        Console.Write(" \n                                                           ☆{0}", i);
            //    }
            //    else if (Maps[i]==2)
            //    {
            //        Console.Write(" \n                                                           ♤{0}", i);
            //    }
            //    else if (Maps[i]==3)
            //    {
            //        Console.Write(" \n                                                           ▲{0}", i);
            //    }
            //    else if (Maps[i]==4)
            //    {
            //        Console.Write(" \n                                                           ⊙{0}", i);
            //    }
            //}
            #endregion


            //  画第二横行

            #region 第二横行方法版本（用）
            for (int i = 64; i>34; i--)
            {
                Console.Write(DrawStringMap(i));
            }
            #endregion

            #region 第二横行if else版本
            //for (int i = 64; i>34; i--)
            //{
            //    if (Maps[i] == 0)
            //    {
            //        Console.Write(" □{0}", i);
            //    }
            //    else if (Maps[i]==1)
            //    {
            //        Console.Write(" ☆{0}", i);
            //    }
            //    else if (Maps[i]==2)
            //    {
            //        Console.Write(" ♤{0}", i);
            //    }
            //    else if (Maps[i]==3)
            //    {
            //        Console.Write(" ▲{0}", i);
            //    }
            //    else if (Maps[i]==4)
            //    {
            //        Console.Write(" ⊙{0}", i);
            //    }
            //}
            #endregion

            Console.WriteLine();


            //  第二竖行

            #region 第二竖行方法版本(用)
            for (int i = 65; i<71; i++)
            {
                Console.WriteLine(DrawStringMap(i));
            }
            #endregion

            #region 第二竖行if else 版本
            //for (int i = 65; i<71; i++)
            //{
            //    if (Maps[i]==0)
            //    {
            //        Console.WriteLine(" □{0}", i);
            //    }
            //    else if (Maps[i]==1)
            //    {
            //        Console.WriteLine(" ☆{0}", i);
            //    }
            //    else if (Maps[i]==2)
            //    {
            //        Console.WriteLine(" ♤{0}", i);
            //    }
            //    else if (Maps[i]==3)
            //    {
            //        Console.WriteLine(" ▲{0}", i);
            //    }
            //    else if (Maps[i]==4)
            //    {
            //        Console.WriteLine(" ⊙{0}", i);
            //    }

            //}
            #endregion


            //  第三横行

            #region 第三横行方法版本（用）
            for (int i = 71; i<100; i++)
            {
                Console.Write(DrawStringMap(i));
            }
            #endregion

            #region 第三横行if else版本
            //for (int i = 71; i<100; i++)
            //{
            //    if (Maps[i] == 0)
            //    {
            //        Console.Write(" □{0}", i);
            //    }
            //    else if (Maps[i]==1)
            //    {
            //        Console.Write(" ☆{0}", i);
            //    }
            //    else if (Maps[i]==2)
            //    {
            //        Console.Write(" ♤{0}", i);
            //    }
            //    else if (Maps[i]==3)
            //    {
            //        Console.Write(" ▲{0}", i);
            //    }
            //    else if (Maps[i]==4)
            //    {
            //        Console.Write(" ⊙{0}", i);
            //    }
            //}
            #endregion

            Console.WriteLine();
        }
        #endregion


        //画地图内五种标识与AB是固定的，可以提取为方法

        #region 五中标识与AB的方法
        /// <summary>
        /// 五中标识与AB的方法
        /// </summary>
        /// <param name="i">传Maps的索引</param>
        /// <returns></returns>
        public static string DrawStringMap(int i)
        {
            string str = "";
            if (PlayerPos[0]==PlayerPos[1]&&PlayerPos[1]==i)
            {
                str="<>";
            }
            else if (PlayerPos[0]==i)
            {
                str=" A";
            }
            else if (PlayerPos[1]==i)
            {
                str=" B";
            }
            else
            {
                switch (Maps[i])
                {
                    case 0:
                        Console.ForegroundColor=ConsoleColor.Green;
                        str=" □";
                        break;
                    case 1:
                        Console.ForegroundColor=ConsoleColor.Red;
                        str=" ☆";
                        break;
                    case 2:
                        Console.ForegroundColor=ConsoleColor.Yellow;
                        str=" ♤";
                        break;
                    case 3:
                        Console.ForegroundColor=ConsoleColor.White;
                        str=" ▲";
                        break;
                    case 4:
                        Console.ForegroundColor=ConsoleColor.Blue;
                        str=" ⊙";
                        break;
                }
            }
            return str;
        }
        #endregion

        #region 没用不想删
        ////  普通空格
        //public static void TeShuGeZhi(ref int i)//传玩家位置的下标过来
        //{
        //    int[] luckturn = { 6, 23, 40, 55, 69, 83 };//幸运轮盘      1☆
        //    for (int j = 0; j<luckturn.Length; j++)
        //    {
        //        if (i==luckturn[j])
        //        {
        //            Console.WriteLine("你碰到幸运轮盘了，还能在掷一次");
        //        }
        //    }

        //    int[] landMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };//地雷  2♤
        //    for (int j = 0; j<landMine.Length; j++)
        //    {
        //        if (i==landMine[j])
        //        {
        //            Console.WriteLine("你碰到地雷了，向后退三步");
        //            i-=3;
        //        }
        //    }

        //    int[] pause = { 9, 27, 60, 93 };//暂停    3▲
        //    for (int j = 0; j<pause.Length; j++)
        //    {
        //        if (i == pause[j])
        //        {
        //            Console.WriteLine("你碰到暂停了，下一回合不能动");
        //        }
        //    }

        //    int[] timeTunnel = { 20, 25, 45, 63, 72, 88, 90 };//时空隧道    4⊙
        //    for (int j = 0; j<timeTunnel.Length;j++)
        //    {
        //        if (i==timeTunnel[j])
        //        {
        //            Console.WriteLine("你碰到时空隧道了，向前三步");
        //            i+=3;
        //        }
        //    }
        //}
        #endregion

        /// <summary>
        /// 玩游戏
        /// </summary>
        /// <param name="PlayNumber"></param>
        public static void PlayGame(int PlayNumber)
        {
            Random r = new Random();
            int rNumber = r.Next(1,7);//产生1到6之间的随机数
            Console.WriteLine("{0}按任意键进行游戏", PlayerName[PlayNumber]);
            Console.ReadKey(true);//    true为不显示敲的数 false为显示敲的数 默认为true
            Console.WriteLine("{0}玩家掷出了{1}", PlayerName[PlayNumber],rNumber);
            PlayerPos[PlayNumber]+=rNumber;
            ChangePos();
            Console.ReadKey();
            Console.WriteLine("{0}按任意键行动", PlayerName[PlayNumber]);
            Console.ReadKey();
            Console.WriteLine("{0}行动完了", PlayerName[PlayNumber]);
            Console.ReadKey();
            if (PlayerPos[PlayNumber]==PlayerPos[1-PlayNumber])
            {
                Console.WriteLine("玩家{0}踩到玩家{1}了，玩家{2}退六格", PlayerName[PlayNumber], PlayerName[1-PlayNumber], PlayerName[1 - PlayNumber]);
                PlayerPos[1-PlayNumber]-=6;
                ChangePos();
                Console.ReadKey();
            }
            else
            {
                switch (Maps[PlayerPos[0]])//踩方块
                {
                    case 0:
                        Console.WriteLine("玩家{0}踩到了方块", PlayerName[PlayNumber]);
                        break;
                    case 1:
                        Console.WriteLine("玩家{0}踩到了幸运轮盘,请选择1为与玩家交换位置，2为让另一玩家退六格", PlayerName[PlayNumber]);
                        string input = Console.ReadLine();
                        while (true)
                        {
                            if (input=="1")
                            {
                                Console.WriteLine("玩家{0}选择与玩家{1}交换位置", PlayerName[PlayNumber], PlayerName[1-PlayNumber]);
                                int temp = PlayerPos[0];
                                PlayerPos[0] = PlayerPos[1];
                                PlayerPos[1] = temp;
                                Console.WriteLine("交换成功!!!,按任意键继续");
                                Console.ReadKey();
                                break;
                            }
                            else if (input=="2")
                            {
                                Console.WriteLine("玩家{0}选择让玩家{1}退六格", PlayerName[PlayNumber], PlayerName[1 - PlayNumber]);
                                PlayerPos[1]-=6;
                                ChangePos();
                                Console.WriteLine("玩家{0}退六格成功", PlayerName[1 - PlayNumber]);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("输入错误，请重新输入");
                                input=Console.ReadLine();
                            }
                        }

                        break;
                    case 2:
                        Console.WriteLine("玩家{0}踩到了地雷退六格", PlayerName[PlayNumber]);
                        PlayerPos[0]-=6;
                        ChangePos();
                        break;
                    case 3:
                        Console.WriteLine("玩家{0}踩到了暂停,暂停一回合", PlayerName[PlayNumber]);
                        //  等下写
                        Console.WriteLine("玩家{0}进行一回合", PlayerName[1-PlayNumber]);
                        PlayGame(1-PlayNumber);

                        break;
                    case 4:
                        Console.WriteLine("玩家{0}踩到了时空隧道,前进10格", PlayerName[PlayNumber]);
                        PlayerPos[0]+=10;
                        ChangePos();
                        break;
                }// switch
            }//else
            ChangePos();
            Console.Clear();
            DrawMap();
        }

        /// <summary>
        /// 防止位置超出地图
        /// </summary>
        public static void ChangePos()
        {
            if (PlayerPos[0]<=0)
            {
                PlayerPos[0]=0;
            }
            if (PlayerPos[0]>=99)
            {
                PlayerPos[0]=99;
            }

            if (PlayerPos[1]<=0)
            {
                PlayerPos[1]=0;
            }
            if (PlayerPos[1]>=99)
            {
                PlayerPos[1]=99;
            }
        }
    }
}
