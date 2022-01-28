import { IControllerButtonStyles } from '../../types'
import { IRawStyle, mergeStyleSets } from '@fluentui/react'
import { lazy } from 'react'

const XboxLogoIcon = lazy(() => import('../icons/xBoxLogoIcon'));

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
            marginLeft: '2vmin',
            height: '8vmin',
            textShadow: '0px 0px 6px rgb(150,150,150)'
        }
    }

    const classes = mergeStyleSets(defaultStyles, styles);

    const logoStyles: IControllerButtonStyles = {
        root: {
            fontSize: '5vmin',
            position: 'relative',
            top: '1.4vmin',
            display: 'inline-block',
            marginRight: '0'
        }
    }

    return <div className={classes.root}>
        <XboxLogoIcon styles={logoStyles} />
        <span>Fight Stick Trainer</span>
    </div>
}

export default Title;