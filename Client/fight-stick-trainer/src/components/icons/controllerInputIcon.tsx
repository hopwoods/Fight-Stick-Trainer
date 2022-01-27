import {
    AButtonIcon,
    BButtonIcon,
    DpadDownButtonIcon,
    DpadLeftButtonIcon,
    DpadRightButtonIcon,
    DpadUpButtonIcon,
    HomeButtonIcon,
    LbButtonIcon,
    RbButtonIcon,
    XButtonIcon,
    YButtonIcon
    } from '../icons'
import { ControllerButtons } from '../../enums'
import { IControllerButtonStyles } from '../../types'
import { LeftStickButtonIcon } from './leftStickButtonIcon'
import { RightStickButtonIcon } from './rightStickButtonIcon'
import { StartButtonIcon } from './startButtonIcon'
import { ViewButtonIcon } from './viewButtonIcon'

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

        default:
            break;
    }
}

export function ControllerInputIcon({ inputName }: { inputName: ControllerButtons }) {
    const icon = getButtonIcon(inputName);
    return <>{icon}</>
}

