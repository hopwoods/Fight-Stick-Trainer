import { IconButton, IIconStyles } from '@fluentui/react'
import { Tooltip } from '../notifications/tooltip'
import { useAppStore } from '../../store/appStore'

export function ClearHistoryButton() {

    const { clearInputHistory } = useAppStore();

    const iconStyles: IIconStyles = {
        root: {
            displayName: 'delete-history-button',
            fontSize: '2.5vmin',
            position: 'relative',
            top: '-3px'
        }
    }

    return <Tooltip content="Delete Button History" id="ClearHistory">
        <IconButton iconProps={{ iconName: 'deleteSweepOutline', styles: iconStyles }} onClick={() => clearInputHistory()} />
    </Tooltip>
}