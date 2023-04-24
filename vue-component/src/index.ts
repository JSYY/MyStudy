import { App } from 'vue';
import { default as MyButton } from '../src/components/MyButton';

const components = [
    MyButton
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
};

export * from './withInstall';