import { baseIconStyles } from '.'
import { ControllerButtonIconProps, IControllerButtonStyles } from '../../types'
import { mergeStyleSets } from '@fluentui/react'

export function LeftStickButtonIcon({ styles }: ControllerButtonIconProps) {

    const defaultStyles: IControllerButtonStyles = {
        root: {
            displayName: 'left-stick-button-icon',
            color: 'Gainsboro',
        }
    }
    const classes = mergeStyleSets(baseIconStyles, defaultStyles, styles);

    return <span className={classes.root}>
        <svg width="1em" height="1em" xmlns="http://www.w3.org/2000/svg" aria-hidden viewBox="0 0 512 512" role="img" preserveAspectRatio="xMidYMid meet">
            <defs>
                <style>{`.cls-1{fill:currentColor;}`}</style>
            </defs>
            <path className="cls-1" d="M415.84,191.87H94.16A38,38,0,0,0,56.23,229.8v12.33a38,38,0,0,0,37.93,37.93h76V387.79a25.61,25.61,0,0,0,25.54,25.54H316.28a25.61,25.61,0,0,0,25.54-25.54V280.06h74a38,38,0,0,0,37.93-37.93V229.8A38,38,0,0,0,415.84,191.87ZM295.21,359.06H216.79V249.45h25.32v87.38h53.1Z" />
            <polygon className="cls-1" points="173.87 98.67 255.67 167.2 338.13 98.67 173.87 98.67" />
        </svg>
    </span>
}