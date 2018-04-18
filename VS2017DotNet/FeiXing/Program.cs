using System;

namespace FeiXing
{
    internal class Program
    {
        public static int[] _Maps = new int[100];//定义地图数组 成员个数为100
        public static int[] _GamePlayerZB = new int[2]; //定义游戏玩家坐标数组，下标为0表示玩家A,为1表示玩家B
        public static string _GamePlayerNameA = "";  //定义玩家A姓名变量
        public static string _GamePlayerNameB = "";  //定义玩家B姓名变量
        public static bool[] _GamePlayer_State = new bool[2]; //定义两个玩家是否投掷状态 0为A 1为B
        public static int[] xingYunLP = new int[] { 9, 18, 32, 37, 61, 68 }; //定义一个幸运轮盘坐标数组
        public static int[] diLei = new int[] { 22, 31, 36, 38, 47, 58, 71 };//定义一个地雷坐标数组
        public static int[] shiKongSD = new int[] { 8, 27, 54, 66, 77, 88 };//定义一个时空隧道坐标数组
        public static int[] zanTing = new int[] { 10, 16, 15, 33, 44, 55, 66 };//定义一个暂停坐标数组

        private static void Main()
        {
            _GamePlayer_State[0] = true;
            GameShowHead();
            GameHead_Select();

            // GamePlayerName(ref _GamePlayerNameA, ref _GamePlayerNameB);
            // StartGame();
        }

        /// <summary>
        /// 游戏头部
        /// </summary>
        public static void GameShowHead()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("┌┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┐");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("├┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┤");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("├┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┤");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("├┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┤");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("├┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┤");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("├┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┤");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("├┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┤");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("├<<<<<<<<<<<小七飞行棋 V1.0>>>>>>>>>>┤");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("├┼┼┼┼┼┼");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Xiaoqi.Me ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("┼┼┼┼┼┼┤");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("├ ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("本程序已在百度贴吧和小七代码本开源");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" ┤");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("├┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┤");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("├┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┤");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("├┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┤");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("├┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┤");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("└┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┘");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ChuMap()
        {
            Console.Clear();
            Console.WriteLine("玩家:{0} 用 A表示 玩家:{1} 用 B 表示", _GamePlayerNameA, _GamePlayerNameB);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("图例：");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("□ 为普通关卡 ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("☆ 为幸运轮盘 ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("¤ 为极限地雷 ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("◎ 为时空隧道 ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("△ 为极限暂停 ");
            Console.WriteLine();

            #region 判断下标并给地图类型 switch写法 但是考虑到后面需要用一个判断，所以此方法不行

            //for (int i = 0; i < _Maps.Length; i++)
            //{
            //switch (i)
            //{
            //    case 7:
            //    case 18:
            //    case 27:
            //    case 39:
            //        {
            //            _Maps[i] = 1;
            //            break;
            //        }
            //    case 10:
            //    case 12:
            //    case 30:
            //        {
            //            _Maps[i] = 2;
            //            break;
            //        }
            //    case 17:
            //    case 37:
            //    case 47:
            //        {
            //            _Maps[i] = 3;
            //            break;
            //        }
            //    case 9:
            //    case 19:
            //    case 20:
            //        {
            //            _Maps[i] = 4;
            //            break;
            //        }
            //    default:
            //        {
            //            _Maps[i] = 0;
            //            break;
            //        }
            //}
            //}

            #endregion 判断下标并给地图类型 switch写法 但是考虑到后面需要用一个判断，所以此方法不行

            #region 判断下标并初始化地图

            foreach (var t in xingYunLP)
            {
                _Maps[t] = 1; //定义幸运轮盘的类型值为1 并赋予给地图数组
            }
            foreach (var t in diLei)
            {
                _Maps[t] = 2; //定义地雷的类型值为1 并赋予给地图数组
            }
            foreach (var t in shiKongSD)
            {
                _Maps[t] = 3;//定义时空隧道的类型值为3 并赋予地图数组
            }
            foreach (var t in zanTing)
            {
                _Maps[t] = 4;//定义暂停的类型值为4 并赋予地图数组
            }
            //初始化地图是将所有值都赋值0，而0在类型中表示普通关卡

            #endregion 判断下标并初始化地图

            ChuMap_Hua();
        }

        /// <summary>
        /// 该方法为画地图
        /// </summary>
        public static void ChuMap_Hua()
        {
            //逐行画地图，因为地图数组是固定的 So.
            ChuMap_Draw_Zline(0, 30);
            Console.WriteLine(); //每行结束需换行
            ChuMap_Draw_list(30);
            Console.WriteLine(); //每行结束需换行
            ChuMap_Draw_list(31);
            Console.WriteLine(); //每行结束需换行
            ChuMap_Draw_list(32);
            Console.WriteLine(); //每行结束需换行
            ChuMap_Draw_list(33);
            Console.WriteLine(); //每行结束需换行
            ChuMap_Draw_list(34);
            Console.WriteLine(); //每行结束需换行
            ChuMap_Draw_Fline(35, 64);
            Console.WriteLine(); //每行结束需换行
            ChuMap_Draw_Dlist(64);
            Console.WriteLine(); //每行结束需换行
            ChuMap_Draw_Dlist(65);
            Console.WriteLine(); //每行结束需换行
            ChuMap_Draw_Dlist(66);
            Console.WriteLine(); //每行结束需换行
            ChuMap_Draw_Dlist(67);
            Console.WriteLine(); //每行结束需换行
            ChuMap_Draw_Dlist(68);
            Console.WriteLine(); //每行结束需换行
            ChuMap_Draw_Zline(69, 99);
            Console.WriteLine(); //每行结束需换行
        }

        /// <summary>
        /// 判断地图数组中储存的类型，并画出地图元素
        /// </summary>
        /// <param name="mold">传进的值</param>
        public static void ChuMap_Judge(int mold)
        {
            if (_GamePlayerZB[0] == mold && _GamePlayerZB[1] != mold)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("A");
            }
            else if (_GamePlayerZB[0] != mold && _GamePlayerZB[1] == mold)

            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("B");
            }
            else if (_GamePlayerZB[0] == mold && _GamePlayerZB[1] == mold)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("卍");
            }
            else if (_GamePlayerZB[0] != mold && _GamePlayerZB[1] != mold)
            {
                switch (_Maps[mold])
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("□");
                        break;

                    case 1:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("☆");
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("¤");
                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("◎");
                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("△");
                        break;
                }
            }
        }

