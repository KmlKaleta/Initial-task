namespace Utility
{
    public sealed class UpdateHook : UpdateHookBase<UpdateHook>
    {
        private void Update()
        {
            InvokeUpdate();
        }
    }
}
