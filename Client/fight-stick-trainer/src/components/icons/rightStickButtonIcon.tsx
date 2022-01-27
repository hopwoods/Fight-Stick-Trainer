import { baseIconStyles } from '.'
import { ControllerButtonIconProps, IControllerButtonStyles } from '../../types'
import { mergeStyleSets } from '@fluentui/react'

export function RightStickButtonIcon({ styles }: ControllerButtonIconProps) {

    const defaultStyles: IControllerButtonStyles = {
        root: {
            displayName: 'right-stick-button-icon',
            color: 'Gainsboro',
        }
    }
    const classes = mergeStyleSets(baseIconStyles, defaultStyles, styles);

    return <span className={classes.root}>
        <svg width="1em" height="1em" xmlns="http://www.w3.org/2000/svg" aria-hidden viewBox="0 0 512 512" role="img" preserveAspectRatio="xMidYMid meet">
            <defs>
                <style>{`.cls-1{fill:currentColor;}`}</style>
            </defs>
            <polygon className="cls-1" points="173.87 98.67 255.67 167.2 338.13 98.67 173.87 98.67" />
            <path className="cls-1" d="M262.57,271.64H240.15v30h23.19q4.49,0,7.73-4.25a17.44,17.44,0,0,0,3.25-10.9q0-6.81-3.71-10.82T262.57,271.64Z" />
            <path className="cls-1" d="M415.84,191.87H94.16A38,38,0,0,0,56.23,229.8v12.33a38,38,0,0,0,37.93,37.93h76V387.79a25.61,25.61,0,0,0,25.54,25.54H316.28a25.61,25.61,0,0,0,25.54-25.54V280.06h74a38,38,0,0,0,37.93-37.93V229.8A38,38,0,0,0,415.84,191.87ZM277.72,359.14l-21-35.41H240.15v35.41H214.8V249.37h49.47a31.9,31.9,0,0,1,14.3,3.25,38.07,38.07,0,0,1,11.36,8.5,40.14,40.14,0,0,1,7.5,11.91,35.44,35.44,0,0,1,2.7,13.45,38.67,38.67,0,0,1-1.23,9.81,38.08,38.08,0,0,1-3.56,8.89,33.07,33.07,0,0,1-5.64,7.5,33.52,33.52,0,0,1-7.5,5.64l24.12,40.82Z" />
        </svg>
    </span>
}