        /// <summary>
        /// 正序输出一行
        /// </summary>
        /// <param name="zLineMix">地图数组元素下标范围最小值</param>
        /// <param name="zLineMax">地图数组元素下标范围最大值</param>
        public static void ChuMap_Draw_Zline(int zLineMix, int zLineMax)
        {
            //正行总数有30个
            for (int lineOne = zLineMix; lineOne < zLineMax; lineOne++)
            {
                ChuMap_Judge(lineOne);
            }
        }

        /// <summary>
        /// 画地图列
        /// </summary>
        /// <param name="list">地图数组下标的值</param>
        public static void ChuMap_Draw_list(int list)
        {
            //第二行总数也有30个，但是只画最后一个元素
            //前面为29*2个空格
            for (int lineOne = 0; lineOne < 30; lineOne++)
            {
                if (lineOne != 29)
                {
                    Console.Write("  ");
                }
                else
                {
                    ChuMap_Judge(list);
                }
            }
        }

        /// <summary>
        /// 倒叙输出一行
        /// </summary>
        /// <param name="fLineMix">地图数组的元素下标范围最小</param>
        /// <param name="fLineMax">地图数组的元素下标范围最大</param>
        public static void ChuMap_Draw_Fline(int fLineMix, int fLineMax)
        {
            //反行总数为30，但要求将地图数组的各个元素倒叙打印
            //定义循环反序实现
            for (int lineOne = fLineMax; lineOne >= fLineMix; lineOne--)
            {
                ChuMap_Judge(lineOne);
            }
        }

