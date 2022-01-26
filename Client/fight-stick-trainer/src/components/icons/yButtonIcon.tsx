import { baseIconStyles } from '.'
import { ControllerButtonIconProps, IControllerButtonStyles } from '../../types'
import { mergeStyleSets } from '@fluentui/react'

export function YButtonIcon({ styles }: ControllerButtonIconProps) {

    const defaultStyles: IControllerButtonStyles = {
        root: {
            color: 'Yellow',
        }
    }
    const classes = mergeStyleSets(baseIconStyles, defaultStyles, styles);

    return <span className={classes.root}>
        <svg width="1em" height="1em" xmlns="http://www.w3.org/2000/svg" aria-hidden viewBox="0 0 512 512" role="img" preserveAspectRatio="xMidYMid meet">
            <path d="M256,103.51c-84.08,0-152.49,68.41-152.49,152.49S171.92,408.49,256,408.49,408.49,340.08,408.49,256,340.08,103.51,256,103.51Zm16.24,188v61.21H239.52V291L178.14,177.51H214l41.79,84.41,42.51-84.41h35.59Z" fill="currentColor" />
        </svg>
    </span>
}