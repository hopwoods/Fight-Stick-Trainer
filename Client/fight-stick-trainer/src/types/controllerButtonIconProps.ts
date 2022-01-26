import { IRawStyle } from '@fluentui/react'

export type ControllerButtonIconProps = {
    styles?: IControllerButtonStyles;
}

export type IControllerButtonStyles = {
    root?: IRawStyle;
}

export const baseIconStyles: IControllerButtonStyles = {
    root: {
        fontSize: '4.5vmin',
        display: 'block',
        height: '1em',
        width: '1em'
    }
}