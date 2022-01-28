import { Spinner, SpinnerSize } from '@fluentui/react'

export default function Loader() {
    return <Spinner size={SpinnerSize.large} styles={{ root: { marginTop: '2vmin' } }} />;
} 