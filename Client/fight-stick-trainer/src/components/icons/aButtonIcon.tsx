import { baseIconStyles } from '.'
import { ControllerButtonIconProps, IControllerButtonStyles } from '../../types'
import { mergeStyleSets } from '@fluentui/react'

export function AButtonIcon({ styles }: ControllerButtonIconProps) {

    const defaultStyles: IControllerButtonStyles = {
        root: {
            color: 'forestgreen',
        }
    }
    const classes = mergeStyleSets(baseIconStyles, defaultStyles, styles);

    return <span className={classes.root}>
        <svg width="1em" height="1em" xmlns="http://www.w3.org/2000/svg" aria-hidden viewBox='0 0 512 512' role="img" preserveAspectRatio="xMidYMid meet">
            <polygon className="cls-1" points="231.76 267.42 279.52 267.42 256.12 198.56 231.76 267.42" fill="currentColor" />
            <path d="M256,103.51c-84.08,0-152.49,68.41-152.49,152.49S171.92,408.49,256,408.49,408.49,340.08,408.49,256,340.08,103.51,256,103.51ZM300.35,333.3,284.9,290.48h-58L211.65,333.3H178.41l63.43-171.73h28.55l63.2,171.73Z" fill="currentColor" />
        </svg>
    </span>
}