using System;

namespace Template_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            // temlpate mothod dizayn paterni bi
            // metod icersindeki islemleri soyutlamaya yarar ve farki islemlerde
            //farkli cur kullanmya yarar
            //farki durumlara gore farkli davranan metotlar uzerinde hakim olmak
            ScoringAlgoritm scoringAlgoritm;
            Console.WriteLine("mens");
            scoringAlgoritm = new MensScoringAlgoritm();
          Console.WriteLine(  scoringAlgoritm.GenerateScore(10, new TimeSpan(0, 2,34)));

            Console.WriteLine("women");
            scoringAlgoritm = new WomensScoringAlgoritm();
            Console.WriteLine(scoringAlgoritm.GenerateScore(10, new TimeSpan(0, 2, 34)));

            Console.WriteLine("children");
            scoringAlgoritm = new ChildrensScoringAlgoritm();
            Console.WriteLine(scoringAlgoritm.GenerateScore(10, new TimeSpan(0, 2, 34)));

        }

        abstract class ScoringAlgoritm
        {
            public int GenerateScore(int hits,TimeSpan time)
            {
                int score = CaluclateBaseScore(hits);
                int rediction = CalculateRediction(time);
                return CaluclateOverallScroe(score, rediction);
            }

            public abstract int CaluclateOverallScroe(int score, int rediction);
            public abstract int CaluclateBaseScore(int hits);
            public abstract int CalculateRediction(TimeSpan time);
        }

        class MensScoringAlgoritm : ScoringAlgoritm
        {
            public override int CalculateRediction(TimeSpan time)
            {
                return (int)time.TotalSeconds / 5;
            }

            public override int CaluclateBaseScore(int hits)
            {
                return hits * 100;
            }

            public override int CaluclateOverallScroe(int score, int rediction)
            {
                return score - rediction;
            }
        }
        class WomensScoringAlgoritm : ScoringAlgoritm
        {
            public override int CalculateRediction(TimeSpan time)
            {
                return (int)time.TotalSeconds / 3;
            }

            public override int CaluclateBaseScore(int hits)
            {
                return hits * 100;
            }

            public override int CaluclateOverallScroe(int score, int rediction)
            {
                return score - rediction;
            }
        }
        class ChildrensScoringAlgoritm : ScoringAlgoritm
        {
            public override int CalculateRediction(TimeSpan time)
            {
                return (int)time.TotalSeconds / 2;
            }

            public override int CaluclateBaseScore(int hits)
            {
                return hits * 80 ;
            }

            public override int CaluclateOverallScroe(int score, int rediction)
            {
                return score - rediction;
            }
        }
    }
}
