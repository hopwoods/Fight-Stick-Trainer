import { baseIconStyles } from '.'
import { ControllerButtonIconProps, IControllerButtonStyles } from '../../types'
import { mergeStyleSets } from '@fluentui/react'

export function AButtonIcon({ styles }: ControllerButtonIconProps) {

    const defaultStyles: IControllerButtonStyles = {
        root: {
            displayName: 'a-button-icon',
            color: 'limegreen',
        }
    }
    const classes = mergeStyleSets(baseIconStyles, defaultStyles, styles);

    return <span className={classes.root}>
        <svg width="1em" height="1em" xmlns="http://www.w3.org/2000/svg" aria-hidden viewBox='0 0 512 512' role="img" preserveAspectRatio="xMidYMid meet">
            <defs>
                <style>{`.cls-1{fill:#currentColor;}`}</style>
            </defs>
            <polygon className="cls-1" points="231.76 267.42 279.52 267.42 256.12 198.56 231.76 267.42" />
            <path className="cls-1" d="M256,128.11A127.89,127.89,0,1,0,383.89,256,128,128,0,0,0,256,128.11ZM300.35,333.3,284.9,290.48h-58L211.65,333.3H178.41l63.43-171.73h28.55l63.2,171.73Z" />
            <path className="cls-1" d="M256,86.35A169.65,169.65,0,1,0,425.65,256,169.66,169.66,0,0,0,256,86.35Zm0,320.52c-83.19,0-150.87-67.68-150.87-150.87S172.81,105.13,256,105.13,406.87,172.81,406.87,256,339.19,406.87,256,406.87Z" />
        </svg>
    </span>
}