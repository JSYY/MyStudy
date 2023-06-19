import { App } from 'vue';
import "../src/assets/common.less";
import { withInstall } from './withInstall';

const allComponents = require.context('./components/', true, /\.vue$/);

const install = function (app: App) {
    allComponents.keys().forEach((key:any) => {
        var c = withInstall(allComponents(key).default);
        app.use(c);
    });
    return app;
};

export default install;

export * from './withInstall';