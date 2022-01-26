import { ControllerButtons } from '../../enums'
import { mergeStyleSets } from '@fluentui/react'

function setColor(inputName: ControllerButtons) {

    const color = {
        'A': () => ('forestgreen'),
        'X': () => ('CornflowerBlue'),
        'B': () => ('FireBrick'),
        'Y': () => ('Yellow'),
        'RB': () => ('transparent'),
        'LB': () => ('transparent'),
        'Up': () => ('transparent'),
        'Down': () => ('transparent'),
        'Left': () => ('transparent'),
        'Right': () => ('transparent'),
    };

    return (color[inputName]());
}
function setBorderColor(inputName: ControllerButtons) {

    const color = {
        'A': () => ('forestgreen'),
        'X': () => ('CornflowerBlue'),
        'B': () => ('FireBrick'),
        'Y': () => ('Yellow'),
        'RB': () => ('white'),
        'LB': () => ('white'),
        'Up': () => ('white'),
        'Down': () => ('white'),
        'Left': () => ('white'),
        'Right': () => ('white'),
    };

    return (color[inputName]());
}

function setTextColor(inputName: ControllerButtons) {

    const color = {
        'A': () => ('white'),
        'X': () => ('white'),
        'B': () => ('white'),
        'Y': () => ('#333'),
        'RB': () => ('white'),
        'LB': () => ('white'),
        'Up': () => ('white'),
        'Down': () => ('white'),
        'Left': () => ('white'),
        'Right': () => ('white'),
    };

    return (color[inputName]());
}

export function ShoulderButton({ inputName }: { inputName: ControllerButtons }) {

    const classes = mergeStyleSets({
        faceButton: {
            minWidth: '1.5rem',
            height: '1.5rem',
            margin: '0.25rem',
            backgroundColor: setColor(inputName),
            borderColor: setBorderColor(inputName),
            borderWidth: '1px',
            borderStyle: 'solid',
            color: setTextColor(inputName),
            textAlign: 'center',
            borderRadius: '50px',
            display: 'inline-block',
            fontSize: '14px',
            lineHeight: '1.5rem',
            fontFamily: "'Segoe UI', sans-serif",
            boxShadow: 'rgb(0 0 0 / 30%) 4px 1px 4px 0px',
            padding: '4px'
        }
    });

    return <div className={classes.faceButton}>{inputName}</div>
}