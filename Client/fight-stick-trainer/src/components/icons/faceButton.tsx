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

export function FaceButton({ inputName }: { inputName: ControllerButtons }) {

    const classes = mergeStyleSets({
        faceButton: {
            minWidth: '1.5vmin',
            height: '1.5vmin',
            margin: '0.25vmin',
            backgroundColor: setColor(inputName),
            borderColor: setBorderColor(inputName),
            borderWidth: '1px',
            borderStyle: 'solid',
            color: setTextColor(inputName),
            textAlign: 'center',
            borderRadius: '50%',
            display: 'inline-block',
            fontSize: '14px',
            lineHeight: '1.5vmin',
            fontFamily: "'Segoe UI', sans-serif",
            boxShadow: 'rgb(0 0 0 / 30%) 4px 1px 4px 0px',
            padding: '4px',
            justifySelf: 'center',
            order: '-1'
        }
    });

    return <div className={classes.faceButton}>{inputName}</div>
}