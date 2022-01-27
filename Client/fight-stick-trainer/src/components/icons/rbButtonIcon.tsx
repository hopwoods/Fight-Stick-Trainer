import { baseIconStyles } from '.'
import { ControllerButtonIconProps, IControllerButtonStyles } from '../../types'
import { mergeStyleSets } from '@fluentui/react'

export function RbButtonIcon({ styles }: ControllerButtonIconProps) {

    const defaultStyles: IControllerButtonStyles = {
        root: {
            displayName: 'rb-button-icon',
            color: 'Gainsboro',
        }
    }

    const classes = mergeStyleSets(baseIconStyles, defaultStyles, styles);

    return <span className={classes.root}>
        <svg width="1em" height="1em" xmlns="http://www.w3.org/2000/svg" aria-hidden viewBox="0 0 512 512" role="img" preserveAspectRatio="xMidYMid meet">
            <path d="M322.76,265.76H296.71v21.37H321.8a9.93,9.93,0,0,0,7.31-2.9,10.28,10.28,0,0,0,2.89-7.58,11.7,11.7,0,0,0-2.62-7.72A8.24,8.24,0,0,0,322.76,265.76Z" fill="currentColor" />
            <path d="M325.52,245.49q2.89-2.48,2.9-7.72c0-3.21-.86-5.69-2.55-7.44a8.27,8.27,0,0,0-6.14-2.62h-23V248H318.9A9.86,9.86,0,0,0,325.52,245.49Z" fill="currentColor" />
            <path d="M224.33,228.26h-20V255H225q4,0,6.89-3.8a15.53,15.53,0,0,0,2.9-9.71c0-4.05-1.11-7.26-3.31-9.66S226.9,228.26,224.33,228.26Z" fill="currentColor" />
            <path d="M459.37,333.48,442,208.75c-86.91-71.57-243-69.7-293.92-67a42.67,42.67,0,0,0-27.85,12.48L66.65,207.86a48.91,48.91,0,0,0-14.12,39.22C56.82,291.91,72,331.63,81.75,353.45a30,30,0,0,0,27.38,17.73H426.56A33.13,33.13,0,0,0,459.37,333.48ZM237.84,306.29l-18.75-31.57H204.34v31.57H181.73V208.41h44.12a28.41,28.41,0,0,1,12.75,2.89,33.89,33.89,0,0,1,10.13,7.59,35.44,35.44,0,0,1,6.69,10.61,31.54,31.54,0,0,1,2.41,12,34.1,34.1,0,0,1-4.27,16.68,30.1,30.1,0,0,1-5,6.68,29.78,29.78,0,0,1-6.69,5l21.5,36.4ZM352.4,292.23a22.79,22.79,0,0,1-7.16,7.79,34.28,34.28,0,0,1-10.62,4.69,50.88,50.88,0,0,1-12.82,1.58H274.1V208.41h54.45a19.46,19.46,0,0,1,9.24,2.2,23.07,23.07,0,0,1,7,5.72,26.46,26.46,0,0,1,4.48,8,27.27,27.27,0,0,1,1.59,9.17,26.32,26.32,0,0,1-3.52,13.23,22.15,22.15,0,0,1-10.55,9.38,25.33,25.33,0,0,1,13.31,8.82Q355,271.28,355,281.2A22.22,22.22,0,0,1,352.4,292.23Z" fill="currentColor" />
        </svg>
    </span>
}