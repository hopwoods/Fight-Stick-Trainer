import deleteSweepOutline from '@iconify/icons-mdi/delete-sweep-outline'
import microsoftXboxController from '@iconify/icons-mdi/microsoft-xbox-controller'
import microsoftXboxControllerOff from '@iconify/icons-mdi/microsoft-xbox-controller-off'
import React from 'react'
import { Icon } from '@iconify/react'
import { initializeIcons, registerIcons as registerIconsDefault } from '@fluentui/react'

export function registerIcons() {

    registerIconsDefault({
        icons: {
            xboxController: <Icon icon={microsoftXboxController} />,
            xboxControllerOff: <Icon icon={microsoftXboxControllerOff} />,
            deleteSweepOutline: <Icon icon={deleteSweepOutline} />,
        }
    });

    initializeIcons();
}
