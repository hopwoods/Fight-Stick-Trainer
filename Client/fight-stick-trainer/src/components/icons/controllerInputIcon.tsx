import AButtonIcon from './aButtonIcon'
import BButtonIcon from './bButtonIcon'
import DpadDownButtonIcon from './dPadDownButtonIcon'
import DpadLeftButtonIcon from './dPadLeftButtonIcon'
import DpadRightButtonIcon from './dPadRightButtonIcon'
import DpadUpButtonIcon from './dPadUpButtonIcon'
import HomeButtonIcon from './homeButtonIcon'
import LbButtonIcon from './lbButtonIcon'
import LeftStickButtonIcon from './leftStickButtonIcon'
import LeftTriggerIcon from './leftTriggerIcon'
import RbButtonIcon from './rbButtonIcon'
import RightStickButtonIcon from './rightStickButtonIcon'
import RightTriggerIcon from './rightTriggerIcon'
import StartButtonIcon from './startButtonIcon'
import ViewButtonIcon from './viewButtonIcon'
import XButtonIcon from './xButtonIcon'
import YButtonIcon from './yButtonIcon'
import { ControllerButtons } from '../../enums'
import { IControllerButtonStyles } from '../../types'


function getButtonIcon(inputName: ControllerButtons) {

    const customStyle: Partial<IControllerButtonStyles> = {};

    switch (inputName) {
        case "A":
            return <AButtonIcon styles={customStyle} />
        case "B":
            return <BButtonIcon styles={customStyle} />
        case "X":
            return <XButtonIcon styles={customStyle} />
        case "Y":
            return <YButtonIcon styles={customStyle} />
        case "RB":
            return <RbButtonIcon styles={customStyle} />
        case "LB":
            return <LbButtonIcon styles={customStyle} />
        case "Up":
            return <DpadUpButtonIcon styles={customStyle} />
        case "Down":
            return <DpadDownButtonIcon styles={customStyle} />
        case "Left":
            return <DpadLeftButtonIcon styles={customStyle} />
        case "Right":
            return <DpadRightButtonIcon styles={customStyle} />
        case "Home":
            return <HomeButtonIcon styles={customStyle} />
        case "View":
            return <ViewButtonIcon styles={customStyle} />
        case "Start":
            return <StartButtonIcon styles={customStyle} />
        case "LsClick":
            return <LeftStickButtonIcon styles={customStyle} />
        case "RsClick":
            return <RightStickButtonIcon styles={customStyle} />
        case "LTrigger":
            return <LeftTriggerIcon styles={customStyle} />
        case "RTrigger":
            return <RightTriggerIcon styles={customStyle} />

        default:
            break;
    }
}

export default function ControllerInputIcon({ inputName }: { inputName: ControllerButtons }) {
    const icon = getButtonIcon(inputName);
    return <>{icon}</>
}
