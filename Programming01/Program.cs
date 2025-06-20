namespace Programming01
{
    class Player
    {
        public int ATK;
        public int HP;
        public int exp;
        public int level;

        public bool Death()
        {
            if(HP <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Player(int ATK, int HP, int exp, int level)
        {
            this.ATK = ATK;
            this.HP = HP;
            this.exp = exp;
            this.level = level;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //Console.WriteLine("Add:" + Add(10, 20));
            //ValMain();
            //PlayerAttackMain();
            //StageMain();
            //CriticalAttackMain();
            //MonsterListMain();
            BattleMain();
        }
        static int Add(int a, int b)
        {
            int c = a + b;
            return c;
        }

        static void ValMain()
        {
            int nScore = 0;
            float fRat = 1.0f / 4.0f;
            Console.WriteLine("Score: " + nScore);
            Console.WriteLine("Rat: " + fRat);
        }

        static void PlayerAttackMain()
        {
            int nMonsterATK = 10;
            int nPlayerHP = 100;

            Console.WriteLine("남은 HP" + nPlayerHP);
            nPlayerHP -= nMonsterATK;
            Console.WriteLine("남은 HP" + nPlayerHP);
        }

        static void StageMain()
        {
            Console.WriteLine("이동할 장소를 입력하세요.(마을, 필드, 상점)");
            string strInput = Console.ReadLine();
            switch (strInput)
            {
                case "마을":
                    Console.WriteLine("마을입니다.");
                    break;
                case "필드":
                    Console.WriteLine("필드입니다.");
                    break;
                case "상점":
                    Console.WriteLine("상점입니다.");
                    break;
            }
        }

        static void CriticalAttackMain()
        {
            int nPlayerATK = 10;
            int nMonsterHP = 100;
            Random cRandom = new Random();
            while (true)
            {
                int nRandom = cRandom.Next(1, 3);
                Console.WriteLine("(공격전) 몬스터의 남은 체력: " + nMonsterHP + "플레이어의 공격력: " + nPlayerATK);
                if (nRandom == 1)
                {
                    nMonsterHP -= (int)(nPlayerATK * 1.5f);
                    Console.WriteLine("크리티컬!");
                }
                else
                {
                    nMonsterHP -= nPlayerATK;
                }
                Console.WriteLine("(공격후) 몬스터의 남은 체력: " + nMonsterHP + "플레이어의 공격력: " + nPlayerATK);
                if (nMonsterHP <= 0)
                {
                    Console.WriteLine("몬스터 사망");
                    break;
                }
            }
        }

        //데이터: 플레이어의 공격력, 플레이어의 체력, 몬스터의 공격력, 몬스터의 체력
        //알고리즘: 플레이어가 먼저 공격하고, 몬스터가 맞고나서 반격한다. 한쪽이 죽을때까지 반복한다.

        static void MonsterListMain()
        {
            List<string> listMonster = new List<string>();

            listMonster.Add("슬라임");
            listMonster.Add("스켈레톤");
            listMonster.Add("좀비");
            listMonster.Add("드래곤");

            Console.WriteLine(listMonster[0]);
            Console.WriteLine(listMonster[3]);

            for (int i = 0; i < listMonster.Count; i++)
            {
                Console.WriteLine("monster[{0}]: {1}", i, listMonster[i]);
            }
        }

        static void BattleMain()
        {
            Player player = new Player(30, 200, 0, 1);
            Random random = new Random();

            while(player.HP > 0)
            {
                Console.WriteLine("몬스터 등장!");
                Player monster = new Player(20, 100, 0, 0);
                while (monster.HP > 0)
                {
                    Console.WriteLine("남은 체력: {0}\n몬스터 체력: {1}", player.HP, monster.HP);
                    while (true)
                    {
                        string act = Console.ReadLine();
                        if (act == "공격")
                        {
                            int nRandom = random.Next(0, 3);
                            if (nRandom == 0)
                            {
                                Console.WriteLine("크리티컬!");
                                monster.HP -= (int)(player.ATK * 1.5f);
                                Console.WriteLine("공격! {0}의 데미지를 입혔다.(몬스터의 남은 체력: {1})", (int)(player.ATK * 1.5f), monster.HP);
                            }
                            else
                            {
                                monster.HP -= player.ATK;
                                Console.WriteLine("공격! {0}의 데미지를 입혔다.(몬스터의 남은 체력: {1})", player.ATK, monster.HP);
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("'공격'을 입력하세요.");
                        }
                    }
                    Console.ReadLine();
                    if(monster.Death())
                    {
                        Console.WriteLine("몬스터 처치!");
                        player.exp += 10;
                        break;
                    }
                    player.HP -= monster.ATK;
                    Console.WriteLine("몬스터의 반격! {0}의 데미지를 입었다.(남은체력: {1})", monster.ATK, player.HP);
                    if(player.Death())
                    {
                        Console.WriteLine("플레이어 사망");
                        break;
                    }
                }
                Console.ReadLine();
                if (player.exp == 50)
                {
                    player.level += 1;
                    Console.WriteLine("레벨업!(현재레벨: {0})", player.level);
                    player.exp = 0;
                }
            }
        }
    }
}
