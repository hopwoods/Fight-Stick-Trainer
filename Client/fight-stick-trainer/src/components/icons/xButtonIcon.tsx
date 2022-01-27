import { baseIconStyles } from '.'
import { ControllerButtonIconProps, IControllerButtonStyles } from '../../types'
import { mergeStyleSets } from '@fluentui/react'

export function XButtonIcon({ styles }: ControllerButtonIconProps) {

    const defaultStyles: IControllerButtonStyles = {
        root: {
            displayName: 'x-button-icon',
            color: 'CornflowerBlue',
        }
    }

    const classes = mergeStyleSets(baseIconStyles, defaultStyles, styles);

    return <span className={classes.root}>
        <svg width="1em" height="1em" xmlns="http://www.w3.org/2000/svg" aria-hidden viewBox="0 0 512 512" role="img" preserveAspectRatio="xMidYMid meet">
            <defs>
                <style>{`.cls-1{fill:#currentColor;}`}</style>
            </defs>
            <path className="cls-1" d="M256,128.11A127.89,127.89,0,1,0,383.89,256,128,128,0,0,0,256,128.11Zm72.6,216.63h-34l-38.35-59.93-38.59,59.93H183.4l55.93-82.58-57.76-84.94h34.25l40.41,62.29,40.18-62.29h34l-57.76,84.94Z" />
            <path className="cls-1" d="M256,83A173,173,0,1,0,429,256,173,173,0,0,0,256,83Zm0,326.93c-84.85,0-153.89-69-153.89-153.89s69-153.89,153.89-153.89,153.89,69,153.89,153.89S340.85,409.89,256,409.89Z" />
        </svg>
    </span>
}