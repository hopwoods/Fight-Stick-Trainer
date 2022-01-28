import { appTheme } from '../../styles/globalStyles'
import { IContentStyles } from './content'
import { IHeaderStyles } from './header'
import { IMainContentStyles } from './mainContent'
import { IRawStyle, mergeStyleSets } from '@fluentui/react'
import { lazy } from 'react'

type PageProps = React.ReactNode & {
    id: string;
    styles?: IPageStyles;
};

interface IPageStyles {
    root: IRawStyle;
}

const Header = lazy(() => import('./header'));
const Content = lazy(() => import('./content'));
const InputHistory = lazy(() => import('./inputHistory'));
const MainContent = lazy(() => import('./mainContent'));

export const Page: React.FC<PageProps> = ({ id, styles, children }) => {

    const defaultStyles: IPageStyles = {
        root: {
            displayName: `page-${id}`,
            textAlign: 'center',
            display: 'grid',
            gridTemplateColumns: 'auto',
            gridTemplateRows: '0.5vmin 10vmin 89.4vmin',
            backgroundColor: appTheme.palette.white,
            fontFamily: "'Barlow Semi Condensed', sans- serif",
            fontDisplay: 'swap',
            fontWeight: 300,
            overflow: 'hidden'
        }
    }

    const classes = mergeStyleSets(defaultStyles, styles);

    const headerStyles: Partial<IHeaderStyles> = {
        root: {
            gridColumn: '1 / span 1',
            gridRow: '2 / span 1',
        },
        rainbow: {
            gridColumn: '1 / span 1',
            gridRow: '1 / span 1',
        }
    }

    const contentStyles: Partial<IContentStyles> = {
        root: {
            gridColumn: '1 / span 1',
            gridRow: '3 / span 1',
        }
    }

    const mainContentStyles: Partial<IMainContentStyles> = {
        root: {
            position: 'relative',
            gridColumn: '2 / span 1',
            gridRow: '1 / span 1',
        }
    }

    return <div className={classes.root}>
        <Header styles={headerStyles} />
        <Content styles={contentStyles}>
            <InputHistory />
            <MainContent styles={mainContentStyles}>
                {children}
            </MainContent>
        </Content>
    </div>

}

export default Page;