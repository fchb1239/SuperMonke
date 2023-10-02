using System;

namespace SuperMonke.Behaviours
{
    class InputHandler
    {
        static ControllerInputPoller cip = ControllerInputPoller.instance;

        public static bool GetInput(bool isLeftHand, InputType inputType)
        {
            bool output = false;

            switch (inputType)
            {
                case InputType.triggerButton:
                    if (isLeftHand)
                    {
                        if (cip.leftControllerIndexFloat > 0)
                        {
                            output = true;
                        }
                    }
                    else
                    {
                        if (cip.rightControllerIndexFloat > 0)
                        {
                            output = true;
                        }
                    }
                    break;
                case InputType.gripButton:
                    if (isLeftHand)
                    {
                        if (cip.leftControllerGripFloat > 0)
                        {
                            output = true;
                        }
                    }
                    else
                    {
                        if (cip.rightControllerGripFloat > 0)
                        {
                            output = true;
                        }
                    }
                    break;
                case InputType.primaryButton:
                    if (isLeftHand)
                    {
                        if (cip.leftControllerPrimaryButton)
                        {
                            output = true;
                        }
                    }
                    else
                    {
                        if (cip.rightControllerPrimaryButton)
                        {
                            output = true;
                        }
                    }
                    break;
                default:
                    break;
            }
            return output;
        }

        public enum InputType
        {
            triggerButton,
            gripButton,
            primaryButton
        }
    }
}
