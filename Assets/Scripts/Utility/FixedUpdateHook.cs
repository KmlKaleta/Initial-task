namespace Utility
{
    public sealed class FixedUpdateHook : UpdateHookBase<FixedUpdateHook>
    {
        private void FixedUpdate()
        {
            InvokeUpdate();
        }
    }
}
