import Loader from './components/notifications/loader'
import { lazy, Suspense } from 'react'

const Page = lazy(() => import('./components/layout/page'));

function App() {
  return <Suspense fallback={Loader()}>
    <Page id="home" />
  </Suspense>
}

export default App;
