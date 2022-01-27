import { baseIconStyles } from '.'
import { ControllerButtonIconProps, IControllerButtonStyles } from '../../types'
import { mergeStyleSets } from '@fluentui/react'

export function DpadLeftButtonIcon({ styles }: ControllerButtonIconProps) {

    const defaultStyles: IControllerButtonStyles = {
        root: {
            displayName: 'dpad-left-button-icon',
            color: 'Gainsboro',
        }
    }
    const classes = mergeStyleSets(baseIconStyles, defaultStyles, styles);

    return <span className={classes.root}>
        <svg width="1em" height="1em" xmlns="http://www.w3.org/2000/svg" aria-hidden viewBox="0 0 512 512" role="img" preserveAspectRatio="xMidYMid meet">
            <defs>
                <style>{`.cls-1{fill:currentColor;}.cls-2{fill:none;stroke:currentColor;stroke-miterlimit:10;stroke-width:20px;}`}</style>
            </defs>
            <path className="cls-1" d="M88.58,315.35s4,9.9,17.39,10.7h97.94V201.88l-97.94,0c-13.38.81-17.39,10.71-17.39,10.71C83,222.21,83,262.62,83,262.62S83,305.71,88.58,315.35Z" />
            <path className="cls-2" d="M88.58,315.35s4,9.9,17.39,10.7H193.9V414c.8,13.38,10.7,17.39,10.7,17.39,9.64,5.62,50,5.62,50,5.62s43.09,0,52.73-5.62c0,0,9.9-4,10.7-17.39l0-87.93h88c13.38-.8,17.39-10.7,17.39-10.7C429,305.71,429,265.3,429,265.3s0-43.09-5.62-52.73c0,0-4-9.9-17.39-10.71H318.1V113.93c-.8-13.38-10.7-17.4-10.7-17.4-9.64-5.62-50.05-5.62-50.05-5.62s-43.09,0-52.73,5.62c0,0-9.9,4-10.7,17.4v87.95l-87.93,0c-13.38.81-17.39,10.71-17.39,10.71C83,222.21,83,262.62,83,262.62S83,305.71,88.58,315.35Z" />
        </svg>
    </span>
}