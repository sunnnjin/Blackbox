using System;

namespace Blackbox
{
    public class RaysEventArgs : EventArgs
    {
        #region Rays attributes
        public Rays Rays
        {
            get;
            set;
        }
        #endregion

        public RaysEventArgs(Rays rays)
        {
            Rays = rays;
        }
    }
}