        /// <summary>
        /// 正序输出列
        /// </summary>
        /// <param name="dList">地图数组的元素下标</param>
        public static void ChuMap_Draw_Dlist(int dList)
        {
            ChuMap_Judge(dList);

            for (int i = 0; i < 29; i++)
            {
                Console.Write("  ");
            }
        }

        /// <summary>
        /// 接收用户输入的玩家姓名
        /// </summary>
        /// <param name="_NameA">ref参数，填写需要改变的string 类型的变量</param>
        /// <param name="_NameB">ref参数，填写需要改变的string 类型的变量</param>
        public static void GamePlayerName(ref string _NameA, ref string _NameB)
        {
            bool aIsOk = false; //定义玩家A的姓名是否输入完毕
            string nameA = "";  //初始化局部变量 ，玩家A
            string nameB;  //初始化局部变量 ，玩家B
            while (true) //定义死循环
            {
                if (aIsOk != true) //判断玩家A是否输入完毕
                {
                    Console.Write("请输入玩家A的名称：");
                    nameA = Console.ReadLine(); //接收并赋予
                    if (nameA == "") //判断是否为空
                    {
                        Console.WriteLine("请不要输入空：");//提示重新输入
                        continue; //返回死循环头
                    }

                    aIsOk = true; //输入正确并写入判断的bool变量
                }

                Console.Write("请输入玩家B的名称：");
                nameB = Console.ReadLine();
                if (nameB == "")
                {
                    Console.WriteLine("请不要输入空：");
                    continue;
                }
                else if (nameB == nameA)
                {
                    Console.WriteLine("请不要与玩家A的名字相同");
                    continue;
                }

                _NameA = nameA; //玩家都输入正确 赋值给参数
                _NameB = nameB;
                break; //跳出死循环
            }
        }

        /// <summary>
        ///返回随机数
        /// </summary>
        /// <returns>返回随机数</returns>
        public static int GetRandomNum()
        {
            Random randomNum = new Random(); //创建对象
            return randomNum.Next(1, 7); //返回1-6中随机的数字
        }

        /// <summary>
        /// 投掷色子
        /// </summary>
        /// <param name="diceNum">色子数</param>
        public static void CastDice(int diceNum)
        {
            if (_GamePlayer_State[0])
            {
                Console.Write("玩家{0}开始投掷色子", _GamePlayerNameA);
                Console.ReadLine();
                Console.WriteLine("玩家{0},投出了{1},前进{2}格", _GamePlayerNameA, diceNum, diceNum);
                _GamePlayerZB[0] += diceNum;
                GameMatterJudge(_GamePlayerZB[0], 0);
                _GamePlayer_State[0] = false;
                _GamePlayer_State[1] = true;
                Console.ReadLine();
                return;
            }

            if (_GamePlayer_State[1])
            {
                Console.Write("玩家{0}开始投掷色子", _GamePlayerNameB);
                Console.ReadLine();
                Console.WriteLine("玩家{0},投出了{1},前进{2}格", _GamePlayerNameB, diceNum, diceNum);
                _GamePlayerZB[1] += diceNum;
                GameMatterJudge(_GamePlayerZB[1], 1);
                _GamePlayer_State[1] = false;
                _GamePlayer_State[0] = true;

                Console.ReadLine();
            }
        }

        /// <summary>
        /// 玩家A加投一局
        /// </summary>
        /// <param name="diceNum">色子数</param>
        public static void CastDice_A(int diceNum)
        {
            Console.Write("玩家{0}开始投掷色子", _GamePlayerNameA);
            Console.ReadLine();
            Console.WriteLine("玩家{0},投出了{1},前进{2}格", _GamePlayerNameA, diceNum, diceNum);
            _GamePlayerZB[0] += diceNum;
            GameMatterJudge(_GamePlayerZB[0], 0);
        }

