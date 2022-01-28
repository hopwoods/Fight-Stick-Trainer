import { baseIconStyles } from '.'
import { ControllerButtonIconProps, IControllerButtonStyles } from '../../types'
import { mergeStyleSets } from '@fluentui/react'

export default function ViewButtonIcon({ styles }: ControllerButtonIconProps) {

    const defaultStyles: IControllerButtonStyles = {
        root: {
            displayName: 'view-button-icon',
            color: 'Gainsboro',
        }
    }
    const classes = mergeStyleSets(baseIconStyles, defaultStyles, styles);

    return <span className={classes.root}>
        <svg width="1em" height="1em" xmlns="http://www.w3.org/2000/svg" aria-hidden viewBox="0 0 512 512" role="img" preserveAspectRatio="xMidYMid meet">
            <defs>
                <style>{`.cls-1{fill:currentColor;}`}</style>
            </defs>
            <rect className="cls-1" x="247.6" y="261.4" width="78.88" height="56.46" />
            <path className="cls-1" d="M256,103.51c-84.08,0-152.49,68.41-152.49,152.49S171.92,408.49,256,408.49,408.49,340.08,408.49,256,340.08,103.51,256,103.51ZM213,273H167.83V176.45h116v54.29h-17.7v-36.6h-80.6v61.15H213Zm131.21,62.57H229.91V243.7H344.17Z" />
        </svg>
    </span>
}