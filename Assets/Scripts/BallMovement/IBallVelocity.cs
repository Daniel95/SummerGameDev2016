using UnityEngine;
using UnityEngine.EventSystems;

public interface IBallVelocity : IEventSystemHandler
{
    void MultiplyVelocity(float _multiplier);

    void MultiplyGivenAxes(Vector3 _multipliers);

    void AddVelocity(Vector3 _velocity);
}
