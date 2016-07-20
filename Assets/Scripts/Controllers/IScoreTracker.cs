using UnityEngine.EventSystems;

public interface IScoreTracker : IEventSystemHandler
{
    void IncreaseShotCount();
    void UnitedCoinCollected();
}