        /// <summary>
        /// 玩家B加一局
        /// </summary>
        /// <param name="diceNum">色子数</param>
        public static void CastDice_B(int diceNum)
        {
            Console.Write("玩家{0}开始投掷色子", _GamePlayerNameB);
            Console.ReadLine();
            Console.WriteLine("玩家{0},投出了{1},前进{2}格", _GamePlayerNameB, diceNum, diceNum);
            _GamePlayerZB[1] += diceNum;
            GameMatterJudge(_GamePlayerZB[1], 1);
        }

        /// <summary>
        /// 游戏中
        /// </summary>
        public static void StartGame()
        {
            if (_GamePlayerZB[0] >= 99)
            {
                ShowGameOver(0);
                return;
            }
            if (_GamePlayerZB[1] >= 99)
            {
                ShowGameOver(1);
                return;
            }
            ChuMap();
            CastDice(GetRandomNum());
            StartGame();
        }

        /// <summary>
        /// 游戏结束判断并结束游戏
        /// </summary>
        /// <param name="gameNameNum">赢的玩家名称下标</param>
        public static void ShowGameOver(int gameNameNum)
        {
            string nameA = "";
            string nameB = "";

            if (gameNameNum == 0)
            {
                nameA = _GamePlayerNameA;
                nameB = _GamePlayerNameB;
            }
            else if (gameNameNum == 1)
            {
                nameA = _GamePlayerNameB;
                nameB = _GamePlayerNameA;
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("玩家{0}赢了玩家{1}", nameA, nameB);
            Console.WriteLine("         .----.");
            Console.WriteLine("      _.'__    `. ");
            Console.WriteLine("  .--(#)(##)---/#\\ ");
            Console.WriteLine("' @          /###\\ ");
            Console.WriteLine(":         ,   #####");
            Console.WriteLine("`-..__.- ' _.-\\###/  ");
            Console.WriteLine("       `; _:    `\"'\\");
            Console.WriteLine("      .'\"\"\"\"\"`.");
            Console.WriteLine("     /\\,  Game  ,\\");
            Console.WriteLine("   //   Over!  \\");
            Console.WriteLine("   `-._For_7_.- '");
            Console.WriteLine("   ___`. | .'___ ");
            Console.WriteLine("  (______ | ______)");
            Console.ReadLine();
        }

        /// <summary>
        /// 游戏开始提示
        /// </summary>
        public static void GameHead_Select()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("A、开始游戏(输入A)   ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("B、查看说明（输入B）");
            Console.ForegroundColor = ConsoleColor.White;
            string select = Console.ReadLine();
            if (select != "A" && select != "B" && select != "a" && select != "b")
            {
                Console.WriteLine("Error!");
                Console.Clear();
                GameShowHead();
                GameHead_Select();
            }
            else if (select == "A" || select == "a")
            {
                Console.Clear();
                GameHead_SetName();
            }
            else if (select == "B" || select == "b")
            {
                GameShow_Explain();
                Console.WriteLine("说明结束   按任意键返回！");
                Console.ReadKey();
                Console.Clear();
                GameHead_ShowOne();
            }
        }

        /// <summary>
        /// 显示游戏头并返回选择选项
        /// </summary>
        public static void GameHead_ShowOne()
        {
            GameShowHead();
            GameHead_Select();
        }

        /// <summary>
        /// 选择完毕，并设置玩家名称开始游戏
        /// </summary>
        public static void GameHead_SetName()
        {
            GameShowHead();
            GamePlayerName(ref _GamePlayerNameA, ref _GamePlayerNameB);
            StartGame();
        }

        /// <summary>
        /// 输出游戏说明
        /// </summary>
        public static void GameShow_Explain()
        {
            ChuMap();
            Console.Write("如图所示：");
            Console.Write("第一行显示正在玩的玩家。");
            Console.WriteLine("游戏关卡分为图例中的几种类型：");
            Console.WriteLine("幸运轮盘：");
            Console.WriteLine("1、可选择攻击另一个玩家，让其后退6个棋盘");
            Console.WriteLine("2、可选择与另一个玩家交换坐标");
            Console.WriteLine("地雷：");
            Console.WriteLine("1、让踩到的玩家后退六格子");
            Console.WriteLine("时空隧道：");
            Console.WriteLine("1、让踩到的玩家前进六格子");
            Console.WriteLine("暂停：");
            Console.WriteLine("1、让踩到的玩家暂停一回合");
            Console.WriteLine("方块：");
            Console.WriteLine("1、平常前进");
        }

        public static void GameMatterJudge(int coord, int GamePlayerNum)
        {
            foreach (var t in xingYunLP)
            {
                if (coord == t)
                {
                    //执行幸运轮盘事件
                    Game_Matter_Luck(GamePlayerNum);
                }
            }
            foreach (var t in diLei)
            {
                if (coord == t)
                {
                    //执行地雷事件
                    Game_Matter_Mine(GamePlayerNum);
                }
            }
            foreach (var t in shiKongSD)
            {
                if (coord == t)
                {
                    //执行时空隧道事件
                    Game_Matter_Tube(GamePlayerNum);
                }
            }
            foreach (var t in zanTing)
            {
                if (coord == t)
                {
                    //执行暂停事件
                    Game_Matter_Pause(GamePlayerNum);
                }
            }
        }

        /// <summary>
        /// 幸运轮盘事件
        /// </summary>
        /// <param name="GamePlayerNum">获得玩家的标识</param>
        public static void Game_Matter_Luck(int GamePlayerNum)

        {
            while (true)
            {
                string name = GamePlayerNum == 0 ? _GamePlayerNameA : _GamePlayerNameB;
                Console.WriteLine("玩家{0}，进入幸运轮盘", name);
                Console.WriteLine("请选择执行方式：A、攻击对方（输入A） B、与对方调换位置");
                string set = Console.ReadLine();
                if (set != "A" && set != "B")
                {
                    Console.Clear();
                    ChuMap();
                    continue;
                }
                else if (set == "A")
                {
                    _GamePlayerZB[GamePlayerNum == 0 ? 1 : 0] -= 6;
                    Console.WriteLine("对方被攻击，后退6格，无视新地域属性");
                    //GameMatterJudge(_GamePlayerZB[GamePlayerNum], GamePlayerNum);
                    break;
                }
                else if (set == "B")
                {
                    var temp = _GamePlayerZB[0];
                    _GamePlayerZB[0] = _GamePlayerZB[1];
                    _GamePlayerZB[1] = temp;
                    Console.WriteLine("您与对方成功交换位置！，双方无视新地域属性");
                    break;
                }
            }
        }

        /// <summary>
        /// 地雷事件
        /// </summary>
        /// <param name="GamePlayerNum">提供一个玩家的标识</param>
        public static void Game_Matter_Mine(int GamePlayerNum)
        {
            string name = GamePlayerNum == 0 ? _GamePlayerNameA : _GamePlayerNameB;
            Console.WriteLine("玩家{0},踩到地雷,后退6格，无视新地域属性", name);
            _GamePlayerZB[GamePlayerNum] -= 6;
        }

        /// <summary>
        /// 时空隧道事件
        /// </summary>
        /// <param name="GamePlayerNum">提供一个玩家标识</param>
        public static void Game_Matter_Tube(int GamePlayerNum)
        {
            string name = GamePlayerNum == 0 ? _GamePlayerNameA : _GamePlayerNameB;
            Console.WriteLine("玩家{0},进入隧道,前进6格，无视新地域属性", name);
            _GamePlayerZB[GamePlayerNum] += 6;
        }

        /// <summary>
        /// 暂停事件[小七是用对手增加一轮投色子来实现相对于该玩家暂停一轮]
        /// </summary>
        /// <param name="GamePlayerNum"></param>
        public static void Game_Matter_Pause(int GamePlayerNum)
        {
            string name = GamePlayerNum == 0 ? _GamePlayerNameA : _GamePlayerNameB;
            Console.WriteLine("玩家{0},踩到暂停，暂停一轮", name);
            if (GamePlayerNum == 0)
            {
                CastDice_B(GetRandomNum());
            }
            else
            {
                CastDice_A(GetRandomNum());
            }
        }
    }
}
