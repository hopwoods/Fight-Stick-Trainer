import React from 'react'
import { AppStylingProps } from '../types'
import { createTheme, ThemeProvider } from '@fluentui/react'

export const appTheme = createTheme({
    palette: {
        themePrimary: '#54ff52',
        themeLighterAlt: '#030a03',
        themeLighter: '#0e290d',
        themeLight: '#194d18',
        themeTertiary: '#339931',
        themeSecondary: '#4ae048',
        themeDarkAlt: '#66ff63',
        themeDark: '#7dff7b',
        themeDarker: '#a0ff9e',
        neutralLighterAlt: '#2f333c',
        neutralLighter: '#353a44',
        neutralLight: '#414651',
        neutralQuaternaryAlt: '#484d59',
        neutralQuaternary: '#4e545f',
        neutralTertiaryAlt: '#686e7a',
        neutralTertiary: '#c8c8c8',
        neutralSecondary: '#d0d0d0',
        neutralPrimaryAlt: '#dadada',
        neutralPrimary: '#ffffff',
        neutralDark: '#f4f4f4',
        black: '#f8f8f8',
        white: '#282c34',
    }
});

export function AppStyling({ theme = appTheme, children }: AppStylingProps) {
    return (
        <ThemeProvider applyTo="body" theme={appTheme} >
            {children}
        </ThemeProvider>
    )
}

