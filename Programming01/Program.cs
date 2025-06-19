namespace Programming01
{
    class Player
    {
        int nATK;
        int nHP;
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
            int playerHP = 100;
            int playerATK = 10;

            int monsterHP = 100;
            int monsterATK = 11;

            while(true)
            {
                Console.WriteLine("\n플레이어 체력: {0}\n몬스터 체력: {1}", playerHP, monsterHP);
                if (playerHP <= 0)
                {
                    Console.WriteLine("플레이어 사망");
                    break;
                }
                monsterHP -= playerATK;
                Console.WriteLine("\n플레이어가 공격");
                Console.WriteLine("\n플레이어 체력: {0}\n몬스터 체력: {1}", playerHP, monsterHP);
                if (playerHP <= 0)
                {
                    Console.WriteLine("몬스터 사망");
                    break;
                }
                playerHP -= monsterATK;
                Console.WriteLine("\n몬스터가 반격");
            }
        }
    }
}
