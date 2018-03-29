 
using System;

namespace WSH.Tools.AutoUpdater
{
    public interface IAutoUpdater
    {
        void Update();

        void RollBack();
    }
}
