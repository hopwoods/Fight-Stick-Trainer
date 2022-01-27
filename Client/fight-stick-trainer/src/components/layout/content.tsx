import { IRawStyle, mergeStyleSets } from '@fluentui/react'

type ContentProps = React.ReactNode & {
    styles?: IContentStyles;
};

export interface IContentStyles {
    root?: IRawStyle;
}

export const Content: React.FunctionComponent<ContentProps> = ({ styles, children }) => {

    const defaultStyles: IContentStyles = {
        root: {
            displayName: 'content',
            display: 'grid',
            gridTemplateColumns: '10vmin 1fr',
            gridTemplateRows: 'auto',
            alignItems: 'center',
            fontSize: 'calc(10px + 2vmin)',
            color: 'white'
        }
    }

    const classes = mergeStyleSets(defaultStyles, styles);

    return <article className={classes.root}>
        {children}
    </article>
}