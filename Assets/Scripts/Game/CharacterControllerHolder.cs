using UnityEngine;
using Utility;

namespace Game
{
    public sealed class CharacterControllerHolder : ObjectHolder<CharacterController>, ICharacterController
    {
        public CharacterControllerHolder(CharacterController characterController) : base(characterController)
        { }

        public void Move(Vector3 direction)
        {
            _object.Move(direction);
        }
    }
}
