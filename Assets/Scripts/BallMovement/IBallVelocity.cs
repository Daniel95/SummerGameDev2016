using UnityEngine.EventSystems;

public interface IBallVelocity : IEventSystemHandler
{
    void MultiplyVelocity(float _multiplier);
}