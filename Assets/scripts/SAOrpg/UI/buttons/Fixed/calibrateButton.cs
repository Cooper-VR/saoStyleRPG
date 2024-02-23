using SAOrpg.playerAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAOrpg.UI.Buttons
{
    public class calibrateButton : buttonHandler
    {
        public FullBodyCalibrator calibrator;

        public override void ButtonAction()
        {
            calibrator.isCalibrating = true;


            isPressed = false;
            DoActionOn();
        }
        public override void PressedAction()
        {
            return;
        }
    }
}
