import { App } from 'vue';
import { default as MyButton } from '../src/components/MyButton';
import { default as MyInput } from '../src/components/MyInput';

const components = [
    MyButton, MyInput
];

const install = function (app: App) {
    components.forEach(component => {
        app.use(component);
    });
    return app;
};

export {
    install,
    MyButton,
    MyInput,
};

export * from './withInstall';