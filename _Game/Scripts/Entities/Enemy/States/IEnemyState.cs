
namespace BlockSurvive.Entities.Enemy.States
{
    public interface IEnemyState
    {
        void Enter();
        void Tick();
        void Exit();
    }
}
