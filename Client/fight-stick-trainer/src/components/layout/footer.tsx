import { appTheme } from '../../styles/globalStyles'
import { IRawStyle, Link, mergeStyleSets } from '@fluentui/react'
import { lazy } from 'react'

type FooterProps = React.ReactNode & {
    styles?: IFooterStyles;
};

export interface IFooterStyles {
    root?: IRawStyle;
}

const Tooltip = lazy(() => import('../notifications/tooltip'));

export const Footer: React.FunctionComponent<FooterProps> = ({ styles, children }) => {

    const defaultStyles: IFooterStyles = {
        root: {
            displayName: 'footer',
            display: 'grid',
            gridTemplateColumns: '100%',
            gridTemplateRows: 'auto',
            alignItems: 'center',
            alignContent: 'center',
            justifySelf: 'end',
            fontSize: '1.75vmin',
            color: '#aaa',
            textAlign: 'right',
            paddingRight: '2vmin'
        }
    }

    const classes = mergeStyleSets(defaultStyles, styles);

    return <footer className={classes.root}>
        <div>
            <span>&copy; Fight Stick Trainer - </span>
            <span>
                <Tooltip content="Stuart Hopwood @ Github">
                    <Link rel='noreferrer' href="https://github.com/hopwoods" target="_blank" styles={{ root: { color: appTheme.palette.themeTertiary } }} >Written by Stuart Hopwood</Link>
                </Tooltip>
            </span>
        </div>
    </footer>
}

export default Footer;