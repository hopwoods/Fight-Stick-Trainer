import { IControllerButtonStyles } from '../../types'
import { IRawStyle, mergeStyleSets } from '@fluentui/react'
import { XboxLogoIcon } from '../icons'


type TitleProps = React.ReactNode & {
    styles?: ITitleStyles;
};

export interface ITitleStyles {
    root?: IRawStyle;
}

export function Title({ styles }: TitleProps) {

    const defaultStyles: ITitleStyles = {
        root: {
            displayName: 'title',
            justifySelf: 'start',
            marginLeft: '3vmin',
            height: '7vmin'
        }
    }

    const classes = mergeStyleSets(defaultStyles, styles);

    const logoStyles: IControllerButtonStyles = {
        root: {
            fontSize: '5vmin',
            position: 'relative',
            top: '1.2vmin',
            display: 'inline-block',
            marginRight: '1rem'
        }
    }

    return <div className={classes.root}>
        <XboxLogoIcon styles={logoStyles} />
        <span>Fight Stick Trainer</span>
    </div>
}