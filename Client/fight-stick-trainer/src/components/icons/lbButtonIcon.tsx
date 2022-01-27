import { baseIconStyles } from '.'
import { ControllerButtonIconProps, IControllerButtonStyles } from '../../types'
import { mergeStyleSets } from '@fluentui/react'

export function LbButtonIcon({ styles }: ControllerButtonIconProps) {

    const defaultStyles: IControllerButtonStyles = {
        root: {
            displayName: 'lb-button-icon',
            color: 'Gainsboro',
        }
    }
    const classes = mergeStyleSets(baseIconStyles, defaultStyles, styles);

    return <span className={classes.root}>
        <svg width="1em" height="1em" xmlns="http://www.w3.org/2000/svg" aria-hidden viewBox="0 0 512 512" role="img" preserveAspectRatio="xMidYMid meet">
            <path d="M445.35,207.86l-53.58-53.59a42.67,42.67,0,0,0-27.85-12.48c-50.9-2.74-207-4.61-293.92,67L52.63,333.48a33.13,33.13,0,0,0,32.81,37.7H402.87a30,30,0,0,0,27.38-17.73c9.79-21.82,24.93-61.54,29.22-106.37A48.91,48.91,0,0,0,445.35,207.86ZM251.76,306.29h-70V208.41h22.61v78h47.42Zm88.92-14.06a22.79,22.79,0,0,1-7.16,7.79,34.28,34.28,0,0,1-10.62,4.69,50.88,50.88,0,0,1-12.82,1.58h-47.7V208.41h54.45a19.46,19.46,0,0,1,9.24,2.2,23.07,23.07,0,0,1,7,5.72,26.46,26.46,0,0,1,4.48,8,27.27,27.27,0,0,1,1.59,9.17,26.32,26.32,0,0,1-3.52,13.23,22.17,22.17,0,0,1-10.54,9.38,25.34,25.34,0,0,1,13.3,8.82q4.89,6.35,4.89,16.27A22.22,22.22,0,0,1,340.68,292.23Z" fill="currentColor" />
            <path d="M311,265.76H285v21.37h25.09a9.93,9.93,0,0,0,7.31-2.9,10.24,10.24,0,0,0,2.89-7.58,11.7,11.7,0,0,0-2.62-7.72A8.24,8.24,0,0,0,311,265.76Z" fill="currentColor" />
            <path d="M313.8,245.49q2.9-2.48,2.9-7.72c0-3.21-.86-5.69-2.55-7.44a8.27,8.27,0,0,0-6.14-2.62H285V248h22.19A9.86,9.86,0,0,0,313.8,245.49Z" fill="currentColor" />
        </svg>
    </span>
}