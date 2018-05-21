﻿using System.Linq;
        public override void TriggerDown()
        {
            if (ViveSR_Experience.ButtonScripts[ThisButtonTypeNum].isOn)
                SetTriggerMessage(true);
        }
        public override void TriggerUp()
        {
            if (ViveSR_Experience.ButtonScripts[ThisButtonTypeNum].isOn)
                SetTriggerMessage(false);
        }

        void SetTriggerMessage(bool isTriggerDown) {

            tutorial.SetRotatorText(tutorial.MainLineManagers[ViveSR_Experience.rotator.currentButtonNum].mainLines.First(x => x.messageType == (isTriggerDown ? "Trigger" : "On")).text);

            tutorial.SetLeftRight(!isTriggerDown);
            tutorial.triggerArrow.SetActive(!isTriggerDown);

            if(tutorial.CurrentMoveTowardsCoroutine != null) StopCoroutine(tutorial.CurrentMoveTowardsCoroutine);
            tutorial.SetMid(!isTriggerDown);
            tutorial.CurrentMoveTowardsCoroutine = tutorial.MoveTowards(isTriggerDown);
            StartCoroutine(tutorial.CurrentMoveTowardsCoroutine);
        }

        protected override void MidPressedDown()
        {
            base.MidPressedDown();
            tutorial.triggerArrow.SetActive(ViveSR_Experience.ButtonScripts[ThisButtonTypeNum].isOn);
        }