import { useStore } from '../store/appStore'

export function ControllerConnectionState() {
    const isConnected = useStore(state => state.isControllerConnected)
    if (isConnected)
        return <span className='Green'>Connected</span>
    else
        return <span className='Red'>Disconnected</span>
}