import { IRawStyle, mergeStyleSets } from '@fluentui/react'


type ConnectionAlertProps = {
    styles?: IConnectionAlertStyles;
}

export interface IConnectionAlertStyles {
    root: IRawStyle;
}

export const ConnectionAlert: React.FunctionComponent<ConnectionAlertProps> = ({ styles, children }) => {

    const defaultStyles: IConnectionAlertStyles = {
        root: {
            displayName: "connection-alert",
            maxWidth: '60vmin',
            boxShadow: '5px 5px 15px rgba(0,0,0,50%)',
            margin: '3vmin',
            padding: '2vmin',
            background: 'linear-gradient(180deg, rgba(63,68,78,1) 0%, rgba(78,84,95,1) 100%)',
            borderRadius: '5px',
            fontSize: '2vmin'
        }
    }

    const classes = mergeStyleSets(defaultStyles, styles);

    return <div className={classes.root}>
        {children}
    </div>
}

export default ConnectionAlert;