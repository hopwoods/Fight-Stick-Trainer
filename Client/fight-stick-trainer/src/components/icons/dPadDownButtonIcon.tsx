import { baseIconStyles } from '.'
import { ControllerButtonIconProps, IControllerButtonStyles } from '../../types'
import { mergeStyleSets } from '@fluentui/react'

export function DpadDownButtonIcon({ styles }: ControllerButtonIconProps) {

    const defaultStyles: IControllerButtonStyles = {
        root: {
            displayName: 'dpad-down-button-icon',
            color: 'Gainsboro',
        }
    }

    const classes = mergeStyleSets(baseIconStyles, defaultStyles, styles);

    return <span className={classes.root}>
        <svg width="1em" height="1em" xmlns="http://www.w3.org/2000/svg" aria-hidden viewBox="0 0 512 512" role="img" preserveAspectRatio="xMidYMid meet">
            <defs>
                <style>{`.cls-1{fill:currentColor;}.cls-2{fill:none;stroke:currentColor;stroke-miterlimit:10;stroke-width:20px;}`}</style>
            </defs>
            <path className="cls-1" d="M303.21,431.38s9.9-4,10.71-17.39V316.05H189.75l0,97.94c.8,13.38,10.71,17.39,10.71,17.39,9.63,5.62,50.05,5.62,50.05,5.62S293.58,437,303.21,431.38Z" />
            <path className="cls-2" d="M303.21,431.38s9.9-4,10.71-17.39V326.06h87.93c13.38-.8,17.4-10.7,17.4-10.7,5.62-9.64,5.62-50.05,5.62-50.05s0-43.09-5.62-52.73c0,0-4-9.9-17.4-10.71l-87.93,0v-88c-.81-13.38-10.71-17.4-10.71-17.4-9.63-5.62-50-5.62-50-5.62s-43.09,0-52.72,5.62c0,0-9.91,4-10.71,17.4l0,87.93H101.8c-13.38.81-17.4,10.71-17.4,10.71-5.62,9.64-5.62,50.05-5.62,50.05s0,43.09,5.62,52.73c0,0,4,9.9,17.4,10.7h88l0,87.93c.8,13.38,10.71,17.39,10.71,17.39,9.63,5.62,50.05,5.62,50.05,5.62S293.58,437,303.21,431.38Z" />
        </svg>
    </span>
}