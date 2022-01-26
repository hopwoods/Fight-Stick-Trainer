import { appTheme } from './styles/globalStyles'
import { Header } from './components/header'
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
    appContent: {
      gridColumn: '1 / span 1',
      gridRow: '2 / span 1',
      display: 'grid',
      gridTemplateColumns: '10vmin 1fr',
      gridTemplateRows: 'auto',
      alignItems: 'center',
      fontSize: 'calc(10px + 2vmin)',
      color: 'white'
    }
  });

  return (
    <div className={classes.app}>
      <Header />
      <section className={classes.appContent}>
        <InputHistory />
        <MainContent>
        </MainContent>
      </section>
    </div>
  );
}

export default App;
