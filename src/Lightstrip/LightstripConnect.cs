using System;
namespace mi_lightstrip_controller.src.Lightstrip
{
    public class LightstripConnect
    {
        private bool state;
        public LightstripConnect()
        {

        }


        public void OpenLightStrip(bool isOpen)
        {
            state = isOpen;
        }
        public void ToggleLightStrip()
        {
            OpenLightStrip(!state);
        }
    }
}
