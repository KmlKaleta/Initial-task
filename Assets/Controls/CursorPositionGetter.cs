using UnityEngine;
using UnityEngine.InputSystem;
using Utility;

namespace Game
{
    public sealed class CursorPositionGetter : ObjectHolder<InputAction>, IValueGetter<Vector2>
    {
        public CursorPositionGetter() : base(Controls.Game.CursorPosition)
        { }

        public Vector2 Value => _object.ReadValue<Vector2>();
    }
}
