using System;

namespace Tools.Testing
{
    public abstract class BaseDataTests : IDisposable
    {
        protected Hooks Hooks { get; }

        protected BaseDataTests(Hooks hooks)
        {
            this.Hooks = hooks;
        }

        public virtual void Dispose()
        {
            this.Hooks.Dispose();
        }
    }
}
