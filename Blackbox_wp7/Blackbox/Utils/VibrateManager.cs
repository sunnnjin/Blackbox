using System;
using Microsoft.Devices;

namespace Blackbox
{
    public class VibrateManager
    {
        public enum VibrateType
        {
            ShortVibrate,
            LongVibrate
        }

        private VibrateController vc;
        
        public bool IsVibrate{ get;set; }

        public void Vibrate(VibrateType type)
        {
            if (!IsVibrate) return;

            switch (type)
            {
                case VibrateType.ShortVibrate:
                    vc.Start(TimeSpan.FromMilliseconds(100));
                    break;
                case VibrateType.LongVibrate:
                    vc.Start(TimeSpan.FromMilliseconds(300));
                    break;
                default:
                    break;
            }
        }

        public VibrateManager()
        {
            IsVibrate = false;
            vc = VibrateController.Default;
        }
    }
}
