import { baseIconStyles } from '.'
import { ControllerButtonIconProps, IControllerButtonStyles } from '../../types'
import { mergeStyleSets } from '@fluentui/react'

export default function RightTriggerIcon({ styles }: ControllerButtonIconProps) {

    const defaultStyles: IControllerButtonStyles = {
        root: {
            displayName: 'right-trigger-icon',
            color: 'Gainsboro',
        }
    }
    const classes = mergeStyleSets(baseIconStyles, defaultStyles, styles);

    return <span className={classes.root}>
        <svg width="1em" height="1em" xmlns="http://www.w3.org/2000/svg" aria-hidden viewBox="0 0 512 512" role="img" preserveAspectRatio="xMidYMid meet">
            <defs>
                <style>{`.cls-1{fill:currentColor;}`}</style>
            </defs>
            <path className="cls-1" d="M231.55,212.48h-20v26.75h20.68c2.67,0,5-1.27,6.89-3.8a15.54,15.54,0,0,0,2.9-9.72q0-6.06-3.31-9.65C236.51,213.68,234.12,212.48,231.55,212.48Z" />
            <path className="cls-1" d="M397.58,109.35a26.66,26.66,0,0,0-25-17.14H148.22c-2.57,0-5,.71-7.57,1.09-29.33,4.41-14.58,32.38-13.66,35.17,8.75,26.71,43.61,149.18-17.11,245.72a30.76,30.76,0,0,1-1.95,2.73c-4.24,5.37-20.15,28.46,8.32,40.76a26.56,26.56,0,0,0,10.48,2.11H251.27a26.82,26.82,0,0,0,5.79-.64C278.25,414.53,399.6,382.06,411.92,243c.05-.57.09-1.14.11-1.72C412.37,232.31,414.74,155.24,397.58,109.35ZM245.06,290.51l-18.75-31.57H211.56v31.57H189V192.63h44.12a28.41,28.41,0,0,1,12.75,2.89A33.89,33.89,0,0,1,256,203.11a35.44,35.44,0,0,1,6.69,10.61,31.53,31.53,0,0,1,2.41,12,34.1,34.1,0,0,1-4.27,16.69,30.1,30.1,0,0,1-5,6.68,29.78,29.78,0,0,1-6.69,5l21.51,36.4Zm109.33-78H324.61v78H302v-78H272.08V192.63h82.31Z" />
        </svg>
    </span>
}