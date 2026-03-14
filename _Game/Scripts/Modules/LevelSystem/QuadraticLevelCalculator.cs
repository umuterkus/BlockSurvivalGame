using BlockSurvive.Interfaces;

namespace BlockSurvive.Modules.LevelSystem
{
    public class QuadraticLevelCalculator : ILevelCalculator
    {
        public int XPToNextLevel(int level)
        {
            return 25 * level * level;
        }

    }
}