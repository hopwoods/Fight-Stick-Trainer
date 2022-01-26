import microsoftXbox from '@iconify/icons-mdi/microsoft-xbox'
import { appTheme } from './styles/globalStyles'
import { ControllerConnectionState } from './components/controllerConnectionState'
import { Icon } from '@iconify/react'
import { InputHistory } from './components/inputHistory'
import { MainContent } from './components/mainContent'
import { mergeStyleSets } from '@fluentui/react'

function App() {

  const classes = mergeStyleSets({
    app: {
      textAlign: 'center',
      display: 'grid',
      gridTemplateColumns: 'auto',
      gridTemplateRows: '10vmin 90vmin',
      backgroundColor: appTheme.palette.white,
      fontFamily: "'Roboto', sans- serif"
    },
    appHeader: {
      gridColumn: '1 / span 1',
      gridRow: '1 / span 1',
      display: 'grid',
      gridTemplateColumns: 'auto 10vmin',
      gridTemplateRows: '10vmin',
      alignItems: 'center',
      fontSize: 'calc(10px + 2vmin) !important',
      color: 'white',
      backgroundColor: appTheme.palette.neutralLighter
    },
    title: {
      gridColumn: '1 / span 1',
      gridRow: '1 / span 1',
      justifySelf: 'start',
      marginLeft: '3vmin'
    },
    controllerStatus: {
      gridColumn: '2 / span 1',
      gridRow: '1 / span 1',
      justifySelf: 'end',
      marginRight: '3vmin'
    },
    appContent: {
      gridColumn: '1 / span 1',
      gridRow: '2 / span 1',
      display: 'grid',
      gridTemplateColumns: '10vmin 1fr',
      gridTemplateRows: 'auto',
      alignItems: 'center',
      fontSize: 'calc(10px + 2vmin)',
      color: 'white'
    },
    xboxLogo: {
      position: 'relative',
      top: '0.5vmin'
    }
  });

  return (
    <div className={classes.app}>
      <header className={classes.appHeader}>
        <div className={classes.title}>
          <span><Icon icon={microsoftXbox} className={classes.xboxLogo} /> Fight Stick Trainer</span>
        </div>
        <div className={classes.controllerStatus}>
          <ControllerConnectionState /></div>
      </header>
      <section className={classes.appContent}>
        <InputHistory />
        <MainContent>

        </MainContent>
      </section>
    </div>
  );
}

export default App;
