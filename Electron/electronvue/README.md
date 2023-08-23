# electronvue

## Project setup
```
npm install
```

### Compiles and hot-reloads for development
```
npm run serve
```

### Compiles and minifies for production
```
npm run build
```

### Customize configuration
See [Configuration Reference](https://cli.vuejs.org/config/).

1.首次安装完electron之后需要再装一个tsloader，否则会报错
2.需要在vue.config.js中配置node-polyfill-plugin,防止报错找不到electron
configureWebpack: {
        plugins: [new NodePolyfillPlugin()],
    },
3.出现can not reslove fs path 时需要在vue.config.js中配置
pluginOptions: {
        electronBuilder: {
            nodeIntegration: true
        }
    },
