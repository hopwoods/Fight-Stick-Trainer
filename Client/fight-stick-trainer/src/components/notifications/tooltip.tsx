import { appTheme } from '../../styles/globalStyles'
import { ICalloutContentStyles, ICalloutProps, ITooltipHostProps, TooltipHost } from '@fluentui/react'

export type TooltipProps = ITooltipHostProps & {}

export const Tooltip: React.FunctionComponent<TooltipProps> = ({ content, children, ...props }) => {

    const calloutProps: ICalloutProps = {
        isBeakVisible: true,
        gapSpace: 2
    }

    const styles: Partial<ICalloutContentStyles> = {
        beak: {
            backgroundColor: appTheme.palette.neutralQuaternaryAlt
        },
        beakCurtain: {
            backgroundColor: appTheme.palette.neutralQuaternaryAlt
        },
        calloutMain: {
            backgroundColor: appTheme.palette.neutralQuaternaryAlt
        }
    }

    return <TooltipHost content={content} calloutProps={calloutProps} id='ControllerConnectedTooltip' tooltipProps={{ calloutProps: { styles: styles } }} {...props}>
        {children}
    </TooltipHost>
}